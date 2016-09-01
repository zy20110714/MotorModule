﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.IO;

namespace ICDIBasic
{
    public partial class OscilloScope : Form
    {
        public static OscilloScope pCurrentWin = null;//句柄
        private Dictionary<byte, string> itemRelection = new Dictionary<byte, string>();
        public static List<ShowItem> showItems = new List<ShowItem>();
        private static byte Mask = 0;

        ComboBox cb;
        Thread thread;//未用
        PCan pc;
        int spanTime = 20;//未用

        //存储X坐标
        float[] pointA;

        //电流、速度、位置值的单位转换比率
        double speedRatio = 60.0 / 65536;
        double positionRatio = 360.0 / 65535;
        double currentRatio = 1.0;

        //电流、速度、位置值在Y轴上的缩放比例
        double cr;
        double sr;
        double pr;

        //电流、速度、位置曲线沿Y轴的偏移值
        float currentOffset;
        float speedOffset;
        float positionOffset;

        //指针1、指针2的X坐标
        int tracePos1 = 0;
        int tracePos2 = 0;

        //另外的线程中需要引用
        public static int Interval = 0;
        public static bool EnableScope = false;
        public static bool EnableFrictionMeasure = false;
        public static bool EnableCurrentCompensation = false;

        public static List<float> currentC = new List<float>();
        public static List<float> currentS = new List<float>();
        public static List<int> currentT   = new List<int>();
        public static List<float> currentA = new List<float>();

        public static byte CURRENT_P   = 0x61;    //电流环P参数
        public static byte CURRENT_I   = 0x62;    //电流环I参数
        public static byte CURRENT_D   = 0x63;    //电流环D参数
        public static byte SPEED_P     = 0x64;    //速度环P参数
        public static byte SPEED_I     = 0x65;    //速度环I参数
        public static byte SPEED_D     = 0x66;    //速度环D参数
        public static byte SPEED_DS    = 0x67;    //速度P死区
        public static byte POSITION_P  = 0x68;    //位置环P参数
        public static byte POSITION_I  = 0x69;    //位置环I参数
        public static byte POSITION_D  = 0x6A;    //位置环D参数
        public static byte POSITION_DS = 0x6B;    //位置P死区


        public static float measureCurrent = 0;    //实际电流
        public static float measureSpeed   = 0;    //实际电流

        public OscilloScope()
        {
            InitializeComponent();
            pc = new PCan();
            InitialControls();
            //开启绘图时钟，进行显示屏刷新，刷新周期80ms
            timerPaint.Start();

            //未用
            thread = new Thread(new ThreadStart(ThreadProc));
            thread.Name = "HighAccuracyTimer";
            //thread.Start();
        }

        ~OscilloScope()
        {
            thread.Abort();
            thread.Join();
            thread = null;
        }

        public static OscilloScope GetInstance()
        {
            if (pCurrentWin == null)
            {
                pCurrentWin = new OscilloScope();
            }
            return pCurrentWin;
        }

        private void OscilloScope_FormClosed(object sender, FormClosedEventArgs e)
        {
            pCurrentWin = null;
            timerPaint.Stop();
        }

        private void OscilloScope_FormClosing(object sender, FormClosingEventArgs e)
        {
            Thread.Sleep(spanTime + 5);   //等待线程thread结束后再abort
            if (thread != null)
            {
                thread.Abort();
                //thread.Join();
                thread = null;
            }
        }

        //窗口启动后的初始化
        private void InitialControls()
        {
            //指针1的初始位置，在显示屏最左侧
            tracePos1 = 0;
            //指针2的初始位置，在显示屏最右侧，pLPaint.Width = 740
            tracePos2 = pLPaint.Width - 1;

            //测量项目的初始化
            itemRelection.Clear();
            itemRelection.Add(Configuration.SCP_TAGCUR_L, "指令电流");
            itemRelection.Add(Configuration.SCP_TAGSPD_L, "指令速度");
            itemRelection.Add(Configuration.SCP_TAGPOS_L, "指令位置");
            itemRelection.Add(Configuration.SCP_MEACUR_L, "实际电流");
            itemRelection.Add(Configuration.SCP_MEASPD_L, "实际速度");
            itemRelection.Add(Configuration.SCP_MEAPOS_L, "实际位置");

            //记录对象标志MASK的初始化
            Mask = (byte)Configuration.MemoryControlTable[Configuration.SCP_MASK];

            //由记录对象标志初始化要显示的测量曲线
            showItems.Clear();
            showItems.Add(new ShowItem((Mask & Configuration.MASK_TAGCUR) != 0x00, Configuration.SCP_TAGCUR_L, "观测", Color.Yellow, DashStyle.Dot, pLPaint.Width, Configuration.MASK_TAGCUR));
            showItems.Add(new ShowItem((Mask & Configuration.MASK_TAGSPD) != 0x00, Configuration.SCP_TAGSPD_L, "观测", Color.Green, DashStyle.Solid, pLPaint.Width, Configuration.MASK_TAGSPD));
            showItems.Add(new ShowItem((Mask & Configuration.MASK_TAGPOS) != 0x00, Configuration.SCP_TAGPOS_L, "观测", Color.Blue, DashStyle.Dash, pLPaint.Width, Configuration.MASK_TAGPOS));
            showItems.Add(new ShowItem((Mask & Configuration.MASK_MEACUR) != 0x00, Configuration.SCP_MEACUR_L, "观测", Color.Cyan, DashStyle.Dot, pLPaint.Width, Configuration.MASK_MEACUR));
            showItems.Add(new ShowItem((Mask & Configuration.MASK_MEASPD) != 0x00, Configuration.SCP_MEASPD_L, "观测", Color.HotPink, DashStyle.Solid, pLPaint.Width, Configuration.MASK_MEASPD));
            showItems.Add(new ShowItem((Mask & Configuration.MASK_MEAPOS) != 0x00, Configuration.SCP_MEAPOS_L, "观测", Color.Red, DashStyle.Dash, pLPaint.Width, Configuration.MASK_MEAPOS));

            //参数表中的“记录时间间隔（对10kHZ的分频值）”显示到测量条件选项卡中的对应控件里
            tBScanFrequency.Text = Configuration.MemoryControlTable[Configuration.SCP_REC_TIM].ToString();
            //同样，用参数表中的“记录时间间隔（对10kHZ的分频值）”设置扫描频率，初始化Interval
            setTimeInterval(Configuration.MemoryControlTable[Configuration.SCP_REC_TIM]);

            //初始化数组pointA，当做要绘制曲线的X坐标，X坐标的值从0到pLPaint.Width - 1
            pointA = new float[pLPaint.Width];
            for (int i = 0; i < pLPaint.Width; i++)
            {
                pointA[i] = i;
            }

            //listview中测量项目初始化，showItems
            loadLVMeasureItems();

            //从文件设置电流、速度、位置（Y轴）缩放比例，并显示到界面
            cr = Convert.ToDouble(IniFile.ContentValue("plRange", "Current", IniFile.StrProPath));
            sr = Convert.ToDouble(IniFile.ContentValue("plRange", "Speed", IniFile.StrProPath));
            pr = Convert.ToDouble(IniFile.ContentValue("plRange", "Position", IniFile.StrProPath));
            cBCurrentRatio.Text = cr.ToString();
            cBSpeedRatio.Text = sr.ToString();
            cBPositionRatio.Text = pr.ToString();

            //电流、速度、位置曲线沿Y轴的偏移值
            currentOffset = 0.0f;
            speedOffset = 0.0f; ;
            positionOffset = 0.0f;

            //开启tMPointer定时器，刷新指针列表数据
            tMPointer.Start();

            //默认启动示波器
            EnableScope = true;
        }

        //修改扫描频率（模块内存中的设置，以及“示波器对象”的属性）
        private void setTimeInterval(short interval)
        {
            //公共属性Interval设置成传入参数的10分之一，初始化时传入参数是参数表中的值
            Interval = interval / 10;
            //由传入参数设置参数表，实现从控件中修改扫描频率
            pc.WriteOneWord(Configuration.SCP_REC_TIM, interval, PCan.currentID);
        }

        //未用方法
        private void ThreadProc()
        {
            //while (running)
            //{
            //    thread.Join(spanTime);
            //    pc.ReadWords(Configuration.SYS_CURRENT_L, 6, PCan.currentID);
            //    //添加元素到显示队列
            //    for (int i = 0; i < showItems.Count;i++)
            //    {
            //        if (showItems[i].sq != null)
            //        {
            //            showItems[i].sq.EnQ(Configuration.MemoryControlTable[showItems[i].Item] + (int)(Configuration.MemoryControlTable[showItems[i].Item + 1] << 16));
            //        }
                  
            //    }
            //}

        }

        //定时器中强制重绘图形
        private void timerPaint_Tick(object sender, EventArgs e)
        {
            pLPaint.Refresh();
        }

        //在控件重新绘制时发生
        private void pLPaint_Paint(object sender, PaintEventArgs e)
        {
            //获取用于绘制的图形
            Graphics g = e.Graphics;
            //图形的抗锯齿设置
            g.SmoothingMode = SmoothingMode.AntiAlias;//AntiAlias - 消除锯齿
            
            //隔 YDotNum 个数据点画1条横向虚线，给画笔指定颜色、线宽及线型
            const byte YDotNum = 30;
            Pen pen = new Pen(Color.DarkGray, 1);//DarkGray - 深灰色
            pen.DashStyle = DashStyle.Dash;
            for (int i = 1; pLPaint.Height / 2 + i * YDotNum < pLPaint.Height; i++)
            {
                //隔 YDotNum 画中间线以下的横向虚线
                g.DrawLines(pen, new Point[] { new Point(0, pLPaint.Height / 2 + i * YDotNum), new Point(pLPaint.Width, pLPaint.Height / 2 + i * YDotNum) });
                //隔 YDotNum 画中间线以上的横向虚线
                g.DrawLines(pen, new Point[] { new Point(0, pLPaint.Height / 2 - i * YDotNum), new Point(pLPaint.Width, pLPaint.Height / 2 - i * YDotNum) });
            }
            //在中间画1条横向实线
            pen.DashStyle = DashStyle.Solid;
            pen.Width = 1.8f;
            g.DrawLines(pen, new Point[] { new Point(0, pLPaint.Height / 2), new Point(pLPaint.Width, pLPaint.Height / 2) });
            //给横线标上刻度
            for (int i = 1; pLPaint.Height / 2 + i * YDotNum < pLPaint.Height; i++)
            {
                //隔 YDotNum 标中间线以上的横向虚线
                g.DrawString((-1 * i).ToString(), new Font("宋体", 10), Brushes.Black, new Point(0, pLPaint.Height / 2 + i * YDotNum));
                //隔 YDotNum 标中间线以下的横向虚线
                g.DrawString(i.ToString(), new Font("宋体", 10), Brushes.Black, new Point(0, pLPaint.Height / 2 - i * YDotNum));
            }
            g.DrawString("0", new Font("宋体", 10), Brushes.Black, new Point(0, pLPaint.Height / 2));

            //隔 XDotNum 个数据点画1条纵向虚线，给画笔指定颜色、线宽及线型
            const byte XDotNum = 50;
            pen.Color = Color.DarkGray;//DarkGray - 深灰色
            pen.DashStyle = DashStyle.Dot;
            pen.Width = 0.9f;
            for (int i = 1; i * XDotNum < pLPaint.Width; i ++)
            {
                g.DrawLines(pen, new Point[] { new Point(i * XDotNum, 0), new Point(i * XDotNum, pLPaint.Height) });
            }
            //给纵线标上刻度
            for (int i = 1; i * XDotNum < pLPaint.Width; i++)
            {
                g.DrawString(i.ToString(), new Font("宋体", 10), Brushes.Black, new Point(i * XDotNum, pLPaint.Height - 15));
            }

            //根据显示指针勾选框选中的情况，绘制两条纵向的指针
            if (cBPointer.Checked)
            {
                pen.Color = Color.Cyan;//Cyan - 青色
                g.DrawLines(pen, new Point[] { new Point(tracePos1, 0), new Point(tracePos1, pLPaint.Height) });
                pen.Color = Color.DarkCyan;//DarkCyan - 暗青色
                g.DrawLines(pen, new Point[] { new Point(tracePos2, 0), new Point(tracePos2, pLPaint.Height) });
            }
            label17.Text = "指针1位置：" + tracePos1.ToString();
            label18.Text = "指针2位置：" + tracePos2.ToString();
            label19.Text = "两指针的间隔时间：" + ((tracePos2 - tracePos1) * Interval).ToString() + " ms";
            label20.Text = "单位间隔时间：" + (Interval * XDotNum).ToString() + " ms";

            //分别处理每条要测量的曲线
            for (int i = 0; i < showItems.Count;i++ )
            {
                //若队列非空并且勾选显示
                if (showItems[i].sq != null && showItems[i].IsCheck)
                {
                    //由队列元素个数创建数组
                    int[] pointY = new int[showItems[i].sq.Count()];
                    //将队列元素的值赋给数组的每个元素
                    showItems[i].sq.Print(ref pointY);

                    int m = pointY.Length;
                    if (m > 1)
                    {
                        //由队列元素个数创建坐标对
                        PointF[] points = new PointF[m];

                        for (int j = 0; j < m; j++)//分别处理每一坐标对
                        {
                            switch (showItems[i].Item)
                            {
                                case Configuration.SCP_TAGCUR_L:
                                case Configuration.SCP_MEACUR_L://若曲线是电流
                                    //currentRatio - 单位转换比率，cr - Y轴缩放比例，YDotNum - 图上单位长度，Y方向的0位在屏幕顶端，(pointY[j] * currentRatio)带单位的数值
                                    points[j] = new PointF(1.0f * pointA[j], (float)((pLPaint.Height / 2 - (pointY[j] * currentRatio + currentOffset) / cr * YDotNum)));
                                    break;
                                case Configuration.SCP_TAGSPD_L:
                                case Configuration.SCP_MEASPD_L://若曲线是速度
                                    points[j] = new PointF(1.0f * pointA[j], (float)((pLPaint.Height / 2 - (pointY[j] * speedRatio + speedOffset) / sr * YDotNum)));
                                    break;
                                case Configuration.SCP_TAGPOS_L:
                                case Configuration.SCP_MEAPOS_L://若曲线是位置
                                    points[j] = new PointF(1.0f * pointA[j], (float)((pLPaint.Height / 2 - (pointY[j] * positionRatio + positionOffset) / pr * YDotNum)));
                                    break;
                            }
                        }

                        //根据曲线定义的颜色和线型，绘制出曲线
                        pen.Color = showItems[i].Cl;
                        pen.DashStyle = showItems[i].Ds;
                        g.DrawLines(pen, points);
                    }
                }
            }
        }

        //指针响应处理函数
        private void tBtrace_Scroll(object sender, EventArgs e)
        {
            if (rBPointer1.Checked)
            {
                tracePos1 = (ushort)tBtrace.Value;
                if (tracePos1 >= tracePos2)//避免指针1越到指针2右边
                {
                    tracePos1 = tracePos2;
                    tBtrace.Value = tracePos2;
                }
            }
            if (rBPointer2.Checked)
            {
                tracePos2 = (ushort)tBtrace.Value - 1;//滑块最大值740（pLPaint.Width），而指针所确定的index，最大739
                if (tracePos1 >= tracePos2)//避免指针2越到指针1左边
                {
                    tracePos2 = tracePos1;
                    tBtrace.Value = tracePos1;
                }
            }
        }

        //选项卡切换事件
        private void tCMonitor_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tCMonitor.SelectedIndex)
            {
                case 0:
                    //listview中测量项目初始化，showItems
                    loadLVMeasureItems();
                    break;
                case 2:
                    //若勾选显示指针
                    if (cBPointer.Checked)
                        refreshlVPointer();
                    break;
                case 3:
                    cBAdjustGroup.Text = Configuration.MemoryControlTable[Configuration.SEV_PARAME_LOCKED].ToString();
                    loadPID();
                    break;
            }
        }

        void loadPID()
        {
            string pidGroup = IniFile.ContentValue("OscilloScope", "PIDGroup", IniFile.StrProPath);
            cBAdjustGroup.Text = pidGroup;
            
            Thread.Sleep(5);

            tBCurrentP.Text = Configuration.MemoryControlTable[CURRENT_P].ToString();
            tBCurrentI.Text = Configuration.MemoryControlTable[CURRENT_I].ToString();
            tBSpeedP.Text = Configuration.MemoryControlTable[SPEED_P].ToString();
            tBSpeedI.Text = Configuration.MemoryControlTable[SPEED_I].ToString();
            tBSpeedD.Text = Configuration.MemoryControlTable[SPEED_D].ToString();
            tBSpeedDeadZone.Text = Configuration.MemoryControlTable[SPEED_DS].ToString();
            tBPosP.Text = Configuration.MemoryControlTable[POSITION_P].ToString();
            tBPosI.Text = Configuration.MemoryControlTable[POSITION_I].ToString();
            tBPosD.Text = Configuration.MemoryControlTable[POSITION_D].ToString();
            tBPosDeadZone.Text = Configuration.MemoryControlTable[POSITION_DS].ToString();
            tBMaxCurrent.Text = Configuration.MemoryControlTable[Configuration.LIT_MAX_CURRENT].ToString();
            tBMaxSpeed.Text = Configuration.MemoryControlTable[Configuration.LIT_MAX_SPEED].ToString();
            tBMaxAcc.Text = Configuration.MemoryControlTable[Configuration.LIT_MAX_ACC].ToString();

           
        }

        //listview中测量项目初始化，showItems
        void loadLVMeasureItems()
        {
            lVMeasureItems.Items.Clear();
            lVMeasureItems.Visible = true;
            for (int i = 0; i < showItems.Count;i++ )
            {
                //添加一个集合
                lVMeasureItems.Items.Add((i+1).ToString());
                //添加字符串数组的子项到集合中，进一步描述集合
                lVMeasureItems.Items[i].SubItems.AddRange(new string[] { itemRelection[showItems[i].Item], showItems[i].Monitor, "", GetDashStyle(showItems[i].Ds) });
                //控制集合子项的显示样式
                lVMeasureItems.Items[i].UseItemStyleForSubItems = false;
                //设置集合子项的背景色
                lVMeasureItems.Items[i].SubItems[3].BackColor = showItems[i].Cl;
                //确定集合是否勾选的状态
                lVMeasureItems.Items[i].Checked = showItems[i].IsCheck;
            }
        }

        //由DashStyle的值返回相应的中文字符串
        private string GetDashStyle(DashStyle ds)
        {
            string str = "";
            switch (ds)
            {
                case DashStyle.Solid:       str = "实线"; break;
                case DashStyle.Dash:        str = "虚线" ; break;
                case DashStyle.Dot:         str = "点线"; break;
                case DashStyle.DashDot:     str = "点划线"; break;
                case DashStyle.DashDotDot : str = "双点划线"; break;
            }
            return str;
        }

        private void lVFormat_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (lVMeasureItems.FocusedItem != null)
            {
                int index = e.Item.Index;
                e.Item.Selected = e.Item.Checked;
                showItems[index].IsCheck = e.Item.Checked;
                if (showItems[index].IsCheck)
                {
                    Mask |= showItems[index].Mask;
                }
                else
                {
                    Mask &= (byte) ~(int)showItems[index].Mask;
                }

                pc.WriteOneWord(Configuration.SCP_MASK, OscilloScope.Mask, PCan.currentID);       //向下位机请求数据
            }
        }

        //按键确认输入值（enter）
        private void tBCurrentP_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (e.KeyCode == Keys.Enter)
            {
                short value = 0;
                try
                {
                     value = Convert.ToInt16(tb.Text);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("请输入合法的字符串！");
                    MainForm.GetInstance().sBFeedbackShow(ex.Message, 1);
                    return;
                }
                switch(tb.Name)
                {
                    case "tBCurrentP":pc.WriteOneWord(CURRENT_P,value,PCan.currentID); break;
                    case "tBCurrentI":pc.WriteOneWord(CURRENT_I,value,PCan.currentID);  break;
                    case "tBSpeedP":pc.WriteOneWord(SPEED_P,value,PCan.currentID);  break;
                    case "tBSpeedI":pc.WriteOneWord(SPEED_I,value,PCan.currentID);  break;
                    case "tBSpeedD":pc.WriteOneWord(SPEED_D,value,PCan.currentID);  break;
                    case "tBSpeedDeadZone": pc.WriteOneWord(SPEED_DS,value,PCan.currentID); break;
                    case "tBPosP":pc.WriteOneWord(POSITION_P,value,PCan.currentID);  break;
                    case "tBPosI": pc.WriteOneWord(POSITION_I,value,PCan.currentID); break;
                    case "tBPosD": pc.WriteOneWord(POSITION_D,value,PCan.currentID); break;
                    case "tBPosDeadZone": pc.WriteOneWord(POSITION_DS,value,PCan.currentID); break; 

                    case "tBMaxCurrent": pc.WriteOneWord(Configuration.LIT_MAX_CURRENT,value,PCan.currentID); break; 
                    case "tBMaxSpeed": pc.WriteOneWord(Configuration.LIT_MAX_SPEED,value,PCan.currentID); break; 
                    case "tBMaxAcc": pc.WriteOneWord(Configuration.LIT_MAX_ACC,value,PCan.currentID); break;

                    case "tBScanFrequency": setTimeInterval(value);break;
                }
            }
        }

        private void cBAdjustGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = cBAdjustGroup.Text;
            switch (type)
            {
                case "1": CURRENT_P = Configuration.S_CURRENT_P;
                    CURRENT_I = Configuration.S_CURRENT_I;
                    CURRENT_D = Configuration.S_CURRENT_D;
                    SPEED_P = Configuration.S_SPEED_P;
                    SPEED_I = Configuration.S_SPEED_I;
                    SPEED_D = Configuration.S_SPEED_D;
                    SPEED_DS = Configuration.S_SPEED_DS;
                    POSITION_P = Configuration.S_POSITION_P;
                    POSITION_I = Configuration.S_POSITION_I;
                    POSITION_D = Configuration.S_POSITION_D;
                    POSITION_DS = Configuration.S_POSITION_DS;
                    break;
                case "2": CURRENT_P = Configuration.M_CURRENT_P;
                    CURRENT_I = Configuration.M_CURRENT_I;
                    CURRENT_D = Configuration.M_CURRENT_D;
                    SPEED_P = Configuration.M_SPEED_P;
                    SPEED_I = Configuration.M_SPEED_I;
                    SPEED_D = Configuration.M_SPEED_D;
                    SPEED_DS = Configuration.M_SPEED_DS;
                    POSITION_P = Configuration.M_POSITION_P;
                    POSITION_I = Configuration.M_POSITION_I;
                    POSITION_D = Configuration.M_POSITION_D;
                    POSITION_DS = Configuration.M_POSITION_DS;
                    break;
                case "3": CURRENT_P = Configuration.L_CURRENT_P;
                    CURRENT_I = Configuration.L_CURRENT_I;
                    CURRENT_D = Configuration.L_CURRENT_D;
                    SPEED_P = Configuration.L_SPEED_P;
                    SPEED_I = Configuration.L_SPEED_I;
                    SPEED_D = Configuration.L_SPEED_D;
                    SPEED_DS = Configuration.L_SPEED_DS;
                    POSITION_P = Configuration.L_POSITION_P;
                    POSITION_I = Configuration.L_POSITION_I;
                    POSITION_D = Configuration.L_POSITION_D;
                    POSITION_DS = Configuration.L_POSITION_DS;
                    break;
            }
            if (type == "0")
            {
                gBCurrent.Enabled = false;
                gBSpeed.Enabled = false;
                gBPos.Enabled = false;
            }
            else
            {
                gBCurrent.Enabled = true;
                gBSpeed.Enabled = true;
                gBPos.Enabled = true;
            }
            pc.WriteOneWord(Configuration.SEV_PARAME_LOCKED, Convert.ToInt16(type), PCan.currentID);    //应设置触发条件
            IniFile.WritePrivateProfileString("OscilloScope", "PIDGroup", type, IniFile.StrProPath);
            loadPID();
        }

        private void tBCurrentP_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            try
            {
                short value = Convert.ToInt16(tb.Text);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请输入合法的字符串！");
                MainForm.GetInstance().sBFeedbackShow(ex.Message, 1);
                return;
            }
        }

        private void cBPointer_CheckedChanged(object sender, EventArgs e)
        {
            if (cBPointer.Checked)
            {
                tBtrace.Enabled = true;
                if (rBPointer1.Checked)
                {
                    tBtrace.Value = tracePos1;
                }
                else
                {
                    tBtrace.Value = tracePos2;
                }

                refreshlVPointer();
            }
            else
            {
                //tMPointer.Stop();
                tBtrace.Enabled = false;
                lVPointer.Items.Clear();
            }
        }

        //刷新指针显示列表
        private void refreshlVPointer()
        {
            //ListView中各项清空
            lVPointer.Items.Clear();
            //分别处理每条要测量的曲线
            for (int i = 0, j = 0; i < showItems.Count; i++)
            {
                //若队列非空并且勾选显示
                if (showItems[i].IsCheck && showItems[i].sq != null)
                {
                    lVPointer.Items.Add(itemRelection[showItems[i].Item]);//ListView中的项目名称
                    double ratio = 1.0;//默认比率是1.0
                    if(showItems[i].Item == Configuration.SCP_TAGSPD_L || showItems[i].Item == Configuration.SCP_MEASPD_L)
                    {
                        ratio = 60.0 / 65536.0;//实际速度和目标速度的比率
                    }
                    int pV1 = Convert.ToInt32(GetPointerValue(showItems[i].sq, tracePos1) * ratio);
                    int pV2 = Convert.ToInt32(GetPointerValue(showItems[i].sq, tracePos2) * ratio);
                    float pAverage = Convert.ToSingle(showItems[i].sq.GetAverageValue(tracePos1, tracePos2) * ratio);
                    float maxValue = Convert.ToSingle(showItems[i].sq.GetMaxValue(tracePos1, tracePos2) * ratio);
                    float minValue = Convert.ToSingle(showItems[i].sq.GetMinValue(tracePos1, tracePos2) * ratio);
                    float sDeviation = Convert.ToSingle(showItems[i].sq.GetSDeviation(tracePos1, tracePos2) * ratio);
                    //更新列表中的显示
                    lVPointer.Items[j].SubItems.AddRange(new string[] {
                        "",                     //准备着要显示“单位”
                        pV1.ToString(),         //指针1所在的值
                        pV2.ToString(),         //指针2所在的值
                        (pV2 - pV1).ToString(), //两者的差值
                        pAverage.ToString(),    //均值
                        maxValue.ToString(),    //区间内极大值
                        minValue.ToString(),    //区间内极小值
                        sDeviation.ToString()   //标准差
                    });
                    j++;
                    
                    //取出实际电流、实际速度值，用于计算摩擦参数
                    if (showItems[i].Item == Configuration.SCP_MEASPD_L)
                    {
                        measureSpeed = pAverage;
                    }
                    else if (showItems[i].Item == Configuration.SCP_MEACUR_L)
                    {
                        measureCurrent = pAverage;
                    }
                }
            }
        }

        //获得链表中指针指定的元素的值
        private int GetPointerValue(ShowQueue sq, int index)
        {
            if (index > sq.Count() - 1)//index从0开始，而Count()在有1个元素时返回1
            {
                return 0;
            }
            else
            {
                return sq.GetValue(index);
            }
        }

        //切换选中指针1或指针2
        private void rBPointer1_CheckedChanged(object sender, EventArgs e)
        {
            if (rBPointer1.Checked)
            {
                tBtrace.Value = tracePos1;
            }
            else
            {
                tBtrace.Value = tracePos2;
            }
        }

        //测量启停按钮
        private void btnMeasure_Click(object sender, EventArgs e)
        {
            if (btnMeasure.Text == "测定")
            {
                btnMeasure.Text = "停止";
                btnMeasure.BackColor = Color.Red;
                EnableScope = true;
                //pBRecordImage.Enabled = true;
            }
            else
            {
                btnMeasure.Text = "测定";
                btnMeasure.BackColor = Color.Green;
                EnableScope = false;
                //pBRecordImage.Enabled = false;
            }
        }

        //鼠标右击表格线型（颜色）区域能选择线型（颜色）
        private void lVFormat_MouseClick(object sender, MouseEventArgs e)
        {
            //若是鼠标右击
            if (e.Button == MouseButtons.Right)
            {
                //右击颜色
                if (e.X > 420 && e.X < 570)
                {
                    int index = lVMeasureItems.FocusedItem.Index;
                    if (cDcolor.ShowDialog() == DialogResult.OK)
                    {
                        showItems[index].Cl = cDcolor.Color;
                        loadLVMeasureItems();
                    }
                }
                //右击线型
                else if (e.X > 570 && e.X < 740)
                {
                    int index = lVMeasureItems.FocusedItem.Index;
                    Rectangle tt = lVMeasureItems.Items[index].SubItems[4].Bounds;
                    if (cb != null)
                    {
                        showItems[(int)cb.Tag].Ds = GetDashStyle(cb.Text);
                        loadLVMeasureItems();
                        lVMeasureItems.Controls.Remove(cb);
                        cb = null;
                    }
                    cb = new ComboBox();
                    cb.Tag = index;
                    cb.Font = new Font("宋体", 13, FontStyle.Bold);
                    cb.Size = new Size(tt.Width, 18);
                    cb.Location = tt.Location;
                    cb.BackColor = Color.White;
                    cb.Text = "实线";
                    cb.Items.Add("实线");
                    cb.Items.Add("虚线");
                    cb.Items.Add("点线");
                    cb.Items.Add("点划线");
                    cb.Items.Add("双点划线");

                    //cb.Focus();
                    lVMeasureItems.Controls.Add(cb);
                }
            }
            ////若是鼠标左击，不懂用处何在？
            //else if (e.Button == MouseButtons.Left)
            //{
                //int index = lVMeasureItems.SelectedItems[0].Index;
                //try
                //{
                //    //若组合框控件cb不为空，并且
                //    if (cb != null && ((object)index != cb.Tag || e.X < 570 || e.X > 740))  //注意判定条件
                //    {
                //        showItems[(int)cb.Tag].Ds = GetDashStyle(cb.Text);
                //        loadLVMeasureItems();
                //        lVMeasureItems.Controls.Remove(cb);
                //        cb = null;
                //    }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("lVFormat_MouseClick()异常！");
                //    MainForm.GetInstance().sBFeedbackShow(ex.Message, 1);
                //}
            //}
        }

        //根据中文返回线型
        private DashStyle GetDashStyle(string strStyle)
        {
            DashStyle ds = new DashStyle();
            switch (strStyle)
            {
                case "实线": ds = DashStyle.Solid;break;
                case "虚线": ds = DashStyle.Dash; break;
                case "点线": ds = DashStyle.Dot; break;
                case "点划线": ds = DashStyle.DashDot; break;
                case "双点划线": ds = DashStyle.DashDotDot; break;
            }
            return ds;
        }

        //tMpointer定时器周期执行（刷新指针显示列表，缩放比例下拉框显示出单位）
        private void tMPointer_Tick(object sender, EventArgs e)
        {
            if (cBPointer.Checked)//若“显示指针”勾选框选中
            {
                refreshlVPointer();
            }
            if (!cBCurrentRatio.Focused)//若比例组合框未处于选中状态
            {
                cBCurrentRatio.Text = cr.ToString() + "mA";//则显示出相应数值
            }
            if (!cBSpeedRatio.Focused)
            {
                cBSpeedRatio.Text = sr.ToString() + "rpm";
            }
            if (!cBPositionRatio.Focused)
            {
                cBPositionRatio.Text = pr.ToString() + "°";
            }
        }

        private void pBRecordImage_Click(object sender, EventArgs e)
        {
            //记录当前波形

        }

        private void cBCurrentRatio_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.Name == "cBCurrentRatio")
            {
                cr = Convert.ToDouble(cBCurrentRatio.Text.Substring(0, cBCurrentRatio.Text.Length - 2));
                IniFile.WritePrivateProfileString("plRange", "Current", cr.ToString(), IniFile.StrProPath);
            }
            else if (cb.Name == "cBSpeedRatio")
            {
                sr = Convert.ToDouble(cBSpeedRatio.Text.Substring(0, cBSpeedRatio.Text.Length - 3));
                IniFile.WritePrivateProfileString("plRange", "Speed", sr.ToString(), IniFile.StrProPath);
            }
            else if (cb.Name == "cBPositionRatio")
            {
                pr = Convert.ToDouble(cBPositionRatio.Text.Substring(0, cBPositionRatio.Text.Length - 1));
                IniFile.WritePrivateProfileString("plRange", "Position", pr.ToString(), IniFile.StrProPath);
            }
            btnMeasure.Focus();
        }

        private void cBCurrentRatio_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                ComboBox cb = sender as ComboBox;
                try
                {
                    if (cb.Name == "cBCurrentRatio")
                    {
                        cr = Convert.ToDouble(cb.Text.Substring(0, cb.Text.Length - 2));
                        IniFile.WritePrivateProfileString("plRange", "Current", cr.ToString(), IniFile.StrProPath);
                    }
                    else if (cb.Name == "cBSpeedRatio")
                    {
                        sr = Convert.ToDouble(cb.Text.Substring(0, cb.Text.Length - 3));
                        IniFile.WritePrivateProfileString("plRange", "Speed", sr.ToString(), IniFile.StrProPath);
                    }
                    else if (cb.Name == "cBPositionRatio")
                    {
                        pr = Convert.ToDouble(cb.Text.Substring(0, cb.Text.Length - 1));
                        IniFile.WritePrivateProfileString("plRange", "Position", pr.ToString(), IniFile.StrProPath);
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("请输入合法的数据!");
                    MainForm.GetInstance().sBFeedbackShow(ex.Message, 1);
                }
            }
        }

        private void cBCurrentRatio_MouseEnter(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            cb.Focus();
            if (cb.Name == "cBCurrentRatio")
            {
                cb.Select(0, cb.Text.Length - 2);
            }
            else if (cb.Name == "cBSpeedRatio")
            {
                cb.Select(0, cb.Text.Length - 3);
            }
            else if (cb.Name == "cBPositionRatio")
            {
                cb.Select(0, cb.Text.Length - 1);
            }
        }

        //电流、速度、位置的偏移值设置
        private void tBCurrentOffset_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextBox tb = sender as TextBox;
                try
                {
                    switch (tb.Name)
                    {
                        case "tBCurrentOffset": currentOffset   = Convert.ToSingle(tBCurrentOffset.Text);   break;
                        case "tBSpeedOffset":   speedOffset     = Convert.ToSingle(tBSpeedOffset.Text);     break;
                        case "tBPositionOffset":positionOffset  = Convert.ToSingle(tBPositionOffset.Text);  break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("请输入合法的数据!");
                    MainForm.GetInstance().sBFeedbackShow(ex.Message, 1);
                }
            }
        }

        private void btnFriction_Click(object sender, EventArgs e)
        {
            pc.WriteOneWord(Configuration.TAG_WORK_MODE, Configuration.MODE_SPEED, PCan.currentID);
            int value = Convert.ToInt32(1500 / 60.0 * 65536.0);
            pc.WriteTwoWords(Configuration.TAG_SPEED_L, value, PCan.currentID);

            OscilloScope.Mask = 10;
            pc.WriteOneWord(Configuration.SCP_MASK, OscilloScope.Mask, PCan.currentID);       //打开电流 速度发送开关
            MotionControl.tCount = 0;
            EnableFrictionMeasure = true;
        }

        private void btnCurrentCompensation_Click(object sender, EventArgs e)
        {
            EnableCurrentCompensation = true;
        }

        private void nUSmoothData_ValueChanged(object sender, EventArgs e)
        {
            switch(Convert.ToInt32(nUSmoothData.Value))
            {
                case 0: MotionControl.kfQ = 0.0; MotionControl.kfR = 0.0; break;
                case 1: MotionControl.kfQ = 0.1; MotionControl.kfR = 0.1; break;
                case 2: MotionControl.kfQ = 0.1; MotionControl.kfR = 10; break;
                case 3: MotionControl.kfQ = 0.01; MotionControl.kfR = 50; break;
                case 4: MotionControl.kfQ = 10; MotionControl.kfR = 0.1; break;
                case 5: MotionControl.kfQ = 50; MotionControl.kfR = 0.01; break;
            }
        }

        #region 标题栏的事件

        private void pLName_Click(object sender, EventArgs e)
        {
            BringToFront();
        }

        #region 用鼠标拖拽移动窗体

        private Point mousePoint = Point.Empty;
        private void pLName_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //_mousePoint.X = e.X;
                //_mousePoint.Y = e.Y;
                mousePoint = MousePosition;
            }
        }

        private void pLName_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && mousePoint != Point.Empty)
            {
                this.Top += MousePosition.Y - mousePoint.Y;
                this.Left += MousePosition.X - mousePoint.X;
                mousePoint = MousePosition;
            }
            //this.PointToClient(MousePosition).Y
        }

        private void pLName_MouseUp(object sender, MouseEventArgs e)
        {
            mousePoint = Point.Empty;
        }

        #endregion

        private void pBExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }

    public class ShowItem
    {
        public bool IsCheck;
        public byte Item;
        public string Monitor;
        public Color Cl;
        public DashStyle Ds;
        public ShowQueue sq;
        public byte Mask;

        public ShowItem(bool isCheck, byte item, string monitor, Color cl, DashStyle ds, int queueSize, byte mask)
        {
            IsCheck = isCheck;
            Item = item;
            Monitor = monitor;
            Cl = cl;
            Ds = ds;
            sq = new ShowQueue(queueSize);
            Mask = mask;
        }
    }

    public class Node
    {
        private int value;
        private Node next;
        public Node(int v)
        {
            value = v;
            this.next = null;
        }

        public int Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public Node Next
        {
            get { return next; }
            set { next = value; }
        }
    }

    public class ShowQueue
    {
        public int QCount;
        public Node front;//队列头
        public Node rear;//队列尾
        private int num;//队列元素个数

        private object ob = new object();

        //public bool flag1 = true;
        //public bool flag2 = true;

        public ShowQueue(int queueSize)  //构造函数
        {
            front = rear = null;
            num = 0;
            QCount = queueSize;
        }

        public int Count()
        {
            return this.num;
        }

        public void Clear()
        {
            front = rear = null;
            num = 0;
        }

        public bool IsEmpty()
        {
            return (front == rear && num == 0);
        }

        //追加
        public void EnQ(int data)
        {
            lock (ob)
            {
                Node q = new Node(data);
                //第一个元素入列时
                if (rear == null)
                {
                    front = rear = q;
                }
                else
                {
                    //若队列已经满了
                    if (Count() == QCount)
                    {
                        //链头指向后移一位
                        front = front.Next;
                        //如果此时链表为空，则同步修正rear，说明链表长度仅为1
                        if (front == null)
                        {
                            front = rear = q;
                        }
                        else
                        {
                            //把新元素挂到链尾
                            rear.Next = q;
                            //修正rear指向为最后一个元素
                            rear = q;
                        }
                        //元素总数-1
                        num--;
                    }
                    else
                    {
                        //把新元素挂到链尾
                        rear.Next = q;
                        //修正rear指向为最后一个元素
                        rear = q;
                    }
                }
                //元素总数+1
                num++;
            }
        }

        //未用
        public int DeQ()
        {
            lock (ob)
            {
                if (IsEmpty())
                {
                    return 0;
                }
                //取链首元素
                Node p = front;
                //链头指向后移一位
                front = front.Next;

                //如果此时链表为空，则同步修正rear
                if (front == null)
                {
                    rear = null;
                }
                num--;//个数-1
                return 1;
            }
           
        }

        //public float[] QMean()
        //{
            //while (!flag2) { };
            //flag1 = false;
            //if (rear != null)
            //{
            //    float[] sum = new float[6];
            //    Node mean = front;
            //    while (mean != null)
            //    {
            //        for (int i = 0; i < 6; i++)
            //        {
            //            //sum[i] += mean.Data[i];
            //        }
            //        mean = mean.Next;
            //    }
            //    //for (int i = 0; i < 6; i++)
            //    //{
            //    //    sum[i] /= Count;
            //    //}
            //    flag1 = true;
            //    return sum;
            //}
            //else
            //{
            //    flag1 = true;
            //    return null;
            //}
        //}

        public int GetValue(int index)
        {
            lock(ob)
            {
                Node current = front;
                int j = 0;
                while (j != index)
                {
                    current = current.Next;
                    j++;
                }
                return current.Value;
            }
        }

        //得到区间内所有数据的平均值
        public float GetAverageValue(int m, int n)
        {
            //允许选定的区间超过数据范围，但选定区间起始位置在数据范围内才返回有效值。m和n都从0开始，而Count()在只有1个元素的时候返回的是1
            if (m > Count() - 1)
            {
                return 0.0f;
            }
            //进入临界区对链表进行读取
            lock (ob)
            {
                //访问链表元素的指针
                Node current = front;
                //用来配合计数
                int j = 0;
                //移动到链表指定区间起始处
                while (j != m)
                {
                    current = current.Next;
                    j++;
                }
                //取所要的值中的第1个
                float sum = current.Value;
                current = current.Next;
                j++;
                //第n个值还没加上，则继续循环
                while (j != n + 1)
                {
                    try
                    {
                        //全部累加后float有可能溢出
                        sum += current.Value;
                        //移动指针
                        current = current.Next;
                        j++;
                    }
                    //队列方面的异常，或者溢出异常
                    catch// (Exception ex)
                    {
                        //MainForm.GetInstance().sBFeedbackShow(ex.Message, 1);
                        break;
                    }
                }
                //总和sum除以已累加的元素个数，得到均值
                return sum / (j - m);
            }
        }

        //得到区间内数据的最大值
        public float GetMaxValue(int m, int n)
        {
            //允许选定的区间超过数据范围，但选定区间起始位置在数据范围内才返回有效值
            if (m > Count() - 1)
            {
                return 0.0f;
            }
            lock (ob)
            {
                Node current = front;
                int j = 0;
                while (j != m)
                {
                    current = current.Next;
                    j++;
                }
                float max = current.Value;
                current = current.Next;
                j++;
                while (j != n + 1)
                {
                    try
                    {
                        if (current.Value > max)
                        {
                            max = current.Value;
                        }
                        current = current.Next;
                        j++;
                    }
                    catch// (Exception ex)
                    {
                        //MainForm.GetInstance().sBFeedbackShow(ex.Message, 1);
                        break;
                    }
                }
                return max;
            }
        }

        //得到区间内数据的最小值
        public float GetMinValue(int m, int n)
        {
            if (m > Count() - 1)
            {
                return 0.0f;
            }
            lock (ob)
            {
                Node current = front;
                int j = 0;
                while (j != m)
                {
                    current = current.Next;
                    j++;
                }
                float min = current.Value;
                current = current.Next;
                j++;
                while (j != n + 1)
                {
                    try
                    {
                        if (current.Value < min)
                        {
                            min = current.Value;
                        }
                        current = current.Next;
                        j++;
                    }
                    catch// (Exception ex)
                    {
                        //MainForm.GetInstance().sBFeedbackShow(ex.Message, 1);
                        break;
                    }
                }
                return min;
            }
        }

        //得到区间内数据的标准差（总体）
        public float GetSDeviation(int m, int n)
        {
            if (m > Count() - 1)
            {
                return 0.0f;
            }
            lock (ob)
            {
                //求出这组数据的均值
                float pAverage = Convert.ToSingle(GetAverageValue(m, n));

                //循环中求“离均差平方和”，访问链表元素的指针
                Node current = front;
                //用来配合计数
                int j = 0;
                //移动到链表指定区间起始处
                while (j != m)
                {
                    current = current.Next;
                    j++;
                }
                //取所要的值中的第1个
                float sum = Convert.ToSingle(Math.Pow(current.Value - pAverage, 2));
                current = current.Next;
                j++;
                //第n个值还没加上，则继续循环
                while (j != n + 1)
                {
                    try
                    {
                        //全部累加后float有可能溢出
                        sum += Convert.ToSingle(Math.Pow(current.Value - pAverage, 2));
                        //移动指针
                        current = current.Next;
                        j++;
                    }
                    //队列方面的异常，或者溢出异常
                    catch// (Exception ex)
                    {
                        //MainForm.GetInstance().sBFeedbackShow(ex.Message, 1);
                        break;
                    }
                }
                
                //返回上一步结果平均后的方根
                return Convert.ToSingle(Math.Sqrt(sum / (j - m)));
            }
        }

        public void Print(ref int[] eachValue)
        {
            lock(ob)
            {
                //int[] eachValue = new int[Count()];
                Node current = front;
                int j = 0;
                //while (current != null)
                while (j != eachValue.Length)
                {
                    eachValue[j] = current.Value;
                    current = current.Next;
                    j++;
                }
            }
        }
    }
}

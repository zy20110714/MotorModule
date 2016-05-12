using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
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
        public static List<ShowItem> showItems = new List<ShowItem>();
        public static byte Mask = 0; 
        public static int Interval = 0;
        Dictionary<byte, string> itemRelection = new Dictionary<byte, string>();
        ComboBox cb;
        Thread thread;
        PCan pc;
        bool running = true;
        int spanTime = 20;
        double speedRatio = 60.0 / 65536;
        double positionRatio = 360.0 / 65535;
        double currentRatio = 1.0;

      
        int tracePos1 = 0;
        int tracePos2 = 0;
        public static bool EnableScope = false;



        public static byte CURRENT_P = 0x61;	  //电流环P参数
        public static byte CURRENT_I = 0x62;	  //电流环I参数
        public static byte CURRENT_D = 0x63;	  //电流环D参数
        public static byte SPEED_P = 0x64;	  //速度环P参数
        public static byte SPEED_I = 0x65;	  //速度环I参数
        public static byte SPEED_D = 0x66;	  //速度环D参数
        public static byte SPEED_DS = 0x67;	  //速度P死区
        public static byte POSITION_P = 0x68;	  //位置环P参数
        public static byte POSITION_I = 0x69;	  //位置环I参数
        public static byte POSITION_D = 0x6A;	  //位置环D参数
        public static byte POSITION_DS = 0x6B;	  //位置P死区

        public OscilloScope()
        {
            InitializeComponent();
            pc = new PCan();

            InitialControls();
            thread = new Thread(new ThreadStart(ThreadProc));
            thread.Name = "HighAccuracyTimer";
            //thread.Start();
            timerPaint.Start();
            EnableScope = true;
        }

        ~OscilloScope()
        {
            running = false;
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
            running = false;
            Thread.Sleep(spanTime + 5);   //等待线程thread结束后再abort
            if (thread != null)
            {
                thread.Abort();
                thread.Join();
                thread = null;
            }
        }

        private void InitialControls()
        {
            tracePos1 = 0;
            tracePos2 = pLPaint.Width;
            itemRelection.Clear();
            itemRelection.Add(Configuration.SCP_TAGCUR_L, "指令电流");
            itemRelection.Add(Configuration.SCP_TAGSPD_L, "指令速度");
            itemRelection.Add(Configuration.SCP_TAGPOS_L, "指令位置");
            itemRelection.Add(Configuration.SCP_MEACUR_L, "实际电流");
            itemRelection.Add(Configuration.SCP_MEASPD_L, "实际速度");
            itemRelection.Add(Configuration.SCP_MEAPOS_L, "实际位置");
            showItems.Clear();
            showItems.Add(new ShowItem(true, Configuration.SCP_TAGCUR_L, "观测", Color.Yellow, DashStyle.Solid, pLPaint.Width, Configuration.MASK_TAGCUR));
            showItems.Add(new ShowItem(true, Configuration.SCP_TAGSPD_L, "观测", Color.Green, DashStyle.Solid, pLPaint.Width, Configuration.MASK_TAGSPD));
            showItems.Add(new ShowItem(true, Configuration.SCP_TAGPOS_L, "观测", Color.Blue, DashStyle.Solid, pLPaint.Width, Configuration.MASK_TAGPOS));
            showItems.Add(new ShowItem(true, Configuration.SCP_MEACUR_L, "观测", Color.Cyan, DashStyle.Solid, pLPaint.Width, Configuration.MASK_MEACUR));
            showItems.Add(new ShowItem(true, Configuration.SCP_MEASPD_L, "观测", Color.HotPink, DashStyle.Solid, pLPaint.Width, Configuration.MASK_MEASPD));
            showItems.Add(new ShowItem(true, Configuration.SCP_MEAPOS_L, "观测", Color.Red, DashStyle.Solid, pLPaint.Width, Configuration.MASK_MEAPOS));

            Mask |= Configuration.MASK_TAGSPD | Configuration.MASK_MEASPD | Configuration.MASK_TAGPOS | Configuration.MASK_MEAPOS | Configuration.MASK_TAGCUR | Configuration.MASK_MEACUR;
            pc.WriteOneWord(Configuration.SCP_MASK, OscilloScope.Mask, PCan.currentID);    //应设置触发条件
            setTimeInterval(10);
        }

        void setTimeInterval(short interval)
        {
            Interval = interval;
            pc.WriteOneWord(Configuration.SCP_REC_TIM, interval, PCan.currentID);
        }
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
            //            showItems[i].sq.EnQ(Configuration.m_CmdMap[showItems[i].Item] + (int)(Configuration.m_CmdMap[showItems[i].Item + 1] << 16));
            //        }
                  
            //    }
            //}

        }

        private void pLPaint_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Font font = new Font("微软雅黑", 16F);
            SolidBrush brush = new SolidBrush(Color.Red);
            g.Clear(Color.White);

            Pen pen = new Pen(Color.DarkGray, 1);
            pen.DashStyle = DashStyle.Dash;
            for (int i = 1; i < 12;i++)
            {
                g.DrawLines(pen, new Point[] { new Point(0, i * 30), new Point(740, i * 30) });
            }
            pen.DashStyle = DashStyle.Custom;
            pen.Width = 1.8f;
            g.DrawLines(pen, new Point[] { new Point(0, 6 * 30), new Point(740, 6 * 30) });

            if (cBPointer.Checked)
            {
                pen.Color = Color.Cyan;
                g.DrawLines(pen, new Point[] { new Point(tracePos1, 0), new Point(tracePos1, 360) });
                pen.Color = Color.DarkCyan;
                g.DrawLines(pen, new Point[] { new Point(tracePos2, 0), new Point(tracePos2, 360) });
            }
          

            for (int i = 0; i < showItems.Count;i++ )
            {
                if (showItems[i].sq != null && showItems[i].IsCheck)
                {
                    int[] pointY = new int[showItems[i].sq.Count()];
                    showItems[i].sq.Print(ref pointY);
                    //MovingAverage(ref pointY, 0);
                    //int maxY = GetMax(pointY);
                    int m = pointY.Length;
                    if (m > 1)
                    {
                        float[] pointA = new float[m];
                        PointF[] points = new PointF[m];
                        if (showItems[i].Item == Configuration.SYS_CURRENT_L || showItems[i].Item == Configuration.TAG_CURRENT_L)
                        {
                            double cr = Convert.ToDouble(cBCurrentRatio.Text.Substring(0, cBCurrentRatio.Text.Length - 2));
                            for (int j = 0; j < m; j++)
                            {
                                pointA[j] = j;
                                points[j] = new PointF(1.0f * pointA[j], (float)(pLPaint.Height / 2 - pointY[j] * currentRatio / cr * 30));
                            }
                        }
                        else if (showItems[i].Item == Configuration.TAG_SPEED_L || showItems[i].Item == Configuration.SYS_SPEED_L)
                        {
                            double sr = Convert.ToDouble(cBSpeedRatio.Text.Substring(0, cBSpeedRatio.Text.Length - 3));
                            for (int j = 0; j < m; j++)
                            {
                                pointA[j] = j;
                                float pointYY = (float)(pLPaint.Height / 2 - pointY[j] * speedRatio / sr * 30);
                                points[j] = new PointF(1.0f * pointA[j], pointYY);
                            }
                        }
                        else if (showItems[i].Item == Configuration.TAG_POSITION_L || showItems[i].Item == Configuration.SYS_POSITION_L)
                        {
                            double pr = Convert.ToDouble(cBPositionRatio.Text.Substring(0, cBPositionRatio.Text.Length - 1));
                            for (int j = 0; j < m; j++)
                            {
                                pointA[j] = j;
                                points[j] = new PointF(1.0f * pointA[j], (float)(pLPaint.Height / 2 - pointY[j] * positionRatio / pr * 30));
                            }
                        }
                      
                        pen.Color = showItems[i].Cl;
                        g.DrawLines(pen, points);
                    }
                }
            }
        }

        void MovingAverage(ref int[] array, int n)
        {
            try
            {
                for (int i = n / 2; i < array.Length - n / 2; i++)
                {
                    int sum = 0;
                    for (int j = 0; j < n; j++)
                    {
                        sum += array[i - n / 2 + j];
                    }
                    array[i] = sum / n;
                }
            }
            catch (System.Exception ex)
            {
            	
            }
           
        }


        private static int GetMax(int[] array)
        {
            int max = 0;
            for (int i = 0; i < array.Length; i++)
            {
                max = max > Math.Abs(array[i]) ? max : Math.Abs(array[i]);

            }
            return max;
        }

        private void timerPaint_Tick(object sender, EventArgs e)
        {
            pLPaint.Refresh();
        }

        //指针响应处理函数
        private void tBtrace_Scroll(object sender, EventArgs e)
        {
            if (rBPointer1.Checked)
            {
                tracePos1 = (ushort)tBtrace.Value;
                if (tracePos1 >= tracePos2)
                {
                    tracePos1 = tracePos2;
                }
            }
            if (rBPointer2.Checked)
            {
                tracePos2 = (ushort)tBtrace.Value - 1;
                if (tracePos1 >= tracePos2)
                {
                    tracePos2 = tracePos1;
                }
            }
          
        }

        private void tCMonitor_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tCMonitor.SelectedIndex)
            {
                case 3: loadLVFormat(); break;
                case 1: loadPID();break;
            }
        }

        void loadPID()
        {
            tBCurrentP.Text = Configuration.m_CmdMap[CURRENT_P].ToString();
            tBCurrentI.Text = Configuration.m_CmdMap[CURRENT_I].ToString();
            tBSpeedP.Text = Configuration.m_CmdMap[SPEED_P].ToString();
            tBSpeedI.Text = Configuration.m_CmdMap[SPEED_I].ToString();
            tBSpeedD.Text = Configuration.m_CmdMap[SPEED_D].ToString();
            tBSpeedDeadZone.Text = Configuration.m_CmdMap[SPEED_DS].ToString();
            tBPosP.Text = Configuration.m_CmdMap[POSITION_P].ToString();
            tBPosI.Text = Configuration.m_CmdMap[POSITION_I].ToString();
            tBPosD.Text = Configuration.m_CmdMap[POSITION_D].ToString();
            tBPosDeadZone.Text = Configuration.m_CmdMap[POSITION_DS].ToString();
            tBMaxCurrent.Text = Configuration.m_CmdMap[Configuration.LIT_MAX_CURRENT].ToString();
            tBMaxSpeed.Text = Configuration.m_CmdMap[Configuration.LIT_MAX_SPEED].ToString();
            tBMaxAcc.Text = Configuration.m_CmdMap[Configuration.LIT_MAX_ACC].ToString();

            cBAdjustGroup.Text = Configuration.m_CmdMap[Configuration.SEV_PARAME_LOCKED].ToString();
        }

        void loadLVFormat()
        {
            lVFormat.Items.Clear();
            lVFormat.Visible = true;
            for (int i = 0; i < showItems.Count;i++ )
            {
                lVFormat.Items.Add((i+1).ToString());
                lVFormat.Items[i].SubItems.AddRange(new string[] { itemRelection[showItems[i].Item], showItems[i].Monitor, "", "—" });
                lVFormat.Items[i].UseItemStyleForSubItems = false;
                lVFormat.Items[i].SubItems[3].BackColor = showItems[i].Cl;
                //lVFormat.Items[i].Focused = true;
                lVFormat.Items[i].Checked = showItems[i].IsCheck;
            }

        }

        private void lVFormat_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.X > 425 && e.X < 570)
            {
                int index = lVFormat.FocusedItem.Index;
                if (cDcolor.ShowDialog() == DialogResult.OK)
                {
                    showItems[index].Cl = cDcolor.Color;
                    loadLVFormat();
                }
            }
            else if (e.X > 570 && e.X < 800)
            {
                Rectangle tt = lVFormat.SelectedItems[0].SubItems[4].Bounds;
                cb = new ComboBox();
                cb.Font = new Font("宋体", 13, FontStyle.Bold);
                //cb.TextAlign = HorizontalAlignment.Center;
                cb.Size = new Size(tt.Width, 18);
                cb.Location = tt.Location;
                cb.BackColor = Color.White;
                cb.Text = lVFormat.SelectedItems[0].SubItems[4].Text;
                cb.Focus();
                lVFormat.Controls.Add(cb);
            }
            
        }

        private void lVFormat_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (lVFormat.FocusedItem != null)
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
                }
            }
        }

        private void cBAdjustGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tpye = cBAdjustGroup.Text;
            switch (tpye)
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
            if (tpye == "0")
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
            }
            else
            {
                tBtrace.Enabled = false;
            }
        }

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
        
    }

    public class ShowItem
    {
        public Color Cl;
        public DashStyle Ds;
        public bool IsCheck;
        public string Monitor;
        public byte Item;
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

        public void EnQ(int data)   //   追加   
        {
            lock (ob)
            {
                Node q = new Node(data);
                if (rear == null)               //第一个元素入列时
                {
                    front = rear = q;
                }
                else
                {
                    if (Count() == QCount)
                    {
                        DeQ();
                    }
                    //把新元素挂到链尾
                    rear.Next = q;
                    //修正rear指向为最后一个元素
                    rear = q;
                }
                //元素总数+1
                num++;
            }
        }

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

        public void Print(ref int[] eachValue)
        {
            lock(ob)
            {
                //int[] eachValue = new int[Count()];
                Node current = front;
                int j = 0;
                while (current != null)
                {
                    eachValue[j] = current.Value;
                    current = current.Next;
                    j++;
                }
                return ;
            }
        
        }
    }
}

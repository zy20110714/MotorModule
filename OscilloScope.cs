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
        Dictionary<byte, string> itemRelection = new Dictionary<byte, string>();
        ComboBox cb;
        Thread thread;
        PCan pc;
        bool running = true;
        int spanTime = 20;
        double speedRatio = 60.0 / 65536;
        double positionRatio = 360.0 / 65535;
        double currentRatio = 1.0;

      
        int tracePos = 0;
        public static bool EnableScope = false;

        public OscilloScope()
        {
            InitializeComponent();
            InitialControls();
            pc = new PCan();
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
            tracePos = pLPaint.Width / 2;
            itemRelection.Clear();
            itemRelection.Add(Configuration.TAG_CURRENT_L, "指令电流");
            itemRelection.Add(Configuration.TAG_SPEED_L, "指令速度");
            itemRelection.Add(Configuration.TAG_POSITION_L, "指令位置");
            itemRelection.Add(Configuration.SYS_CURRENT_L, "实际电流");
            itemRelection.Add(Configuration.SYS_SPEED_L, "实际速度");
            itemRelection.Add(Configuration.SYS_POSITION_L, "实际位置");
            showItems.Clear();
            showItems.Add(new ShowItem(true, Configuration.TAG_SPEED_L, "观测", Color.Green, DashStyle.Solid, pLPaint.Width));
            showItems.Add(new ShowItem(true, Configuration.SYS_SPEED_L, "观测", Color.HotPink, DashStyle.Solid, pLPaint.Width));
            showItems.Add(new ShowItem(true, Configuration.TAG_POSITION_L, "观测", Color.Blue, DashStyle.Solid, pLPaint.Width));
            showItems.Add(new ShowItem(true, Configuration.SYS_POSITION_L, "观测", Color.Red, DashStyle.Solid, pLPaint.Width));
            showItems.Add(new ShowItem(true, Configuration.TAG_CURRENT_L, "观测", Color.Yellow, DashStyle.Solid, pLPaint.Width));
            showItems.Add(new ShowItem(true, Configuration.SYS_CURRENT_L, "观测", Color.Cyan, DashStyle.Solid, pLPaint.Width));
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
            pen.DashStyle = DashStyle.Solid;
            pen.Width = 1.8f;
            g.DrawLines(pen, new Point[] { new Point(0, 6 * 30), new Point(740, 6 * 30) });

            g.DrawLines(pen, new Point[] { new Point(tracePos, 0), new Point(tracePos, 360) });

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
            //Graphics g = e.Graphics;
            //pLPaint_Paint(sender, new PaintEventArgs());

        }

        private void tBtrace_Scroll(object sender, EventArgs e)
        {
            tracePos = (ushort)tBtrace.Value;
        }

        private void tCMonitor_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tCMonitor.SelectedIndex)
            {
                case 3: loadLVFormat(); break;
            }
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
                int index = lVFormat.FocusedItem.Index;
                showItems[index].IsCheck = lVFormat.FocusedItem.Checked;
                if (showItems[index].IsCheck && showItems[index].sq == null)
                {
                    showItems[index].sq = new ShowQueue(pLPaint.Width);
                }
                else
                {
                    showItems[index].sq = null;
                }
                
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
        public ShowItem(bool isCheck, byte item, string monitor, Color cl, DashStyle ds, int queueSize)
        {
            IsCheck = isCheck;
            Item = item;
            Monitor = monitor;
            Cl = cl;
            Ds = ds;
            sq = new ShowQueue(queueSize);
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

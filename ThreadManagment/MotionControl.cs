using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

using Peak.Can.Basic;
using TPCANHandle = System.UInt16;
using TPCANBitrateFD = System.String;
using TPCANTimestampFD = System.UInt64;

namespace ICDIBasic
{
    public class MotionControl
    {
        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);//得到高精度计时器的值（如果存在这样的定时器），二次调用的差去除以频率就得到精确的计时
        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(out long lpFrequency);//返回硬件支持的高精度定时器的频率（次每秒），返回0表示失败

        public const byte WAVE_MODE_DC = 0;
        public const byte WAVE_MODE_SQUARE = 1;
        public const byte WAVE_MODE_TRIANGLE = 2;
        public const byte WAVE_MODE_SINE = 3;
        public const byte WAVE_MODE_USER = 4;

        public const byte WAVE_CONNECT_NON = 0;
        public const byte WAVE_CONNECT_PWM = 1;
        public const byte WAVE_CONNECT_CUR = 2;
        public const byte WAVE_CONNECT_SPD = 3;
        public const byte WAVE_CONNECT_POS = 4;

        PCan pc;
       
        static bool s_bHigh = false;
        static int s_iCount = 0;
        static int s_iCountforwave = 0;
        public static int tCount = 0;

        //示波器显示曲线用的计数量
        private static int gatherCount = 0;

        //public delegate void timerEvent();
        //public event timerEvent tickEvent;

        //private object threadLock = new object();// for thread safe
        private long clockFrequency;// result of QueryPerformanceFrequency() 
        bool running = true;//高精度定时器进程处于执行状态的标志
        Thread thread;

        private float intervalMs;//interval in mimliseccond;
        private long intevalTicks;
        private long nextTriggerTime;//任务被执行的下一个节拍数

        //卡尔曼滤波中使用
        public static double kfQ = 30.0;//measure noise
        public static double kfR = 0.2;//system noise
        private double[] kfP = new double[] { 1.0, 1.0, 1.0, 1.0, 1.0, 1.0 };
        private double[] kfN = new double[] { 1.0, 1.0, 1.0, 1.0, 1.0, 1.0 };
        private double[] kfK = new double[] { 1.0, 1.0, 1.0, 1.0, 1.0, 1.0 };

        public delegate void MessageEventHandler(object sender, MessageEventArgs e);
        //定义事件
        public event MessageEventHandler MessageSend;

        public void OnMessageSend(object sender, MessageEventArgs e)
        {
            if (MessageSend != null)
                this.MessageSend(sender, e);
        }


        //高精度定时器控制的方法执行的时间间隔
        public float Interval
        {
            get { return intervalMs; }
            set
            {
                intervalMs = value;
                intevalTicks = (long)((double)value * (double)clockFrequency / (double)1000);//毫秒值除以1000等于秒，再乘以频率得到“次数”
            }
        }

        public MotionControl()
        {
            pc = new PCan();
            //tickEvent = new timerEvent(tick);

            //若不存在这样的定时器
            if (QueryPerformanceFrequency(out clockFrequency) == false)
            {
                throw new Win32Exception("QueryPerformanceFrequency() function is not supported");
            }

            //高精度定时器控制的方法执行的时间间隔（单位：ms）
            Interval = 1.0f;

            //开启一个新进程，用来做高精度定时器
            thread = new Thread(new ThreadStart(ThreadProc));
            thread.Name = "HighAccuracyTimer";
            thread.Priority = ThreadPriority.Highest;
            thread.Start();
        }

        //高精度定时器进程的方法
        private void ThreadProc()
        {
            long currTime;
            GetTick(out currTime);
            nextTriggerTime = currTime + intevalTicks;
            while (running)
            {
                while (currTime < nextTriggerTime)//等待间隔结束，间隔是用的定时器计数值确定的
                {
                    GetTick(out currTime);
                }
                nextTriggerTime = currTime + intevalTicks;
                tick();
            }
        }

        //高精度定时器控制的周期执行的方法
        void tick()
        {
            //AllocConsole();
            //System.Console.WriteLine(DateTime.Now.Millisecond.ToString()); 
            if (TestRun.EnableRun && TestRun.ChangeOK)
            {
                double tempf = 0;
                double time = 0;
                double T = 0;

                s_iCount ++;
                
                //根据所选波形进入相应控制步骤
                switch (TestRun.m_iWaveMode)
                {
                    case WAVE_MODE_DC:
                        if (s_iCount >= 100)//衡值100个Interval发送一次
                        {
                            s_iCount = 0;
                            SetValue((int)TestRun.m_fBias);
                        }
                        break;
                    case WAVE_MODE_SQUARE:
                        if (s_iCount >= 500.0 / TestRun.m_fFrequency)//方波时根据选定频率发送，经过半个周期变换一次方向，所以是乘500
                        {
                            s_iCount = 0;
                            s_bHigh = !s_bHigh;
                            SetValue((int)(TestRun.m_fAmplitude * (s_bHigh ? 1 : -1) + TestRun.m_fBias));
                        }
                        break;
                    case WAVE_MODE_TRIANGLE://三角波时 TriangleInterval 个 Interval 发送一次
                        const byte TriangleInterval = 10;
                        if (s_iCount >= TriangleInterval)
                        {
                            s_iCount = 0;

                            ////得到三角波的1/4周期
                            //T = 1000.0f / TestRun.m_fFrequency / 4.0f;
                            ////校准指令发送的间隔时间
                            //s_iCountforwave++;
                            ////获得发送指令时真正的时间
                            //time = s_iCountforwave * TriangleInterval;
                            ////若时间在三角波的1/4周期内
                            //if (time <= T)
                            //{
                            //    tempf = time * TestRun.m_fAmplitude / T;
                            //}
                            //else if (time > T && time <= T * 2)
                            //{
                            //    time -= T;
                            //    time = T - time;
                            //    tempf = time * TestRun.m_fAmplitude / T;
                            //}
                            //else if (time > T * 2 && time <= T * 3)
                            //{
                            //    time -= T * 2;
                            //    tempf = -time * TestRun.m_fAmplitude / T;
                            //}
                            //else if (time > T * 3 && time < T * 4)
                            //{
                            //    time -= T * 3;
                            //    time = T - time;
                            //    tempf = -time * TestRun.m_fAmplitude / T;
                            //}
                            //else
                            //{
                            //    tempf = 0;
                            //    s_iCountforwave = 0;
                            //}

                            //得到三角波的周期
                            T = 1000.0f / TestRun.m_fFrequency;
                            //校准指令发送的间隔时间
                            s_iCountforwave++;
                            //获得发送指令时真正的时间
                            time = s_iCountforwave * TriangleInterval;
                            //由当前时间得到当前控制值
                            tempf = time * TestRun.m_fAmplitude / T;
                            //若当前时间超过一个周期，校准时间使得时间回到周期开始
                            if (time >= T)
                            {
                                tempf = 0;
                                s_iCountforwave = 0;
                            }

                            //发送控制值
                            SetValue((short)(tempf + TestRun.m_fBias));
                        }
                        break;
                    case WAVE_MODE_SINE://正弦波时SineInterval 个Interval 发送一次
                        const byte SineInterval = 10;
                        if (s_iCount >= SineInterval)
                        {
                            s_iCount = 0;
                            //得到正弦波的周期
                            T = 1000.0f / TestRun.m_fFrequency;
                            //校准指令发送的间隔时间
                            s_iCountforwave++;
                            //获得发送指令时真正的时间
                            time = s_iCountforwave * SineInterval;
                            //由当前时间得到当前控制值
                            tempf = Math.Sin(time / T * 2 * Math.PI) * TestRun.m_fAmplitude;
                            //若当前时间超过一个周期，校准时间使得时间回到周期开始
                            if (time >= T)
                            {
                                tempf = 0;
                                s_iCountforwave = 0;
                            }
                            //发送控制值
                            SetValue((short)(tempf + TestRun.m_fBias));
                        }
                        break;
                }
            }
            
            //示波器绘制曲线使能开启
            if (OscilloScope.EnableScope)
            {
                //间隔计数会从1开始判断
                gatherCount++;
                //按照Interval限定的间隔去执行
                if (gatherCount >= OscilloScope.Interval)
                {
                    //间隔计数清零
                    gatherCount = 0;
                    //向控制台写入当前时间
                    Console.WriteLine(DateTime.Now.Millisecond.ToString());
                    //分别处理每个显示项
                    for (int i = 0; i < OscilloScope.showItems.Count; i++)
                    {
                        //显示项的显示队列不为空才向队列追加一个新值，该32位有符号值由2个16位有符号数组合而成
                        if (OscilloScope.showItems[i].sq != null)
                        {
                            // pc.ReadWords(OscilloScope.showItems[i].Item, 2, PCan.currentID);

                            //16位有符号转8位无符号，Item分别会是：SCP_TAGCUR_L, SCP_TAGSPD_L, SCP_TAGPOS_L, SCP_MEACUR_L, SCP_MEASPD_L, SCP_MEAPOS_L
                            byte[] value1 = BitConverter.GetBytes(Configuration.MemoryControlTable[OscilloScope.showItems[i].Item]);
                            byte[] value2 = BitConverter.GetBytes(Configuration.MemoryControlTable[OscilloScope.showItems[i].Item + 1]);

                            int value = 0;
                            int oldValue = 0;

                            ////位置的数据，没有高16位，这样会产生bug
                            //if (OscilloScope.showItems[i].Item == Configuration.SCP_TAGPOS_L || OscilloScope.showItems[i].Item == Configuration.SCP_MEAPOS_L)
                            //{
                            //    value = BitConverter.ToInt32(new byte[] { value1[0], value1[1], 0x00, 0x00 }, 0);
                            //}
                            //else
                            //{
                            //    value = BitConverter.ToInt32(new byte[] { value1[0], value1[1], value2[0], value2[1] }, 0);
                            //}

                            //统一的方法组成32位数
                            value = BitConverter.ToInt32(new byte[] { value1[0], value1[1], value2[0], value2[1] }, 0);

                            //该32位数再进行卡尔曼滤波后追加到队列尾部
                            kfN[i] = kfP[i] + kfQ;//kfQ measure noise 可选变
                            kfK[i] = kfN[i] / (kfN[i] + kfR);//kfR system noise 可选变
                            kfP[i] = (1 - kfK[i]) * kfN[i];
                            try
                            {
                                oldValue = OscilloScope.showItems[i].sq.rear.Value;
                            }
                            catch
                            {

                            }
                            value = Convert.ToInt32(oldValue + kfK[i] * (value - oldValue));
                            //向队尾追加值
                            OscilloScope.showItems[i].sq.EnQ(value);
                        }
                    }
                }                
            }

            if (OscilloScope.EnableFrictionMeasure)
            {
                float err = 0;
                int speed = getSpeed(tCount,ref err);
                if (Math.Abs(OscilloScope.measureSpeed - speed) < err)
                {
                  
                    FileStream fs1 = new FileStream("D:\\cc.txt", FileMode.Append, FileAccess.Write, FileShare.None);
                    StreamWriter sw1 = new StreamWriter(fs1, Encoding.Default);
                    sw1.WriteLine(speed.ToString() + " " + OscilloScope.measureCurrent.ToString());
                    sw1.Flush();
                    sw1.Close();
                    fs1.Close();
                    this.OnMessageSend(this, new MessageEventArgs("MotionControl", "Measure " + speed + " done!"));
                 
                    tCount++;
                    speed = getSpeed(tCount, ref err);
                    int value = Convert.ToInt32(speed / 60.0 * 65536.0);
                    pc.WriteTwoWords(Configuration.TAG_SPEED_L, value, PCan.currentID);

                    if (tCount == 94)
                    {
                        OscilloScope.EnableFrictionMeasure = false;
                        MessageBox.Show("Measure process finished!");
                    }
                }
                //if (tCount >= 100 && tCount <= 2300)
                //{
                //    //电流
                //    byte[] value1 = BitConverter.GetBytes(Configuration.MemoryControlTable[Configuration.SCP_MEACUR_L]);
                //    byte[] value2 = BitConverter.GetBytes(Configuration.MemoryControlTable[Configuration.SCP_MEACUR_H]);
                //    float current = BitConverter.ToInt32(new byte[] { value1[0], value1[1], value2[0], value2[1] }, 0);
                //    OscilloScope.currentC.Add(0.118f * current / 1000.0f);

                //    //速度
                //    value1 = BitConverter.GetBytes(Configuration.MemoryControlTable[Configuration.SCP_MEASPD_L]);
                //    value2 = BitConverter.GetBytes(Configuration.MemoryControlTable[Configuration.SCP_MEASPD_H]);
                //    float speed = (float)(BitConverter.ToInt32(new byte[] { value1[0], value1[1], value2[0], value2[1] }, 0) * 2.0 * Math.PI / 65536.0); // rad/s
                //    OscilloScope.currentS.Add(speed);

                //    OscilloScope.currentT.Add(DateTime.Now.Millisecond);
                //}
                
                //if (tCount == 2300)
                //{
                //    tCount = 0;
                //    for (int i = 0; i < OscilloScope.currentS.Count; i++)
                //    {
                //        sw1.WriteLine(Math.Sign(OscilloScope.currentS[i]).ToString() + " " + OscilloScope.currentS[i].ToString() + " " 
                //                      + OscilloScope.currentC[i].ToString() + " " + OscilloScope.currentT[i].ToString());
                //    }
                //    OscilloScope.EnableFrictionMeasure = false;
                //}
              
            }

            if (OscilloScope.EnableCurrentCompensation)
            {
                if(OscilloScope.measureSpeed < 0.5)
                {
                    pc.WriteTwoWords(Configuration.TAG_CURRENT_L, 192, PCan.currentID);
                }
                else if(OscilloScope.measureSpeed < 95)
                {
                    int value = Convert.ToInt32(156.0648 - (OscilloScope.measureSpeed - 1) / 94.0 * (156.0648 - 146.6248));
                    pc.WriteTwoWords(Configuration.TAG_CURRENT_L, value, PCan.currentID);
                }
                else
                {
                    int value = Convert.ToInt32(-0.000036681545 * OscilloScope.measureSpeed * OscilloScope.measureSpeed + 0.22859848 * OscilloScope.measureSpeed + 126.16865);
                }
            }
        }

        //根据运动模式（占空比、电流、速度、位置）发控制量
        void SetValue(int value)
        {
            switch (TestRun.m_iWaveChannel)
            {
                case WAVE_CONNECT_NON:
                    break;
                case WAVE_CONNECT_PWM:
                    pc.WriteOneWord(Configuration.TAG_OPEN_PWM, (short)value, PCan.currentID);
                    break;
                case WAVE_CONNECT_CUR:
                    pc.WriteTwoWords(Configuration.TAG_CURRENT_L, value, PCan.currentID);
                    break;
                case WAVE_CONNECT_SPD:
                    value = Convert.ToInt32(value * 65536.0 / 60.0);
                    pc.WriteTwoWords(Configuration.TAG_SPEED_L, value, PCan.currentID);
                    break;
                case WAVE_CONNECT_POS:
                    value = Convert.ToInt32(value * 65536.0 / 360.0);
                    pc.WriteTwoWords(Configuration.TAG_POSITION_L, value, PCan.currentID);
                    break;
                default:
                    break;
            }
        }

        int getSpeed(int i, ref float err)
        {
            if (i <= 30)
            {
                err = 3;            //1500 - 600
                return (30 - i) * 30 + 600;
            }
            else if (i <= 45)
            {
                err = 2;
                return (45 - i) * 20 + 300;
            }                         //600 - 300
            else if (i <= 64)
            {
                err = 1;                //300 - 110
                return (64 - i) * 10 + 110;
            }                        
            else if (i <= 84)
            {
                err = 0.5f;              //110 - 10   
                return (84 - i) * 5 + 10;                          
            }
            else if (i <= 93)
            {
                err = 0.1f;
                return (94 - i);                            //10 - 1
            }

            return 0;
        }

        //返回“获取当前时钟计数值”成功与否的信息
        public bool GetTick(out long currentTickCount)
        {
            if (QueryPerformanceCounter(out currentTickCount) == false)
            {
                throw new Win32Exception("QueryPerformanceCounter() failed!");
            }
            else
            {
                return true;
            } 
        }
        
        //高精度定时器进程开始运行
        public void Start()
        {
            thread.Start();
        }

        //高精度定时器进程中结束循环
        public void Stop()
        {
            running = false;
        }

        ~MotionControl()
        {
            running = false;
            thread.Abort();
            //thread.Join();
            thread = null;
        }
    }
}

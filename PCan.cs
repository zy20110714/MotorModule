using System;
using System.Collections.Generic;
using System.Text;
using Peak.Can.Basic;
using System.Threading;

namespace ICDIBasic
{
    public  class PCan
    {
        public const byte MAX_FRAME_NUM = 255;
        public static TPCANMsg[] m_CANFrames_HP = new TPCANMsg[MAX_FRAME_NUM];           //high priority 具有高优先级发送的数据
        public static  byte m_CANFrames_Tail_HP;					//数据发送队列尾指针
        public static  byte m_CANFrames_Head_HP;					//数据发送队列头指针

        public static  TPCANMsg[] m_CANFrames = new TPCANMsg[MAX_FRAME_NUM];           //优先级较低的数据
        public static  byte m_CANFrames_Tail;					                        //数据发送队列尾指针
        public static  byte m_CANFrames_Head;					                        //数据发送队列头指针

        public static  int m_iFramesCount = 0;
        public static bool m_Terminated = false;                 //通讯结束标志    
        public static bool m_FlagListen;			       //是否监听标志

        private Object PushFrameLock = new Object();                         //互斥锁
        private Object PushFrameLockHP = new Object();                         //互斥锁

       
        public static byte currentID = 0;                                                         //当前选中的模块ID号

        public void SearchModuleID()
        {
            for (byte i = 1; i < byte.MaxValue; i++)          //ID number from 1 to 254
            {
                ReadWords(Configuration.SYS_ID, 1, i);
                //Thread.Sleep(1);
            }
            return;
        }

        //public void CheckConnection()
        //{
        //    for (byte i = 1; i < byte.MaxValue; i++)          //ID number from 1 to 254
        //    {
        //        ReadWords(Configuration.SYS_ID, 1, i);
        //        //Thread.Sleep(1);
        //    }
        //    return;
        //}


        public void PushFrame(byte Datelen, uint ID, byte Cmd, byte Index, byte[] pdata)
        {
            //if (!IsCanInite()||Datelen>6) return;//	if (Datelen > 6) return;
            lock (PushFrameLock)
            {
                m_CANFrames[m_CANFrames_Head].DATA = new byte[8];

                m_CANFrames[m_CANFrames_Head].ID = ID;				//标准格式
                m_CANFrames[m_CANFrames_Head].LEN = (byte)(Datelen + 2);
                m_CANFrames[m_CANFrames_Head].MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;//CAN_STANDARD_FORMAT;
                m_CANFrames[m_CANFrames_Head].DATA[0] = Cmd;
                m_CANFrames[m_CANFrames_Head].DATA[1] = Index;

                Buffer.BlockCopy(pdata, 0, m_CANFrames[m_CANFrames_Head].DATA, 2, pdata.Length);

                m_CANFrames_Head++;
                if (m_CANFrames_Head == MAX_FRAME_NUM)
                    m_CANFrames_Head = 0;
            }
        }

        public void ReadOneWord(byte Index, int ID = -1)
        {
            byte[] data = { 2 };
            if (ID == -1)
                PushFrame((byte)1, currentID, Configuration.CMDTYPE_RD, Index, data);
            else
                PushFrame((byte)1, (uint)ID, Configuration.CMDTYPE_RD, Index, data);
        }

        public void WriteOneWord(byte Index, short value, int ID)
        {
            if (ID == -1)
                PushFrame(2, currentID, Configuration.CMDTYPE_WR, Index, BitConverter.GetBytes(value));
            else
                PushFrame(2, (uint)ID, Configuration.CMDTYPE_WR, Index, BitConverter.GetBytes(value));
            Configuration.m_CmdMap[Index] = value;
        }

        public void ReadWords(byte Index, int Wordsnum, int ID = -1)
        {
            byte[] value = { (byte)(Wordsnum * 2) };
            if (ID == -1)
                PushFrame(1, currentID, Configuration.CMDTYPE_RD, Index, value);
            else
                PushFrame(1, (uint)ID, Configuration.CMDTYPE_RD, Index, value);
        }

        public void WriteTwoWords(byte Index, int value, int ID)
        {


            if (ID == -1)
                PushFrame((byte)4, currentID, Configuration.CMDTYPE_WR, Index, BitConverter.GetBytes(value));
            else
                PushFrame((byte)4, (uint)ID, Configuration.CMDTYPE_WR, Index, BitConverter.GetBytes(value));

            Configuration.m_CmdMap[Index] = (short)value;
            Configuration.m_CmdMap[Index + 1] = (short)(value >> 16);
        }




        public void PushFrameHP(byte Datelen, uint ID, byte Cmd, byte Index, byte[] pdata)
        {
            //if (!IsCanInite()||Datelen>6) return;
            lock (PushFrameLockHP)
            {
                m_CANFrames_HP[m_CANFrames_Head_HP].DATA = new byte[8];
                //memset(&m_CANFrames_HP[m_CANFrames_Head_HP],0,sizeof(CAN_msg));
                //如果全部赋值是否就不需清零
                m_CANFrames_HP[m_CANFrames_Head_HP].ID = ID;				//标准格式
                m_CANFrames_HP[m_CANFrames_Head_HP].LEN = (byte)(Datelen + 2);
                m_CANFrames_HP[m_CANFrames_Head_HP].MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD; //CAN_STANDARD_FORMAT;
                m_CANFrames_HP[m_CANFrames_Head_HP].DATA[0] = Cmd;
                m_CANFrames_HP[m_CANFrames_Head_HP].DATA[1] = Index;

                Buffer.BlockCopy(pdata, 0, m_CANFrames_HP[m_CANFrames_Head_HP].DATA, 2, pdata.Length);

                m_CANFrames_Head_HP++;
                if (m_CANFrames_Head_HP == MAX_FRAME_NUM)
                    m_CANFrames_Head_HP = 0;
            }
        }

        public void WriteTwoWordsHP(byte Index, Int32 value, int ID = -1)
        {
            if (ID == -1)
                PushFrameHP((byte)4, currentID, Configuration.CMDTYPE_WR, Index, BitConverter.GetBytes(value));
            else
                PushFrameHP((byte)4, (uint)ID, Configuration.CMDTYPE_WR, Index, BitConverter.GetBytes(value));

            Configuration.m_CmdMap[Index] = (short)value;
            Configuration.m_CmdMap[Index + 1] = (short)(value >> 16);
        }

        public void WriteOneWordHP(byte Index, short value, int ID = -1)
        {
            if (ID == -1)
                PushFrameHP((byte)2, currentID, Configuration.CMDTYPE_WR, Index, BitConverter.GetBytes(value));
            else
                PushFrameHP((byte)2, (uint)ID, Configuration.CMDTYPE_WR, Index, BitConverter.GetBytes(value));
            Configuration.m_CmdMap[Index] = value;
        }



        public void OpenListen()
        {
            m_FlagListen = true;
        }
        void CloseListen()
        {
            m_FlagListen = false;
        }

        //void InitRXNodifyMessage(HWND hWnd, UINT Msg)
        //{ 
        //    m_message = Msg;
        //    m_hParentWnd = hWnd;
        //}

        public void SetID(byte ID)
        {
            currentID = ID;
        }


        public void add(int a, int b)
        {
            int c = a + b;
        }

    }
}

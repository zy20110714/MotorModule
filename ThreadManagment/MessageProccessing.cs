﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;


using Peak.Can.Basic;
using TPCANHandle = System.UInt16;
using TPCANBitrateFD = System.String;
using TPCANTimestampFD = System.UInt64;

namespace ICDIBasic
{
    public class MessageEventArgs : EventArgs
    {
        public String Who;//传递字符串信息
        public String Action;//传递字符串信息
        public MessageEventArgs(string who)
        {
            this.Who = who;
        }
        public MessageEventArgs(string who, string action)
        {
            this.Who = who;
            this.Action = action;
        }
    }

    public class MessageProccessing
    {
        public const byte CAN_FRAME = 1;

        public const byte CAN_CMD = 0;
        public const byte CAN_INDEX = 1;
        public const byte CAN_DATA = 2;

        public const byte BUF_LEN = 10;

        public const byte CAN_STANDARD_FORMAT = 0;//标准帧
        public const byte CAN_EXTENDED_FORMAT = 1;//扩展帧
        public const byte CAN_DATA_FRAME = 0;//数据帧
        public const byte CAN_REMOTE_FRAME = 1;//远程帧

        public static List<short> allID = new List<short>();
        public static List<short> allID2 = new List<short>();//供检测连接用

        /// <summary>
        /// Thread for message reading (using events)
        /// </summary>
        private System.Threading.Thread m_ProcessThread;
        public static bool IsAlive = false;
        private static string threadType = "";

        public delegate void MessageEventHandler(object sender, MessageEventArgs e);
        //定义事件
        public event MessageEventHandler MessageSend;

        public void OnMessageSend(object sender, MessageEventArgs e)
        {
            if (MessageSend != null)
                this.MessageSend(sender, e);
        }
                                      
        #region Message-proccessing functions

        /// <summary>
        /// Thread-Function used for reading PCAN-Basic messages
        /// </summary>
        private void CANReadThreadFunc()
        {
            UInt32 iBuffer;
            UInt32 dwTemp;
            TPCANStatus stsResult;
            PCan.m_Terminated = false;
            short count = 0;

            iBuffer = Convert.ToUInt32(MainForm.m_ReceiveEvent.SafeWaitHandle.DangerousGetHandle().ToInt32());
            // Sets the handle of the Receive-Event.
            stsResult = PCANBasic.SetValue(MainForm.m_PcanHandle, TPCANParameter.PCAN_RECEIVE_EVENT, ref iBuffer, sizeof(UInt32));

            if (stsResult != TPCANStatus.PCAN_ERROR_OK)
            {
                //MessageBox.Show(GetFormatedError(stsResult), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PCan.m_Terminated = true;
                return;
            }

            // While this mode is selected
            while (!PCan.m_Terminated)
            {
                // Waiting for Receive-Event
                if (!MainForm.m_ReceiveEvent.WaitOne(0))
                    // Process Receive-Event using .NET Invoke function
                    // in order to interact with Winforms UI (calling the 
                    // function ReadMessages)
                    //if (this.IsHandleCreated)
                    //{

                    //}

                    //System.Console.WriteLine(DateTime.Now.Millisecond.ToString()); 
                    ReadMessages();
                    //this.Invoke(m_ReadDelegate);


                if (++count >= 2)
                {
                    //Console.WriteLine("tt");
                    count = 0;
                    if (!PCan.m_FlagListen)
                    {
                        SendFrame();
                    }
                }
            }

            dwTemp = 0;
            stsResult = PCANBasic.SetValue(MainForm.m_PcanHandle, TPCANParameter.PCAN_RECEIVE_EVENT, ref dwTemp, sizeof(UInt32));
        }

        void SendFrame()
        {
            TPCANMsg CANMsg = new TPCANMsg();
            CANMsg.DATA = new byte[8];//赋初值

           // TPCANTimestamp CANTimeStamp;
            TPCANStatus stsResult;
            //send data
            if (PCan.m_CANFrames_Head_HP != PCan.m_CANFrames_Tail_HP)
            {
                CANMsg.ID = PCan.m_CANFrames_HP[PCan.m_CANFrames_Tail_HP].ID;
                CANMsg.LEN = PCan.m_CANFrames_HP[PCan.m_CANFrames_Tail_HP].LEN;
                CANMsg.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;

                Buffer.BlockCopy(PCan.m_CANFrames_HP[PCan.m_CANFrames_Tail_HP].DATA, 0, CANMsg.DATA, 0, 8);
                //出队后释放资源
                PCan.m_CANFrames_HP[PCan.m_CANFrames_Tail_HP].DATA = null;

                //m_traceLog.WriteLog(LOGBOOK_TRACE,(char*)_T( "<<send, pcan.%u len=%d data=0x%02x %02x %02x %02x %02x %02x %02x %02x \n"), 
                //    CANMsg.ID, CANMsg.LEN, CANMsg.DATA[0], CANMsg.DATA[1], CANMsg.DATA[2], CANMsg.DATA[3], CANMsg.DATA[4], CANMsg.DATA[5], CANMsg.DATA[6], CANMsg.DATA[7]);
                stsResult = PCANBasic.Write(MainForm.m_PcanHandle, ref CANMsg);  //(m_IsFD == true) ? PCANBasic.WriteFD(m_PcanHandle, ref CANMsg);
                if (stsResult != TPCANStatus.PCAN_ERROR_OK)
                {
                    //m_traceLog.WriteLog(LOGBOOK_ERROR, (char*)_T("pcan.%u send error! msg:%s\n"), CANMsg.ID, GetFormatedError(stsResult));
                }
                PCan.m_CANFrames_Tail_HP++;
                if (PCan.m_CANFrames_Tail_HP == PCan.MAX_FRAME_NUM) PCan.m_CANFrames_Tail_HP = 0;
            }
            else if (PCan.m_CANFrames_Head != PCan.m_CANFrames_Tail)
            {
                CANMsg.ID = PCan.m_CANFrames[PCan.m_CANFrames_Tail].ID;
                CANMsg.LEN = PCan.m_CANFrames[PCan.m_CANFrames_Tail].LEN;
                CANMsg.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;

                Buffer.BlockCopy(PCan.m_CANFrames[PCan.m_CANFrames_Tail].DATA, 0, CANMsg.DATA, 0, 8);
                //出队后释放资源
                // m_CANFrames[m_CANFrames_Tail_HP].DATA = null;

                //m_traceLog.WriteLog(LOGBOOK_TRACE,(char*)_T( "<<send, pcan.%u len=%d data=0x%02x %02x %02x %02x %02x %02x %02x %02x \n"), 
                //    CANMsg.ID, CANMsg.LEN, CANMsg.DATA[0], CANMsg.DATA[1], CANMsg.DATA[2], CANMsg.DATA[3], CANMsg.DATA[4], CANMsg.DATA[5], CANMsg.DATA[6], CANMsg.DATA[7]);
                stsResult = PCANBasic.Write(MainForm.m_PcanHandle, ref CANMsg);
                if (stsResult != TPCANStatus.PCAN_ERROR_OK)
                {
                    //m_traceLog.WriteLog(LOGBOOK_ERROR, (char*)_T("pcan.%u send error! msg:%s\n"), CANMsg.ID, GetFormatedError(stsResult));
                }
                PCan.m_CANFrames_Tail++;
                if (PCan.m_CANFrames_Tail == PCan.MAX_FRAME_NUM) PCan.m_CANFrames_Tail = 0;
            }
            // 	TRACE( "send tail=%d!!\n ",m_CANFrames_Tail);
            // 	TRACE( "send head=%d!!\n ",m_CANFrames_Head);
            // 	TRACE( "send HPtail=%d!!\n ",m_CANFrames_Tail_HP);
            // 	TRACE( "send HPhead=%d!!\n ",m_CANFrames_Head_HP);

        }


        /// <summary>
        /// Function for reading PCAN-Basic messages
        /// </summary>
        private void ReadMessages()
        {
            TPCANStatus stsResult;

            // We read at least one time the queue looking for messages.
            // If a message is found, we look again trying to find more.
            // If the queue is empty or an error occurr, we get out from
            // the dowhile statement.
            //			
            do
            {
                //stsResult = m_IsFD ? ReadMessageFD() : ReadMessage();
                stsResult = ReadMessage();
                if (stsResult == TPCANStatus.PCAN_ERROR_ILLOPERATION)
                    break;
            } while (PCan.m_Terminated && (!Convert.ToBoolean(stsResult & TPCANStatus.PCAN_ERROR_QRCVEMPTY))); //while (btnRelease.Enabled && (!Convert.ToBoolean(stsResult & TPCANStatus.PCAN_ERROR_QRCVEMPTY))) ;
        }

        /// <summary>
        /// Function for reading CAN messages on normal CAN devices
        /// </summary>
        /// <returns>A TPCANStatus error code</returns>
        private TPCANStatus ReadMessage()
        {
            TPCANMsg CANMsg;
            TPCANTimestamp CANTimeStamp;
            TPCANStatus stsResult;

            // We execute the "Read" function of the PCANBasic                
            //
            stsResult = PCANBasic.Read(MainForm.m_PcanHandle, out CANMsg, out CANTimeStamp);
            if (stsResult != TPCANStatus.PCAN_ERROR_QRCVEMPTY)
                // We process the received message
                ProcessMessage(CANMsg, CANTimeStamp);
          
            return stsResult;
        }

        /// <summary>
        /// Processes a received message, in order to show it in the Message-ListView
        /// </summary>
        /// <param name="theMsg">The received PCAN-Basic message</param>
        /// <returns>True if the message must be created, false if it must be modified</returns>
        private void ProcessMessage(TPCANMsg theMsg, TPCANTimestamp itsTimeStamp)
        {
            CAN_ParseFrame(theMsg);
        }


        void CAN_ParseFrame(TPCANMsg pCanMsg)
        {
            if (pCanMsg.DATA[CAN_CMD] == Configuration.CMDTYPE_RD)
            {
                //此处效率不高，有待改进
                int index = pCanMsg.DATA[CAN_INDEX] - 1;
                for (int i = 0; i < (pCanMsg.LEN - 2) / 2; i++)
                {
                    index++;
                    Int16 value = (Int16)(pCanMsg.DATA[CAN_DATA + i * 2] + (pCanMsg.DATA[CAN_DATA + i * 2 + 1] << 8));
                    if (index == Configuration.SYS_ID)
                    {
                        if (!allID.Contains(value))
                        {
                            allID.Add(value);
                        }
                        allID2.Add(value);
                    }
                    else if (index == Configuration.SCP_MEAPOS_H && MainForm.FirstQRequest)
                    {
                        Configuration.MemoryControlTable[index] = value;
                        MainForm.FirstQRequest = false;
                        //备份内存控制表
                        backUpMemoryControlTable();
                    }
                    else if (index == Configuration.SYS_SAVE_TO_FLASH)
                    {
                        //参数更新完成
                        if (pCanMsg.DATA[2] == 0)
                        {
                            WriteParameters.ProgramFinished = true;
                        }
                        Configuration.MemoryControlTable[index] = value;
                    }
                    else
                    {
                        //ID信号有干扰，应单独分开
                        Configuration.MemoryControlTable[index] = value;
                    }

                   
                }
            }
            else if (pCanMsg.DATA[CAN_CMD] == Configuration.CMDTYPE_SCP)
            {
                int index = pCanMsg.DATA[CAN_INDEX];
                //if (index == Configuration.SCP_MEAPOS_L)
                //{
                //    int aa = 1;
                //}
                Configuration.MemoryControlTable[index] = (Int16)(pCanMsg.DATA[CAN_DATA] + (pCanMsg.DATA[CAN_DATA + 1] << 8));
                Configuration.MemoryControlTable[index + 1] = (Int16)(pCanMsg.DATA[CAN_DATA + 2] + (pCanMsg.DATA[CAN_DATA + 3] << 8));

            }
            else if (pCanMsg.DATA[CAN_CMD] == Configuration.CMDTYPE_WR)
            {

            }
            if (pCanMsg.DATA[CAN_CMD] != 0)
            {
                 MainForm.IDName = (short)(pCanMsg.ID - 256);
                 MainForm.IsDataRecieved = true;
            }
            PCan.m_iFramesCount++;
        }

        /// <summary>
        /// back up  MemoryControlTable
        /// </summary>
        private void backUpMemoryControlTable()
        {
            for (int i = 0; i < Configuration.CMDMAP_LEN;i++ )
            {
                Configuration.MemoryControlTableBak[i] = Configuration.MemoryControlTable[i];
            }
        }

        //开始线程函数
        public void StartSend(string str)
        {
            m_ProcessThread = new System.Threading.Thread(new System.Threading.ThreadStart(CANReadThreadFunc));
            m_ProcessThread.Start();
            IsAlive = true;
            threadType = str;
        }

         //结束线程函数
        public void Abort()
        {
            IsAlive = false;
            m_ProcessThread.Abort();
        }

        public void Join()
        {
            m_ProcessThread.Join();
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ICDIBasic
{
    public class Configuration
    {
        public static int[] paramTypeNumber = { Convert.ToInt32("0f", 16) };            //specifie the length of different type of  parameters

        //指令类型宏定义
        public const byte CMDTYPE_RD = 1;    //读控制表指令
        public const byte CMDTYPE_WR = 2;    //写控制表指令
        public const byte CMDTYPE_WR_NR = 3; //写控制表指令（无返回）
        public const byte CMDTYPE_SCP = 5;   //示波器数据返回指令（保留）
        public const byte CMDTYPE_RD_HP = 8;   //读控制表指令，高优先级

        public const sbyte BROADCAST_ID = (sbyte)(0xff - 256);   //-1

        //模块类型宏定义
        public const byte MODEL_TYPE_M14    = 0x10;
        public const byte MODEL_TYPE_M17    = 0x02;
        public const byte MODEL_TYPE_M17E   = 0x21;
        public const byte MODEL_TYPE_M20    = 0x30;

        //模块减速比宏定义
        public const byte GEAR_RATIO_M14    = 100;
        public const byte GEAR_RATIO_M17    = 100;
        public const byte GEAR_RATIO_M17E   = 120;
        public const byte GEAR_RATIO_M20    = 160;

        //内存控制表宏定义
        public const byte CMDMAP_LEN = 160;
        public static short[] MemoryControlTable = new short[CMDMAP_LEN];     //内存控制表
        public static short[] MemoryControlTableBak = new short[CMDMAP_LEN];     //内存控制表
        public const byte CMDMAP_INDLEN = 10;
        public const byte CMDMAP_SUBLEN = 16;

        //驱动器模式定义
        public const byte MODE_OPEN = 0;
        public const byte MODE_CURRENT = 1;
        public const byte MODE_SPEED = 2;
        public const byte MODE_POSITION = 3;

        //系统状态相关
        public const byte SYS_ID				    = 0x01;	//驱动器ID
        public const byte SYS_MODEL_TYPE			= 0x02;	//驱动器型号
        public const byte SYS_FW_VERSION			= 0x03;	//固件版本
        public const byte SYS_ERROR					= 0x04;	//错误代码
        public const byte SYS_VOLTAGE				= 0x05;	//系统电压
        public const byte SYS_TEMP					= 0x06;	//系统温度
        public const byte SYS_REDU_RATIO			= 0x07;	//模块减速比
        //public const byte SYS_BAUDRATE_232		= 0x08;	//232端口波特率
        public const byte SYS_BAUDRATE_CAN			= 0x09;	//CAN总线波特率
        public const byte SYS_ENABLE_DRIVER			= 0x0a;	//驱动器使能标志
        public const byte SYS_ENABLE_ON_POWER		= 0x0b;	//上电使能驱动器标志
        public const byte SYS_SAVE_TO_FLASH			= 0x0c;	//保存数据到Flash标志
        //public const byte SYS_DEMA_ABSPOS			= 0x0d;	//自动标定绝对位置标志
        public const byte SYS_SET_ZERO_POS			= 0x0e;	//将当前位置设置为零点标志
        public const byte SYS_CLEAR_ERROR			= 0x0f;	//清除错误标志
                                                          
        public const byte SYS_CURRENT_L				= 0x10;	//当前电流低16位（mA）
        public const byte SYS_CURRENT_H				= 0x11;	//当前电流高16位（mA）
        public const byte SYS_SPEED_L				= 0x12;	//当前速度低16位（units/s）
        public const byte SYS_SPEED_H				= 0x13;	//当前速度高16位（units/s）
        public const byte SYS_POSITION_L			= 0x14;	//当前位置低16位（units）
        public const byte SYS_POSITION_H			= 0x15;	//当前位置高16位（units）
        public const byte SYS_POTEN_VALUE			= 0x16;	//数字电位器值
        public const byte SYS_ZERO_POS_OFFSET_L	    = 0x17;	//零点位置偏移量低16位（units）
        public const byte SYS_ZERO_POS_OFFSET_H	    = 0x18;	//零点位置偏移量高16位（units）
                                                          
        //电机相关信息                                    
        public const byte MOT_RES					= 0x20;	//电机内阻
        public const byte MOT_INDUC					= 0x21;	//电机电感
        public const byte MOT_RATED_VOL				= 0x22;	//电机额定电压
        public const byte MOT_RATED_CUR				= 0x23;	//电机额定电流
        //public const byte MOT_ENC_LINES			= 0x24;	//码盘线数
        //public const byte MOT_HALL_VALUE			= 0x25;	//当前霍尔状态
        public const byte MOT_ST_DAT  				= 0x26;	//绝对编码器单圈数据
        public const byte MOT_MT_DAT  				= 0x27;	//绝对编码器多圈数据
                                                          
        //控制目标值                                      
        public const byte TAG_WORK_MODE				= 0x30;	//工作模式，0-开环，1-电流模式，2-速度模式，3-位置模式
        public const byte TAG_OPEN_PWM				= 0x31;	//开环模式下占空比（0~100）
        public const byte TAG_CURRENT_L				= 0x32;	//目标电流低16位（mA）
        public const byte TAG_CURRENT_H				= 0x33;	//目标电流高16位（mA）
        public const byte TAG_SPEED_L				= 0x34;	//目标速度低16位（units/s）
        public const byte TAG_SPEED_H				= 0x35;	//目标速度高16位（units/s）
        public const byte TAG_POSITION_L			= 0x36;	//目标位置低16位（units）
        public const byte TAG_POSITION_H			= 0x37;	//目标位置高16位（units）
                                                          
        //控制限制值                                      
        public const byte LIT_MAX_CURRENT			= 0x40;	//最大电流（mA）
        public const byte LIT_MAX_SPEED				= 0x41;	//最大速度（rpm）
        public const byte LIT_MAX_ACC				= 0x42;	//最大加速度（rpm/s）
        public const byte LIT_MIN_POSITION_L		= 0x43;	//最小位置低16位（units）
        public const byte LIT_MIN_POSITION_H		= 0x44;	//最小位置高16位（units）
        public const byte LIT_MAX_POSITION_L		= 0x45;	//最大位置低16位（units）
        public const byte LIT_MAX_POSITION_H		= 0x46;	//最大位置高16位（units）
                                                          
        //三闭环环相关                                    ;
        public const byte SEV_PARAME_LOCKED			= 0x50;	//三闭环参数锁定标志, 0-不锁定(自动切换), 1-低速（S）,2-中速（M）,3-高速（L）
                                                          
        public const byte S_CURRENT_P				= 0x51;	  //电流环P参数
        public const byte S_CURRENT_I				= 0x52;	  //电流环I参数
        public const byte S_CURRENT_D				= 0x53;	  //电流环D参数
        public const byte S_SPEED_P					= 0x54;	  //速度环P参数
        public const byte S_SPEED_I					= 0x55;	  //速度环I参数
        public const byte S_SPEED_D					= 0x56;	  //速度环D参数
        public const byte S_SPEED_DS				= 0x57;	  //速度P死区
        public const byte S_POSITION_P				= 0x58;	  //位置环P参数
        public const byte S_POSITION_I				= 0x59;	  //位置环I参数
        public const byte S_POSITION_D				= 0x5A;	  //位置环D参数
        public const byte S_POSITION_DS				= 0x5B;	  //位置P死区
                                                          
        public const byte M_CURRENT_P				= 0x61;	  //电流环P参数
        public const byte M_CURRENT_I				= 0x62;	  //电流环I参数
        public const byte M_CURRENT_D				= 0x63;	  //电流环D参数
        public const byte M_SPEED_P					= 0x64;	  //速度环P参数
        public const byte M_SPEED_I					= 0x65;	  //速度环I参数
        public const byte M_SPEED_D					= 0x66;	  //速度环D参数
        public const byte M_SPEED_DS				= 0x67;	  //速度P死区
        public const byte M_POSITION_P				= 0x68;	  //位置环P参数
        public const byte M_POSITION_I				= 0x69;	  //位置环I参数
        public const byte M_POSITION_D				= 0x6A;	  //位置环D参数
        public const byte M_POSITION_DS				= 0x6B;	  //位置P死区
                                                          
        public const byte L_CURRENT_P				= 0x71;	  //电流环P参数
        public const byte L_CURRENT_I				= 0x72;	  //电流环I参数
        public const byte L_CURRENT_D				= 0x73;	  //电流环D参数
        public const byte L_SPEED_P					= 0x74;	  //速度环P参数
        public const byte L_SPEED_I					= 0x75;	  //速度环I参数
        public const byte L_SPEED_D					= 0x76;	  //速度环D参数
        public const byte L_SPEED_DS				= 0x77;	  //速度P死区
        public const byte L_POSITION_P				= 0x78;	  //位置环P参数
        public const byte L_POSITION_I				= 0x79;	  //位置环I参数
        public const byte L_POSITION_D				= 0x7A;	  //位置环D参数
        public const byte L_POSITION_DS				= 0x7B;	  //位置P死区
                                                          
        //刹车控制命令                                    
        public const byte BRAKE_RELEASE_CMD		    = 0x80;	//刹车释放命令，0-保持制动，1-释放刹车
        public const byte BRAKE_STATE				= 0x81;  //刹车状态，0-保持制动，1-释放刹车
                                                          
        //示波器模块子索引地址定义                        
        public const byte SCP_MASK					= 0x90;	//记录对象标志MASK
        public const byte SCP_REC_TIM				= 0x91;	//记录时间间隔（对10kHZ的分频值）
        public const byte SCP_TAGCUR_L		    	= 0x92;	//目标电流数据集
        public const byte SCP_TAGCUR_H		    	= 0x93;	//目标电流数据集
        public const byte SCP_MEACUR_L		    	= 0x94;	//实际电流数据集
        public const byte SCP_MEACUR_H		    	= 0x95;	//实际电流数据集
        public const byte SCP_TAGSPD_L		    	= 0x96;	//目标速度数据集
        public const byte SCP_TAGSPD_H		    	= 0x97;	//目标速度数据集
        public const byte SCP_MEASPD_L		    	= 0x98;	//实际速度数据集
        public const byte SCP_MEASPD_H		    	= 0x99;	//实际速度数据集
        public const byte SCP_TAGPOS_L		    	= 0x9A;	//目标位置数据集
        public const byte SCP_TAGPOS_H		    	= 0x9B;	//目标位置数据集
        public const byte SCP_MEAPOS_L              = 0x9C;	//实际位置数据集
        public const byte SCP_MEAPOS_H              = 0x9D;	//实际位置数据集

        public const byte MASK_TAGCUR				=	0x01;		//记录目标电流MASK
        public const byte MASK_MEACUR				=	0x02;		//记录实际电流MASK
        public const byte MASK_TAGSPD				=	0x04;		//记录目标速度MASK
        public const byte MASK_MEASPD				=	0x08;		//记录实际速度MASK
        public const byte MASK_TAGPOS				=	0x10;		//记录目标位置MASK
        public const byte MASK_MEAPOS				=	0x20;		//记录实际位置MASK

        //错误字节MASK定义                           
        public const ushort ERROR_MASK_OVER_CURRENT = 0x0001;//过流
        public const ushort ERROR_MASK_OVER_VOLTAGE = 0x0002;//过压
        public const ushort ERROR_MASK_UNDER_VOLTAGE = 0x0004;	//欠压
        public const ushort ERROR_MASK_OVER_TEMP = 0x0008;//过温
        public const ushort ERROR_MASK_HALL = 0x0010;//霍尔错误
        public const ushort ERROR_MASK_ENCODER = 0x0020;	//码盘错误
        public const ushort ERROR_MASK_POTEN = 0x0040;	//电位器错误
        public const ushort ERROR_MASK_CURRENT_INIT = 0x0080;//电流检测错误
        public const ushort ERROR_MASK_FUSE = 0x0100;//保险丝断开错误


        
        public Configuration()
        {
            InitialMemoryControlTable();
        }

       
        private void InitialMemoryControlTable()
        {
            //MemoryControlTable.Add(Convert.ToByte("00", 16), MemoryControlTable[0]);
            //MemoryControlTable.Add(Convert.ToByte("01", 16), MemoryControlTable[SYS_ID]);
            //MemoryControlTable.Add(Convert.ToByte("02", 16), MemoryControlTable[SYS_MODEL_TYPE]);
            //MemoryControlTable.Add(Convert.ToByte("03", 16), MemoryControlTable[SYS_FW_VERSION]);
            //MemoryControlTable.Add(Convert.ToByte("04", 16), MemoryControlTable[SYS_ERROR]);
            //MemoryControlTable.Add(Convert.ToByte("05", 16), MemoryControlTable[SYS_VOLTAGE]);
            //MemoryControlTable.Add(Convert.ToByte("06", 16), MemoryControlTable[SYS_TEMP]);
            //MemoryControlTable.Add(Convert.ToByte("07", 16), MemoryControlTable[SYS_REDU_RATIO]);
            //MemoryControlTable.Add(Convert.ToByte("08", 16), MemoryControlTable[0x08]);
            //MemoryControlTable.Add(Convert.ToByte("09", 16), MemoryControlTable[SYS_BAUDRATE_CAN]);
            //MemoryControlTable.Add(Convert.ToByte("0a", 16), MemoryControlTable[SYS_ENABLE_DRIVER]);
            //MemoryControlTable.Add(Convert.ToByte("0b", 16), MemoryControlTable[SYS_ENABLE_ON_POWER]);
            //MemoryControlTable.Add(Convert.ToByte("0c", 16), MemoryControlTable[SYS_SAVE_TO_FLASH]);
            //MemoryControlTable.Add(Convert.ToByte("0d", 16), MemoryControlTable[0x0d]);
            //MemoryControlTable.Add(Convert.ToByte("0e", 16), MemoryControlTable[SYS_SET_ZERO_POS]);
            //MemoryControlTable.Add(Convert.ToByte("0f", 16), MemoryControlTable[SYS_CLEAR_ERROR]);
        }

        public short GetCmdMapValue(byte Index)
        {
            return (Index < CMDMAP_LEN) ? MemoryControlTable[Index] : (short)0;
        }



    }
}

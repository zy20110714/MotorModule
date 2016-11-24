namespace ICDIBasic
{
    partial class Monitor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Monitor));
            this.gBMonitorError = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tBInterval = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.Monitor77 = new System.Windows.Forms.Label();
            this.btnMonitorStart2 = new System.Windows.Forms.Button();
            this.tBRegisterNumber2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Monitor76 = new System.Windows.Forms.Label();
            this.btnMonitorStart = new System.Windows.Forms.Button();
            this.tBRegisterNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSetZeroForAll = new System.Windows.Forms.Button();
            this.tBMultiTurn = new System.Windows.Forms.TextBox();
            this.tmrCheck = new System.Windows.Forms.Timer(this.components);
            this.gBMonitorTurns = new System.Windows.Forms.GroupBox();
            this.btnClearError = new System.Windows.Forms.Button();
            this.btnSetZeroPosition = new System.Windows.Forms.Button();
            this.gBMonitorCur = new System.Windows.Forms.GroupBox();
            this.tBCur = new System.Windows.Forms.TextBox();
            this.gBError = new System.Windows.Forms.GroupBox();
            this.tBError = new System.Windows.Forms.TextBox();
            this.gBMonitorVol = new System.Windows.Forms.GroupBox();
            this.tBVol = new System.Windows.Forms.TextBox();
            this.Reload = new System.Windows.Forms.Button();
            this.chkFasterReload = new System.Windows.Forms.CheckBox();
            this.SetID = new System.Windows.Forms.GroupBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.EnableOnPower = new System.Windows.Forms.GroupBox();
            this.rdoDisable = new System.Windows.Forms.RadioButton();
            this.rdoEnable = new System.Windows.Forms.RadioButton();
            this.Encode = new System.Windows.Forms.GroupBox();
            this.tBMulti_Turn = new System.Windows.Forms.TextBox();
            this.tBSingleTurn = new System.Windows.Forms.TextBox();
            this.Title = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pBExit = new System.Windows.Forms.PictureBox();
            this.picMinimized = new System.Windows.Forms.PictureBox();
            this.gBMonitorError.SuspendLayout();
            this.gBMonitorTurns.SuspendLayout();
            this.gBMonitorCur.SuspendLayout();
            this.gBError.SuspendLayout();
            this.gBMonitorVol.SuspendLayout();
            this.SetID.SuspendLayout();
            this.EnableOnPower.SuspendLayout();
            this.Encode.SuspendLayout();
            this.Title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimized)).BeginInit();
            this.SuspendLayout();
            // 
            // gBMonitorError
            // 
            this.gBMonitorError.Controls.Add(this.label15);
            this.gBMonitorError.Controls.Add(this.label14);
            this.gBMonitorError.Controls.Add(this.label12);
            this.gBMonitorError.Controls.Add(this.tBInterval);
            this.gBMonitorError.Controls.Add(this.label11);
            this.gBMonitorError.Controls.Add(this.Monitor77);
            this.gBMonitorError.Controls.Add(this.btnMonitorStart2);
            this.gBMonitorError.Controls.Add(this.tBRegisterNumber2);
            this.gBMonitorError.Controls.Add(this.label4);
            this.gBMonitorError.Controls.Add(this.Monitor76);
            this.gBMonitorError.Controls.Add(this.btnMonitorStart);
            this.gBMonitorError.Controls.Add(this.tBRegisterNumber);
            this.gBMonitorError.Controls.Add(this.label1);
            this.gBMonitorError.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gBMonitorError.Location = new System.Drawing.Point(750, 319);
            this.gBMonitorError.Name = "gBMonitorError";
            this.gBMonitorError.Size = new System.Drawing.Size(400, 300);
            this.gBMonitorError.TabIndex = 11;
            this.gBMonitorError.TabStop = false;
            this.gBMonitorError.Text = "编码器寄存器操作";
            this.gBMonitorError.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(41, 80);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(94, 28);
            this.label15.TabIndex = 21;
            this.label15.Text = "地址+00";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(32, 214);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(112, 28);
            this.label14.TabIndex = 20;
            this.label14.Text = "地址+数据";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(340, 127);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 28);
            this.label12.TabIndex = 19;
            this.label12.Text = "ms";
            // 
            // tBInterval
            // 
            this.tBInterval.Location = new System.Drawing.Point(234, 120);
            this.tBInterval.Name = "tBInterval";
            this.tBInterval.Size = new System.Drawing.Size(100, 35);
            this.tBInterval.TabIndex = 18;
            this.tBInterval.Text = "1000";
            this.tBInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBInterval.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBInterval_KeyDown);
            this.tBInterval.Leave += new System.EventHandler(this.tBInterval_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(132, 127);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 28);
            this.label11.TabIndex = 17;
            this.label11.Text = "查询间隔";
            // 
            // Monitor77
            // 
            this.Monitor77.AutoSize = true;
            this.Monitor77.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Monitor77.Location = new System.Drawing.Point(261, 183);
            this.Monitor77.Name = "Monitor77";
            this.Monitor77.Size = new System.Drawing.Size(0, 21);
            this.Monitor77.TabIndex = 14;
            // 
            // btnMonitorStart2
            // 
            this.btnMonitorStart2.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMonitorStart2.Location = new System.Drawing.Point(150, 168);
            this.btnMonitorStart2.Margin = new System.Windows.Forms.Padding(0);
            this.btnMonitorStart2.Name = "btnMonitorStart2";
            this.btnMonitorStart2.Size = new System.Drawing.Size(120, 50);
            this.btnMonitorStart2.TabIndex = 13;
            this.btnMonitorStart2.Text = "写入";
            this.btnMonitorStart2.UseVisualStyleBackColor = true;
            this.btnMonitorStart2.Click += new System.EventHandler(this.btnMonitorStart2_Click);
            // 
            // tBRegisterNumber2
            // 
            this.tBRegisterNumber2.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBRegisterNumber2.Location = new System.Drawing.Point(37, 176);
            this.tBRegisterNumber2.Name = "tBRegisterNumber2";
            this.tBRegisterNumber2.Size = new System.Drawing.Size(100, 35);
            this.tBRegisterNumber2.TabIndex = 15;
            this.tBRegisterNumber2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBRegisterNumber2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBRegisterNumber2_KeyDown);
            this.tBRegisterNumber2.Leave += new System.EventHandler(this.tBRegisterNumber2_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(6, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 28);
            this.label4.TabIndex = 16;
            this.label4.Text = "0x";
            // 
            // Monitor76
            // 
            this.Monitor76.AutoSize = true;
            this.Monitor76.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Monitor76.Location = new System.Drawing.Point(293, 42);
            this.Monitor76.Name = "Monitor76";
            this.Monitor76.Size = new System.Drawing.Size(75, 28);
            this.Monitor76.TabIndex = 9;
            this.Monitor76.Text = "未启动";
            // 
            // btnMonitorStart
            // 
            this.btnMonitorStart.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMonitorStart.Location = new System.Drawing.Point(150, 26);
            this.btnMonitorStart.Margin = new System.Windows.Forms.Padding(0);
            this.btnMonitorStart.Name = "btnMonitorStart";
            this.btnMonitorStart.Size = new System.Drawing.Size(120, 50);
            this.btnMonitorStart.TabIndex = 8;
            this.btnMonitorStart.Text = "开始查询";
            this.btnMonitorStart.UseVisualStyleBackColor = true;
            this.btnMonitorStart.Click += new System.EventHandler(this.btnMonitorStart_Click);
            // 
            // tBRegisterNumber
            // 
            this.tBRegisterNumber.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBRegisterNumber.Location = new System.Drawing.Point(37, 39);
            this.tBRegisterNumber.Name = "tBRegisterNumber";
            this.tBRegisterNumber.Size = new System.Drawing.Size(100, 35);
            this.tBRegisterNumber.TabIndex = 10;
            this.tBRegisterNumber.Text = "7700";
            this.tBRegisterNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBRegisterNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBRegisterNumber_KeyDown);
            this.tBRegisterNumber.Leave += new System.EventHandler(this.tBRegisterNumber_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 28);
            this.label1.TabIndex = 11;
            this.label1.Text = "0x";
            // 
            // btnSetZeroForAll
            // 
            this.btnSetZeroForAll.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSetZeroForAll.Location = new System.Drawing.Point(750, 120);
            this.btnSetZeroForAll.Name = "btnSetZeroForAll";
            this.btnSetZeroForAll.Size = new System.Drawing.Size(120, 100);
            this.btnSetZeroForAll.TabIndex = 12;
            this.btnSetZeroForAll.Text = "全部ID\r\n设零\r\n（临时）";
            this.btnSetZeroForAll.UseVisualStyleBackColor = true;
            this.btnSetZeroForAll.Visible = false;
            this.btnSetZeroForAll.Click += new System.EventHandler(this.btnSetZeroForAll_Click);
            // 
            // tBMultiTurn
            // 
            this.tBMultiTurn.Location = new System.Drawing.Point(45, 41);
            this.tBMultiTurn.Name = "tBMultiTurn";
            this.tBMultiTurn.ReadOnly = true;
            this.tBMultiTurn.Size = new System.Drawing.Size(100, 35);
            this.tBMultiTurn.TabIndex = 54;
            this.tBMultiTurn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tmrCheck
            // 
            this.tmrCheck.Interval = 1000;
            this.tmrCheck.Tick += new System.EventHandler(this.tmrCheck_Tick);
            // 
            // gBMonitorTurns
            // 
            this.gBMonitorTurns.Controls.Add(this.tBMultiTurn);
            this.gBMonitorTurns.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gBMonitorTurns.Location = new System.Drawing.Point(424, 199);
            this.gBMonitorTurns.Name = "gBMonitorTurns";
            this.gBMonitorTurns.Size = new System.Drawing.Size(200, 100);
            this.gBMonitorTurns.TabIndex = 55;
            this.gBMonitorTurns.TabStop = false;
            this.gBMonitorTurns.Text = "当前圈数";
            // 
            // btnClearError
            // 
            this.btnClearError.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClearError.Location = new System.Drawing.Point(40, 133);
            this.btnClearError.Name = "btnClearError";
            this.btnClearError.Size = new System.Drawing.Size(120, 50);
            this.btnClearError.TabIndex = 56;
            this.btnClearError.Text = "清错使能";
            this.btnClearError.UseVisualStyleBackColor = true;
            this.btnClearError.Click += new System.EventHandler(this.btnClearError_Click);
            // 
            // btnSetZeroPosition
            // 
            this.btnSetZeroPosition.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSetZeroPosition.Location = new System.Drawing.Point(750, 120);
            this.btnSetZeroPosition.Name = "btnSetZeroPosition";
            this.btnSetZeroPosition.Size = new System.Drawing.Size(120, 100);
            this.btnSetZeroPosition.TabIndex = 57;
            this.btnSetZeroPosition.Text = "当前位置\r\n设为零点";
            this.btnSetZeroPosition.UseVisualStyleBackColor = true;
            this.btnSetZeroPosition.Click += new System.EventHandler(this.btnSetZeroPosition_Click);
            // 
            // gBMonitorCur
            // 
            this.gBMonitorCur.Controls.Add(this.tBCur);
            this.gBMonitorCur.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gBMonitorCur.Location = new System.Drawing.Point(218, 199);
            this.gBMonitorCur.Name = "gBMonitorCur";
            this.gBMonitorCur.Size = new System.Drawing.Size(200, 100);
            this.gBMonitorCur.TabIndex = 56;
            this.gBMonitorCur.TabStop = false;
            this.gBMonitorCur.Text = "当前电流";
            // 
            // tBCur
            // 
            this.tBCur.Location = new System.Drawing.Point(45, 41);
            this.tBCur.Name = "tBCur";
            this.tBCur.ReadOnly = true;
            this.tBCur.Size = new System.Drawing.Size(100, 35);
            this.tBCur.TabIndex = 54;
            this.tBCur.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gBError
            // 
            this.gBError.Controls.Add(this.tBError);
            this.gBError.Controls.Add(this.btnClearError);
            this.gBError.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gBError.Location = new System.Drawing.Point(12, 412);
            this.gBError.Name = "gBError";
            this.gBError.Size = new System.Drawing.Size(200, 207);
            this.gBError.TabIndex = 56;
            this.gBError.TabStop = false;
            this.gBError.Text = "错误类型";
            // 
            // tBError
            // 
            this.tBError.Location = new System.Drawing.Point(45, 41);
            this.tBError.Name = "tBError";
            this.tBError.ReadOnly = true;
            this.tBError.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tBError.Size = new System.Drawing.Size(100, 35);
            this.tBError.TabIndex = 54;
            this.tBError.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gBMonitorVol
            // 
            this.gBMonitorVol.Controls.Add(this.tBVol);
            this.gBMonitorVol.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gBMonitorVol.Location = new System.Drawing.Point(218, 306);
            this.gBMonitorVol.Name = "gBMonitorVol";
            this.gBMonitorVol.Size = new System.Drawing.Size(200, 100);
            this.gBMonitorVol.TabIndex = 57;
            this.gBMonitorVol.TabStop = false;
            this.gBMonitorVol.Text = "当前电压";
            // 
            // tBVol
            // 
            this.tBVol.Location = new System.Drawing.Point(45, 41);
            this.tBVol.Name = "tBVol";
            this.tBVol.ReadOnly = true;
            this.tBVol.Size = new System.Drawing.Size(100, 35);
            this.tBVol.TabIndex = 54;
            this.tBVol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Reload
            // 
            this.Reload.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Reload.Location = new System.Drawing.Point(12, 71);
            this.Reload.Name = "Reload";
            this.Reload.Size = new System.Drawing.Size(120, 50);
            this.Reload.TabIndex = 58;
            this.Reload.Text = "刷新";
            this.Reload.UseVisualStyleBackColor = true;
            this.Reload.Click += new System.EventHandler(this.Reload_Click);
            // 
            // chkFasterReload
            // 
            this.chkFasterReload.AutoSize = true;
            this.chkFasterReload.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkFasterReload.Location = new System.Drawing.Point(138, 100);
            this.chkFasterReload.Name = "chkFasterReload";
            this.chkFasterReload.Size = new System.Drawing.Size(75, 21);
            this.chkFasterReload.TabIndex = 59;
            this.chkFasterReload.Text = "连续刷新";
            this.chkFasterReload.UseVisualStyleBackColor = true;
            this.chkFasterReload.CheckedChanged += new System.EventHandler(this.chkFasterReload_CheckedChanged);
            // 
            // SetID
            // 
            this.SetID.Controls.Add(this.txtID);
            this.SetID.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SetID.Location = new System.Drawing.Point(12, 306);
            this.SetID.Name = "SetID";
            this.SetID.Size = new System.Drawing.Size(200, 100);
            this.SetID.TabIndex = 60;
            this.SetID.TabStop = false;
            this.SetID.Text = "设置ID";
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtID.Location = new System.Drawing.Point(49, 41);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 35);
            this.txtID.TabIndex = 16;
            this.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtID_KeyDown);
            this.txtID.Leave += new System.EventHandler(this.txtID_Leave);
            // 
            // EnableOnPower
            // 
            this.EnableOnPower.Controls.Add(this.rdoDisable);
            this.EnableOnPower.Controls.Add(this.rdoEnable);
            this.EnableOnPower.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EnableOnPower.Location = new System.Drawing.Point(12, 199);
            this.EnableOnPower.Name = "EnableOnPower";
            this.EnableOnPower.Size = new System.Drawing.Size(200, 100);
            this.EnableOnPower.TabIndex = 61;
            this.EnableOnPower.TabStop = false;
            this.EnableOnPower.Text = "上电使能";
            // 
            // rdoDisable
            // 
            this.rdoDisable.AutoSize = true;
            this.rdoDisable.Location = new System.Drawing.Point(125, 47);
            this.rdoDisable.Name = "rdoDisable";
            this.rdoDisable.Size = new System.Drawing.Size(51, 32);
            this.rdoDisable.TabIndex = 1;
            this.rdoDisable.TabStop = true;
            this.rdoDisable.Text = "关";
            this.rdoDisable.UseVisualStyleBackColor = true;
            this.rdoDisable.Click += new System.EventHandler(this.rdoDisable_Click);
            // 
            // rdoEnable
            // 
            this.rdoEnable.AutoSize = true;
            this.rdoEnable.Location = new System.Drawing.Point(28, 47);
            this.rdoEnable.Name = "rdoEnable";
            this.rdoEnable.Size = new System.Drawing.Size(51, 32);
            this.rdoEnable.TabIndex = 0;
            this.rdoEnable.TabStop = true;
            this.rdoEnable.Text = "开";
            this.rdoEnable.UseVisualStyleBackColor = true;
            this.rdoEnable.Click += new System.EventHandler(this.rdoEnable_Click);
            // 
            // Encode
            // 
            this.Encode.Controls.Add(this.tBMulti_Turn);
            this.Encode.Controls.Add(this.tBSingleTurn);
            this.Encode.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Encode.Location = new System.Drawing.Point(218, 412);
            this.Encode.Name = "Encode";
            this.Encode.Size = new System.Drawing.Size(200, 207);
            this.Encode.TabIndex = 56;
            this.Encode.TabStop = false;
            this.Encode.Text = "编码器读数";
            // 
            // tBMulti_Turn
            // 
            this.tBMulti_Turn.Location = new System.Drawing.Point(45, 141);
            this.tBMulti_Turn.Name = "tBMulti_Turn";
            this.tBMulti_Turn.ReadOnly = true;
            this.tBMulti_Turn.Size = new System.Drawing.Size(100, 35);
            this.tBMulti_Turn.TabIndex = 55;
            this.tBMulti_Turn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tBSingleTurn
            // 
            this.tBSingleTurn.Location = new System.Drawing.Point(45, 41);
            this.tBSingleTurn.Name = "tBSingleTurn";
            this.tBSingleTurn.ReadOnly = true;
            this.tBSingleTurn.Size = new System.Drawing.Size(100, 35);
            this.tBSingleTurn.TabIndex = 54;
            this.tBSingleTurn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Title
            // 
            this.Title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Title.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Title.Controls.Add(this.picMinimized);
            this.Title.Controls.Add(this.label2);
            this.Title.Controls.Add(this.pBExit);
            this.Title.Location = new System.Drawing.Point(0, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(637, 50);
            this.Title.TabIndex = 62;
            this.Title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Title_MouseDown);
            this.Title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Title_MouseMove);
            this.Title.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Title_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(261, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "监视器";
            // 
            // pBExit
            // 
            this.pBExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pBExit.BackgroundImage")));
            this.pBExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pBExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.pBExit.Location = new System.Drawing.Point(587, 0);
            this.pBExit.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.pBExit.Name = "pBExit";
            this.pBExit.Size = new System.Drawing.Size(50, 50);
            this.pBExit.TabIndex = 0;
            this.pBExit.TabStop = false;
            this.pBExit.Click += new System.EventHandler(this.pBExit_Click);
            // 
            // picMinimized
            // 
            this.picMinimized.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picMinimized.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picMinimized.BackgroundImage")));
            this.picMinimized.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picMinimized.InitialImage = null;
            this.picMinimized.Location = new System.Drawing.Point(536, 0);
            this.picMinimized.Margin = new System.Windows.Forms.Padding(0);
            this.picMinimized.Name = "picMinimized";
            this.picMinimized.Size = new System.Drawing.Size(50, 50);
            this.picMinimized.TabIndex = 2;
            this.picMinimized.TabStop = false;
            this.picMinimized.Click += new System.EventHandler(this.picMinimized_Click);
            // 
            // Monitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(637, 631);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.Reload);
            this.Controls.Add(this.chkFasterReload);
            this.Controls.Add(this.EnableOnPower);
            this.Controls.Add(this.gBMonitorCur);
            this.Controls.Add(this.gBMonitorTurns);
            this.Controls.Add(this.SetID);
            this.Controls.Add(this.gBMonitorVol);
            this.Controls.Add(this.gBError);
            this.Controls.Add(this.Encode);
            this.Controls.Add(this.btnSetZeroPosition);
            this.Controls.Add(this.btnSetZeroForAll);
            this.Controls.Add(this.gBMonitorError);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Monitor";
            this.Text = "监视器";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Monitor_FormClosed);
            this.gBMonitorError.ResumeLayout(false);
            this.gBMonitorError.PerformLayout();
            this.gBMonitorTurns.ResumeLayout(false);
            this.gBMonitorTurns.PerformLayout();
            this.gBMonitorCur.ResumeLayout(false);
            this.gBMonitorCur.PerformLayout();
            this.gBError.ResumeLayout(false);
            this.gBError.PerformLayout();
            this.gBMonitorVol.ResumeLayout(false);
            this.gBMonitorVol.PerformLayout();
            this.SetID.ResumeLayout(false);
            this.SetID.PerformLayout();
            this.EnableOnPower.ResumeLayout(false);
            this.EnableOnPower.PerformLayout();
            this.Encode.ResumeLayout(false);
            this.Encode.PerformLayout();
            this.Title.ResumeLayout(false);
            this.Title.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimized)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gBMonitorError;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tBInterval;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label Monitor77;
        private System.Windows.Forms.Button btnMonitorStart2;
        private System.Windows.Forms.TextBox tBRegisterNumber2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Monitor76;
        private System.Windows.Forms.Button btnMonitorStart;
        private System.Windows.Forms.TextBox tBRegisterNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSetZeroForAll;
        private System.Windows.Forms.TextBox tBMultiTurn;
        private System.Windows.Forms.Timer tmrCheck;
        private System.Windows.Forms.GroupBox gBMonitorTurns;
        private System.Windows.Forms.Button btnClearError;
        private System.Windows.Forms.Button btnSetZeroPosition;
        private System.Windows.Forms.GroupBox gBMonitorCur;
        private System.Windows.Forms.TextBox tBCur;
        private System.Windows.Forms.GroupBox gBError;
        private System.Windows.Forms.TextBox tBError;
        private System.Windows.Forms.GroupBox gBMonitorVol;
        private System.Windows.Forms.TextBox tBVol;
        private System.Windows.Forms.Button Reload;
        private System.Windows.Forms.CheckBox chkFasterReload;
        private System.Windows.Forms.GroupBox SetID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.GroupBox EnableOnPower;
        private System.Windows.Forms.RadioButton rdoDisable;
        private System.Windows.Forms.RadioButton rdoEnable;
        private System.Windows.Forms.GroupBox Encode;
        private System.Windows.Forms.TextBox tBSingleTurn;
        private System.Windows.Forms.TextBox tBMulti_Turn;
        private System.Windows.Forms.Panel Title;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pBExit;
        private System.Windows.Forms.PictureBox picMinimized;
    }
}
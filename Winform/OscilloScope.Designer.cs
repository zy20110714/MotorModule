namespace ICDIBasic
{
    partial class OscilloScope
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
            this.pLBoard = new System.Windows.Forms.Panel();
            this.btnMeasure = new System.Windows.Forms.Button();
            this.cBSpeedRatio = new System.Windows.Forms.ComboBox();
            this.cBPositionRatio = new System.Windows.Forms.ComboBox();
            this.cBCurrentRatio = new System.Windows.Forms.ComboBox();
            this.pLPaint = new ICDIBasic.NewPanel();
            this.tBtrace = new System.Windows.Forms.TrackBar();
            this.timerPaint = new System.Windows.Forms.Timer(this.components);
            this.cDcolor = new System.Windows.Forms.ColorDialog();
            this.tCMonitor = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gBPos = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tBPosDeadZone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tBPosD = new System.Windows.Forms.TextBox();
            this.tBPosI = new System.Windows.Forms.TextBox();
            this.tBPosP = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cBAdjustGroup = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tBMaxCurrent = new System.Windows.Forms.TextBox();
            this.tBMaxAcc = new System.Windows.Forms.TextBox();
            this.tBMaxSpeed = new System.Windows.Forms.TextBox();
            this.gBSpeed = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tBSpeedD = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tBSpeedDeadZone = new System.Windows.Forms.TextBox();
            this.tBSpeedP = new System.Windows.Forms.TextBox();
            this.tBSpeedI = new System.Windows.Forms.TextBox();
            this.gBCurrent = new System.Windows.Forms.GroupBox();
            this.tBCurrentI = new System.Windows.Forms.TextBox();
            this.tBCurrentP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.nUSmoothData = new System.Windows.Forms.NumericUpDown();
            this.rBPointer2 = new System.Windows.Forms.RadioButton();
            this.rBPointer1 = new System.Windows.Forms.RadioButton();
            this.cBPointer = new System.Windows.Forms.CheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.lVFormat = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pLBoard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBtrace)).BeginInit();
            this.tCMonitor.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.gBPos.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gBSpeed.SuspendLayout();
            this.gBCurrent.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUSmoothData)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pLBoard
            // 
            this.pLBoard.Controls.Add(this.btnMeasure);
            this.pLBoard.Controls.Add(this.cBSpeedRatio);
            this.pLBoard.Controls.Add(this.cBPositionRatio);
            this.pLBoard.Controls.Add(this.cBCurrentRatio);
            this.pLBoard.Controls.Add(this.pLPaint);
            this.pLBoard.Controls.Add(this.tBtrace);
            this.pLBoard.Location = new System.Drawing.Point(-3, 17);
            this.pLBoard.Name = "pLBoard";
            this.pLBoard.Size = new System.Drawing.Size(886, 397);
            this.pLBoard.TabIndex = 0;
            // 
            // btnMeasure
            // 
            this.btnMeasure.BackColor = System.Drawing.Color.Green;
            this.btnMeasure.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMeasure.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMeasure.Location = new System.Drawing.Point(804, 176);
            this.btnMeasure.Name = "btnMeasure";
            this.btnMeasure.Size = new System.Drawing.Size(71, 36);
            this.btnMeasure.TabIndex = 2;
            this.btnMeasure.Text = "测定";
            this.btnMeasure.UseVisualStyleBackColor = false;
            this.btnMeasure.Click += new System.EventHandler(this.btnMeasure_Click);
            // 
            // cBSpeedRatio
            // 
            this.cBSpeedRatio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cBSpeedRatio.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cBSpeedRatio.FormattingEnabled = true;
            this.cBSpeedRatio.Items.AddRange(new object[] {
            "1rpm",
            "5rpm",
            "20rpm",
            "100rpm",
            "300rpm",
            "1000rpm"});
            this.cBSpeedRatio.Location = new System.Drawing.Point(806, 79);
            this.cBSpeedRatio.Name = "cBSpeedRatio";
            this.cBSpeedRatio.Size = new System.Drawing.Size(73, 24);
            this.cBSpeedRatio.TabIndex = 1;
            this.cBSpeedRatio.Text = "100rpm";
            // 
            // cBPositionRatio
            // 
            this.cBPositionRatio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cBPositionRatio.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cBPositionRatio.FormattingEnabled = true;
            this.cBPositionRatio.Items.AddRange(new object[] {
            "0.1°",
            "0.5°",
            "2°",
            "5°",
            "10°",
            "50°",
            "100°",
            "500°"});
            this.cBPositionRatio.Location = new System.Drawing.Point(806, 126);
            this.cBPositionRatio.Name = "cBPositionRatio";
            this.cBPositionRatio.Size = new System.Drawing.Size(73, 27);
            this.cBPositionRatio.TabIndex = 1;
            this.cBPositionRatio.Text = "10°";
            // 
            // cBCurrentRatio
            // 
            this.cBCurrentRatio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cBCurrentRatio.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cBCurrentRatio.FormattingEnabled = true;
            this.cBCurrentRatio.Items.AddRange(new object[] {
            "1mA",
            "5mA",
            "20mA",
            "100mA",
            "500mA"});
            this.cBCurrentRatio.Location = new System.Drawing.Point(806, 33);
            this.cBCurrentRatio.Name = "cBCurrentRatio";
            this.cBCurrentRatio.Size = new System.Drawing.Size(73, 24);
            this.cBCurrentRatio.TabIndex = 1;
            this.cBCurrentRatio.Text = "5mA";
            // 
            // pLPaint
            // 
            this.pLPaint.BackColor = System.Drawing.Color.White;
            this.pLPaint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLPaint.Location = new System.Drawing.Point(60, 11);
            this.pLPaint.Name = "pLPaint";
            this.pLPaint.Size = new System.Drawing.Size(740, 360);
            this.pLPaint.TabIndex = 0;
            this.pLPaint.Paint += new System.Windows.Forms.PaintEventHandler(this.pLPaint_Paint);
            // 
            // tBtrace
            // 
            this.tBtrace.AutoSize = false;
            this.tBtrace.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.tBtrace.Location = new System.Drawing.Point(47, 371);
            this.tBtrace.Margin = new System.Windows.Forms.Padding(0);
            this.tBtrace.Maximum = 740;
            this.tBtrace.Name = "tBtrace";
            this.tBtrace.Size = new System.Drawing.Size(766, 25);
            this.tBtrace.TabIndex = 0;
            this.tBtrace.TickFrequency = 2;
            this.tBtrace.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tBtrace.Value = 370;
            this.tBtrace.Scroll += new System.EventHandler(this.tBtrace_Scroll);
            // 
            // timerPaint
            // 
            this.timerPaint.Interval = 80;
            this.timerPaint.Tick += new System.EventHandler(this.timerPaint_Tick);
            // 
            // tCMonitor
            // 
            this.tCMonitor.Controls.Add(this.tabPage1);
            this.tCMonitor.Controls.Add(this.tabPage2);
            this.tCMonitor.Controls.Add(this.tabPage3);
            this.tCMonitor.Controls.Add(this.tabPage4);
            this.tCMonitor.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tCMonitor.Location = new System.Drawing.Point(0, 420);
            this.tCMonitor.Name = "tCMonitor";
            this.tCMonitor.SelectedIndex = 0;
            this.tCMonitor.Size = new System.Drawing.Size(876, 150);
            this.tCMonitor.TabIndex = 1;
            this.tCMonitor.SelectedIndexChanged += new System.EventHandler(this.tCMonitor_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(868, 115);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "实测项目";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gBPos);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.gBSpeed);
            this.tabPage2.Controls.Add(this.gBCurrent);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(868, 115);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "PID调节";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gBPos
            // 
            this.gBPos.Controls.Add(this.label10);
            this.gBPos.Controls.Add(this.label4);
            this.gBPos.Controls.Add(this.label9);
            this.gBPos.Controls.Add(this.tBPosDeadZone);
            this.gBPos.Controls.Add(this.label3);
            this.gBPos.Controls.Add(this.tBPosD);
            this.gBPos.Controls.Add(this.tBPosI);
            this.gBPos.Controls.Add(this.tBPosP);
            this.gBPos.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gBPos.Location = new System.Drawing.Point(626, 6);
            this.gBPos.Name = "gBPos";
            this.gBPos.Size = new System.Drawing.Size(230, 106);
            this.gBPos.TabIndex = 0;
            this.gBPos.TabStop = false;
            this.gBPos.Text = "位置环";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(120, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 14);
            this.label10.TabIndex = 0;
            this.label10.Text = "死区";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(120, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "I参数";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(6, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 14);
            this.label9.TabIndex = 0;
            this.label9.Text = "D参数";
            // 
            // tBPosDeadZone
            // 
            this.tBPosDeadZone.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBPosDeadZone.Location = new System.Drawing.Point(174, 74);
            this.tBPosDeadZone.Name = "tBPosDeadZone";
            this.tBPosDeadZone.Size = new System.Drawing.Size(54, 26);
            this.tBPosDeadZone.TabIndex = 1;
            this.tBPosDeadZone.TextChanged += new System.EventHandler(this.tBCurrentP_TextChanged);
            this.tBPosDeadZone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBCurrentP_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(6, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "P参数";
            // 
            // tBPosD
            // 
            this.tBPosD.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBPosD.Location = new System.Drawing.Point(60, 74);
            this.tBPosD.Name = "tBPosD";
            this.tBPosD.Size = new System.Drawing.Size(54, 26);
            this.tBPosD.TabIndex = 1;
            this.tBPosD.TextChanged += new System.EventHandler(this.tBCurrentP_TextChanged);
            this.tBPosD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBCurrentP_KeyDown);
            // 
            // tBPosI
            // 
            this.tBPosI.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBPosI.Location = new System.Drawing.Point(174, 31);
            this.tBPosI.Name = "tBPosI";
            this.tBPosI.Size = new System.Drawing.Size(54, 26);
            this.tBPosI.TabIndex = 1;
            this.tBPosI.TextChanged += new System.EventHandler(this.tBCurrentP_TextChanged);
            this.tBPosI.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBCurrentP_KeyDown);
            // 
            // tBPosP
            // 
            this.tBPosP.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBPosP.Location = new System.Drawing.Point(60, 31);
            this.tBPosP.Name = "tBPosP";
            this.tBPosP.Size = new System.Drawing.Size(54, 26);
            this.tBPosP.TabIndex = 1;
            this.tBPosP.TextChanged += new System.EventHandler(this.tBCurrentP_TextChanged);
            this.tBPosP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBCurrentP_KeyDown);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cBAdjustGroup);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.tBMaxCurrent);
            this.groupBox3.Controls.Add(this.tBMaxAcc);
            this.groupBox3.Controls.Add(this.tBMaxSpeed);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(3, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(250, 106);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "参数设置";
            // 
            // cBAdjustGroup
            // 
            this.cBAdjustGroup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cBAdjustGroup.FormattingEnabled = true;
            this.cBAdjustGroup.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.cBAdjustGroup.Location = new System.Drawing.Point(64, 31);
            this.cBAdjustGroup.Name = "cBAdjustGroup";
            this.cBAdjustGroup.Size = new System.Drawing.Size(47, 27);
            this.cBAdjustGroup.TabIndex = 2;
            this.cBAdjustGroup.Text = "2";
            this.cBAdjustGroup.SelectedIndexChanged += new System.EventHandler(this.cBAdjustGroup_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(117, 80);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 14);
            this.label14.TabIndex = 0;
            this.label14.Text = "最大加速度";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(0, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 14);
            this.label11.TabIndex = 0;
            this.label11.Text = "调整组";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(117, 36);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 14);
            this.label13.TabIndex = 0;
            this.label13.Text = "最大电流";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(0, 80);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 14);
            this.label12.TabIndex = 0;
            this.label12.Text = "最大速度";
            // 
            // tBMaxCurrent
            // 
            this.tBMaxCurrent.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBMaxCurrent.Location = new System.Drawing.Point(194, 31);
            this.tBMaxCurrent.Name = "tBMaxCurrent";
            this.tBMaxCurrent.Size = new System.Drawing.Size(47, 26);
            this.tBMaxCurrent.TabIndex = 1;
            this.tBMaxCurrent.TextChanged += new System.EventHandler(this.tBCurrentP_TextChanged);
            this.tBMaxCurrent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBCurrentP_KeyDown);
            // 
            // tBMaxAcc
            // 
            this.tBMaxAcc.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBMaxAcc.Location = new System.Drawing.Point(194, 74);
            this.tBMaxAcc.Name = "tBMaxAcc";
            this.tBMaxAcc.Size = new System.Drawing.Size(47, 26);
            this.tBMaxAcc.TabIndex = 1;
            this.tBMaxAcc.TextChanged += new System.EventHandler(this.tBCurrentP_TextChanged);
            this.tBMaxAcc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBCurrentP_KeyDown);
            // 
            // tBMaxSpeed
            // 
            this.tBMaxSpeed.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBMaxSpeed.Location = new System.Drawing.Point(64, 74);
            this.tBMaxSpeed.Name = "tBMaxSpeed";
            this.tBMaxSpeed.Size = new System.Drawing.Size(47, 26);
            this.tBMaxSpeed.TabIndex = 1;
            this.tBMaxSpeed.TextChanged += new System.EventHandler(this.tBCurrentP_TextChanged);
            this.tBMaxSpeed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBCurrentP_KeyDown);
            // 
            // gBSpeed
            // 
            this.gBSpeed.Controls.Add(this.label8);
            this.gBSpeed.Controls.Add(this.label6);
            this.gBSpeed.Controls.Add(this.label7);
            this.gBSpeed.Controls.Add(this.tBSpeedD);
            this.gBSpeed.Controls.Add(this.label5);
            this.gBSpeed.Controls.Add(this.tBSpeedDeadZone);
            this.gBSpeed.Controls.Add(this.tBSpeedP);
            this.gBSpeed.Controls.Add(this.tBSpeedI);
            this.gBSpeed.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gBSpeed.Location = new System.Drawing.Point(390, 6);
            this.gBSpeed.Name = "gBSpeed";
            this.gBSpeed.Size = new System.Drawing.Size(230, 106);
            this.gBSpeed.TabIndex = 0;
            this.gBSpeed.TabStop = false;
            this.gBSpeed.Text = "速度环";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(120, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 14);
            this.label8.TabIndex = 0;
            this.label8.Text = "死区";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(120, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 14);
            this.label6.TabIndex = 0;
            this.label6.Text = "I参数";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(6, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 14);
            this.label7.TabIndex = 0;
            this.label7.Text = "D参数";
            // 
            // tBSpeedD
            // 
            this.tBSpeedD.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBSpeedD.Location = new System.Drawing.Point(60, 74);
            this.tBSpeedD.Name = "tBSpeedD";
            this.tBSpeedD.Size = new System.Drawing.Size(54, 26);
            this.tBSpeedD.TabIndex = 1;
            this.tBSpeedD.TextChanged += new System.EventHandler(this.tBCurrentP_TextChanged);
            this.tBSpeedD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBCurrentP_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(6, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "P参数";
            // 
            // tBSpeedDeadZone
            // 
            this.tBSpeedDeadZone.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBSpeedDeadZone.Location = new System.Drawing.Point(174, 74);
            this.tBSpeedDeadZone.Name = "tBSpeedDeadZone";
            this.tBSpeedDeadZone.Size = new System.Drawing.Size(54, 26);
            this.tBSpeedDeadZone.TabIndex = 1;
            this.tBSpeedDeadZone.TextChanged += new System.EventHandler(this.tBCurrentP_TextChanged);
            this.tBSpeedDeadZone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBCurrentP_KeyDown);
            // 
            // tBSpeedP
            // 
            this.tBSpeedP.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBSpeedP.Location = new System.Drawing.Point(60, 31);
            this.tBSpeedP.Name = "tBSpeedP";
            this.tBSpeedP.Size = new System.Drawing.Size(54, 26);
            this.tBSpeedP.TabIndex = 1;
            this.tBSpeedP.TextChanged += new System.EventHandler(this.tBCurrentP_TextChanged);
            this.tBSpeedP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBCurrentP_KeyDown);
            // 
            // tBSpeedI
            // 
            this.tBSpeedI.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBSpeedI.Location = new System.Drawing.Point(174, 31);
            this.tBSpeedI.Name = "tBSpeedI";
            this.tBSpeedI.Size = new System.Drawing.Size(54, 26);
            this.tBSpeedI.TabIndex = 1;
            this.tBSpeedI.TextChanged += new System.EventHandler(this.tBCurrentP_TextChanged);
            this.tBSpeedI.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBCurrentP_KeyDown);
            // 
            // gBCurrent
            // 
            this.gBCurrent.Controls.Add(this.tBCurrentI);
            this.gBCurrent.Controls.Add(this.tBCurrentP);
            this.gBCurrent.Controls.Add(this.label2);
            this.gBCurrent.Controls.Add(this.label1);
            this.gBCurrent.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gBCurrent.Location = new System.Drawing.Point(259, 6);
            this.gBCurrent.Name = "gBCurrent";
            this.gBCurrent.Size = new System.Drawing.Size(125, 106);
            this.gBCurrent.TabIndex = 0;
            this.gBCurrent.TabStop = false;
            this.gBCurrent.Text = "电流环";
            // 
            // tBCurrentI
            // 
            this.tBCurrentI.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBCurrentI.Location = new System.Drawing.Point(60, 74);
            this.tBCurrentI.Name = "tBCurrentI";
            this.tBCurrentI.Size = new System.Drawing.Size(54, 26);
            this.tBCurrentI.TabIndex = 1;
            this.tBCurrentI.TextChanged += new System.EventHandler(this.tBCurrentP_TextChanged);
            this.tBCurrentI.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBCurrentP_KeyDown);
            // 
            // tBCurrentP
            // 
            this.tBCurrentP.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBCurrentP.Location = new System.Drawing.Point(60, 31);
            this.tBCurrentP.Name = "tBCurrentP";
            this.tBCurrentP.Size = new System.Drawing.Size(54, 26);
            this.tBCurrentP.TabIndex = 1;
            this.tBCurrentP.TextChanged += new System.EventHandler(this.tBCurrentP_TextChanged);
            this.tBCurrentP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBCurrentP_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(6, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "I参数";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "P参数";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.nUSmoothData);
            this.tabPage3.Controls.Add(this.rBPointer2);
            this.tabPage3.Controls.Add(this.rBPointer1);
            this.tabPage3.Controls.Add(this.cBPointer);
            this.tabPage3.Location = new System.Drawing.Point(4, 31);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(868, 115);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "指针";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(57, 92);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(85, 19);
            this.label15.TabIndex = 4;
            this.label15.Text = "数据平滑";
            // 
            // nUSmoothData
            // 
            this.nUSmoothData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nUSmoothData.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nUSmoothData.Location = new System.Drawing.Point(3, 83);
            this.nUSmoothData.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUSmoothData.Name = "nUSmoothData";
            this.nUSmoothData.Size = new System.Drawing.Size(48, 29);
            this.nUSmoothData.TabIndex = 3;
            this.nUSmoothData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rBPointer2
            // 
            this.rBPointer2.AutoSize = true;
            this.rBPointer2.Checked = true;
            this.rBPointer2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rBPointer2.Location = new System.Drawing.Point(26, 57);
            this.rBPointer2.Name = "rBPointer2";
            this.rBPointer2.Size = new System.Drawing.Size(66, 20);
            this.rBPointer2.TabIndex = 2;
            this.rBPointer2.TabStop = true;
            this.rBPointer2.Text = "指针2";
            this.rBPointer2.UseVisualStyleBackColor = true;
            // 
            // rBPointer1
            // 
            this.rBPointer1.AutoSize = true;
            this.rBPointer1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rBPointer1.Location = new System.Drawing.Point(26, 25);
            this.rBPointer1.Name = "rBPointer1";
            this.rBPointer1.Size = new System.Drawing.Size(66, 20);
            this.rBPointer1.TabIndex = 1;
            this.rBPointer1.Text = "指针1";
            this.rBPointer1.UseVisualStyleBackColor = true;
            this.rBPointer1.CheckedChanged += new System.EventHandler(this.rBPointer1_CheckedChanged);
            // 
            // cBPointer
            // 
            this.cBPointer.AutoSize = true;
            this.cBPointer.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cBPointer.Location = new System.Drawing.Point(3, 3);
            this.cBPointer.Name = "cBPointer";
            this.cBPointer.Size = new System.Drawing.Size(104, 23);
            this.cBPointer.TabIndex = 0;
            this.cBPointer.Text = "显示指针";
            this.cBPointer.UseVisualStyleBackColor = true;
            this.cBPointer.CheckedChanged += new System.EventHandler(this.cBPointer_CheckedChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.lVFormat);
            this.tabPage4.Location = new System.Drawing.Point(4, 31);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(868, 115);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "格式";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // lVFormat
            // 
            this.lVFormat.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lVFormat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lVFormat.CheckBoxes = true;
            this.lVFormat.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lVFormat.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lVFormat.FullRowSelect = true;
            this.lVFormat.Location = new System.Drawing.Point(0, 0);
            this.lVFormat.MultiSelect = false;
            this.lVFormat.Name = "lVFormat";
            this.lVFormat.Size = new System.Drawing.Size(865, 115);
            this.lVFormat.TabIndex = 0;
            this.lVFormat.UseCompatibleStateImageBehavior = false;
            this.lVFormat.View = System.Windows.Forms.View.Details;
            this.lVFormat.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lVFormat_ItemChecked);
            this.lVFormat.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lVFormat_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = " 显示";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "测定项目";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "观测/参考";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 140;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "颜色";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "线型";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 200;
            // 
            // OscilloScope
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 571);
            this.Controls.Add(this.tCMonitor);
            this.Controls.Add(this.pLBoard);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OscilloScope";
            this.Text = "Oscilloscope";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OscilloScope_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OscilloScope_FormClosed);
            this.pLBoard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tBtrace)).EndInit();
            this.tCMonitor.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.gBPos.ResumeLayout(false);
            this.gBPos.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gBSpeed.ResumeLayout(false);
            this.gBSpeed.PerformLayout();
            this.gBCurrent.ResumeLayout(false);
            this.gBCurrent.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUSmoothData)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pLBoard;
        private System.Windows.Forms.Timer timerPaint;
        private System.Windows.Forms.ColorDialog cDcolor;
        private System.Windows.Forms.TabControl tCMonitor;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private NewPanel pLPaint;
        private System.Windows.Forms.TrackBar tBtrace;
        private System.Windows.Forms.ListView lVFormat;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ComboBox cBSpeedRatio;
        private System.Windows.Forms.ComboBox cBPositionRatio;
        private System.Windows.Forms.ComboBox cBCurrentRatio;
        private System.Windows.Forms.GroupBox gBPos;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tBPosDeadZone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tBPosD;
        private System.Windows.Forms.TextBox tBPosI;
        private System.Windows.Forms.TextBox tBPosP;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cBAdjustGroup;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tBMaxCurrent;
        private System.Windows.Forms.TextBox tBMaxAcc;
        private System.Windows.Forms.TextBox tBMaxSpeed;
        private System.Windows.Forms.GroupBox gBSpeed;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tBSpeedD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tBSpeedDeadZone;
        private System.Windows.Forms.TextBox tBSpeedP;
        private System.Windows.Forms.TextBox tBSpeedI;
        private System.Windows.Forms.GroupBox gBCurrent;
        private System.Windows.Forms.TextBox tBCurrentI;
        private System.Windows.Forms.TextBox tBCurrentP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown nUSmoothData;
        private System.Windows.Forms.RadioButton rBPointer2;
        private System.Windows.Forms.RadioButton rBPointer1;
        private System.Windows.Forms.CheckBox cBPointer;
        private System.Windows.Forms.Button btnMeasure;
    }
}
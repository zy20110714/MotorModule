﻿namespace ICDIBasic
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbCanFD = new System.Windows.Forms.CheckBox();
            this.cbbHwType = new System.Windows.Forms.ComboBox();
            this.cbbInterrupt = new System.Windows.Forms.ComboBox();
            this.cbbIO = new System.Windows.Forms.ComboBox();
            this.cbbBaudrates = new System.Windows.Forms.ComboBox();
            this.txtBitrate = new System.Windows.Forms.TextBox();
            this.btnHwRefresh = new System.Windows.Forms.Button();
            this.cbbChannel = new System.Windows.Forms.ComboBox();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnRelease = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbbParameter = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnStatus = new System.Windows.Forms.Button();
            this.lbxInfo = new System.Windows.Forms.ListBox();
            this.tMMainFormRefresh = new System.Windows.Forms.Timer(this.components);
            this.tMCheck = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.sBFeedback = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel4 = new System.Windows.Forms.StatusBarPanel();
            this.pLContent = new System.Windows.Forms.Panel();
            this.tBMultiTurn = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cBID = new System.Windows.Forms.ComboBox();
            this.btnOther = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnWave = new System.Windows.Forms.Button();
            this.btnMonitor = new System.Windows.Forms.Button();
            this.btnParameters = new System.Windows.Forms.Button();
            this.pLMain = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).BeginInit();
            this.pLContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chbCanFD);
            this.groupBox1.Controls.Add(this.cbbHwType);
            this.groupBox1.Controls.Add(this.cbbInterrupt);
            this.groupBox1.Controls.Add(this.cbbIO);
            this.groupBox1.Controls.Add(this.cbbBaudrates);
            this.groupBox1.Controls.Add(this.txtBitrate);
            this.groupBox1.Controls.Add(this.btnHwRefresh);
            this.groupBox1.Controls.Add(this.cbbChannel);
            this.groupBox1.Controls.Add(this.btnInit);
            this.groupBox1.Controls.Add(this.btnRelease);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(11, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(0, 60);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Connection ";
            // 
            // chbCanFD
            // 
            this.chbCanFD.Location = new System.Drawing.Point(0, 0);
            this.chbCanFD.Name = "chbCanFD";
            this.chbCanFD.Size = new System.Drawing.Size(104, 24);
            this.chbCanFD.TabIndex = 0;
            // 
            // cbbHwType
            // 
            this.cbbHwType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbHwType.Items.AddRange(new object[] {
            "ISA-82C200",
            "ISA-SJA1000",
            "ISA-PHYTEC",
            "DNG-82C200",
            "DNG-82C200 EPP",
            "DNG-SJA1000",
            "DNG-SJA1000 EPP"});
            this.cbbHwType.Location = new System.Drawing.Point(326, 29);
            this.cbbHwType.Name = "cbbHwType";
            this.cbbHwType.Size = new System.Drawing.Size(120, 20);
            this.cbbHwType.TabIndex = 50;
            this.cbbHwType.SelectedIndexChanged += new System.EventHandler(this.cbbHwType_SelectedIndexChanged);
            // 
            // cbbInterrupt
            // 
            this.cbbInterrupt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbInterrupt.Items.AddRange(new object[] {
            "3",
            "4",
            "5",
            "7",
            "9",
            "10",
            "11",
            "12",
            "15"});
            this.cbbInterrupt.Location = new System.Drawing.Point(513, 29);
            this.cbbInterrupt.Name = "cbbInterrupt";
            this.cbbInterrupt.Size = new System.Drawing.Size(55, 20);
            this.cbbInterrupt.TabIndex = 52;
            // 
            // cbbIO
            // 
            this.cbbIO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbIO.Items.AddRange(new object[] {
            "0100",
            "0120",
            "0140",
            "0200",
            "0220",
            "0240",
            "0260",
            "0278",
            "0280",
            "02A0",
            "02C0",
            "02E0",
            "02E8",
            "02F8",
            "0300",
            "0320",
            "0340",
            "0360",
            "0378",
            "0380",
            "03BC",
            "03E0",
            "03E8",
            "03F8"});
            this.cbbIO.Location = new System.Drawing.Point(452, 29);
            this.cbbIO.Name = "cbbIO";
            this.cbbIO.Size = new System.Drawing.Size(55, 20);
            this.cbbIO.TabIndex = 51;
            // 
            // cbbBaudrates
            // 
            this.cbbBaudrates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBaudrates.Items.AddRange(new object[] {
            "1 MBit/sec",
            "800 kBit/s",
            "500 kBit/sec",
            "250 kBit/sec",
            "125 kBit/sec",
            "100 kBit/sec",
            "95,238 kBit/s",
            "83,333 kBit/s",
            "50 kBit/sec",
            "47,619 kBit/s",
            "33,333 kBit/s",
            "20 kBit/sec",
            "10 kBit/sec",
            "5 kBit/sec"});
            this.cbbBaudrates.Location = new System.Drawing.Point(204, 29);
            this.cbbBaudrates.Name = "cbbBaudrates";
            this.cbbBaudrates.Size = new System.Drawing.Size(116, 20);
            this.cbbBaudrates.TabIndex = 49;
            this.cbbBaudrates.SelectedIndexChanged += new System.EventHandler(this.cbbBaudrates_SelectedIndexChanged);
            // 
            // txtBitrate
            // 
            this.txtBitrate.Location = new System.Drawing.Point(204, 23);
            this.txtBitrate.Multiline = true;
            this.txtBitrate.Name = "txtBitrate";
            this.txtBitrate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBitrate.Size = new System.Drawing.Size(364, 32);
            this.txtBitrate.TabIndex = 48;
            this.txtBitrate.Visible = false;
            // 
            // btnHwRefresh
            // 
            this.btnHwRefresh.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnHwRefresh.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnHwRefresh.Location = new System.Drawing.Point(141, 28);
            this.btnHwRefresh.Name = "btnHwRefresh";
            this.btnHwRefresh.Size = new System.Drawing.Size(57, 21);
            this.btnHwRefresh.TabIndex = 45;
            this.btnHwRefresh.Text = "Refresh";
            this.btnHwRefresh.Click += new System.EventHandler(this.btnHwRefresh_Click);
            // 
            // cbbChannel
            // 
            this.cbbChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbChannel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbChannel.Items.AddRange(new object[] {
            "None",
            "DNG-Channel 1",
            "ISA-Channel 1",
            "ISA-Channel 2",
            "ISA-Channel 3",
            "ISA-Channel 4",
            "ISA-Channel 5",
            "ISA-Channel 6",
            "ISA-Channel 7",
            "ISA-Channel 8",
            "PCC-Channel 1",
            "PCC-Channel 2",
            "PCI-Channel 1",
            "PCI-Channel 2",
            "PCI-Channel 3",
            "PCI-Channel 4",
            "PCI-Channel 5",
            "PCI-Channel 6",
            "PCI-Channel 7",
            "PCI-Channel 8",
            "USB-Channel 1",
            "USB-Channel 2",
            "USB-Channel 3",
            "USB-Channel 4",
            "USB-Channel 5",
            "USB-Channel 6",
            "USB-Channel 7",
            "USB-Channel 8"});
            this.cbbChannel.Location = new System.Drawing.Point(8, 29);
            this.cbbChannel.Name = "cbbChannel";
            this.cbbChannel.Size = new System.Drawing.Size(127, 21);
            this.cbbChannel.TabIndex = 32;
            this.cbbChannel.SelectedIndexChanged += new System.EventHandler(this.cbbChannel_SelectedIndexChanged);
            // 
            // btnInit
            // 
            this.btnInit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInit.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnInit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnInit.Location = new System.Drawing.Point(-65, 10);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(65, 21);
            this.btnInit.TabIndex = 34;
            this.btnInit.Text = "Initialize";
            // 
            // btnRelease
            // 
            this.btnRelease.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRelease.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnRelease.Enabled = false;
            this.btnRelease.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRelease.Location = new System.Drawing.Point(-65, 33);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(65, 21);
            this.btnRelease.TabIndex = 35;
            this.btnRelease.Text = "Release";
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cbbParameter);
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(0, 32);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Configuration Parameters ";
            // 
            // cbbParameter
            // 
            this.cbbParameter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbParameter.FormattingEnabled = true;
            this.cbbParameter.Items.AddRange(new object[] {
            "USB\'s Device Number",
            "USB/PC-Card\'s 5V Power",
            "Auto-reset on BUS-OFF",
            "CAN Listen-Only",
            "Debug\'s Log",
            "Receive Status",
            "CAN Controller Number",
            "Trace File",
            "Channel Identification (USB)",
            "FD Capability",
            "Bit rate Adaptation",
            "Get Bit rate Information",
            "Get Bit rate FD Information",
            "Get CAN Nominal Speed Bit/s",
            "Get CAN Data Speed Bit/s",
            "Get IP Address"});
            this.cbbParameter.Location = new System.Drawing.Point(10, 29);
            this.cbbParameter.Name = "cbbParameter";
            this.cbbParameter.Size = new System.Drawing.Size(217, 20);
            this.cbbParameter.TabIndex = 44;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.btnReset);
            this.groupBox4.Controls.Add(this.btnStatus);
            this.groupBox4.Controls.Add(this.lbxInfo);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox4.Location = new System.Drawing.Point(0, -10);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(0, 68);
            this.groupBox4.TabIndex = 47;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Information";
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Enabled = false;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnReset.Location = new System.Drawing.Point(-65, 44);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(65, 21);
            this.btnReset.TabIndex = 58;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnStatus
            // 
            this.btnStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStatus.Enabled = false;
            this.btnStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnStatus.Location = new System.Drawing.Point(-136, 44);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(65, 21);
            this.btnStatus.TabIndex = 57;
            this.btnStatus.Text = "Status";
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // lbxInfo
            // 
            this.lbxInfo.ItemHeight = 12;
            this.lbxInfo.Location = new System.Drawing.Point(0, 0);
            this.lbxInfo.Name = "lbxInfo";
            this.lbxInfo.Size = new System.Drawing.Size(120, 88);
            this.lbxInfo.TabIndex = 59;
            // 
            // tMMainFormRefresh
            // 
            this.tMMainFormRefresh.Interval = 1000;
            this.tMMainFormRefresh.Tick += new System.EventHandler(this.tMMainFormRefresh_Tick);
            // 
            // tMCheck
            // 
            this.tMCheck.Interval = 2000;
            this.tMCheck.Tick += new System.EventHandler(this.tMCheck_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Location = new System.Drawing.Point(711, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 10);
            this.panel1.TabIndex = 52;
            // 
            // sBFeedback
            // 
            this.sBFeedback.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sBFeedback.Location = new System.Drawing.Point(0, 649);
            this.sBFeedback.Name = "sBFeedback";
            this.sBFeedback.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3,
            this.statusBarPanel4});
            this.sBFeedback.ShowPanels = true;
            this.sBFeedback.Size = new System.Drawing.Size(994, 22);
            this.sBFeedback.TabIndex = 53;
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
            this.statusBarPanel1.Icon = ((System.Drawing.Icon)(resources.GetObject("statusBarPanel1.Icon")));
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Text = "tt1";
            this.statusBarPanel1.Width = 150;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Icon = ((System.Drawing.Icon)(resources.GetObject("statusBarPanel2.Icon")));
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Text = "tt2";
            this.statusBarPanel2.Width = 350;
            // 
            // statusBarPanel3
            // 
            this.statusBarPanel3.Icon = ((System.Drawing.Icon)(resources.GetObject("statusBarPanel3.Icon")));
            this.statusBarPanel3.Name = "statusBarPanel3";
            this.statusBarPanel3.Text = "遨博（北京）智能科技有限公司";
            this.statusBarPanel3.Width = 300;
            // 
            // statusBarPanel4
            // 
            this.statusBarPanel4.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.Raised;
            this.statusBarPanel4.Icon = ((System.Drawing.Icon)(resources.GetObject("statusBarPanel4.Icon")));
            this.statusBarPanel4.Name = "statusBarPanel4";
            this.statusBarPanel4.Text = "tt4";
            this.statusBarPanel4.Width = 160;
            // 
            // pLContent
            // 
            this.pLContent.BackColor = System.Drawing.Color.Tan;
            this.pLContent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pLContent.Controls.Add(this.tBMultiTurn);
            this.pLContent.Controls.Add(this.panel1);
            this.pLContent.Controls.Add(this.panel2);
            this.pLContent.Controls.Add(this.label2);
            this.pLContent.Controls.Add(this.cBID);
            this.pLContent.Controls.Add(this.btnOther);
            this.pLContent.Controls.Add(this.btnRun);
            this.pLContent.Controls.Add(this.btnWave);
            this.pLContent.Controls.Add(this.btnMonitor);
            this.pLContent.Controls.Add(this.btnParameters);
            this.pLContent.Location = new System.Drawing.Point(0, 0);
            this.pLContent.Name = "pLContent";
            this.pLContent.Size = new System.Drawing.Size(997, 35);
            this.pLContent.TabIndex = 54;
            // 
            // tBMultiTurn
            // 
            this.tBMultiTurn.Location = new System.Drawing.Point(644, 5);
            this.tBMultiTurn.Name = "tBMultiTurn";
            this.tBMultiTurn.Size = new System.Drawing.Size(81, 21);
            this.tBMultiTurn.TabIndex = 53;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.Location = new System.Drawing.Point(845, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(26, 28);
            this.panel2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(79, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "驱动器ID";
            // 
            // cBID
            // 
            this.cBID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBID.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cBID.FormattingEnabled = true;
            this.cBID.Location = new System.Drawing.Point(-2, -2);
            this.cBID.Name = "cBID";
            this.cBID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cBID.Size = new System.Drawing.Size(64, 37);
            this.cBID.TabIndex = 2;
            this.cBID.DropDown += new System.EventHandler(this.cBID_DropDown);
            this.cBID.SelectedIndexChanged += new System.EventHandler(this.cBID_SelectedIndexChanged);
            // 
            // btnOther
            // 
            this.btnOther.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOther.BackgroundImage")));
            this.btnOther.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOther.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOther.Location = new System.Drawing.Point(535, -2);
            this.btnOther.Name = "btnOther";
            this.btnOther.Size = new System.Drawing.Size(75, 35);
            this.btnOther.TabIndex = 1;
            this.btnOther.UseVisualStyleBackColor = true;
            // 
            // btnRun
            // 
            this.btnRun.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRun.BackgroundImage")));
            this.btnRun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRun.Location = new System.Drawing.Point(444, -2);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(85, 35);
            this.btnRun.TabIndex = 1;
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnWave
            // 
            this.btnWave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnWave.BackgroundImage")));
            this.btnWave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnWave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnWave.Location = new System.Drawing.Point(348, -2);
            this.btnWave.Name = "btnWave";
            this.btnWave.Size = new System.Drawing.Size(92, 35);
            this.btnWave.TabIndex = 1;
            this.btnWave.UseVisualStyleBackColor = true;
            this.btnWave.Click += new System.EventHandler(this.btnWave_Click);
            // 
            // btnMonitor
            // 
            this.btnMonitor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMonitor.BackgroundImage")));
            this.btnMonitor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMonitor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMonitor.Location = new System.Drawing.Point(254, -2);
            this.btnMonitor.Name = "btnMonitor";
            this.btnMonitor.Size = new System.Drawing.Size(90, 35);
            this.btnMonitor.TabIndex = 1;
            this.btnMonitor.UseVisualStyleBackColor = true;
            // 
            // btnParameters
            // 
            this.btnParameters.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnParameters.BackgroundImage")));
            this.btnParameters.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnParameters.Enabled = false;
            this.btnParameters.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnParameters.Location = new System.Drawing.Point(156, -1);
            this.btnParameters.Name = "btnParameters";
            this.btnParameters.Size = new System.Drawing.Size(94, 35);
            this.btnParameters.TabIndex = 0;
            this.btnParameters.UseVisualStyleBackColor = true;
            this.btnParameters.Click += new System.EventHandler(this.btnParameters_Click);
            // 
            // pLMain
            // 
            this.pLMain.BackColor = System.Drawing.Color.Silver;
            this.pLMain.Location = new System.Drawing.Point(0, 35);
            this.pLMain.Name = "pLMain";
            this.pLMain.Size = new System.Drawing.Size(994, 612);
            this.pLMain.TabIndex = 55;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 671);
            this.Controls.Add(this.pLMain);
            this.Controls.Add(this.pLContent);
            this.Controls.Add(this.sBFeedback);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OR模块调试";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).EndInit();
            this.pLContent.ResumeLayout(false);
            this.pLContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbbChannel;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbbParameter;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox lbxInfo;
        private System.Windows.Forms.Timer tMMainFormRefresh;
        private System.Windows.Forms.Button btnHwRefresh;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.Timer tMCheck;
        private System.Windows.Forms.ComboBox cbbHwType;
        private System.Windows.Forms.ComboBox cbbInterrupt;
        private System.Windows.Forms.ComboBox cbbIO;
        private System.Windows.Forms.ComboBox cbbBaudrates;
        private System.Windows.Forms.CheckBox chbCanFD;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusBar sBFeedback;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel2;
        private System.Windows.Forms.StatusBarPanel statusBarPanel3;
        private System.Windows.Forms.StatusBarPanel statusBarPanel4;
        private System.Windows.Forms.Panel pLContent;
        private System.Windows.Forms.Button btnMonitor;
        private System.Windows.Forms.Button btnParameters;
        private System.Windows.Forms.ComboBox cBID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOther;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnWave;
        private System.Windows.Forms.Panel pLMain;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tBMultiTurn;
        private System.Windows.Forms.TextBox txtBitrate;
    }
}


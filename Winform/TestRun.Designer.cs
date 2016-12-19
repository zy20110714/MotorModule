﻿namespace ICDIBasic
{
    partial class TestRun
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestRun));
            this.tMManualControl = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.pLName = new System.Windows.Forms.Panel();
            this.picMinimized = new System.Windows.Forms.PictureBox();
            this.pBExit = new System.Windows.Forms.PictureBox();
            this.tMRefreshtBCurrent = new System.Windows.Forms.Timer(this.components);
            this.btnSetZeroPosition = new System.Windows.Forms.Button();
            this.btnClearError = new System.Windows.Forms.Button();
            this.gBManually = new System.Windows.Forms.GroupBox();
            this.gBStepMovement = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tBControlInterval = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnReverse = new System.Windows.Forms.Button();
            this.lLOffset = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tBStep = new System.Windows.Forms.TextBox();
            this.btnForward = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tBCurrent = new System.Windows.Forms.TextBox();
            this.btnRandomMotion = new System.Windows.Forms.Button();
            this.btnReturnToZero = new System.Windows.Forms.Button();
            this.cBSymmetry = new System.Windows.Forms.CheckBox();
            this.btnEnManCtrl = new System.Windows.Forms.Button();
            this.tBManual = new System.Windows.Forms.TrackBar();
            this.tBMax = new System.Windows.Forms.TextBox();
            this.tBMin = new System.Windows.Forms.TextBox();
            this.gBWaveFormProperty = new System.Windows.Forms.GroupBox();
            this.pBWaveForm = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cBWaveForm = new System.Windows.Forms.ComboBox();
            this.tBAmplitude = new System.Windows.Forms.TextBox();
            this.tBFrequency = new System.Windows.Forms.TextBox();
            this.tBBias = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.pBMode = new System.Windows.Forms.PictureBox();
            this.lLUnit = new System.Windows.Forms.Label();
            this.cBControlMode = new System.Windows.Forms.ComboBox();
            this.pLName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimized)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBExit)).BeginInit();
            this.gBManually.SuspendLayout();
            this.gBStepMovement.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBManual)).BeginInit();
            this.gBWaveFormProperty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBWaveForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBMode)).BeginInit();
            this.SuspendLayout();
            // 
            // tMManualControl
            // 
            this.tMManualControl.Tick += new System.EventHandler(this.tMManualControl_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(120, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 33);
            this.label2.TabIndex = 0;
            this.label2.Text = "试运行";
            // 
            // pLName
            // 
            this.pLName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pLName.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pLName.Controls.Add(this.picMinimized);
            this.pLName.Controls.Add(this.label2);
            this.pLName.Controls.Add(this.pBExit);
            this.pLName.Location = new System.Drawing.Point(0, 0);
            this.pLName.Margin = new System.Windows.Forms.Padding(0);
            this.pLName.Name = "pLName";
            this.pLName.Size = new System.Drawing.Size(384, 50);
            this.pLName.TabIndex = 5;
            this.pLName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pLName_MouseDown);
            this.pLName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pLName_MouseMove);
            this.pLName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pLName_MouseUp);
            // 
            // picMinimized
            // 
            this.picMinimized.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picMinimized.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picMinimized.BackgroundImage")));
            this.picMinimized.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picMinimized.InitialImage = null;
            this.picMinimized.Location = new System.Drawing.Point(283, 0);
            this.picMinimized.Margin = new System.Windows.Forms.Padding(0);
            this.picMinimized.Name = "picMinimized";
            this.picMinimized.Size = new System.Drawing.Size(50, 50);
            this.picMinimized.TabIndex = 1;
            this.picMinimized.TabStop = false;
            this.picMinimized.Click += new System.EventHandler(this.picMinimized_Click);
            // 
            // pBExit
            // 
            this.pBExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pBExit.BackgroundImage")));
            this.pBExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pBExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.pBExit.Location = new System.Drawing.Point(334, 0);
            this.pBExit.Margin = new System.Windows.Forms.Padding(0);
            this.pBExit.Name = "pBExit";
            this.pBExit.Size = new System.Drawing.Size(50, 50);
            this.pBExit.TabIndex = 0;
            this.pBExit.TabStop = false;
            this.pBExit.Click += new System.EventHandler(this.pBExit_Click);
            // 
            // tMRefreshtBCurrent
            // 
            this.tMRefreshtBCurrent.Interval = 1000;
            this.tMRefreshtBCurrent.Tick += new System.EventHandler(this.tMRefreshtBCurrent_Tick);
            // 
            // btnSetZeroPosition
            // 
            this.btnSetZeroPosition.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSetZeroPosition.Location = new System.Drawing.Point(62, 687);
            this.btnSetZeroPosition.Name = "btnSetZeroPosition";
            this.btnSetZeroPosition.Size = new System.Drawing.Size(120, 50);
            this.btnSetZeroPosition.TabIndex = 58;
            this.btnSetZeroPosition.Text = "设置零点";
            this.btnSetZeroPosition.UseVisualStyleBackColor = true;
            this.btnSetZeroPosition.Click += new System.EventHandler(this.btnSetZeroPosition_Click);
            // 
            // btnClearError
            // 
            this.btnClearError.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClearError.Location = new System.Drawing.Point(202, 687);
            this.btnClearError.Name = "btnClearError";
            this.btnClearError.Size = new System.Drawing.Size(120, 50);
            this.btnClearError.TabIndex = 59;
            this.btnClearError.Text = "清错使能";
            this.btnClearError.UseVisualStyleBackColor = true;
            this.btnClearError.Click += new System.EventHandler(this.btnClearError_Click);
            // 
            // gBManually
            // 
            this.gBManually.BackColor = System.Drawing.Color.White;
            this.gBManually.Controls.Add(this.gBStepMovement);
            this.gBManually.Controls.Add(this.groupBox1);
            this.gBManually.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gBManually.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gBManually.Location = new System.Drawing.Point(12, 368);
            this.gBManually.Name = "gBManually";
            this.gBManually.Size = new System.Drawing.Size(368, 313);
            this.gBManually.TabIndex = 4;
            this.gBManually.TabStop = false;
            this.gBManually.Text = "手动控制";
            // 
            // gBStepMovement
            // 
            this.gBStepMovement.Controls.Add(this.label13);
            this.gBStepMovement.Controls.Add(this.tBControlInterval);
            this.gBStepMovement.Controls.Add(this.label3);
            this.gBStepMovement.Controls.Add(this.btnReverse);
            this.gBStepMovement.Controls.Add(this.lLOffset);
            this.gBStepMovement.Controls.Add(this.label9);
            this.gBStepMovement.Controls.Add(this.label8);
            this.gBStepMovement.Controls.Add(this.tBStep);
            this.gBStepMovement.Controls.Add(this.btnForward);
            this.gBStepMovement.Location = new System.Drawing.Point(368, 30);
            this.gBStepMovement.Name = "gBStepMovement";
            this.gBStepMovement.Size = new System.Drawing.Size(390, 155);
            this.gBStepMovement.TabIndex = 9;
            this.gBStepMovement.TabStop = false;
            this.gBStepMovement.Text = "连续运动";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(187, 128);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 21);
            this.label13.TabIndex = 20;
            this.label13.Text = "ms";
            // 
            // tBControlInterval
            // 
            this.tBControlInterval.Location = new System.Drawing.Point(117, 118);
            this.tBControlInterval.Name = "tBControlInterval";
            this.tBControlInterval.Size = new System.Drawing.Size(62, 31);
            this.tBControlInterval.TabIndex = 19;
            this.tBControlInterval.Text = "100";
            this.tBControlInterval.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBControlInterval_KeyDown);
            this.tBControlInterval.Leave += new System.EventHandler(this.tBControlInterval_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 21);
            this.label3.TabIndex = 18;
            this.label3.Text = "控制间隔";
            // 
            // btnReverse
            // 
            this.btnReverse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReverse.BackgroundImage")));
            this.btnReverse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReverse.Location = new System.Drawing.Point(11, 37);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(50, 50);
            this.btnReverse.TabIndex = 0;
            this.btnReverse.UseVisualStyleBackColor = true;
            this.btnReverse.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnReverse_MouseDown);
            this.btnReverse.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnReverse_MouseUp);
            // 
            // lLOffset
            // 
            this.lLOffset.AutoSize = true;
            this.lLOffset.Location = new System.Drawing.Point(282, 66);
            this.lLOffset.Name = "lLOffset";
            this.lLOffset.Size = new System.Drawing.Size(0, 21);
            this.lLOffset.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(261, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 21);
            this.label9.TabIndex = 2;
            this.label9.Text = "控制量";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(79, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 21);
            this.label8.TabIndex = 1;
            this.label8.Text = "步长";
            // 
            // tBStep
            // 
            this.tBStep.Location = new System.Drawing.Point(83, 54);
            this.tBStep.Name = "tBStep";
            this.tBStep.Size = new System.Drawing.Size(55, 31);
            this.tBStep.TabIndex = 0;
            this.tBStep.Text = "0.1";
            this.tBStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBStep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBStep_KeyDown);
            this.tBStep.Leave += new System.EventHandler(this.tBStep_Leave);
            // 
            // btnForward
            // 
            this.btnForward.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnForward.BackgroundImage")));
            this.btnForward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnForward.Location = new System.Drawing.Point(169, 37);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(50, 50);
            this.btnForward.TabIndex = 0;
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnReverse_MouseDown);
            this.btnForward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnReverse_MouseUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tBCurrent);
            this.groupBox1.Controls.Add(this.btnRandomMotion);
            this.groupBox1.Controls.Add(this.btnReturnToZero);
            this.groupBox1.Controls.Add(this.cBSymmetry);
            this.groupBox1.Controls.Add(this.btnEnManCtrl);
            this.groupBox1.Controls.Add(this.tBManual);
            this.groupBox1.Controls.Add(this.tBMax);
            this.groupBox1.Controls.Add(this.tBMin);
            this.groupBox1.Location = new System.Drawing.Point(6, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 276);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "零位偏移";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "偏移最小/°";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(141, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "目标位置";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(251, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "偏移最大/°";
            // 
            // tBCurrent
            // 
            this.tBCurrent.Location = new System.Drawing.Point(125, 54);
            this.tBCurrent.Name = "tBCurrent";
            this.tBCurrent.Size = new System.Drawing.Size(100, 31);
            this.tBCurrent.TabIndex = 11;
            this.tBCurrent.Text = "0";
            this.tBCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBCurrent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBCurrent_KeyDown);
            this.tBCurrent.Leave += new System.EventHandler(this.tBCurrent_Leave);
            // 
            // btnRandomMotion
            // 
            this.btnRandomMotion.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRandomMotion.Location = new System.Drawing.Point(224, 167);
            this.btnRandomMotion.Margin = new System.Windows.Forms.Padding(0);
            this.btnRandomMotion.Name = "btnRandomMotion";
            this.btnRandomMotion.Size = new System.Drawing.Size(110, 50);
            this.btnRandomMotion.TabIndex = 7;
            this.btnRandomMotion.Text = "开始随机";
            this.btnRandomMotion.UseVisualStyleBackColor = true;
            this.btnRandomMotion.Click += new System.EventHandler(this.btnRandomMotion_Click);
            // 
            // btnReturnToZero
            // 
            this.btnReturnToZero.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReturnToZero.Location = new System.Drawing.Point(116, 167);
            this.btnReturnToZero.Margin = new System.Windows.Forms.Padding(0);
            this.btnReturnToZero.Name = "btnReturnToZero";
            this.btnReturnToZero.Size = new System.Drawing.Size(106, 50);
            this.btnReturnToZero.TabIndex = 6;
            this.btnReturnToZero.Text = "回零";
            this.btnReturnToZero.UseVisualStyleBackColor = true;
            this.btnReturnToZero.Click += new System.EventHandler(this.btnReturnToZero_Click);
            // 
            // cBSymmetry
            // 
            this.cBSymmetry.AutoSize = true;
            this.cBSymmetry.Checked = true;
            this.cBSymmetry.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBSymmetry.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cBSymmetry.Location = new System.Drawing.Point(14, 237);
            this.cBSymmetry.Name = "cBSymmetry";
            this.cBSymmetry.Size = new System.Drawing.Size(155, 25);
            this.cBSymmetry.TabIndex = 8;
            this.cBSymmetry.Text = "零位偏移对称";
            this.cBSymmetry.UseVisualStyleBackColor = true;
            this.cBSymmetry.CheckedChanged += new System.EventHandler(this.cBSymmetry_CheckedChanged);
            // 
            // btnEnManCtrl
            // 
            this.btnEnManCtrl.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEnManCtrl.Location = new System.Drawing.Point(3, 167);
            this.btnEnManCtrl.Margin = new System.Windows.Forms.Padding(0);
            this.btnEnManCtrl.Name = "btnEnManCtrl";
            this.btnEnManCtrl.Size = new System.Drawing.Size(110, 50);
            this.btnEnManCtrl.TabIndex = 4;
            this.btnEnManCtrl.Text = "开始";
            this.btnEnManCtrl.UseVisualStyleBackColor = true;
            this.btnEnManCtrl.Click += new System.EventHandler(this.btnEnManCtrl_Click);
            // 
            // tBManual
            // 
            this.tBManual.AutoSize = false;
            this.tBManual.BackColor = System.Drawing.SystemColors.Control;
            this.tBManual.Location = new System.Drawing.Point(3, 91);
            this.tBManual.Margin = new System.Windows.Forms.Padding(0);
            this.tBManual.Maximum = 100;
            this.tBManual.Name = "tBManual";
            this.tBManual.Size = new System.Drawing.Size(330, 50);
            this.tBManual.TabIndex = 3;
            this.tBManual.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tBManual.Value = 50;
            this.tBManual.Scroll += new System.EventHandler(this.tBManual_Scroll);
            this.tBManual.Enter += new System.EventHandler(this.tBManual_Scroll);
            // 
            // tBMax
            // 
            this.tBMax.Location = new System.Drawing.Point(269, 54);
            this.tBMax.Name = "tBMax";
            this.tBMax.Size = new System.Drawing.Size(55, 31);
            this.tBMax.TabIndex = 2;
            this.tBMax.Text = "30";
            this.tBMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBMax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBMax_KeyDown);
            this.tBMax.Leave += new System.EventHandler(this.tBMax_Leave);
            // 
            // tBMin
            // 
            this.tBMin.Location = new System.Drawing.Point(25, 52);
            this.tBMin.Name = "tBMin";
            this.tBMin.Size = new System.Drawing.Size(55, 31);
            this.tBMin.TabIndex = 1;
            this.tBMin.Text = "-30";
            this.tBMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBMin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBMin_KeyDown);
            this.tBMin.Leave += new System.EventHandler(this.tBMin_Leave);
            // 
            // gBWaveFormProperty
            // 
            this.gBWaveFormProperty.BackColor = System.Drawing.Color.LightSteelBlue;
            this.gBWaveFormProperty.Controls.Add(this.pBWaveForm);
            this.gBWaveFormProperty.Controls.Add(this.pictureBox3);
            this.gBWaveFormProperty.Controls.Add(this.pictureBox1);
            this.gBWaveFormProperty.Controls.Add(this.pictureBox2);
            this.gBWaveFormProperty.Controls.Add(this.cBWaveForm);
            this.gBWaveFormProperty.Controls.Add(this.tBAmplitude);
            this.gBWaveFormProperty.Controls.Add(this.tBFrequency);
            this.gBWaveFormProperty.Controls.Add(this.tBBias);
            this.gBWaveFormProperty.Controls.Add(this.btnConfirm);
            this.gBWaveFormProperty.Controls.Add(this.btnClearAll);
            this.gBWaveFormProperty.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gBWaveFormProperty.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gBWaveFormProperty.Location = new System.Drawing.Point(12, 112);
            this.gBWaveFormProperty.Name = "gBWaveFormProperty";
            this.gBWaveFormProperty.Size = new System.Drawing.Size(330, 250);
            this.gBWaveFormProperty.TabIndex = 2;
            this.gBWaveFormProperty.TabStop = false;
            this.gBWaveFormProperty.Text = "波形发生器";
            // 
            // pBWaveForm
            // 
            this.pBWaveForm.Image = ((System.Drawing.Image)(resources.GetObject("pBWaveForm.Image")));
            this.pBWaveForm.Location = new System.Drawing.Point(17, 30);
            this.pBWaveForm.Name = "pBWaveForm";
            this.pBWaveForm.Size = new System.Drawing.Size(35, 35);
            this.pBWaveForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBWaveForm.TabIndex = 4;
            this.pBWaveForm.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(185, 30);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(35, 35);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(17, 113);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(185, 113);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 35);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // cBWaveForm
            // 
            this.cBWaveForm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cBWaveForm.FormattingEnabled = true;
            this.cBWaveForm.Items.AddRange(new object[] {
            "衡值",
            "方波",
            "三角波",
            "正弦波"});
            this.cBWaveForm.Location = new System.Drawing.Point(60, 36);
            this.cBWaveForm.Name = "cBWaveForm";
            this.cBWaveForm.Size = new System.Drawing.Size(82, 24);
            this.cBWaveForm.TabIndex = 1;
            this.cBWaveForm.SelectedIndexChanged += new System.EventHandler(this.cBWaveform_SelectedIndexChanged);
            // 
            // tBAmplitude
            // 
            this.tBAmplitude.Location = new System.Drawing.Point(226, 34);
            this.tBAmplitude.Name = "tBAmplitude";
            this.tBAmplitude.Size = new System.Drawing.Size(82, 31);
            this.tBAmplitude.TabIndex = 2;
            this.tBAmplitude.Text = "0";
            this.tBAmplitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBAmplitude.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBAmplitude_KeyDown);
            this.tBAmplitude.Leave += new System.EventHandler(this.tBAmplitude_Leave);
            // 
            // tBFrequency
            // 
            this.tBFrequency.Location = new System.Drawing.Point(60, 117);
            this.tBFrequency.Name = "tBFrequency";
            this.tBFrequency.Size = new System.Drawing.Size(82, 31);
            this.tBFrequency.TabIndex = 1;
            this.tBFrequency.Text = "0.5";
            this.tBFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBFrequency.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBFrequency_KeyDown);
            this.tBFrequency.Leave += new System.EventHandler(this.tBFrequency_Leave);
            // 
            // tBBias
            // 
            this.tBBias.Location = new System.Drawing.Point(226, 117);
            this.tBBias.Name = "tBBias";
            this.tBBias.Size = new System.Drawing.Size(82, 31);
            this.tBBias.TabIndex = 2;
            this.tBBias.Text = "0";
            this.tBBias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBBias.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBBias_KeyDown);
            this.tBBias.Leave += new System.EventHandler(this.tBBias_Leave);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConfirm.BackgroundImage")));
            this.btnConfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnConfirm.Location = new System.Drawing.Point(77, 168);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(50, 50);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClearAll.BackgroundImage")));
            this.btnClearAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClearAll.Location = new System.Drawing.Point(193, 169);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(50, 50);
            this.btnClearAll.TabIndex = 3;
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // pBMode
            // 
            this.pBMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pBMode.Image = ((System.Drawing.Image)(resources.GetObject("pBMode.Image")));
            this.pBMode.Location = new System.Drawing.Point(292, 56);
            this.pBMode.Name = "pBMode";
            this.pBMode.Size = new System.Drawing.Size(50, 50);
            this.pBMode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBMode.TabIndex = 5;
            this.pBMode.TabStop = false;
            this.pBMode.Tag = "1";
            this.pBMode.Click += new System.EventHandler(this.pBMode_Click);
            // 
            // lLUnit
            // 
            this.lLUnit.AutoSize = true;
            this.lLUnit.BackColor = System.Drawing.Color.White;
            this.lLUnit.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lLUnit.Location = new System.Drawing.Point(193, 68);
            this.lLUnit.Name = "lLUnit";
            this.lLUnit.Size = new System.Drawing.Size(53, 23);
            this.lLUnit.TabIndex = 0;
            this.lLUnit.Text = "Unit:";
            // 
            // cBControlMode
            // 
            this.cBControlMode.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.cBControlMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBControlMode.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cBControlMode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cBControlMode.FormattingEnabled = true;
            this.cBControlMode.Items.AddRange(new object[] {
            "开环占空比",
            "电流控制",
            "速度控制",
            "位置控制"});
            this.cBControlMode.Location = new System.Drawing.Point(9, 62);
            this.cBControlMode.Margin = new System.Windows.Forms.Padding(0);
            this.cBControlMode.Name = "cBControlMode";
            this.cBControlMode.Size = new System.Drawing.Size(150, 32);
            this.cBControlMode.TabIndex = 1;
            this.cBControlMode.SelectedIndexChanged += new System.EventHandler(this.cBControlMode_SelectedIndexChanged);
            // 
            // TestRun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(385, 748);
            this.Controls.Add(this.gBManually);
            this.Controls.Add(this.gBWaveFormProperty);
            this.Controls.Add(this.pBMode);
            this.Controls.Add(this.lLUnit);
            this.Controls.Add(this.cBControlMode);
            this.Controls.Add(this.btnClearError);
            this.Controls.Add(this.btnSetZeroPosition);
            this.Controls.Add(this.pLName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TestRun";
            this.Text = "试运行";
            this.TopMost = true;
            this.Enter += new System.EventHandler(this.TestRun_Enter);
            this.Leave += new System.EventHandler(this.TestRun_Leave);
            this.pLName.ResumeLayout(false);
            this.pLName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimized)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBExit)).EndInit();
            this.gBManually.ResumeLayout(false);
            this.gBStepMovement.ResumeLayout(false);
            this.gBStepMovement.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBManual)).EndInit();
            this.gBWaveFormProperty.ResumeLayout(false);
            this.gBWaveFormProperty.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBWaveForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBMode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer tMManualControl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pLName;
        private System.Windows.Forms.PictureBox pBExit;
        private System.Windows.Forms.PictureBox picMinimized;
        private System.Windows.Forms.Timer tMRefreshtBCurrent;
        private System.Windows.Forms.Button btnSetZeroPosition;
        private System.Windows.Forms.Button btnClearError;
        private System.Windows.Forms.GroupBox gBManually;
        private System.Windows.Forms.GroupBox gBStepMovement;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tBControlInterval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnReverse;
        private System.Windows.Forms.Label lLOffset;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tBStep;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tBCurrent;
        public System.Windows.Forms.Button btnRandomMotion;
        private System.Windows.Forms.Button btnReturnToZero;
        private System.Windows.Forms.CheckBox cBSymmetry;
        public System.Windows.Forms.Button btnEnManCtrl;
        private System.Windows.Forms.TrackBar tBManual;
        private System.Windows.Forms.TextBox tBMax;
        private System.Windows.Forms.TextBox tBMin;
        private System.Windows.Forms.GroupBox gBWaveFormProperty;
        private System.Windows.Forms.PictureBox pBWaveForm;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox cBWaveForm;
        private System.Windows.Forms.TextBox tBAmplitude;
        private System.Windows.Forms.TextBox tBFrequency;
        private System.Windows.Forms.TextBox tBBias;
        private System.Windows.Forms.Button btnConfirm;
        public System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.PictureBox pBMode;
        private System.Windows.Forms.Label lLUnit;
        private System.Windows.Forms.ComboBox cBControlMode;
    }
}
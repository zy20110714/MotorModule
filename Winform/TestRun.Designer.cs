namespace ICDIBasic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestRun));
            this.cBWaveForm = new System.Windows.Forms.ComboBox();
            this.cBControlMode = new System.Windows.Forms.ComboBox();
            this.gBWaveFormProperty = new System.Windows.Forms.GroupBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pBWaveForm = new System.Windows.Forms.PictureBox();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.tBBias = new System.Windows.Forms.TextBox();
            this.tBAmplitude = new System.Windows.Forms.TextBox();
            this.tBFrequency = new System.Windows.Forms.TextBox();
            this.btnEnable = new System.Windows.Forms.Button();
            this.pLEnable = new System.Windows.Forms.Panel();
            this.pBMode = new System.Windows.Forms.PictureBox();
            this.gBManually = new System.Windows.Forms.GroupBox();
            this.tBStep = new System.Windows.Forms.TextBox();
            this.tBCur = new System.Windows.Forms.TextBox();
            this.btnReverse = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.tBManual = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tBMax = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tBMin = new System.Windows.Forms.TextBox();
            this.lLUnit = new System.Windows.Forms.Label();
            this.pLName = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pBExit = new System.Windows.Forms.PictureBox();
            this.pBSetUp = new System.Windows.Forms.PictureBox();
            this.gBWaveFormProperty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBWaveForm)).BeginInit();
            this.pLEnable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBMode)).BeginInit();
            this.gBManually.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBManual)).BeginInit();
            this.pLName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBSetUp)).BeginInit();
            this.SuspendLayout();
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
            // cBControlMode
            // 
            this.cBControlMode.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.cBControlMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBControlMode.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cBControlMode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cBControlMode.FormattingEnabled = true;
            this.cBControlMode.Items.AddRange(new object[] {
            "开环占空比",
            "电流控制",
            "速度控制",
            "位置控制"});
            this.cBControlMode.Location = new System.Drawing.Point(6, 13);
            this.cBControlMode.Name = "cBControlMode";
            this.cBControlMode.Size = new System.Drawing.Size(125, 29);
            this.cBControlMode.TabIndex = 1;
            this.cBControlMode.SelectedIndexChanged += new System.EventHandler(this.cBControlMode_SelectedIndexChanged);
            // 
            // gBWaveFormProperty
            // 
            this.gBWaveFormProperty.BackColor = System.Drawing.Color.SlateGray;
            this.gBWaveFormProperty.Controls.Add(this.pictureBox3);
            this.gBWaveFormProperty.Controls.Add(this.pictureBox2);
            this.gBWaveFormProperty.Controls.Add(this.pictureBox1);
            this.gBWaveFormProperty.Controls.Add(this.pBWaveForm);
            this.gBWaveFormProperty.Controls.Add(this.btnClearAll);
            this.gBWaveFormProperty.Controls.Add(this.btnConfirm);
            this.gBWaveFormProperty.Controls.Add(this.tBBias);
            this.gBWaveFormProperty.Controls.Add(this.tBAmplitude);
            this.gBWaveFormProperty.Controls.Add(this.tBFrequency);
            this.gBWaveFormProperty.Controls.Add(this.cBWaveForm);
            this.gBWaveFormProperty.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gBWaveFormProperty.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gBWaveFormProperty.Location = new System.Drawing.Point(6, 59);
            this.gBWaveFormProperty.Name = "gBWaveFormProperty";
            this.gBWaveFormProperty.Size = new System.Drawing.Size(330, 225);
            this.gBWaveFormProperty.TabIndex = 2;
            this.gBWaveFormProperty.TabStop = false;
            this.gBWaveFormProperty.Text = "波形发生器";
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
            // tBBias
            // 
            this.tBBias.Location = new System.Drawing.Point(226, 117);
            this.tBBias.Name = "tBBias";
            this.tBBias.Size = new System.Drawing.Size(82, 31);
            this.tBBias.TabIndex = 2;
            this.tBBias.Text = "0";
            this.tBBias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBBias.TextChanged += new System.EventHandler(this.tBBias_TextChanged);
            this.tBBias.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBBias_KeyDown);
            // 
            // tBAmplitude
            // 
            this.tBAmplitude.Location = new System.Drawing.Point(226, 34);
            this.tBAmplitude.Name = "tBAmplitude";
            this.tBAmplitude.Size = new System.Drawing.Size(82, 31);
            this.tBAmplitude.TabIndex = 2;
            this.tBAmplitude.Text = "0";
            this.tBAmplitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBAmplitude.TextChanged += new System.EventHandler(this.tBAmplitude_TextChanged);
            this.tBAmplitude.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBAmplitude_KeyDown);
            // 
            // tBFrequency
            // 
            this.tBFrequency.Location = new System.Drawing.Point(60, 117);
            this.tBFrequency.Name = "tBFrequency";
            this.tBFrequency.Size = new System.Drawing.Size(82, 31);
            this.tBFrequency.TabIndex = 1;
            this.tBFrequency.Text = "0.5";
            this.tBFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBFrequency.TextChanged += new System.EventHandler(this.tBFrequency_TextChanged);
            this.tBFrequency.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBFrequency_KeyDown);
            // 
            // btnEnable
            // 
            this.btnEnable.BackColor = System.Drawing.Color.Green;
            this.btnEnable.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEnable.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEnable.Location = new System.Drawing.Point(238, 53);
            this.btnEnable.Name = "btnEnable";
            this.btnEnable.Size = new System.Drawing.Size(343, 43);
            this.btnEnable.TabIndex = 3;
            this.btnEnable.Text = "使能开启";
            this.btnEnable.UseVisualStyleBackColor = false;
            this.btnEnable.Click += new System.EventHandler(this.btnEnable_Click);
            // 
            // pLEnable
            // 
            this.pLEnable.BackColor = System.Drawing.Color.White;
            this.pLEnable.Controls.Add(this.pBMode);
            this.pLEnable.Controls.Add(this.gBManually);
            this.pLEnable.Controls.Add(this.gBWaveFormProperty);
            this.pLEnable.Controls.Add(this.cBControlMode);
            this.pLEnable.Controls.Add(this.lLUnit);
            this.pLEnable.Location = new System.Drawing.Point(238, 98);
            this.pLEnable.Name = "pLEnable";
            this.pLEnable.Size = new System.Drawing.Size(343, 510);
            this.pLEnable.TabIndex = 4;
            // 
            // pBMode
            // 
            this.pBMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pBMode.Image = ((System.Drawing.Image)(resources.GetObject("pBMode.Image")));
            this.pBMode.Location = new System.Drawing.Point(286, 4);
            this.pBMode.Name = "pBMode";
            this.pBMode.Size = new System.Drawing.Size(50, 50);
            this.pBMode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBMode.TabIndex = 5;
            this.pBMode.TabStop = false;
            this.pBMode.Tag = "1";
            this.pBMode.Click += new System.EventHandler(this.pBMode_Click);
            // 
            // gBManually
            // 
            this.gBManually.BackColor = System.Drawing.Color.White;
            this.gBManually.Controls.Add(this.tBStep);
            this.gBManually.Controls.Add(this.tBCur);
            this.gBManually.Controls.Add(this.btnReverse);
            this.gBManually.Controls.Add(this.btnForward);
            this.gBManually.Controls.Add(this.tBManual);
            this.gBManually.Controls.Add(this.label5);
            this.gBManually.Controls.Add(this.label3);
            this.gBManually.Controls.Add(this.label6);
            this.gBManually.Controls.Add(this.tBMax);
            this.gBManually.Controls.Add(this.label7);
            this.gBManually.Controls.Add(this.tBMin);
            this.gBManually.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gBManually.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gBManually.Location = new System.Drawing.Point(6, 293);
            this.gBManually.Name = "gBManually";
            this.gBManually.Size = new System.Drawing.Size(330, 210);
            this.gBManually.TabIndex = 4;
            this.gBManually.TabStop = false;
            this.gBManually.Text = "手动控制";
            // 
            // tBStep
            // 
            this.tBStep.Location = new System.Drawing.Point(143, 79);
            this.tBStep.Name = "tBStep";
            this.tBStep.Size = new System.Drawing.Size(55, 31);
            this.tBStep.TabIndex = 5;
            this.tBStep.Text = "0";
            this.tBStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBStep.TextChanged += new System.EventHandler(this.tBStep_TextChanged);
            // 
            // tBCur
            // 
            this.tBCur.Location = new System.Drawing.Point(143, 155);
            this.tBCur.Name = "tBCur";
            this.tBCur.Size = new System.Drawing.Size(55, 31);
            this.tBCur.TabIndex = 2;
            this.tBCur.Text = "0";
            this.tBCur.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBCur.TextChanged += new System.EventHandler(this.tBBias_TextChanged);
            // 
            // btnReverse
            // 
            this.btnReverse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReverse.BackgroundImage")));
            this.btnReverse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReverse.Location = new System.Drawing.Point(25, 34);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(75, 75);
            this.btnReverse.TabIndex = 4;
            this.btnReverse.UseVisualStyleBackColor = true;
            this.btnReverse.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnReverse_MouseDown);
            this.btnReverse.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnReverse_MouseUp);
            // 
            // btnForward
            // 
            this.btnForward.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnForward.BackgroundImage")));
            this.btnForward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnForward.Location = new System.Drawing.Point(244, 35);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(75, 75);
            this.btnForward.TabIndex = 4;
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnReverse_MouseDown);
            this.btnForward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnReverse_MouseUp);
            // 
            // tBManual
            // 
            this.tBManual.AutoSize = false;
            this.tBManual.BackColor = System.Drawing.SystemColors.Control;
            this.tBManual.Enabled = false;
            this.tBManual.Location = new System.Drawing.Point(0, 192);
            this.tBManual.Maximum = 100;
            this.tBManual.Name = "tBManual";
            this.tBManual.Size = new System.Drawing.Size(330, 20);
            this.tBManual.TabIndex = 3;
            this.tBManual.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tBManual.Value = 50;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(36, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Min";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(152, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Step";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(143, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "Current";
            // 
            // tBMax
            // 
            this.tBMax.Location = new System.Drawing.Point(264, 155);
            this.tBMax.Name = "tBMax";
            this.tBMax.Size = new System.Drawing.Size(55, 31);
            this.tBMax.TabIndex = 2;
            this.tBMax.Text = "0";
            this.tBMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBMax.TextChanged += new System.EventHandler(this.tBBias_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(273, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 19);
            this.label7.TabIndex = 0;
            this.label7.Text = "Max";
            // 
            // tBMin
            // 
            this.tBMin.Location = new System.Drawing.Point(25, 154);
            this.tBMin.Name = "tBMin";
            this.tBMin.Size = new System.Drawing.Size(55, 31);
            this.tBMin.TabIndex = 2;
            this.tBMin.Text = "0";
            this.tBMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBMin.TextChanged += new System.EventHandler(this.tBBias_TextChanged);
            // 
            // lLUnit
            // 
            this.lLUnit.AutoSize = true;
            this.lLUnit.BackColor = System.Drawing.Color.White;
            this.lLUnit.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lLUnit.Location = new System.Drawing.Point(177, 18);
            this.lLUnit.Name = "lLUnit";
            this.lLUnit.Size = new System.Drawing.Size(45, 21);
            this.lLUnit.TabIndex = 0;
            this.lLUnit.Text = "Unit:";
            // 
            // pLName
            // 
            this.pLName.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pLName.Controls.Add(this.label2);
            this.pLName.Controls.Add(this.pBExit);
            this.pLName.Controls.Add(this.pBSetUp);
            this.pLName.Location = new System.Drawing.Point(0, 0);
            this.pLName.Name = "pLName";
            this.pLName.Size = new System.Drawing.Size(590, 52);
            this.pLName.TabIndex = 5;
            this.pLName.Click += new System.EventHandler(this.pLName_Click);
            this.pLName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pLName_MouseDown);
            this.pLName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pLName_MouseMove);
            this.pLName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pLName_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("隶书", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(233, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "试运行";
            // 
            // pBExit
            // 
            this.pBExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pBExit.BackgroundImage")));
            this.pBExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pBExit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pBExit.Location = new System.Drawing.Point(538, 0);
            this.pBExit.Name = "pBExit";
            this.pBExit.Size = new System.Drawing.Size(52, 52);
            this.pBExit.TabIndex = 0;
            this.pBExit.TabStop = false;
            this.pBExit.Click += new System.EventHandler(this.pBExit_Click);
            // 
            // pBSetUp
            // 
            this.pBSetUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pBSetUp.BackgroundImage")));
            this.pBSetUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pBSetUp.Location = new System.Drawing.Point(0, 0);
            this.pBSetUp.Name = "pBSetUp";
            this.pBSetUp.Size = new System.Drawing.Size(52, 52);
            this.pBSetUp.TabIndex = 0;
            this.pBSetUp.TabStop = false;
            // 
            // TestRun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 610);
            this.Controls.Add(this.pLName);
            this.Controls.Add(this.pLEnable);
            this.Controls.Add(this.btnEnable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TestRun";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TestRun";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TestRun_FormClosed);
            this.gBWaveFormProperty.ResumeLayout(false);
            this.gBWaveFormProperty.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBWaveForm)).EndInit();
            this.pLEnable.ResumeLayout(false);
            this.pLEnable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBMode)).EndInit();
            this.gBManually.ResumeLayout(false);
            this.gBManually.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBManual)).EndInit();
            this.pLName.ResumeLayout(false);
            this.pLName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBSetUp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cBWaveForm;
        private System.Windows.Forms.ComboBox cBControlMode;
        private System.Windows.Forms.GroupBox gBWaveFormProperty;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TextBox tBBias;
        private System.Windows.Forms.TextBox tBAmplitude;
        private System.Windows.Forms.TextBox tBFrequency;
        private System.Windows.Forms.Button btnEnable;
        private System.Windows.Forms.Panel pLEnable;
        private System.Windows.Forms.TrackBar tBManual;
        private System.Windows.Forms.TextBox tBMin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tBMax;
        private System.Windows.Forms.TextBox tBCur;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gBManually;
        private System.Windows.Forms.PictureBox pBMode;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pBWaveForm;
        private System.Windows.Forms.Panel pLName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pBExit;
        private System.Windows.Forms.PictureBox pBSetUp;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.TextBox tBStep;
        private System.Windows.Forms.Button btnReverse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lLUnit;
    }
}
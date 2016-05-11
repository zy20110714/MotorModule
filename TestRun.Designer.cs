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
            this.components = new System.ComponentModel.Container();
            this.lLWaveForm = new System.Windows.Forms.Label();
            this.cBWaveform = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cBControlMode = new System.Windows.Forms.ComboBox();
            this.gBWaveFormProperty = new System.Windows.Forms.GroupBox();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.tBSteps = new System.Windows.Forms.TextBox();
            this.tBBias = new System.Windows.Forms.TextBox();
            this.tBAmplitude = new System.Windows.Forms.TextBox();
            this.tBFrequency = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEnable = new System.Windows.Forms.Button();
            this.pLEnable = new System.Windows.Forms.Panel();
            this.tBManual = new System.Windows.Forms.TrackBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.tBMin = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tBCur = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tBMax = new System.Windows.Forms.TextBox();
            this.gBWaveFormProperty.SuspendLayout();
            this.pLEnable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBManual)).BeginInit();
            this.SuspendLayout();
            // 
            // lLWaveForm
            // 
            this.lLWaveForm.AutoSize = true;
            this.lLWaveForm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lLWaveForm.Location = new System.Drawing.Point(3, 15);
            this.lLWaveForm.Name = "lLWaveForm";
            this.lLWaveForm.Size = new System.Drawing.Size(72, 16);
            this.lLWaveForm.TabIndex = 0;
            this.lLWaveForm.Text = "波形模式";
            // 
            // cBWaveform
            // 
            this.cBWaveform.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cBWaveform.FormattingEnabled = true;
            this.cBWaveform.Items.AddRange(new object[] {
            "衡值",
            "方波",
            "三角波",
            "正弦波"});
            this.cBWaveform.Location = new System.Drawing.Point(81, 12);
            this.cBWaveform.Name = "cBWaveform";
            this.cBWaveform.Size = new System.Drawing.Size(72, 24);
            this.cBWaveform.TabIndex = 1;
            this.cBWaveform.SelectedIndexChanged += new System.EventHandler(this.cBWaveform_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(155, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "控制模式";
            // 
            // cBControlMode
            // 
            this.cBControlMode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cBControlMode.FormattingEnabled = true;
            this.cBControlMode.Items.AddRange(new object[] {
            "无",
            "开环占空比",
            "电流控制",
            "速度控制",
            "位置控制"});
            this.cBControlMode.Location = new System.Drawing.Point(233, 12);
            this.cBControlMode.Name = "cBControlMode";
            this.cBControlMode.Size = new System.Drawing.Size(92, 24);
            this.cBControlMode.TabIndex = 1;
            this.cBControlMode.SelectedIndexChanged += new System.EventHandler(this.cBControlMode_SelectedIndexChanged);
            // 
            // gBWaveFormProperty
            // 
            this.gBWaveFormProperty.Controls.Add(this.btnClearAll);
            this.gBWaveFormProperty.Controls.Add(this.btnConfirm);
            this.gBWaveFormProperty.Controls.Add(this.tBSteps);
            this.gBWaveFormProperty.Controls.Add(this.tBBias);
            this.gBWaveFormProperty.Controls.Add(this.tBAmplitude);
            this.gBWaveFormProperty.Controls.Add(this.tBFrequency);
            this.gBWaveFormProperty.Controls.Add(this.label4);
            this.gBWaveFormProperty.Controls.Add(this.label3);
            this.gBWaveFormProperty.Controls.Add(this.label2);
            this.gBWaveFormProperty.Location = new System.Drawing.Point(6, 53);
            this.gBWaveFormProperty.Name = "gBWaveFormProperty";
            this.gBWaveFormProperty.Size = new System.Drawing.Size(315, 191);
            this.gBWaveFormProperty.TabIndex = 2;
            this.gBWaveFormProperty.TabStop = false;
            this.gBWaveFormProperty.Text = "波形属性";
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(214, 75);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(75, 23);
            this.btnClearAll.TabIndex = 3;
            this.btnClearAll.Text = "清零";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(214, 28);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // tBSteps
            // 
            this.tBSteps.Location = new System.Drawing.Point(214, 128);
            this.tBSteps.Name = "tBSteps";
            this.tBSteps.Size = new System.Drawing.Size(75, 21);
            this.tBSteps.TabIndex = 2;
            this.tBSteps.Text = "0.01";
            this.tBSteps.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBSteps.TextChanged += new System.EventHandler(this.tBSteps_TextChanged);
            // 
            // tBBias
            // 
            this.tBBias.Location = new System.Drawing.Point(53, 128);
            this.tBBias.Name = "tBBias";
            this.tBBias.Size = new System.Drawing.Size(75, 21);
            this.tBBias.TabIndex = 2;
            this.tBBias.Text = "0";
            this.tBBias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBBias.TextChanged += new System.EventHandler(this.tBBias_TextChanged);
            this.tBBias.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBBias_KeyDown);
            // 
            // tBAmplitude
            // 
            this.tBAmplitude.Location = new System.Drawing.Point(52, 77);
            this.tBAmplitude.Name = "tBAmplitude";
            this.tBAmplitude.Size = new System.Drawing.Size(75, 21);
            this.tBAmplitude.TabIndex = 2;
            this.tBAmplitude.Text = "0";
            this.tBAmplitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBAmplitude.TextChanged += new System.EventHandler(this.tBAmplitude_TextChanged);
            this.tBAmplitude.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBAmplitude_KeyDown);
            // 
            // tBFrequency
            // 
            this.tBFrequency.Location = new System.Drawing.Point(53, 30);
            this.tBFrequency.Name = "tBFrequency";
            this.tBFrequency.Size = new System.Drawing.Size(74, 21);
            this.tBFrequency.TabIndex = 1;
            this.tBFrequency.Text = "0.5";
            this.tBFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBFrequency.TextChanged += new System.EventHandler(this.tBFrequency_TextChanged);
            this.tBFrequency.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBFrequency_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(6, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "偏置";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(6, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "幅值";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(6, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "频率";
            // 
            // btnEnable
            // 
            this.btnEnable.BackColor = System.Drawing.Color.Green;
            this.btnEnable.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEnable.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEnable.Location = new System.Drawing.Point(246, 13);
            this.btnEnable.Name = "btnEnable";
            this.btnEnable.Size = new System.Drawing.Size(326, 43);
            this.btnEnable.TabIndex = 3;
            this.btnEnable.Text = "使能开启";
            this.btnEnable.UseVisualStyleBackColor = false;
            this.btnEnable.Click += new System.EventHandler(this.btnEnable_Click);
            // 
            // pLEnable
            // 
            this.pLEnable.Controls.Add(this.tBManual);
            this.pLEnable.Controls.Add(this.lLWaveForm);
            this.pLEnable.Controls.Add(this.label1);
            this.pLEnable.Controls.Add(this.tBMax);
            this.pLEnable.Controls.Add(this.tBCur);
            this.pLEnable.Controls.Add(this.tBMin);
            this.pLEnable.Controls.Add(this.gBWaveFormProperty);
            this.pLEnable.Controls.Add(this.cBWaveform);
            this.pLEnable.Controls.Add(this.cBControlMode);
            this.pLEnable.Controls.Add(this.label7);
            this.pLEnable.Controls.Add(this.label6);
            this.pLEnable.Controls.Add(this.label5);
            this.pLEnable.Location = new System.Drawing.Point(238, 71);
            this.pLEnable.Name = "pLEnable";
            this.pLEnable.Size = new System.Drawing.Size(334, 353);
            this.pLEnable.TabIndex = 4;
            // 
            // tBManual
            // 
            this.tBManual.Location = new System.Drawing.Point(8, 305);
            this.tBManual.Maximum = 100;
            this.tBManual.Name = "tBManual";
            this.tBManual.Size = new System.Drawing.Size(302, 45);
            this.tBManual.TabIndex = 3;
            this.tBManual.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tBManual.Value = 50;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(5, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "最小值";
            // 
            // tBMin
            // 
            this.tBMin.Location = new System.Drawing.Point(58, 284);
            this.tBMin.Name = "tBMin";
            this.tBMin.Size = new System.Drawing.Size(47, 21);
            this.tBMin.TabIndex = 2;
            this.tBMin.Text = "0";
            this.tBMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBMin.TextChanged += new System.EventHandler(this.tBBias_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(111, 286);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "当前值";
            // 
            // tBCur
            // 
            this.tBCur.Location = new System.Drawing.Point(164, 284);
            this.tBCur.Name = "tBCur";
            this.tBCur.Size = new System.Drawing.Size(47, 21);
            this.tBCur.TabIndex = 2;
            this.tBCur.Text = "0";
            this.tBCur.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBCur.TextChanged += new System.EventHandler(this.tBBias_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(217, 286);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "最大值";
            // 
            // tBMax
            // 
            this.tBMax.Location = new System.Drawing.Point(270, 284);
            this.tBMax.Name = "tBMax";
            this.tBMax.Size = new System.Drawing.Size(47, 21);
            this.tBMax.TabIndex = 2;
            this.tBMax.Text = "0";
            this.tBMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBMax.TextChanged += new System.EventHandler(this.tBBias_TextChanged);
            // 
            // TestRun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 581);
            this.Controls.Add(this.pLEnable);
            this.Controls.Add(this.btnEnable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TestRun";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TestRun";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TestRun_FormClosed);
            this.gBWaveFormProperty.ResumeLayout(false);
            this.gBWaveFormProperty.PerformLayout();
            this.pLEnable.ResumeLayout(false);
            this.pLEnable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBManual)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lLWaveForm;
        private System.Windows.Forms.ComboBox cBWaveform;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cBControlMode;
        private System.Windows.Forms.GroupBox gBWaveFormProperty;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TextBox tBSteps;
        private System.Windows.Forms.TextBox tBBias;
        private System.Windows.Forms.TextBox tBAmplitude;
        private System.Windows.Forms.TextBox tBFrequency;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEnable;
        private System.Windows.Forms.Panel pLEnable;
        private System.Windows.Forms.TrackBar tBManual;
        private System.Windows.Forms.TextBox tBMin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox tBMax;
        private System.Windows.Forms.TextBox tBCur;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}
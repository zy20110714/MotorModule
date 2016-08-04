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
            this.gBMonitorError.SuspendLayout();
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
            this.gBMonitorError.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gBMonitorError.Location = new System.Drawing.Point(158, 72);
            this.gBMonitorError.Name = "gBMonitorError";
            this.gBMonitorError.Size = new System.Drawing.Size(390, 250);
            this.gBMonitorError.TabIndex = 11;
            this.gBMonitorError.TabStop = false;
            this.gBMonitorError.Text = "编码器寄存器操作";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(53, 73);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(85, 21);
            this.label15.TabIndex = 21;
            this.label15.Text = "地址+00";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(50, 218);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(105, 21);
            this.label14.TabIndex = 20;
            this.label14.Text = "地址+数据";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(302, 95);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 21);
            this.label12.TabIndex = 19;
            this.label12.Text = "ms";
            // 
            // tBInterval
            // 
            this.tBInterval.Location = new System.Drawing.Point(234, 92);
            this.tBInterval.Name = "tBInterval";
            this.tBInterval.Size = new System.Drawing.Size(62, 31);
            this.tBInterval.TabIndex = 18;
            this.tBInterval.Text = "1000";
            this.tBInterval.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBInterval_KeyDown);
            this.tBInterval.Leave += new System.EventHandler(this.tBInterval_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(134, 92);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 21);
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
            this.btnMonitorStart2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMonitorStart2.Location = new System.Drawing.Point(138, 168);
            this.btnMonitorStart2.Margin = new System.Windows.Forms.Padding(0);
            this.btnMonitorStart2.Name = "btnMonitorStart2";
            this.btnMonitorStart2.Size = new System.Drawing.Size(106, 50);
            this.btnMonitorStart2.TabIndex = 13;
            this.btnMonitorStart2.Text = "写入";
            this.btnMonitorStart2.UseVisualStyleBackColor = true;
            this.btnMonitorStart2.Click += new System.EventHandler(this.btnMonitorStart2_Click);
            // 
            // tBRegisterNumber2
            // 
            this.tBRegisterNumber2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBRegisterNumber2.Location = new System.Drawing.Point(79, 173);
            this.tBRegisterNumber2.Name = "tBRegisterNumber2";
            this.tBRegisterNumber2.Size = new System.Drawing.Size(49, 31);
            this.tBRegisterNumber2.TabIndex = 15;
            this.tBRegisterNumber2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBRegisterNumber2_KeyDown);
            this.tBRegisterNumber2.Leave += new System.EventHandler(this.tBRegisterNumber2_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(41, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 21);
            this.label4.TabIndex = 16;
            this.label4.Text = "0x";
            // 
            // Monitor76
            // 
            this.Monitor76.AutoSize = true;
            this.Monitor76.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Monitor76.Location = new System.Drawing.Point(261, 44);
            this.Monitor76.Name = "Monitor76";
            this.Monitor76.Size = new System.Drawing.Size(73, 21);
            this.Monitor76.TabIndex = 9;
            this.Monitor76.Text = "未启动";
            // 
            // btnMonitorStart
            // 
            this.btnMonitorStart.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMonitorStart.Location = new System.Drawing.Point(138, 27);
            this.btnMonitorStart.Margin = new System.Windows.Forms.Padding(0);
            this.btnMonitorStart.Name = "btnMonitorStart";
            this.btnMonitorStart.Size = new System.Drawing.Size(106, 50);
            this.btnMonitorStart.TabIndex = 8;
            this.btnMonitorStart.Text = "开始查询";
            this.btnMonitorStart.UseVisualStyleBackColor = true;
            this.btnMonitorStart.Click += new System.EventHandler(this.btnMonitorStart_Click);
            // 
            // tBRegisterNumber
            // 
            this.tBRegisterNumber.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBRegisterNumber.Location = new System.Drawing.Point(79, 39);
            this.tBRegisterNumber.Name = "tBRegisterNumber";
            this.tBRegisterNumber.Size = new System.Drawing.Size(49, 31);
            this.tBRegisterNumber.TabIndex = 10;
            this.tBRegisterNumber.Text = "7700";
            this.tBRegisterNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBRegisterNumber_KeyDown);
            this.tBRegisterNumber.Leave += new System.EventHandler(this.tBRegisterNumber_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(41, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 21);
            this.label1.TabIndex = 11;
            this.label1.Text = "0x";
            // 
            // Monitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 537);
            this.Controls.Add(this.gBMonitorError);
            this.Name = "Monitor";
            this.Text = "监视器";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Monitor_FormClosed);
            this.gBMonitorError.ResumeLayout(false);
            this.gBMonitorError.PerformLayout();
            this.ResumeLayout(false);

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
    }
}
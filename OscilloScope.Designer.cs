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
            this.cBSpeedRatio = new System.Windows.Forms.ComboBox();
            this.cBPositionRatio = new System.Windows.Forms.ComboBox();
            this.cBCurrentRatio = new System.Windows.Forms.ComboBox();
            this.tBtrace = new System.Windows.Forms.TrackBar();
            this.timerPaint = new System.Windows.Forms.Timer(this.components);
            this.cDcolor = new System.Windows.Forms.ColorDialog();
            this.tCMonitor = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.lVFormat = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pLPaint = new ICDIBasic.NewPanel();
            this.pLBoard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBtrace)).BeginInit();
            this.tCMonitor.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pLBoard
            // 
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
            this.tCMonitor.Size = new System.Drawing.Size(833, 150);
            this.tCMonitor.TabIndex = 1;
            this.tCMonitor.SelectedIndexChanged += new System.EventHandler(this.tCMonitor_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(825, 115);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "测量项目";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(825, 115);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "纵轴/横轴";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 31);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(825, 115);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "指针";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.lVFormat);
            this.tabPage4.Location = new System.Drawing.Point(4, 31);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(825, 115);
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
            this.lVFormat.Size = new System.Drawing.Size(825, 115);
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
            // OscilloScope
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 571);
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
    }
}
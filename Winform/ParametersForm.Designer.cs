namespace ICDIBasic
{
    partial class ParametersForm
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
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("分类0（系统信息）");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("分类1（系统状态）");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("分类2（电机相关）");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("分类3（控制目标值）");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("分类4（控制限制值）");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("分类5（三闭环参数S）");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("分类6（三闭环参数M）");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("分类7（三闭环参数L）");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("节点8（刹车相关）");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("节点9（示波器相关）");
            this.panel1 = new System.Windows.Forms.Panel();
            this.tVParam = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.lVParam = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pLDescribe = new System.Windows.Forms.Panel();
            this.pLExplain = new System.Windows.Forms.Panel();
            this.cBHexDisplay = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tBSystem = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.tBUnused = new System.Windows.Forms.TextBox();
            this.tBReadOnly = new System.Windows.Forms.TextBox();
            this.tBExplain = new System.Windows.Forms.TextBox();
            this.pLExplain2 = new System.Windows.Forms.Panel();
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.pLExplain.SuspendLayout();
            this.pLExplain2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(844, 35);
            this.panel1.TabIndex = 0;
            // 
            // tVParam
            // 
            this.tVParam.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tVParam.Location = new System.Drawing.Point(0, 65);
            this.tVParam.Name = "tVParam";
            treeNode11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            treeNode11.Checked = true;
            treeNode11.ForeColor = System.Drawing.Color.Black;
            treeNode11.Name = "节点0";
            treeNode11.Tag = "tt";
            treeNode11.Text = "分类0（系统信息）";
            treeNode12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            treeNode12.ForeColor = System.Drawing.Color.Black;
            treeNode12.Name = "节点1";
            treeNode12.Text = "分类1（系统状态）";
            treeNode13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            treeNode13.ForeColor = System.Drawing.Color.Black;
            treeNode13.Name = "节点2";
            treeNode13.Text = "分类2（电机相关）";
            treeNode14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            treeNode14.ForeColor = System.Drawing.Color.Black;
            treeNode14.Name = "节点3";
            treeNode14.Text = "分类3（控制目标值）";
            treeNode15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            treeNode15.ForeColor = System.Drawing.Color.Black;
            treeNode15.Name = "节点4";
            treeNode15.Text = "分类4（控制限制值）";
            treeNode16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            treeNode16.ForeColor = System.Drawing.Color.Black;
            treeNode16.Name = "节点5";
            treeNode16.Text = "分类5（三闭环参数S）";
            treeNode17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            treeNode17.ForeColor = System.Drawing.Color.Black;
            treeNode17.Name = "节点6";
            treeNode17.Text = "分类6（三闭环参数M）";
            treeNode18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            treeNode18.ForeColor = System.Drawing.Color.Black;
            treeNode18.Name = "节点0";
            treeNode18.Text = "分类7（三闭环参数L）";
            treeNode19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            treeNode19.ForeColor = System.Drawing.Color.Black;
            treeNode19.Name = "节点8";
            treeNode19.Text = "节点8（刹车相关）";
            treeNode20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            treeNode20.ForeColor = System.Drawing.Color.Black;
            treeNode20.Name = "节点9";
            treeNode20.Text = "节点9（示波器相关）";
            this.tVParam.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19,
            treeNode20});
            this.tVParam.Size = new System.Drawing.Size(200, 516);
            this.tVParam.TabIndex = 1;
            this.tVParam.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tVParam_AfterSelect);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(44, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "参数一览";
            // 
            // lVParam
            // 
            this.lVParam.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.lVParam.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lVParam.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lVParam.FullRowSelect = true;
            this.lVParam.GridLines = true;
            this.lVParam.Location = new System.Drawing.Point(205, 131);
            this.lVParam.MultiSelect = false;
            this.lVParam.Name = "lVParam";
            this.lVParam.Size = new System.Drawing.Size(639, 304);
            this.lVParam.TabIndex = 3;
            this.lVParam.UseCompatibleStateImageBehavior = false;
            this.lVParam.View = System.Windows.Forms.View.Details;
            this.lVParam.SelectedIndexChanged += new System.EventHandler(this.lVParam_SelectedIndexChanged);
            this.lVParam.DoubleClick += new System.EventHandler(this.lVParam_DoubleClick);
            this.lVParam.MouseLeave += new System.EventHandler(this.lVParam_MouseLeave);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "分类";
            this.columnHeader1.Width = 55;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "编号";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 55;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "参数名称";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "范围";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 135;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "设定值";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 120;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "单位";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pLDescribe
            // 
            this.pLDescribe.Location = new System.Drawing.Point(206, 38);
            this.pLDescribe.Name = "pLDescribe";
            this.pLDescribe.Size = new System.Drawing.Size(638, 87);
            this.pLDescribe.TabIndex = 4;
            this.pLDescribe.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pLExplain2_MouseClick);
            // 
            // pLExplain
            // 
            this.pLExplain.Controls.Add(this.cBHexDisplay);
            this.pLExplain.Controls.Add(this.checkBox1);
            this.pLExplain.Controls.Add(this.textBox4);
            this.pLExplain.Controls.Add(this.textBox2);
            this.pLExplain.Controls.Add(this.tBSystem);
            this.pLExplain.Controls.Add(this.textBox3);
            this.pLExplain.Controls.Add(this.tBUnused);
            this.pLExplain.Controls.Add(this.tBReadOnly);
            this.pLExplain.Location = new System.Drawing.Point(3, 79);
            this.pLExplain.Name = "pLExplain";
            this.pLExplain.Size = new System.Drawing.Size(639, 63);
            this.pLExplain.TabIndex = 5;
            // 
            // cBHexDisplay
            // 
            this.cBHexDisplay.AutoSize = true;
            this.cBHexDisplay.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cBHexDisplay.Location = new System.Drawing.Point(420, 36);
            this.cBHexDisplay.Name = "cBHexDisplay";
            this.cBHexDisplay.Size = new System.Drawing.Size(158, 24);
            this.cBHexDisplay.TabIndex = 1;
            this.cBHexDisplay.Text = "显示 - 16进制";
            this.cBHexDisplay.UseVisualStyleBackColor = true;
            this.cBHexDisplay.CheckedChanged += new System.EventHandler(this.cBHexDisplay_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox1.Location = new System.Drawing.Point(420, 9);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(188, 24);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "可超范围设定许可";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.White;
            this.textBox4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox4.Location = new System.Drawing.Point(267, 31);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(126, 30);
            this.textBox4.TabIndex = 0;
            this.textBox4.Text = "正常";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.DimGray;
            this.textBox2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox2.Location = new System.Drawing.Point(134, 31);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(126, 30);
            this.textBox2.TabIndex = 0;
            this.textBox2.Text = "其他";
            // 
            // tBSystem
            // 
            this.tBSystem.BackColor = System.Drawing.Color.Pink;
            this.tBSystem.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBSystem.Location = new System.Drawing.Point(1, 31);
            this.tBSystem.Name = "tBSystem";
            this.tBSystem.ReadOnly = true;
            this.tBSystem.Size = new System.Drawing.Size(126, 30);
            this.tBSystem.TabIndex = 0;
            this.tBSystem.Text = "系统";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.Yellow;
            this.textBox3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox3.Location = new System.Drawing.Point(266, 0);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(127, 30);
            this.textBox3.TabIndex = 0;
            this.textBox3.Text = "复位后有效";
            // 
            // tBUnused
            // 
            this.tBUnused.BackColor = System.Drawing.Color.Silver;
            this.tBUnused.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBUnused.Location = new System.Drawing.Point(133, 0);
            this.tBUnused.Name = "tBUnused";
            this.tBUnused.ReadOnly = true;
            this.tBUnused.Size = new System.Drawing.Size(127, 30);
            this.tBUnused.TabIndex = 0;
            this.tBUnused.Text = "未使用";
            // 
            // tBReadOnly
            // 
            this.tBReadOnly.BackColor = System.Drawing.Color.Orange;
            this.tBReadOnly.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBReadOnly.Location = new System.Drawing.Point(0, 0);
            this.tBReadOnly.Name = "tBReadOnly";
            this.tBReadOnly.ReadOnly = true;
            this.tBReadOnly.Size = new System.Drawing.Size(127, 30);
            this.tBReadOnly.TabIndex = 0;
            this.tBReadOnly.Text = "只读";
            // 
            // tBExplain
            // 
            this.tBExplain.BackColor = System.Drawing.Color.White;
            this.tBExplain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tBExplain.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBExplain.Location = new System.Drawing.Point(3, 3);
            this.tBExplain.Multiline = true;
            this.tBExplain.Name = "tBExplain";
            this.tBExplain.ReadOnly = true;
            this.tBExplain.Size = new System.Drawing.Size(633, 57);
            this.tBExplain.TabIndex = 0;
            // 
            // pLExplain2
            // 
            this.pLExplain2.Controls.Add(this.tBExplain);
            this.pLExplain2.Controls.Add(this.pLExplain);
            this.pLExplain2.Location = new System.Drawing.Point(205, 431);
            this.pLExplain2.Name = "pLExplain2";
            this.pLExplain2.Size = new System.Drawing.Size(639, 150);
            this.pLExplain2.TabIndex = 6;
            this.pLExplain2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pLExplain2_MouseClick);
            // 
            // timerUpdate
            // 
            this.timerUpdate.Interval = 1000;
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // ParametersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 581);
            this.Controls.Add(this.pLExplain2);
            this.Controls.Add(this.pLDescribe);
            this.Controls.Add(this.lVParam);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tVParam);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ParametersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Parameters";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ParametersForm_FormClosed);
            this.pLExplain.ResumeLayout(false);
            this.pLExplain.PerformLayout();
            this.pLExplain2.ResumeLayout(false);
            this.pLExplain2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView tVParam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lVParam;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Panel pLDescribe;
        private System.Windows.Forms.Panel pLExplain;
        private System.Windows.Forms.TextBox tBExplain;
        private System.Windows.Forms.CheckBox cBHexDisplay;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox tBSystem;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox tBUnused;
        private System.Windows.Forms.TextBox tBReadOnly;
        public System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Panel pLExplain2;
        private System.Windows.Forms.Timer timerUpdate;
    }
}
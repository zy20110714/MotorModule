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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParametersForm));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("分类0（系统信息）");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("分类1（系统状态）");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("分类2（电机相关）");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("分类3（控制目标值）");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("分类4（控制限制值）");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("分类5（三闭环参数S）");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("分类6（三闭环参数M）");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("分类7（三闭环参数L）");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("节点8（刹车相关）");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("节点9（示波器相关）");
            this.pLName = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pBExit = new System.Windows.Forms.PictureBox();
            this.pBSetUp = new System.Windows.Forms.PictureBox();
            this.tVParam = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.pLDescribe = new System.Windows.Forms.Panel();
            this.btnSetZeroPosition = new System.Windows.Forms.Button();
            this.btnClearError = new System.Windows.Forms.Button();
            this.btnFlash = new System.Windows.Forms.Button();
            this.btnCalculator = new System.Windows.Forms.Button();
            this.btnCompare = new System.Windows.Forms.Button();
            this.btnInitialize = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
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
            this.cBParametersSource = new System.Windows.Forms.ComboBox();
            this.oFParaPath = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogParaPath = new System.Windows.Forms.SaveFileDialog();
            this.lVParam = new ICDIBasic.NewListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pLName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBSetUp)).BeginInit();
            this.pLDescribe.SuspendLayout();
            this.pLExplain.SuspendLayout();
            this.pLExplain2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pLName
            // 
            this.pLName.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pLName.Controls.Add(this.label2);
            this.pLName.Controls.Add(this.pBExit);
            this.pLName.Controls.Add(this.pBSetUp);
            this.pLName.Location = new System.Drawing.Point(0, 0);
            this.pLName.Name = "pLName";
            this.pLName.Size = new System.Drawing.Size(926, 52);
            this.pLName.TabIndex = 0;
            this.pLName.Click += new System.EventHandler(this.pLName_Click);
            this.pLName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pLName_MouseDown);
            this.pLName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pLName_MouseMove);
            this.pLName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pLName_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(362, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "参数设置";
            // 
            // pBExit
            // 
            this.pBExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pBExit.BackgroundImage")));
            this.pBExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pBExit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pBExit.Location = new System.Drawing.Point(874, 0);
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
            // tVParam
            // 
            this.tVParam.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tVParam.Location = new System.Drawing.Point(0, 90);
            this.tVParam.Name = "tVParam";
            treeNode1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            treeNode1.Checked = true;
            treeNode1.ForeColor = System.Drawing.Color.Black;
            treeNode1.Name = "节点0";
            treeNode1.Tag = "tt";
            treeNode1.Text = "分类0（系统信息）";
            treeNode2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            treeNode2.ForeColor = System.Drawing.Color.Black;
            treeNode2.Name = "节点1";
            treeNode2.Text = "分类1（系统状态）";
            treeNode3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            treeNode3.ForeColor = System.Drawing.Color.Black;
            treeNode3.Name = "节点2";
            treeNode3.Text = "分类2（电机相关）";
            treeNode4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            treeNode4.ForeColor = System.Drawing.Color.Black;
            treeNode4.Name = "节点3";
            treeNode4.Text = "分类3（控制目标值）";
            treeNode5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            treeNode5.ForeColor = System.Drawing.Color.Black;
            treeNode5.Name = "节点4";
            treeNode5.Text = "分类4（控制限制值）";
            treeNode6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            treeNode6.ForeColor = System.Drawing.Color.Black;
            treeNode6.Name = "节点5";
            treeNode6.Text = "分类5（三闭环参数S）";
            treeNode7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            treeNode7.ForeColor = System.Drawing.Color.Black;
            treeNode7.Name = "节点6";
            treeNode7.Text = "分类6（三闭环参数M）";
            treeNode8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            treeNode8.ForeColor = System.Drawing.Color.Black;
            treeNode8.Name = "节点0";
            treeNode8.Text = "分类7（三闭环参数L）";
            treeNode9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            treeNode9.ForeColor = System.Drawing.Color.Black;
            treeNode9.Name = "节点8";
            treeNode9.Text = "节点8（刹车相关）";
            treeNode10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            treeNode10.ForeColor = System.Drawing.Color.Black;
            treeNode10.Name = "节点9";
            treeNode10.Text = "节点9（示波器相关）";
            this.tVParam.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10});
            this.tVParam.Size = new System.Drawing.Size(245, 452);
            this.tVParam.TabIndex = 1;
            this.tVParam.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tVParam_AfterSelect);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(41, 382);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "参数一览";
            // 
            // pLDescribe
            // 
            this.pLDescribe.Controls.Add(this.btnSetZeroPosition);
            this.pLDescribe.Controls.Add(this.btnClearError);
            this.pLDescribe.Controls.Add(this.btnFlash);
            this.pLDescribe.Controls.Add(this.btnCalculator);
            this.pLDescribe.Controls.Add(this.btnCompare);
            this.pLDescribe.Controls.Add(this.btnInitialize);
            this.pLDescribe.Controls.Add(this.btnSave);
            this.pLDescribe.Location = new System.Drawing.Point(251, 55);
            this.pLDescribe.Name = "pLDescribe";
            this.pLDescribe.Size = new System.Drawing.Size(675, 55);
            this.pLDescribe.TabIndex = 4;
            // 
            // btnSetZeroPosition
            // 
            this.btnSetZeroPosition.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSetZeroPosition.Location = new System.Drawing.Point(484, 3);
            this.btnSetZeroPosition.Name = "btnSetZeroPosition";
            this.btnSetZeroPosition.Size = new System.Drawing.Size(101, 51);
            this.btnSetZeroPosition.TabIndex = 8;
            this.btnSetZeroPosition.Text = "当前位置\r\n设为零点";
            this.btnSetZeroPosition.UseVisualStyleBackColor = true;
            this.btnSetZeroPosition.Click += new System.EventHandler(this.btnSetZeroPosition_Click);
            // 
            // btnClearError
            // 
            this.btnClearError.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClearError.Location = new System.Drawing.Point(375, 13);
            this.btnClearError.Name = "btnClearError";
            this.btnClearError.Size = new System.Drawing.Size(87, 29);
            this.btnClearError.TabIndex = 9;
            this.btnClearError.Text = "清错使能";
            this.btnClearError.UseVisualStyleBackColor = true;
            this.btnClearError.Click += new System.EventHandler(this.btnClearError_Click);
            // 
            // btnFlash
            // 
            this.btnFlash.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFlash.BackgroundImage")));
            this.btnFlash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFlash.FlatAppearance.BorderSize = 0;
            this.btnFlash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFlash.Location = new System.Drawing.Point(602, 2);
            this.btnFlash.Name = "btnFlash";
            this.btnFlash.Size = new System.Drawing.Size(70, 50);
            this.btnFlash.TabIndex = 0;
            this.btnFlash.UseVisualStyleBackColor = true;
            this.btnFlash.Click += new System.EventHandler(this.btnFlash_Click);
            // 
            // btnCalculator
            // 
            this.btnCalculator.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCalculator.BackgroundImage")));
            this.btnCalculator.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCalculator.FlatAppearance.BorderSize = 0;
            this.btnCalculator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalculator.Location = new System.Drawing.Point(221, 4);
            this.btnCalculator.Name = "btnCalculator";
            this.btnCalculator.Size = new System.Drawing.Size(67, 50);
            this.btnCalculator.TabIndex = 0;
            this.btnCalculator.UseVisualStyleBackColor = true;
            this.btnCalculator.Click += new System.EventHandler(this.btnCalculator_Click);
            // 
            // btnCompare
            // 
            this.btnCompare.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCompare.BackgroundImage")));
            this.btnCompare.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCompare.FlatAppearance.BorderSize = 0;
            this.btnCompare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompare.Location = new System.Drawing.Point(150, 4);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(65, 50);
            this.btnCompare.TabIndex = 0;
            this.btnCompare.UseVisualStyleBackColor = true;
            // 
            // btnInitialize
            // 
            this.btnInitialize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnInitialize.BackgroundImage")));
            this.btnInitialize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnInitialize.Enabled = false;
            this.btnInitialize.FlatAppearance.BorderSize = 0;
            this.btnInitialize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInitialize.Location = new System.Drawing.Point(79, 3);
            this.btnInitialize.Name = "btnInitialize";
            this.btnInitialize.Size = new System.Drawing.Size(65, 50);
            this.btnInitialize.TabIndex = 0;
            this.btnInitialize.UseVisualStyleBackColor = true;
            this.btnInitialize.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(294, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 50);
            this.btnSave.TabIndex = 0;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.pLExplain.Size = new System.Drawing.Size(666, 63);
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
            this.tBReadOnly.BackColor = System.Drawing.Color.SteelBlue;
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
            this.tBExplain.Size = new System.Drawing.Size(666, 57);
            this.tBExplain.TabIndex = 0;
            // 
            // pLExplain2
            // 
            this.pLExplain2.Controls.Add(this.tBExplain);
            this.pLExplain2.Controls.Add(this.pLExplain);
            this.pLExplain2.Location = new System.Drawing.Point(251, 549);
            this.pLExplain2.Name = "pLExplain2";
            this.pLExplain2.Size = new System.Drawing.Size(672, 150);
            this.pLExplain2.TabIndex = 6;
            // 
            // timerUpdate
            // 
            this.timerUpdate.Interval = 1000;
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // cBParametersSource
            // 
            this.cBParametersSource.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cBParametersSource.FormattingEnabled = true;
            this.cBParametersSource.Items.AddRange(new object[] {
            "从驱动器读取",
            "从文件读取",
            "读取标准出厂设置"});
            this.cBParametersSource.Location = new System.Drawing.Point(0, 55);
            this.cBParametersSource.Name = "cBParametersSource";
            this.cBParametersSource.Size = new System.Drawing.Size(245, 29);
            this.cBParametersSource.TabIndex = 7;
            this.cBParametersSource.TabStop = false;
            this.cBParametersSource.Text = "从驱动器读取";
            this.cBParametersSource.SelectedIndexChanged += new System.EventHandler(this.cBParametersSource_SelectedIndexChanged);
            // 
            // oFParaPath
            // 
            this.oFParaPath.FileName = "openFileDialog1";
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
            this.lVParam.Location = new System.Drawing.Point(251, 116);
            this.lVParam.MultiSelect = false;
            this.lVParam.Name = "lVParam";
            this.lVParam.Size = new System.Drawing.Size(675, 427);
            this.lVParam.TabIndex = 3;
            this.lVParam.UseCompatibleStateImageBehavior = false;
            this.lVParam.View = System.Windows.Forms.View.Details;
            this.lVParam.DoubleClick += new System.EventHandler(this.lVParam_DoubleClick);
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
            this.columnHeader3.Width = 255;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "范围";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 116;
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
            this.columnHeader6.Width = 69;
            // 
            // ParametersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 701);
            this.Controls.Add(this.cBParametersSource);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pLExplain2);
            this.Controls.Add(this.pLDescribe);
            this.Controls.Add(this.lVParam);
            this.Controls.Add(this.tVParam);
            this.Controls.Add(this.pLName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ParametersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "            ";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ParametersForm_FormClosed);
            this.pLName.ResumeLayout(false);
            this.pLName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBSetUp)).EndInit();
            this.pLDescribe.ResumeLayout(false);
            this.pLExplain.ResumeLayout(false);
            this.pLExplain.PerformLayout();
            this.pLExplain2.ResumeLayout(false);
            this.pLExplain2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pLName;
        private System.Windows.Forms.TreeView tVParam;
        private System.Windows.Forms.Label label1;
        private NewListView lVParam;
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
        private System.Windows.Forms.Button btnFlash;
        private System.Windows.Forms.PictureBox pBExit;
        private System.Windows.Forms.PictureBox pBSetUp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cBParametersSource;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCalculator;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Button btnInitialize;
        private System.Windows.Forms.OpenFileDialog oFParaPath;
        private System.Windows.Forms.SaveFileDialog saveFileDialogParaPath;
        private System.Windows.Forms.Button btnSetZeroPosition;
        private System.Windows.Forms.Button btnClearError;
    }
}
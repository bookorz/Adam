namespace Adam
{
    partial class FormTerminal
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
            this.tlpTerminal = new System.Windows.Forms.TableLayoutPanel();
            this.tlpCommandSetting = new System.Windows.Forms.TableLayoutPanel();
            this.spcCommandHistory = new System.Windows.Forms.SplitContainer();
            this.gbCommandList = new System.Windows.Forms.GroupBox();
            this.spcCommandList = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUP = new System.Windows.Forms.Button();
            this.sbtnRun = new System.Controls.SplitButton();
            this.cmsRunMode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmtRunStep = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmtRunList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tstbfrequency = new System.Windows.Forms.ToolStripTextBox();
            this.tsmtExcute = new System.Windows.Forms.ToolStripMenuItem();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.dgvCommandList = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Command = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbHistory = new System.Windows.Forms.GroupBox();
            this.lsbHistory = new System.Windows.Forms.ListBox();
            this.gbSetting = new System.Windows.Forms.GroupBox();
            this.spcSettingandTest = new System.Windows.Forms.SplitContainer();
            this.tlpAssemblySetting = new System.Windows.Forms.TableLayoutPanel();
            this.tlpAssemblyUI = new System.Windows.Forms.TableLayoutPanel();
            this.txbManually = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAppendlist = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.tlpButtonList = new System.Windows.Forms.TableLayoutPanel();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnClearHistory = new System.Windows.Forms.Button();
            this.lbQueue = new System.Windows.Forms.Label();
            this.gbCondition = new System.Windows.Forms.GroupBox();
            this.tlpOperationSplit = new System.Windows.Forms.TableLayoutPanel();
            this.lsbCommand = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbNotice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lsbCommandType = new System.Windows.Forms.ListBox();
            this.lsbDeviceName = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tlpTerminal.SuspendLayout();
            this.tlpCommandSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcCommandHistory)).BeginInit();
            this.spcCommandHistory.Panel1.SuspendLayout();
            this.spcCommandHistory.Panel2.SuspendLayout();
            this.spcCommandHistory.SuspendLayout();
            this.gbCommandList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcCommandList)).BeginInit();
            this.spcCommandList.Panel1.SuspendLayout();
            this.spcCommandList.Panel2.SuspendLayout();
            this.spcCommandList.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.cmsRunMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommandList)).BeginInit();
            this.gbHistory.SuspendLayout();
            this.gbSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcSettingandTest)).BeginInit();
            this.spcSettingandTest.Panel1.SuspendLayout();
            this.spcSettingandTest.Panel2.SuspendLayout();
            this.spcSettingandTest.SuspendLayout();
            this.tlpAssemblySetting.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tlpButtonList.SuspendLayout();
            this.gbCondition.SuspendLayout();
            this.tlpOperationSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpTerminal
            // 
            this.tlpTerminal.ColumnCount = 2;
            this.tlpTerminal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.87671F));
            this.tlpTerminal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.12329F));
            this.tlpTerminal.Controls.Add(this.tlpCommandSetting, 0, 0);
            this.tlpTerminal.Controls.Add(this.gbCondition, 0, 0);
            this.tlpTerminal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTerminal.Location = new System.Drawing.Point(0, 0);
            this.tlpTerminal.Margin = new System.Windows.Forms.Padding(5);
            this.tlpTerminal.Name = "tlpTerminal";
            this.tlpTerminal.RowCount = 1;
            this.tlpTerminal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTerminal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 861F));
            this.tlpTerminal.Size = new System.Drawing.Size(1484, 861);
            this.tlpTerminal.TabIndex = 0;
            // 
            // tlpCommandSetting
            // 
            this.tlpCommandSetting.ColumnCount = 1;
            this.tlpCommandSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCommandSetting.Controls.Add(this.spcCommandHistory, 0, 1);
            this.tlpCommandSetting.Controls.Add(this.gbSetting, 0, 0);
            this.tlpCommandSetting.Controls.Add(this.tlpButtonList, 0, 2);
            this.tlpCommandSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCommandSetting.Location = new System.Drawing.Point(268, 3);
            this.tlpCommandSetting.Name = "tlpCommandSetting";
            this.tlpCommandSetting.RowCount = 3;
            this.tlpCommandSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.44371F));
            this.tlpCommandSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 69.27152F));
            this.tlpCommandSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.152318F));
            this.tlpCommandSetting.Size = new System.Drawing.Size(1213, 855);
            this.tlpCommandSetting.TabIndex = 1;
            // 
            // spcCommandHistory
            // 
            this.spcCommandHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcCommandHistory.Location = new System.Drawing.Point(3, 203);
            this.spcCommandHistory.Name = "spcCommandHistory";
            // 
            // spcCommandHistory.Panel1
            // 
            this.spcCommandHistory.Panel1.Controls.Add(this.gbCommandList);
            // 
            // spcCommandHistory.Panel2
            // 
            this.spcCommandHistory.Panel2.Controls.Add(this.gbHistory);
            this.spcCommandHistory.Size = new System.Drawing.Size(1207, 587);
            this.spcCommandHistory.SplitterDistance = 743;
            this.spcCommandHistory.TabIndex = 2;
            // 
            // gbCommandList
            // 
            this.gbCommandList.Controls.Add(this.spcCommandList);
            this.gbCommandList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCommandList.Location = new System.Drawing.Point(0, 0);
            this.gbCommandList.Name = "gbCommandList";
            this.gbCommandList.Size = new System.Drawing.Size(743, 587);
            this.gbCommandList.TabIndex = 1;
            this.gbCommandList.TabStop = false;
            this.gbCommandList.Text = "Command List";
            // 
            // spcCommandList
            // 
            this.spcCommandList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcCommandList.Location = new System.Drawing.Point(3, 25);
            this.spcCommandList.Name = "spcCommandList";
            this.spcCommandList.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcCommandList.Panel1
            // 
            this.spcCommandList.Panel1.Controls.Add(this.tableLayoutPanel3);
            // 
            // spcCommandList.Panel2
            // 
            this.spcCommandList.Panel2.Controls.Add(this.dgvCommandList);
            this.spcCommandList.Size = new System.Drawing.Size(737, 559);
            this.spcCommandList.SplitterDistance = 49;
            this.spcCommandList.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 7;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.Controls.Add(this.btnDown, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnUP, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.sbtnRun, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnContinue, 6, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnDelete, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnStop, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnPause, 4, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(737, 49);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // btnDown
            // 
            this.btnDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.Location = new System.Drawing.Point(108, 3);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(99, 43);
            this.btnDown.TabIndex = 3;
            this.btnDown.Tag = "Down";
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnUP_Click);
            // 
            // btnUP
            // 
            this.btnUP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUP.Location = new System.Drawing.Point(3, 3);
            this.btnUP.Name = "btnUP";
            this.btnUP.Size = new System.Drawing.Size(99, 43);
            this.btnUP.TabIndex = 2;
            this.btnUP.Tag = "UP";
            this.btnUP.Text = "UP";
            this.btnUP.UseVisualStyleBackColor = true;
            this.btnUP.Click += new System.EventHandler(this.btnUP_Click);
            // 
            // sbtnRun
            // 
            this.sbtnRun.AutoSize = true;
            this.sbtnRun.ContextMenuStrip = this.cmsRunMode;
            this.sbtnRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbtnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sbtnRun.Location = new System.Drawing.Point(318, 3);
            this.sbtnRun.MenuStripShowShowMode = true;
            this.sbtnRun.Name = "sbtnRun";
            this.sbtnRun.Size = new System.Drawing.Size(99, 43);
            this.sbtnRun.SplitMenuStrip = this.cmsRunMode;
            this.sbtnRun.SplitMenuStripShowUp = true;
            this.sbtnRun.TabIndex = 5;
            this.sbtnRun.Text = "Run";
            this.sbtnRun.UseVisualStyleBackColor = true;
            // 
            // cmsRunMode
            // 
            this.cmsRunMode.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmsRunMode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmtRunStep,
            this.tsmtRunList,
            this.toolStripMenuItem1});
            this.cmsRunMode.Name = "contextMenuStrip1";
            this.cmsRunMode.ShowCheckMargin = true;
            this.cmsRunMode.Size = new System.Drawing.Size(257, 76);
            // 
            // tsmtRunStep
            // 
            this.tsmtRunStep.Name = "tsmtRunStep";
            this.tsmtRunStep.Size = new System.Drawing.Size(256, 24);
            this.tsmtRunStep.Text = "Run Step";
            this.tsmtRunStep.Click += new System.EventHandler(this.tsmtRunStep_Click);
            // 
            // tsmtRunList
            // 
            this.tsmtRunList.Name = "tsmtRunList";
            this.tsmtRunList.Size = new System.Drawing.Size(256, 24);
            this.tsmtRunList.Text = "Run list";
            this.tsmtRunList.Click += new System.EventHandler(this.tsmtRunList_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstbfrequency,
            this.tsmtExcute});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(256, 24);
            this.toolStripMenuItem1.Text = "Run list by frequency";
            // 
            // tstbfrequency
            // 
            this.tstbfrequency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tstbfrequency.ForeColor = System.Drawing.Color.Black;
            this.tstbfrequency.MaxLength = 10000;
            this.tstbfrequency.Name = "tstbfrequency";
            this.tstbfrequency.Size = new System.Drawing.Size(100, 23);
            this.tstbfrequency.Text = "1";
            this.tstbfrequency.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tsmtExcute
            // 
            this.tsmtExcute.Name = "tsmtExcute";
            this.tsmtExcute.Size = new System.Drawing.Size(160, 24);
            this.tsmtExcute.Text = "Excute";
            this.tsmtExcute.Click += new System.EventHandler(this.tsmtExcute_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinue.Location = new System.Drawing.Point(633, 3);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(101, 43);
            this.btnContinue.TabIndex = 8;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(213, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(99, 43);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnStop
            // 
            this.btnStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Location = new System.Drawing.Point(528, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(99, 43);
            this.btnStop.TabIndex = 7;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Visible = false;
            // 
            // btnPause
            // 
            this.btnPause.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPause.Location = new System.Drawing.Point(423, 3);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(99, 43);
            this.btnPause.TabIndex = 6;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Visible = false;
            // 
            // dgvCommandList
            // 
            this.dgvCommandList.AllowUserToAddRows = false;
            this.dgvCommandList.AllowUserToDeleteRows = false;
            this.dgvCommandList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCommandList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCommandList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCommandList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.DeviceName,
            this.Command});
            this.dgvCommandList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCommandList.Location = new System.Drawing.Point(0, 0);
            this.dgvCommandList.Name = "dgvCommandList";
            this.dgvCommandList.ReadOnly = true;
            this.dgvCommandList.RowTemplate.Height = 24;
            this.dgvCommandList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCommandList.Size = new System.Drawing.Size(737, 506);
            this.dgvCommandList.TabIndex = 0;
            // 
            // No
            // 
            this.No.DataPropertyName = "No";
            this.No.HeaderText = "No.";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Width = 61;
            // 
            // DeviceName
            // 
            this.DeviceName.DataPropertyName = "Device_Name";
            this.DeviceName.HeaderText = "Device Name";
            this.DeviceName.Name = "DeviceName";
            this.DeviceName.ReadOnly = true;
            this.DeviceName.Width = 134;
            // 
            // Command
            // 
            this.Command.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Command.DataPropertyName = "Command";
            this.Command.HeaderText = "Command";
            this.Command.Name = "Command";
            this.Command.ReadOnly = true;
            // 
            // gbHistory
            // 
            this.gbHistory.Controls.Add(this.lsbHistory);
            this.gbHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbHistory.Location = new System.Drawing.Point(0, 0);
            this.gbHistory.Name = "gbHistory";
            this.gbHistory.Size = new System.Drawing.Size(460, 587);
            this.gbHistory.TabIndex = 0;
            this.gbHistory.TabStop = false;
            this.gbHistory.Text = "History";
            // 
            // lsbHistory
            // 
            this.lsbHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbHistory.FormattingEnabled = true;
            this.lsbHistory.ItemHeight = 20;
            this.lsbHistory.Location = new System.Drawing.Point(3, 25);
            this.lsbHistory.Name = "lsbHistory";
            this.lsbHistory.Size = new System.Drawing.Size(454, 559);
            this.lsbHistory.TabIndex = 0;
            // 
            // gbSetting
            // 
            this.gbSetting.Controls.Add(this.spcSettingandTest);
            this.gbSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSetting.Location = new System.Drawing.Point(3, 3);
            this.gbSetting.Name = "gbSetting";
            this.gbSetting.Size = new System.Drawing.Size(1207, 194);
            this.gbSetting.TabIndex = 0;
            this.gbSetting.TabStop = false;
            this.gbSetting.Text = "Setting and Test Run";
            // 
            // spcSettingandTest
            // 
            this.spcSettingandTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcSettingandTest.Location = new System.Drawing.Point(3, 25);
            this.spcSettingandTest.Name = "spcSettingandTest";
            // 
            // spcSettingandTest.Panel1
            // 
            this.spcSettingandTest.Panel1.Controls.Add(this.tlpAssemblySetting);
            // 
            // spcSettingandTest.Panel2
            // 
            this.spcSettingandTest.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.spcSettingandTest.Size = new System.Drawing.Size(1201, 166);
            this.spcSettingandTest.SplitterDistance = 1062;
            this.spcSettingandTest.TabIndex = 0;
            // 
            // tlpAssemblySetting
            // 
            this.tlpAssemblySetting.ColumnCount = 1;
            this.tlpAssemblySetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAssemblySetting.Controls.Add(this.tlpAssemblyUI, 0, 0);
            this.tlpAssemblySetting.Controls.Add(this.txbManually, 0, 1);
            this.tlpAssemblySetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAssemblySetting.Location = new System.Drawing.Point(0, 0);
            this.tlpAssemblySetting.Name = "tlpAssemblySetting";
            this.tlpAssemblySetting.RowCount = 2;
            this.tlpAssemblySetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAssemblySetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpAssemblySetting.Size = new System.Drawing.Size(1062, 166);
            this.tlpAssemblySetting.TabIndex = 1;
            // 
            // tlpAssemblyUI
            // 
            this.tlpAssemblyUI.ColumnCount = 10;
            this.tlpAssemblyUI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpAssemblyUI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpAssemblyUI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpAssemblyUI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpAssemblyUI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpAssemblyUI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpAssemblyUI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpAssemblyUI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpAssemblyUI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpAssemblyUI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpAssemblyUI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAssemblyUI.Location = new System.Drawing.Point(3, 3);
            this.tlpAssemblyUI.Name = "tlpAssemblyUI";
            this.tlpAssemblyUI.RowCount = 4;
            this.tlpAssemblyUI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpAssemblyUI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpAssemblyUI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpAssemblyUI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpAssemblyUI.Size = new System.Drawing.Size(1056, 125);
            this.tlpAssemblyUI.TabIndex = 0;
            // 
            // txbManually
            // 
            this.txbManually.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txbManually.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbManually.Location = new System.Drawing.Point(3, 134);
            this.txbManually.Name = "txbManually";
            this.txbManually.Size = new System.Drawing.Size(1056, 29);
            this.txbManually.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnAppendlist, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSend, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(135, 166);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnAppendlist
            // 
            this.btnAppendlist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAppendlist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAppendlist.Location = new System.Drawing.Point(3, 58);
            this.btnAppendlist.Name = "btnAppendlist";
            this.btnAppendlist.Size = new System.Drawing.Size(129, 49);
            this.btnAppendlist.TabIndex = 2;
            this.btnAppendlist.Text = "Append List";
            this.btnAppendlist.UseVisualStyleBackColor = true;
            this.btnAppendlist.Click += new System.EventHandler(this.btnAppendlist_Click);
            // 
            // btnSend
            // 
            this.btnSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Location = new System.Drawing.Point(3, 3);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(129, 49);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tlpButtonList
            // 
            this.tlpButtonList.ColumnCount = 8;
            this.tlpButtonList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpButtonList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpButtonList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpButtonList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpButtonList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpButtonList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpButtonList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpButtonList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpButtonList.Controls.Add(this.btnRemove, 0, 0);
            this.tlpButtonList.Controls.Add(this.btnExport, 0, 0);
            this.tlpButtonList.Controls.Add(this.btnImport, 0, 0);
            this.tlpButtonList.Controls.Add(this.btnClearHistory, 7, 0);
            this.tlpButtonList.Controls.Add(this.lbQueue, 5, 0);
            this.tlpButtonList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButtonList.Location = new System.Drawing.Point(3, 796);
            this.tlpButtonList.Name = "tlpButtonList";
            this.tlpButtonList.RowCount = 1;
            this.tlpButtonList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtonList.Size = new System.Drawing.Size(1207, 56);
            this.tlpButtonList.TabIndex = 1;
            // 
            // btnRemove
            // 
            this.btnRemove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Location = new System.Drawing.Point(303, 3);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(144, 50);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Remove List";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnExport
            // 
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Location = new System.Drawing.Point(153, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(144, 50);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Export List";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnImport
            // 
            this.btnImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Location = new System.Drawing.Point(3, 3);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(144, 50);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "Import List";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnClearHistory
            // 
            this.btnClearHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClearHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearHistory.Location = new System.Drawing.Point(1053, 3);
            this.btnClearHistory.Name = "btnClearHistory";
            this.btnClearHistory.Size = new System.Drawing.Size(151, 50);
            this.btnClearHistory.TabIndex = 2;
            this.btnClearHistory.Text = "Clear History";
            this.btnClearHistory.UseVisualStyleBackColor = true;
            this.btnClearHistory.Click += new System.EventHandler(this.btnClearHistory_Click);
            // 
            // lbQueue
            // 
            this.lbQueue.AutoSize = true;
            this.lbQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbQueue.Location = new System.Drawing.Point(753, 0);
            this.lbQueue.Name = "lbQueue";
            this.lbQueue.Size = new System.Drawing.Size(144, 56);
            this.lbQueue.TabIndex = 6;
            this.lbQueue.Text = "Queue:";
            this.lbQueue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbCondition
            // 
            this.gbCondition.Controls.Add(this.tlpOperationSplit);
            this.gbCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCondition.Location = new System.Drawing.Point(5, 5);
            this.gbCondition.Margin = new System.Windows.Forms.Padding(5);
            this.gbCondition.Name = "gbCondition";
            this.gbCondition.Padding = new System.Windows.Forms.Padding(5);
            this.gbCondition.Size = new System.Drawing.Size(255, 851);
            this.gbCondition.TabIndex = 0;
            this.gbCondition.TabStop = false;
            this.gbCondition.Text = "Condition";
            // 
            // tlpOperationSplit
            // 
            this.tlpOperationSplit.ColumnCount = 1;
            this.tlpOperationSplit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOperationSplit.Controls.Add(this.lsbCommand, 0, 5);
            this.tlpOperationSplit.Controls.Add(this.label3, 0, 4);
            this.tlpOperationSplit.Controls.Add(this.txbNotice, 0, 6);
            this.tlpOperationSplit.Controls.Add(this.label2, 0, 2);
            this.tlpOperationSplit.Controls.Add(this.lsbCommandType, 0, 3);
            this.tlpOperationSplit.Controls.Add(this.lsbDeviceName, 0, 1);
            this.tlpOperationSplit.Controls.Add(this.label1, 0, 0);
            this.tlpOperationSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpOperationSplit.Location = new System.Drawing.Point(5, 27);
            this.tlpOperationSplit.Name = "tlpOperationSplit";
            this.tlpOperationSplit.RowCount = 7;
            this.tlpOperationSplit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpOperationSplit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpOperationSplit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpOperationSplit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpOperationSplit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpOperationSplit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpOperationSplit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpOperationSplit.Size = new System.Drawing.Size(245, 819);
            this.tlpOperationSplit.TabIndex = 1;
            // 
            // lsbCommand
            // 
            this.lsbCommand.BackColor = System.Drawing.Color.White;
            this.lsbCommand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsbCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbCommand.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lsbCommand.ForeColor = System.Drawing.Color.Black;
            this.lsbCommand.FormattingEnabled = true;
            this.lsbCommand.ItemHeight = 27;
            this.lsbCommand.Location = new System.Drawing.Point(3, 383);
            this.lsbCommand.Name = "lsbCommand";
            this.lsbCommand.Size = new System.Drawing.Size(239, 285);
            this.lsbCommand.TabIndex = 3;
            this.lsbCommand.Click += new System.EventHandler(this.lsbCommand_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Location = new System.Drawing.Point(3, 350);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(239, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "Command";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbNotice
            // 
            this.txbNotice.BackColor = System.Drawing.Color.Black;
            this.txbNotice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbNotice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbNotice.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txbNotice.ForeColor = System.Drawing.Color.White;
            this.txbNotice.Location = new System.Drawing.Point(3, 674);
            this.txbNotice.Multiline = true;
            this.txbNotice.Name = "txbNotice";
            this.txbNotice.ReadOnly = true;
            this.txbNotice.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txbNotice.Size = new System.Drawing.Size(239, 142);
            this.txbNotice.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Location = new System.Drawing.Point(3, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(239, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Command Type";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lsbCommandType
            // 
            this.lsbCommandType.BackColor = System.Drawing.Color.White;
            this.lsbCommandType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsbCommandType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbCommandType.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lsbCommandType.ForeColor = System.Drawing.Color.Black;
            this.lsbCommandType.FormattingEnabled = true;
            this.lsbCommandType.ItemHeight = 27;
            this.lsbCommandType.Location = new System.Drawing.Point(3, 208);
            this.lsbCommandType.Name = "lsbCommandType";
            this.lsbCommandType.Size = new System.Drawing.Size(239, 139);
            this.lsbCommandType.TabIndex = 2;
            this.lsbCommandType.Click += new System.EventHandler(this.lsbCommandType_Click);
            // 
            // lsbDeviceName
            // 
            this.lsbDeviceName.BackColor = System.Drawing.Color.White;
            this.lsbDeviceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsbDeviceName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbDeviceName.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lsbDeviceName.ForeColor = System.Drawing.Color.Black;
            this.lsbDeviceName.FormattingEnabled = true;
            this.lsbDeviceName.ItemHeight = 27;
            this.lsbDeviceName.Location = new System.Drawing.Point(3, 33);
            this.lsbDeviceName.Name = "lsbDeviceName";
            this.lsbDeviceName.Size = new System.Drawing.Size(239, 139);
            this.lsbDeviceName.TabIndex = 1;
            this.lsbDeviceName.Click += new System.EventHandler(this.lsbDeviceName_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Device Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer1.Size = new System.Drawing.Size(636, 507);
            this.splitContainer1.SplitterDistance = 465;
            this.splitContainer1.TabIndex = 0;
            // 
            // FormTerminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1484, 861);
            this.Controls.Add(this.tlpTerminal);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FormTerminal";
            this.Text = "Terminal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormTerminal_Load);
            this.tlpTerminal.ResumeLayout(false);
            this.tlpCommandSetting.ResumeLayout(false);
            this.spcCommandHistory.Panel1.ResumeLayout(false);
            this.spcCommandHistory.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcCommandHistory)).EndInit();
            this.spcCommandHistory.ResumeLayout(false);
            this.gbCommandList.ResumeLayout(false);
            this.spcCommandList.Panel1.ResumeLayout(false);
            this.spcCommandList.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcCommandList)).EndInit();
            this.spcCommandList.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.cmsRunMode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommandList)).EndInit();
            this.gbHistory.ResumeLayout(false);
            this.gbSetting.ResumeLayout(false);
            this.spcSettingandTest.Panel1.ResumeLayout(false);
            this.spcSettingandTest.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcSettingandTest)).EndInit();
            this.spcSettingandTest.ResumeLayout(false);
            this.tlpAssemblySetting.ResumeLayout(false);
            this.tlpAssemblySetting.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tlpButtonList.ResumeLayout(false);
            this.tlpButtonList.PerformLayout();
            this.gbCondition.ResumeLayout(false);
            this.tlpOperationSplit.ResumeLayout(false);
            this.tlpOperationSplit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpTerminal;
        private System.Windows.Forms.GroupBox gbCondition;
        private System.Windows.Forms.TableLayoutPanel tlpOperationSplit;
        private System.Windows.Forms.ListBox lsbCommandType;
        private System.Windows.Forms.ListBox lsbDeviceName;
        private System.Windows.Forms.ListBox lsbCommand;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbNotice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tlpCommandSetting;
        private System.Windows.Forms.GroupBox gbCommandList;
        private System.Windows.Forms.GroupBox gbHistory;
        private System.Windows.Forms.GroupBox gbSetting;
        private System.Windows.Forms.TableLayoutPanel tlpButtonList;
        private System.Windows.Forms.SplitContainer spcSettingandTest;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnAppendlist;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.SplitContainer spcCommandHistory;
        private System.Windows.Forms.Button btnClearHistory;
        private System.Windows.Forms.TableLayoutPanel tlpAssemblyUI;
        private System.Windows.Forms.SplitContainer spcCommandList;
        private System.Windows.Forms.ListBox lsbHistory;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUP;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TableLayoutPanel tlpAssemblySetting;
        private System.Windows.Forms.TextBox txbManually;
        private System.Controls.SplitButton sbtnRun;
        private System.Windows.Forms.ContextMenuStrip cmsRunMode;
        private System.Windows.Forms.ToolStripMenuItem tsmtRunList;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripTextBox tstbfrequency;
        private System.Windows.Forms.ToolStripMenuItem tsmtExcute;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.DataGridView dgvCommandList;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeviceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Command;
        private System.Windows.Forms.Label lbQueue;
        private System.Windows.Forms.ToolStripMenuItem tsmtRunStep;
    }
}
namespace Adam.Menu.SystemSetting
{
    partial class FormAlarmEventSet
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbAlarmSetting = new System.Windows.Forms.GroupBox();
            this.spcAlarmSetting = new System.Windows.Forms.SplitContainer();
            this.gbAlarmSettingCondition = new System.Windows.Forms.GroupBox();
            this.tlpAlarmCondition = new System.Windows.Forms.TableLayoutPanel();
            this.tlpAlarmCondition_2 = new System.Windows.Forms.TableLayoutPanel();
            this.txbAlarmConditionDeviceType = new System.Windows.Forms.TextBox();
            this.lbAlarmConditionDeviceType = new System.Windows.Forms.Label();
            this.lsbAlarmConditionDeviceType = new System.Windows.Forms.ListBox();
            this.tlpAlarmCondition_1 = new System.Windows.Forms.TableLayoutPanel();
            this.txbAlarmConditionVendorCode = new System.Windows.Forms.TextBox();
            this.lbAlarmConditionVendorCode = new System.Windows.Forms.Label();
            this.lsbAlarmConditionVendorCode = new System.Windows.Forms.ListBox();
            this.gbAlarmSettingData = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvlsbAlarmData = new System.Windows.Forms.DataGridView();
            this.Event_AlarmNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Event_AlarmDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Event_AlarmDescriptionEnglish = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Event_AlarmType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Event_AlarmLevel = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Event_AlarmLED_Red = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Event_AlarmLED_Yellow = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Event_AlarmLED_Green = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Event_AlarmLED_Bule = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Event_AlarmBuzzer_A = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Event_AlarmBuzzer_B = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Event_AlarmIS_Stop = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.gbAlarmSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcAlarmSetting)).BeginInit();
            this.spcAlarmSetting.Panel1.SuspendLayout();
            this.spcAlarmSetting.Panel2.SuspendLayout();
            this.spcAlarmSetting.SuspendLayout();
            this.gbAlarmSettingCondition.SuspendLayout();
            this.tlpAlarmCondition.SuspendLayout();
            this.tlpAlarmCondition_2.SuspendLayout();
            this.tlpAlarmCondition_1.SuspendLayout();
            this.gbAlarmSettingData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlsbAlarmData)).BeginInit();
            this.SuspendLayout();
            // 
            // gbAlarmSetting
            // 
            this.gbAlarmSetting.Controls.Add(this.spcAlarmSetting);
            this.gbAlarmSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAlarmSetting.Location = new System.Drawing.Point(0, 0);
            this.gbAlarmSetting.Name = "gbAlarmSetting";
            this.gbAlarmSetting.Size = new System.Drawing.Size(1420, 740);
            this.gbAlarmSetting.TabIndex = 2;
            this.gbAlarmSetting.TabStop = false;
            this.gbAlarmSetting.Text = "Alarm Setting";
            // 
            // spcAlarmSetting
            // 
            this.spcAlarmSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcAlarmSetting.Location = new System.Drawing.Point(3, 25);
            this.spcAlarmSetting.Name = "spcAlarmSetting";
            // 
            // spcAlarmSetting.Panel1
            // 
            this.spcAlarmSetting.Panel1.Controls.Add(this.gbAlarmSettingCondition);
            // 
            // spcAlarmSetting.Panel2
            // 
            this.spcAlarmSetting.Panel2.Controls.Add(this.gbAlarmSettingData);
            this.spcAlarmSetting.Size = new System.Drawing.Size(1414, 712);
            this.spcAlarmSetting.SplitterDistance = 333;
            this.spcAlarmSetting.TabIndex = 0;
            // 
            // gbAlarmSettingCondition
            // 
            this.gbAlarmSettingCondition.Controls.Add(this.tlpAlarmCondition);
            this.gbAlarmSettingCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAlarmSettingCondition.Location = new System.Drawing.Point(0, 0);
            this.gbAlarmSettingCondition.Name = "gbAlarmSettingCondition";
            this.gbAlarmSettingCondition.Size = new System.Drawing.Size(333, 712);
            this.gbAlarmSettingCondition.TabIndex = 0;
            this.gbAlarmSettingCondition.TabStop = false;
            this.gbAlarmSettingCondition.Text = "Condition";
            // 
            // tlpAlarmCondition
            // 
            this.tlpAlarmCondition.ColumnCount = 1;
            this.tlpAlarmCondition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAlarmCondition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpAlarmCondition.Controls.Add(this.tlpAlarmCondition_2, 0, 1);
            this.tlpAlarmCondition.Controls.Add(this.tlpAlarmCondition_1, 0, 0);
            this.tlpAlarmCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAlarmCondition.Location = new System.Drawing.Point(3, 25);
            this.tlpAlarmCondition.Name = "tlpAlarmCondition";
            this.tlpAlarmCondition.RowCount = 3;
            this.tlpAlarmCondition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpAlarmCondition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpAlarmCondition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpAlarmCondition.Size = new System.Drawing.Size(327, 684);
            this.tlpAlarmCondition.TabIndex = 0;
            // 
            // tlpAlarmCondition_2
            // 
            this.tlpAlarmCondition_2.ColumnCount = 1;
            this.tlpAlarmCondition_2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAlarmCondition_2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpAlarmCondition_2.Controls.Add(this.txbAlarmConditionDeviceType, 0, 2);
            this.tlpAlarmCondition_2.Controls.Add(this.lbAlarmConditionDeviceType, 0, 0);
            this.tlpAlarmCondition_2.Controls.Add(this.lsbAlarmConditionDeviceType, 0, 1);
            this.tlpAlarmCondition_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAlarmCondition_2.Location = new System.Drawing.Point(3, 231);
            this.tlpAlarmCondition_2.Name = "tlpAlarmCondition_2";
            this.tlpAlarmCondition_2.RowCount = 3;
            this.tlpAlarmCondition_2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.55605F));
            this.tlpAlarmCondition_2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.7444F));
            this.tlpAlarmCondition_2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.69955F));
            this.tlpAlarmCondition_2.Size = new System.Drawing.Size(321, 222);
            this.tlpAlarmCondition_2.TabIndex = 1;
            // 
            // txbAlarmConditionDeviceType
            // 
            this.txbAlarmConditionDeviceType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbAlarmConditionDeviceType.BackColor = System.Drawing.Color.White;
            this.txbAlarmConditionDeviceType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbAlarmConditionDeviceType.Location = new System.Drawing.Point(3, 160);
            this.txbAlarmConditionDeviceType.Multiline = true;
            this.txbAlarmConditionDeviceType.Name = "txbAlarmConditionDeviceType";
            this.txbAlarmConditionDeviceType.ReadOnly = true;
            this.txbAlarmConditionDeviceType.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txbAlarmConditionDeviceType.Size = new System.Drawing.Size(315, 50);
            this.txbAlarmConditionDeviceType.TabIndex = 5;
            this.txbAlarmConditionDeviceType.Visible = false;
            // 
            // lbAlarmConditionDeviceType
            // 
            this.lbAlarmConditionDeviceType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbAlarmConditionDeviceType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbAlarmConditionDeviceType.Location = new System.Drawing.Point(3, 0);
            this.lbAlarmConditionDeviceType.Name = "lbAlarmConditionDeviceType";
            this.lbAlarmConditionDeviceType.Size = new System.Drawing.Size(315, 27);
            this.lbAlarmConditionDeviceType.TabIndex = 3;
            this.lbAlarmConditionDeviceType.Text = "Device Type :";
            this.lbAlarmConditionDeviceType.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lsbAlarmConditionDeviceType
            // 
            this.lsbAlarmConditionDeviceType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbAlarmConditionDeviceType.FormattingEnabled = true;
            this.lsbAlarmConditionDeviceType.ItemHeight = 20;
            this.lsbAlarmConditionDeviceType.Location = new System.Drawing.Point(3, 30);
            this.lsbAlarmConditionDeviceType.Name = "lsbAlarmConditionDeviceType";
            this.lsbAlarmConditionDeviceType.Size = new System.Drawing.Size(315, 124);
            this.lsbAlarmConditionDeviceType.TabIndex = 4;
            this.lsbAlarmConditionDeviceType.Click += new System.EventHandler(this.lsbAlarmConditionVendorCode_Click);
            // 
            // tlpAlarmCondition_1
            // 
            this.tlpAlarmCondition_1.ColumnCount = 1;
            this.tlpAlarmCondition_1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAlarmCondition_1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpAlarmCondition_1.Controls.Add(this.txbAlarmConditionVendorCode, 0, 2);
            this.tlpAlarmCondition_1.Controls.Add(this.lbAlarmConditionVendorCode, 0, 0);
            this.tlpAlarmCondition_1.Controls.Add(this.lsbAlarmConditionVendorCode, 0, 1);
            this.tlpAlarmCondition_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAlarmCondition_1.Location = new System.Drawing.Point(3, 3);
            this.tlpAlarmCondition_1.Name = "tlpAlarmCondition_1";
            this.tlpAlarmCondition_1.RowCount = 3;
            this.tlpAlarmCondition_1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.55605F));
            this.tlpAlarmCondition_1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.7444F));
            this.tlpAlarmCondition_1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.69955F));
            this.tlpAlarmCondition_1.Size = new System.Drawing.Size(321, 222);
            this.tlpAlarmCondition_1.TabIndex = 0;
            // 
            // txbAlarmConditionVendorCode
            // 
            this.txbAlarmConditionVendorCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbAlarmConditionVendorCode.BackColor = System.Drawing.Color.White;
            this.txbAlarmConditionVendorCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbAlarmConditionVendorCode.Location = new System.Drawing.Point(3, 160);
            this.txbAlarmConditionVendorCode.Multiline = true;
            this.txbAlarmConditionVendorCode.Name = "txbAlarmConditionVendorCode";
            this.txbAlarmConditionVendorCode.ReadOnly = true;
            this.txbAlarmConditionVendorCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txbAlarmConditionVendorCode.Size = new System.Drawing.Size(315, 50);
            this.txbAlarmConditionVendorCode.TabIndex = 5;
            this.txbAlarmConditionVendorCode.Visible = false;
            // 
            // lbAlarmConditionVendorCode
            // 
            this.lbAlarmConditionVendorCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbAlarmConditionVendorCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbAlarmConditionVendorCode.Location = new System.Drawing.Point(3, 0);
            this.lbAlarmConditionVendorCode.Name = "lbAlarmConditionVendorCode";
            this.lbAlarmConditionVendorCode.Size = new System.Drawing.Size(315, 27);
            this.lbAlarmConditionVendorCode.TabIndex = 3;
            this.lbAlarmConditionVendorCode.Text = "Vendor Code :";
            this.lbAlarmConditionVendorCode.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lsbAlarmConditionVendorCode
            // 
            this.lsbAlarmConditionVendorCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbAlarmConditionVendorCode.FormattingEnabled = true;
            this.lsbAlarmConditionVendorCode.ItemHeight = 20;
            this.lsbAlarmConditionVendorCode.Location = new System.Drawing.Point(3, 30);
            this.lsbAlarmConditionVendorCode.Name = "lsbAlarmConditionVendorCode";
            this.lsbAlarmConditionVendorCode.Size = new System.Drawing.Size(315, 124);
            this.lsbAlarmConditionVendorCode.TabIndex = 4;
            this.lsbAlarmConditionVendorCode.Click += new System.EventHandler(this.lsbAlarmConditionVendorCode_Click);
            // 
            // gbAlarmSettingData
            // 
            this.gbAlarmSettingData.Controls.Add(this.btnSave);
            this.gbAlarmSettingData.Controls.Add(this.dgvlsbAlarmData);
            this.gbAlarmSettingData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAlarmSettingData.Location = new System.Drawing.Point(0, 0);
            this.gbAlarmSettingData.Name = "gbAlarmSettingData";
            this.gbAlarmSettingData.Size = new System.Drawing.Size(1077, 712);
            this.gbAlarmSettingData.TabIndex = 0;
            this.gbAlarmSettingData.TabStop = false;
            this.gbAlarmSettingData.Text = "Data";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(845, 658);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(229, 48);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvlsbAlarmData
            // 
            this.dgvlsbAlarmData.AllowUserToAddRows = false;
            this.dgvlsbAlarmData.AllowUserToDeleteRows = false;
            this.dgvlsbAlarmData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvlsbAlarmData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvlsbAlarmData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvlsbAlarmData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Event_AlarmNo,
            this.Event_AlarmDescription,
            this.Event_AlarmDescriptionEnglish,
            this.Event_AlarmType,
            this.Event_AlarmLevel,
            this.Event_AlarmLED_Red,
            this.Event_AlarmLED_Yellow,
            this.Event_AlarmLED_Green,
            this.Event_AlarmLED_Bule,
            this.Event_AlarmBuzzer_A,
            this.Event_AlarmBuzzer_B,
            this.Event_AlarmIS_Stop});
            this.dgvlsbAlarmData.Location = new System.Drawing.Point(3, 25);
            this.dgvlsbAlarmData.Name = "dgvlsbAlarmData";
            this.dgvlsbAlarmData.RowHeadersVisible = false;
            this.dgvlsbAlarmData.RowTemplate.Height = 24;
            this.dgvlsbAlarmData.Size = new System.Drawing.Size(1071, 625);
            this.dgvlsbAlarmData.TabIndex = 5;
            // 
            // Event_AlarmNo
            // 
            this.Event_AlarmNo.DataPropertyName = "code_id";
            this.Event_AlarmNo.Frozen = true;
            this.Event_AlarmNo.HeaderText = "Alarm No";
            this.Event_AlarmNo.Name = "Event_AlarmNo";
            this.Event_AlarmNo.ReadOnly = true;
            this.Event_AlarmNo.Width = 97;
            // 
            // Event_AlarmDescription
            // 
            this.Event_AlarmDescription.DataPropertyName = "code_desc";
            this.Event_AlarmDescription.HeaderText = "Alarm description";
            this.Event_AlarmDescription.Name = "Event_AlarmDescription";
            this.Event_AlarmDescription.ReadOnly = true;
            this.Event_AlarmDescription.Width = 152;
            // 
            // Event_AlarmDescriptionEnglish
            // 
            this.Event_AlarmDescriptionEnglish.DataPropertyName = "code_desc_en";
            this.Event_AlarmDescriptionEnglish.HeaderText = "Alarm description english";
            this.Event_AlarmDescriptionEnglish.Name = "Event_AlarmDescriptionEnglish";
            this.Event_AlarmDescriptionEnglish.ReadOnly = true;
            this.Event_AlarmDescriptionEnglish.Width = 204;
            // 
            // Event_AlarmType
            // 
            this.Event_AlarmType.DataPropertyName = "alarm_type";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.Event_AlarmType.DefaultCellStyle = dataGridViewCellStyle1;
            this.Event_AlarmType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Event_AlarmType.HeaderText = "Alarm Type";
            this.Event_AlarmType.Items.AddRange(new object[] {
            "System",
            "User",
            "Device connection failed",
            "Initialization failed",
            "Device timeout",
            "Device alert error",
            "Third-party software fails",
            "Command timeout",
            "Software function fails or exception",
            "Communication fails"});
            this.Event_AlarmType.Name = "Event_AlarmType";
            this.Event_AlarmType.Visible = false;
            this.Event_AlarmType.Width = 90;
            // 
            // Event_AlarmLevel
            // 
            this.Event_AlarmLevel.DataPropertyName = "alarm_level";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.Event_AlarmLevel.DefaultCellStyle = dataGridViewCellStyle2;
            this.Event_AlarmLevel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Event_AlarmLevel.HeaderText = "Alarm Level";
            this.Event_AlarmLevel.Items.AddRange(new object[] {
            "High",
            "Nornal",
            "Low"});
            this.Event_AlarmLevel.Name = "Event_AlarmLevel";
            this.Event_AlarmLevel.Visible = false;
            this.Event_AlarmLevel.Width = 92;
            // 
            // Event_AlarmLED_Red
            // 
            this.Event_AlarmLED_Red.DataPropertyName = "led_red";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Event_AlarmLED_Red.DefaultCellStyle = dataGridViewCellStyle3;
            this.Event_AlarmLED_Red.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Event_AlarmLED_Red.HeaderText = "Red";
            this.Event_AlarmLED_Red.Items.AddRange(new object[] {
            "Y",
            "N",
            "F"});
            this.Event_AlarmLED_Red.Name = "Event_AlarmLED_Red";
            this.Event_AlarmLED_Red.Visible = false;
            this.Event_AlarmLED_Red.Width = 44;
            // 
            // Event_AlarmLED_Yellow
            // 
            this.Event_AlarmLED_Yellow.DataPropertyName = "led_yellow";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Event_AlarmLED_Yellow.DefaultCellStyle = dataGridViewCellStyle4;
            this.Event_AlarmLED_Yellow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Event_AlarmLED_Yellow.HeaderText = "Yellow";
            this.Event_AlarmLED_Yellow.Items.AddRange(new object[] {
            "Y",
            "N",
            "F"});
            this.Event_AlarmLED_Yellow.Name = "Event_AlarmLED_Yellow";
            this.Event_AlarmLED_Yellow.Visible = false;
            this.Event_AlarmLED_Yellow.Width = 64;
            // 
            // Event_AlarmLED_Green
            // 
            this.Event_AlarmLED_Green.DataPropertyName = "led_green";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Event_AlarmLED_Green.DefaultCellStyle = dataGridViewCellStyle5;
            this.Event_AlarmLED_Green.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Event_AlarmLED_Green.HeaderText = "Green";
            this.Event_AlarmLED_Green.Items.AddRange(new object[] {
            "Y",
            "N",
            "F"});
            this.Event_AlarmLED_Green.Name = "Event_AlarmLED_Green";
            this.Event_AlarmLED_Green.Visible = false;
            this.Event_AlarmLED_Green.Width = 61;
            // 
            // Event_AlarmLED_Bule
            // 
            this.Event_AlarmLED_Bule.DataPropertyName = "led_bule";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.Event_AlarmLED_Bule.DefaultCellStyle = dataGridViewCellStyle6;
            this.Event_AlarmLED_Bule.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Event_AlarmLED_Bule.HeaderText = "Blue";
            this.Event_AlarmLED_Bule.Items.AddRange(new object[] {
            "Y",
            "N",
            "F"});
            this.Event_AlarmLED_Bule.Name = "Event_AlarmLED_Bule";
            this.Event_AlarmLED_Bule.Visible = false;
            this.Event_AlarmLED_Bule.Width = 48;
            // 
            // Event_AlarmBuzzer_A
            // 
            this.Event_AlarmBuzzer_A.DataPropertyName = "buzzer_01";
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Event_AlarmBuzzer_A.DefaultCellStyle = dataGridViewCellStyle7;
            this.Event_AlarmBuzzer_A.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Event_AlarmBuzzer_A.HeaderText = "Buzzer A";
            this.Event_AlarmBuzzer_A.Items.AddRange(new object[] {
            "Y",
            "N",
            "F"});
            this.Event_AlarmBuzzer_A.Name = "Event_AlarmBuzzer_A";
            this.Event_AlarmBuzzer_A.Visible = false;
            this.Event_AlarmBuzzer_A.Width = 73;
            // 
            // Event_AlarmBuzzer_B
            // 
            this.Event_AlarmBuzzer_B.DataPropertyName = "buzzer_02";
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Event_AlarmBuzzer_B.DefaultCellStyle = dataGridViewCellStyle8;
            this.Event_AlarmBuzzer_B.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Event_AlarmBuzzer_B.HeaderText = "Buzzer B";
            this.Event_AlarmBuzzer_B.Items.AddRange(new object[] {
            "Y",
            "N",
            "F"});
            this.Event_AlarmBuzzer_B.Name = "Event_AlarmBuzzer_B";
            this.Event_AlarmBuzzer_B.Visible = false;
            this.Event_AlarmBuzzer_B.Width = 72;
            // 
            // Event_AlarmIS_Stop
            // 
            this.Event_AlarmIS_Stop.DataPropertyName = "Is_stop";
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            this.Event_AlarmIS_Stop.DefaultCellStyle = dataGridViewCellStyle9;
            this.Event_AlarmIS_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Event_AlarmIS_Stop.HeaderText = "IS Stop";
            this.Event_AlarmIS_Stop.Items.AddRange(new object[] {
            "Y",
            "N"});
            this.Event_AlarmIS_Stop.Name = "Event_AlarmIS_Stop";
            this.Event_AlarmIS_Stop.Width = 61;
            // 
            // FormAlarmEventSet
            // 
            this.ClientSize = new System.Drawing.Size(1420, 740);
            this.Controls.Add(this.gbAlarmSetting);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAlarmEventSet";
            this.Text = "Alarm Event Set ";
            this.Load += new System.EventHandler(this.FormAlarmEventSet_Load);
            this.gbAlarmSetting.ResumeLayout(false);
            this.spcAlarmSetting.Panel1.ResumeLayout(false);
            this.spcAlarmSetting.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcAlarmSetting)).EndInit();
            this.spcAlarmSetting.ResumeLayout(false);
            this.gbAlarmSettingCondition.ResumeLayout(false);
            this.tlpAlarmCondition.ResumeLayout(false);
            this.tlpAlarmCondition_2.ResumeLayout(false);
            this.tlpAlarmCondition_2.PerformLayout();
            this.tlpAlarmCondition_1.ResumeLayout(false);
            this.tlpAlarmCondition_1.PerformLayout();
            this.gbAlarmSettingData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvlsbAlarmData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAlarmSetting;
        private System.Windows.Forms.SplitContainer spcAlarmSetting;
        private System.Windows.Forms.GroupBox gbAlarmSettingCondition;
        private System.Windows.Forms.TableLayoutPanel tlpAlarmCondition;
        private System.Windows.Forms.TableLayoutPanel tlpAlarmCondition_2;
        private System.Windows.Forms.TextBox txbAlarmConditionDeviceType;
        private System.Windows.Forms.Label lbAlarmConditionDeviceType;
        private System.Windows.Forms.ListBox lsbAlarmConditionDeviceType;
        private System.Windows.Forms.TableLayoutPanel tlpAlarmCondition_1;
        private System.Windows.Forms.TextBox txbAlarmConditionVendorCode;
        private System.Windows.Forms.Label lbAlarmConditionVendorCode;
        private System.Windows.Forms.ListBox lsbAlarmConditionVendorCode;
        private System.Windows.Forms.GroupBox gbAlarmSettingData;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvlsbAlarmData;
        private System.Windows.Forms.DataGridViewTextBoxColumn Event_AlarmNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Event_AlarmDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn Event_AlarmDescriptionEnglish;
        private System.Windows.Forms.DataGridViewComboBoxColumn Event_AlarmType;
        private System.Windows.Forms.DataGridViewComboBoxColumn Event_AlarmLevel;
        private System.Windows.Forms.DataGridViewComboBoxColumn Event_AlarmLED_Red;
        private System.Windows.Forms.DataGridViewComboBoxColumn Event_AlarmLED_Yellow;
        private System.Windows.Forms.DataGridViewComboBoxColumn Event_AlarmLED_Green;
        private System.Windows.Forms.DataGridViewComboBoxColumn Event_AlarmLED_Bule;
        private System.Windows.Forms.DataGridViewComboBoxColumn Event_AlarmBuzzer_A;
        private System.Windows.Forms.DataGridViewComboBoxColumn Event_AlarmBuzzer_B;
        private System.Windows.Forms.DataGridViewComboBoxColumn Event_AlarmIS_Stop;
    }
}

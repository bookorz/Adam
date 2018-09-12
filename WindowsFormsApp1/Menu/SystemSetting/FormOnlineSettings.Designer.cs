namespace Adam.Menu.SystemSetting
{
    partial class FormOnlineSettings
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
            this.tlpConfiguration = new System.Windows.Forms.TableLayoutPanel();
            this.gbConnectingMethod = new System.Windows.Forms.GroupBox();
            this.tlpConnectingMethod = new System.Windows.Forms.TableLayoutPanel();
            this.rdbTCPIP = new System.Windows.Forms.RadioButton();
            this.gbConnectSetting_RS232C = new System.Windows.Forms.GroupBox();
            this.nudCOM = new System.Windows.Forms.NumericUpDown();
            this.label159 = new System.Windows.Forms.Label();
            this.label160 = new System.Windows.Forms.Label();
            this.rdbRS232 = new System.Windows.Forms.RadioButton();
            this.gbConnectSetting_TCPIP = new System.Windows.Forms.GroupBox();
            this.palSubnetMark = new System.Windows.Forms.Panel();
            this.nudMask_4 = new System.Windows.Forms.NumericUpDown();
            this.nudMask_3 = new System.Windows.Forms.NumericUpDown();
            this.nudMask_1 = new System.Windows.Forms.NumericUpDown();
            this.nudMask_2 = new System.Windows.Forms.NumericUpDown();
            this.label161 = new System.Windows.Forms.Label();
            this.label162 = new System.Windows.Forms.Label();
            this.label163 = new System.Windows.Forms.Label();
            this.panel37 = new System.Windows.Forms.Panel();
            this.nudIP_4 = new System.Windows.Forms.NumericUpDown();
            this.nudIP_3 = new System.Windows.Forms.NumericUpDown();
            this.nudIP_1 = new System.Windows.Forms.NumericUpDown();
            this.nudIP_2 = new System.Windows.Forms.NumericUpDown();
            this.label164 = new System.Windows.Forms.Label();
            this.label165 = new System.Windows.Forms.Label();
            this.label166 = new System.Windows.Forms.Label();
            this.txbPort = new System.Windows.Forms.TextBox();
            this.label167 = new System.Windows.Forms.Label();
            this.label168 = new System.Windows.Forms.Label();
            this.label169 = new System.Windows.Forms.Label();
            this.rdbClient = new System.Windows.Forms.RadioButton();
            this.label170 = new System.Windows.Forms.Label();
            this.rdbServer = new System.Windows.Forms.RadioButton();
            this.gbStartCode = new System.Windows.Forms.GroupBox();
            this.rdbASCII = new System.Windows.Forms.RadioButton();
            this.rdbSOH = new System.Windows.Forms.RadioButton();
            this.palIPAddress = new System.Windows.Forms.GroupBox();
            this.rdbCSi = new System.Windows.Forms.RadioButton();
            this.rdbCSih = new System.Windows.Forms.RadioButton();
            this.rdbCShi = new System.Windows.Forms.RadioButton();
            this.gbLengthCode = new System.Windows.Forms.GroupBox();
            this.rdbLENi = new System.Windows.Forms.RadioButton();
            this.rdbLENih = new System.Windows.Forms.RadioButton();
            this.rdbLENhi = new System.Windows.Forms.RadioButton();
            this.spcConfiguration = new System.Windows.Forms.SplitContainer();
            this.gbExitCode = new System.Windows.Forms.GroupBox();
            this.rdbEASCii = new System.Windows.Forms.RadioButton();
            this.rdbCRLF = new System.Windows.Forms.RadioButton();
            this.rdbEXT = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.tlpConfiguration.SuspendLayout();
            this.gbConnectingMethod.SuspendLayout();
            this.tlpConnectingMethod.SuspendLayout();
            this.gbConnectSetting_RS232C.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCOM)).BeginInit();
            this.gbConnectSetting_TCPIP.SuspendLayout();
            this.palSubnetMark.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMask_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMask_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMask_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMask_2)).BeginInit();
            this.panel37.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIP_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIP_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIP_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIP_2)).BeginInit();
            this.gbStartCode.SuspendLayout();
            this.palIPAddress.SuspendLayout();
            this.gbLengthCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcConfiguration)).BeginInit();
            this.spcConfiguration.Panel1.SuspendLayout();
            this.spcConfiguration.Panel2.SuspendLayout();
            this.spcConfiguration.SuspendLayout();
            this.gbExitCode.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpConfiguration
            // 
            this.tlpConfiguration.ColumnCount = 1;
            this.tlpConfiguration.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpConfiguration.Controls.Add(this.gbConnectingMethod, 0, 0);
            this.tlpConfiguration.Controls.Add(this.gbStartCode, 0, 1);
            this.tlpConfiguration.Controls.Add(this.palIPAddress, 0, 3);
            this.tlpConfiguration.Controls.Add(this.gbLengthCode, 0, 2);
            this.tlpConfiguration.Controls.Add(this.spcConfiguration, 0, 4);
            this.tlpConfiguration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpConfiguration.Location = new System.Drawing.Point(0, 0);
            this.tlpConfiguration.Name = "tlpConfiguration";
            this.tlpConfiguration.RowCount = 5;
            this.tlpConfiguration.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48F));
            this.tlpConfiguration.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tlpConfiguration.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tlpConfiguration.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tlpConfiguration.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tlpConfiguration.Size = new System.Drawing.Size(1420, 740);
            this.tlpConfiguration.TabIndex = 1;
            // 
            // gbConnectingMethod
            // 
            this.gbConnectingMethod.Controls.Add(this.tlpConnectingMethod);
            this.gbConnectingMethod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbConnectingMethod.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gbConnectingMethod.Location = new System.Drawing.Point(3, 3);
            this.gbConnectingMethod.Name = "gbConnectingMethod";
            this.gbConnectingMethod.Size = new System.Drawing.Size(1414, 349);
            this.gbConnectingMethod.TabIndex = 89;
            this.gbConnectingMethod.TabStop = false;
            this.gbConnectingMethod.Text = "Connecting method";
            // 
            // tlpConnectingMethod
            // 
            this.tlpConnectingMethod.ColumnCount = 2;
            this.tlpConnectingMethod.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpConnectingMethod.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpConnectingMethod.Controls.Add(this.rdbTCPIP, 0, 0);
            this.tlpConnectingMethod.Controls.Add(this.gbConnectSetting_RS232C, 1, 1);
            this.tlpConnectingMethod.Controls.Add(this.rdbRS232, 1, 0);
            this.tlpConnectingMethod.Controls.Add(this.gbConnectSetting_TCPIP, 0, 1);
            this.tlpConnectingMethod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpConnectingMethod.Location = new System.Drawing.Point(3, 29);
            this.tlpConnectingMethod.Name = "tlpConnectingMethod";
            this.tlpConnectingMethod.RowCount = 2;
            this.tlpConnectingMethod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.05212F));
            this.tlpConnectingMethod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.94788F));
            this.tlpConnectingMethod.Size = new System.Drawing.Size(1408, 317);
            this.tlpConnectingMethod.TabIndex = 87;
            // 
            // rdbTCPIP
            // 
            this.rdbTCPIP.AutoSize = true;
            this.rdbTCPIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdbTCPIP.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbTCPIP.Location = new System.Drawing.Point(3, 3);
            this.rdbTCPIP.Name = "rdbTCPIP";
            this.rdbTCPIP.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.rdbTCPIP.Size = new System.Drawing.Size(698, 32);
            this.rdbTCPIP.TabIndex = 0;
            this.rdbTCPIP.TabStop = true;
            this.rdbTCPIP.Text = "TCP/IP";
            this.rdbTCPIP.UseVisualStyleBackColor = true;
            // 
            // gbConnectSetting_RS232C
            // 
            this.gbConnectSetting_RS232C.Controls.Add(this.nudCOM);
            this.gbConnectSetting_RS232C.Controls.Add(this.label159);
            this.gbConnectSetting_RS232C.Controls.Add(this.label160);
            this.gbConnectSetting_RS232C.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbConnectSetting_RS232C.Font = new System.Drawing.Font("微軟正黑體", 15.75F);
            this.gbConnectSetting_RS232C.Location = new System.Drawing.Point(707, 41);
            this.gbConnectSetting_RS232C.Name = "gbConnectSetting_RS232C";
            this.gbConnectSetting_RS232C.Size = new System.Drawing.Size(698, 273);
            this.gbConnectSetting_RS232C.TabIndex = 86;
            this.gbConnectSetting_RS232C.TabStop = false;
            this.gbConnectSetting_RS232C.Text = "Connect setting";
            // 
            // nudCOM
            // 
            this.nudCOM.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.nudCOM.Location = new System.Drawing.Point(193, 44);
            this.nudCOM.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.nudCOM.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCOM.Name = "nudCOM";
            this.nudCOM.Size = new System.Drawing.Size(59, 33);
            this.nudCOM.TabIndex = 85;
            this.nudCOM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudCOM.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label159
            // 
            this.label159.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label159.AutoSize = true;
            this.label159.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.label159.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label159.Location = new System.Drawing.Point(49, 48);
            this.label159.Name = "label159";
            this.label159.Size = new System.Drawing.Size(83, 24);
            this.label159.TabIndex = 70;
            this.label159.Text = "Port No:";
            this.label159.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label160
            // 
            this.label160.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label160.AutoSize = true;
            this.label160.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.label160.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label160.Location = new System.Drawing.Point(138, 48);
            this.label160.Name = "label160";
            this.label160.Size = new System.Drawing.Size(56, 24);
            this.label160.TabIndex = 86;
            this.label160.Text = "COM";
            this.label160.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rdbRS232
            // 
            this.rdbRS232.AutoSize = true;
            this.rdbRS232.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdbRS232.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbRS232.Location = new System.Drawing.Point(707, 3);
            this.rdbRS232.Name = "rdbRS232";
            this.rdbRS232.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.rdbRS232.Size = new System.Drawing.Size(698, 32);
            this.rdbRS232.TabIndex = 1;
            this.rdbRS232.TabStop = true;
            this.rdbRS232.Text = "RS-232C";
            this.rdbRS232.UseVisualStyleBackColor = true;
            // 
            // gbConnectSetting_TCPIP
            // 
            this.gbConnectSetting_TCPIP.Controls.Add(this.palSubnetMark);
            this.gbConnectSetting_TCPIP.Controls.Add(this.panel37);
            this.gbConnectSetting_TCPIP.Controls.Add(this.txbPort);
            this.gbConnectSetting_TCPIP.Controls.Add(this.label167);
            this.gbConnectSetting_TCPIP.Controls.Add(this.label168);
            this.gbConnectSetting_TCPIP.Controls.Add(this.label169);
            this.gbConnectSetting_TCPIP.Controls.Add(this.rdbClient);
            this.gbConnectSetting_TCPIP.Controls.Add(this.label170);
            this.gbConnectSetting_TCPIP.Controls.Add(this.rdbServer);
            this.gbConnectSetting_TCPIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbConnectSetting_TCPIP.Font = new System.Drawing.Font("微軟正黑體", 15.75F);
            this.gbConnectSetting_TCPIP.Location = new System.Drawing.Point(3, 41);
            this.gbConnectSetting_TCPIP.Name = "gbConnectSetting_TCPIP";
            this.gbConnectSetting_TCPIP.Size = new System.Drawing.Size(698, 273);
            this.gbConnectSetting_TCPIP.TabIndex = 2;
            this.gbConnectSetting_TCPIP.TabStop = false;
            this.gbConnectSetting_TCPIP.Text = "Connect setting";
            // 
            // palSubnetMark
            // 
            this.palSubnetMark.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.palSubnetMark.Controls.Add(this.nudMask_4);
            this.palSubnetMark.Controls.Add(this.nudMask_3);
            this.palSubnetMark.Controls.Add(this.nudMask_1);
            this.palSubnetMark.Controls.Add(this.nudMask_2);
            this.palSubnetMark.Controls.Add(this.label161);
            this.palSubnetMark.Controls.Add(this.label162);
            this.palSubnetMark.Controls.Add(this.label163);
            this.palSubnetMark.Location = new System.Drawing.Point(173, 142);
            this.palSubnetMark.Name = "palSubnetMark";
            this.palSubnetMark.Size = new System.Drawing.Size(296, 38);
            this.palSubnetMark.TabIndex = 85;
            // 
            // nudMask_4
            // 
            this.nudMask_4.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.nudMask_4.Location = new System.Drawing.Point(232, 0);
            this.nudMask_4.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudMask_4.Name = "nudMask_4";
            this.nudMask_4.Size = new System.Drawing.Size(57, 33);
            this.nudMask_4.TabIndex = 84;
            this.nudMask_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nudMask_3
            // 
            this.nudMask_3.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.nudMask_3.Location = new System.Drawing.Point(155, 0);
            this.nudMask_3.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudMask_3.Name = "nudMask_3";
            this.nudMask_3.Size = new System.Drawing.Size(59, 33);
            this.nudMask_3.TabIndex = 82;
            this.nudMask_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudMask_3.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // nudMask_1
            // 
            this.nudMask_1.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.nudMask_1.Location = new System.Drawing.Point(1, 0);
            this.nudMask_1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudMask_1.Name = "nudMask_1";
            this.nudMask_1.Size = new System.Drawing.Size(59, 33);
            this.nudMask_1.TabIndex = 76;
            this.nudMask_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudMask_1.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // nudMask_2
            // 
            this.nudMask_2.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.nudMask_2.Location = new System.Drawing.Point(75, 0);
            this.nudMask_2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudMask_2.Name = "nudMask_2";
            this.nudMask_2.Size = new System.Drawing.Size(59, 33);
            this.nudMask_2.TabIndex = 80;
            this.nudMask_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudMask_2.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // label161
            // 
            this.label161.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label161.AutoSize = true;
            this.label161.Font = new System.Drawing.Font("微軟正黑體", 18F);
            this.label161.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label161.Location = new System.Drawing.Point(60, 1);
            this.label161.Name = "label161";
            this.label161.Size = new System.Drawing.Size(19, 30);
            this.label161.TabIndex = 77;
            this.label161.Text = ".";
            this.label161.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label162
            // 
            this.label162.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label162.AutoSize = true;
            this.label162.Font = new System.Drawing.Font("微軟正黑體", 18F);
            this.label162.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label162.Location = new System.Drawing.Point(137, 1);
            this.label162.Name = "label162";
            this.label162.Size = new System.Drawing.Size(19, 30);
            this.label162.TabIndex = 81;
            this.label162.Text = ".";
            this.label162.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label163
            // 
            this.label163.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label163.AutoSize = true;
            this.label163.Font = new System.Drawing.Font("微軟正黑體", 18F);
            this.label163.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label163.Location = new System.Drawing.Point(212, 0);
            this.label163.Name = "label163";
            this.label163.Size = new System.Drawing.Size(19, 30);
            this.label163.TabIndex = 83;
            this.label163.Text = ".";
            this.label163.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel37
            // 
            this.panel37.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel37.Controls.Add(this.nudIP_4);
            this.panel37.Controls.Add(this.nudIP_3);
            this.panel37.Controls.Add(this.nudIP_1);
            this.panel37.Controls.Add(this.nudIP_2);
            this.panel37.Controls.Add(this.label164);
            this.panel37.Controls.Add(this.label165);
            this.panel37.Controls.Add(this.label166);
            this.panel37.Location = new System.Drawing.Point(173, 94);
            this.panel37.Name = "panel37";
            this.panel37.Size = new System.Drawing.Size(296, 38);
            this.panel37.TabIndex = 85;
            // 
            // nudIP_4
            // 
            this.nudIP_4.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.nudIP_4.Location = new System.Drawing.Point(232, 0);
            this.nudIP_4.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudIP_4.Name = "nudIP_4";
            this.nudIP_4.Size = new System.Drawing.Size(57, 33);
            this.nudIP_4.TabIndex = 84;
            this.nudIP_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudIP_4.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudIP_3
            // 
            this.nudIP_3.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.nudIP_3.Location = new System.Drawing.Point(155, 0);
            this.nudIP_3.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudIP_3.Name = "nudIP_3";
            this.nudIP_3.Size = new System.Drawing.Size(59, 33);
            this.nudIP_3.TabIndex = 82;
            this.nudIP_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nudIP_1
            // 
            this.nudIP_1.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.nudIP_1.Location = new System.Drawing.Point(1, 0);
            this.nudIP_1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudIP_1.Name = "nudIP_1";
            this.nudIP_1.Size = new System.Drawing.Size(59, 33);
            this.nudIP_1.TabIndex = 76;
            this.nudIP_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudIP_1.Value = new decimal(new int[] {
            127,
            0,
            0,
            0});
            // 
            // nudIP_2
            // 
            this.nudIP_2.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.nudIP_2.Location = new System.Drawing.Point(75, 0);
            this.nudIP_2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudIP_2.Name = "nudIP_2";
            this.nudIP_2.Size = new System.Drawing.Size(59, 33);
            this.nudIP_2.TabIndex = 80;
            this.nudIP_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label164
            // 
            this.label164.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label164.AutoSize = true;
            this.label164.Font = new System.Drawing.Font("微軟正黑體", 18F);
            this.label164.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label164.Location = new System.Drawing.Point(60, 1);
            this.label164.Name = "label164";
            this.label164.Size = new System.Drawing.Size(19, 30);
            this.label164.TabIndex = 77;
            this.label164.Text = ".";
            this.label164.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label165
            // 
            this.label165.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label165.AutoSize = true;
            this.label165.Font = new System.Drawing.Font("微軟正黑體", 18F);
            this.label165.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label165.Location = new System.Drawing.Point(137, 1);
            this.label165.Name = "label165";
            this.label165.Size = new System.Drawing.Size(19, 30);
            this.label165.TabIndex = 81;
            this.label165.Text = ".";
            this.label165.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label166
            // 
            this.label166.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label166.AutoSize = true;
            this.label166.Font = new System.Drawing.Font("微軟正黑體", 18F);
            this.label166.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label166.Location = new System.Drawing.Point(212, 0);
            this.label166.Name = "label166";
            this.label166.Size = new System.Drawing.Size(19, 30);
            this.label166.TabIndex = 83;
            this.label166.Text = ".";
            this.label166.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txbPort
            // 
            this.txbPort.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbPort.BackColor = System.Drawing.Color.White;
            this.txbPort.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbPort.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.txbPort.Location = new System.Drawing.Point(173, 192);
            this.txbPort.Name = "txbPort";
            this.txbPort.ReadOnly = true;
            this.txbPort.Size = new System.Drawing.Size(296, 26);
            this.txbPort.TabIndex = 75;
            this.txbPort.Text = "13000";
            this.txbPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label167
            // 
            this.label167.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label167.AutoSize = true;
            this.label167.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.label167.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label167.Location = new System.Drawing.Point(98, 193);
            this.label167.Name = "label167";
            this.label167.Size = new System.Drawing.Size(51, 24);
            this.label167.TabIndex = 74;
            this.label167.Text = "Port:";
            this.label167.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label168
            // 
            this.label168.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label168.AutoSize = true;
            this.label168.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.label168.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label168.Location = new System.Drawing.Point(11, 148);
            this.label168.Name = "label168";
            this.label168.Size = new System.Drawing.Size(131, 24);
            this.label168.TabIndex = 72;
            this.label168.Text = "Subnet Mask:";
            this.label168.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label169
            // 
            this.label169.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label169.AutoSize = true;
            this.label169.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.label169.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label169.Location = new System.Drawing.Point(35, 100);
            this.label169.Name = "label169";
            this.label169.Size = new System.Drawing.Size(108, 24);
            this.label169.TabIndex = 72;
            this.label169.Text = "IP Address:";
            this.label169.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rdbClient
            // 
            this.rdbClient.AutoSize = true;
            this.rdbClient.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.rdbClient.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbClient.Location = new System.Drawing.Point(272, 48);
            this.rdbClient.Name = "rdbClient";
            this.rdbClient.Size = new System.Drawing.Size(81, 28);
            this.rdbClient.TabIndex = 71;
            this.rdbClient.TabStop = true;
            this.rdbClient.Text = "Client";
            this.rdbClient.UseVisualStyleBackColor = true;
            // 
            // label170
            // 
            this.label170.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label170.AutoSize = true;
            this.label170.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.label170.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label170.Location = new System.Drawing.Point(21, 50);
            this.label170.Name = "label170";
            this.label170.Size = new System.Drawing.Size(123, 24);
            this.label170.TabIndex = 70;
            this.label170.Text = "Socket Type:";
            this.label170.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rdbServer
            // 
            this.rdbServer.AutoSize = true;
            this.rdbServer.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.rdbServer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbServer.Location = new System.Drawing.Point(173, 48);
            this.rdbServer.Name = "rdbServer";
            this.rdbServer.Size = new System.Drawing.Size(85, 28);
            this.rdbServer.TabIndex = 0;
            this.rdbServer.TabStop = true;
            this.rdbServer.Text = "Server";
            this.rdbServer.UseVisualStyleBackColor = true;
            // 
            // gbStartCode
            // 
            this.gbStartCode.Controls.Add(this.rdbASCII);
            this.gbStartCode.Controls.Add(this.rdbSOH);
            this.gbStartCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbStartCode.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gbStartCode.Location = new System.Drawing.Point(3, 358);
            this.gbStartCode.Name = "gbStartCode";
            this.gbStartCode.Size = new System.Drawing.Size(1414, 90);
            this.gbStartCode.TabIndex = 93;
            this.gbStartCode.TabStop = false;
            this.gbStartCode.Text = "Start Code Of The Message";
            // 
            // rdbASCII
            // 
            this.rdbASCII.AutoSize = true;
            this.rdbASCII.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbASCII.Location = new System.Drawing.Point(451, 38);
            this.rdbASCII.Name = "rdbASCII";
            this.rdbASCII.Size = new System.Drawing.Size(122, 28);
            this.rdbASCII.TabIndex = 1;
            this.rdbASCII.TabStop = true;
            this.rdbASCII.Text = "ASCII(5Bh)";
            this.rdbASCII.UseVisualStyleBackColor = true;
            // 
            // rdbSOH
            // 
            this.rdbSOH.AutoSize = true;
            this.rdbSOH.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbSOH.Location = new System.Drawing.Point(39, 38);
            this.rdbSOH.Name = "rdbSOH";
            this.rdbSOH.Size = new System.Drawing.Size(114, 28);
            this.rdbSOH.TabIndex = 0;
            this.rdbSOH.TabStop = true;
            this.rdbSOH.Text = "SOH(01h)";
            this.rdbSOH.UseVisualStyleBackColor = true;
            // 
            // palIPAddress
            // 
            this.palIPAddress.Controls.Add(this.rdbCSi);
            this.palIPAddress.Controls.Add(this.rdbCSih);
            this.palIPAddress.Controls.Add(this.rdbCShi);
            this.palIPAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palIPAddress.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.palIPAddress.Location = new System.Drawing.Point(3, 550);
            this.palIPAddress.Name = "palIPAddress";
            this.palIPAddress.Size = new System.Drawing.Size(1414, 90);
            this.palIPAddress.TabIndex = 91;
            this.palIPAddress.TabStop = false;
            this.palIPAddress.Text = "Check-sum Code Of The Message";
            // 
            // rdbCSi
            // 
            this.rdbCSi.AutoSize = true;
            this.rdbCSi.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbCSi.Location = new System.Drawing.Point(837, 38);
            this.rdbCSi.Name = "rdbCSi";
            this.rdbCSi.Size = new System.Drawing.Size(116, 28);
            this.rdbCSi.TabIndex = 0;
            this.rdbCSi.TabStop = true;
            this.rdbCSi.Text = "CSl(ASCII)";
            this.rdbCSi.UseVisualStyleBackColor = true;
            // 
            // rdbCSih
            // 
            this.rdbCSih.AutoSize = true;
            this.rdbCSih.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbCSih.Location = new System.Drawing.Point(451, 38);
            this.rdbCSih.Name = "rdbCSih";
            this.rdbCSih.Size = new System.Drawing.Size(185, 28);
            this.rdbCSih.TabIndex = 0;
            this.rdbCSih.TabStop = true;
            this.rdbCSih.Text = "CSl + CSh(Binary)";
            this.rdbCSih.UseVisualStyleBackColor = true;
            // 
            // rdbCShi
            // 
            this.rdbCShi.AutoSize = true;
            this.rdbCShi.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbCShi.Location = new System.Drawing.Point(39, 38);
            this.rdbCShi.Name = "rdbCShi";
            this.rdbCShi.Size = new System.Drawing.Size(185, 28);
            this.rdbCShi.TabIndex = 0;
            this.rdbCShi.TabStop = true;
            this.rdbCShi.Text = "CSh + CSl(Binary)";
            this.rdbCShi.UseVisualStyleBackColor = true;
            // 
            // gbLengthCode
            // 
            this.gbLengthCode.Controls.Add(this.rdbLENi);
            this.gbLengthCode.Controls.Add(this.rdbLENih);
            this.gbLengthCode.Controls.Add(this.rdbLENhi);
            this.gbLengthCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbLengthCode.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gbLengthCode.Location = new System.Drawing.Point(3, 454);
            this.gbLengthCode.Name = "gbLengthCode";
            this.gbLengthCode.Size = new System.Drawing.Size(1414, 90);
            this.gbLengthCode.TabIndex = 92;
            this.gbLengthCode.TabStop = false;
            this.gbLengthCode.Text = "Length Code Of The Message";
            // 
            // rdbLENi
            // 
            this.rdbLENi.AutoSize = true;
            this.rdbLENi.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbLENi.Location = new System.Drawing.Point(837, 38);
            this.rdbLENi.Name = "rdbLENi";
            this.rdbLENi.Size = new System.Drawing.Size(127, 28);
            this.rdbLENi.TabIndex = 0;
            this.rdbLENi.TabStop = true;
            this.rdbLENi.Text = "LENl(ASCII)";
            this.rdbLENi.UseVisualStyleBackColor = true;
            // 
            // rdbLENih
            // 
            this.rdbLENih.AutoSize = true;
            this.rdbLENih.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbLENih.Location = new System.Drawing.Point(451, 38);
            this.rdbLENih.Name = "rdbLENih";
            this.rdbLENih.Size = new System.Drawing.Size(207, 28);
            this.rdbLENih.TabIndex = 0;
            this.rdbLENih.TabStop = true;
            this.rdbLENih.Text = "LENl + LENh(Binary)";
            this.rdbLENih.UseVisualStyleBackColor = true;
            // 
            // rdbLENhi
            // 
            this.rdbLENhi.AutoSize = true;
            this.rdbLENhi.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbLENhi.Location = new System.Drawing.Point(39, 38);
            this.rdbLENhi.Name = "rdbLENhi";
            this.rdbLENhi.Size = new System.Drawing.Size(207, 28);
            this.rdbLENhi.TabIndex = 0;
            this.rdbLENhi.TabStop = true;
            this.rdbLENhi.Text = "LENh + LENl(Binary)";
            this.rdbLENhi.UseVisualStyleBackColor = true;
            // 
            // spcConfiguration
            // 
            this.spcConfiguration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcConfiguration.Location = new System.Drawing.Point(3, 646);
            this.spcConfiguration.Name = "spcConfiguration";
            // 
            // spcConfiguration.Panel1
            // 
            this.spcConfiguration.Panel1.Controls.Add(this.gbExitCode);
            // 
            // spcConfiguration.Panel2
            // 
            this.spcConfiguration.Panel2.Controls.Add(this.btnSave);
            this.spcConfiguration.Size = new System.Drawing.Size(1414, 91);
            this.spcConfiguration.SplitterDistance = 1189;
            this.spcConfiguration.TabIndex = 94;
            // 
            // gbExitCode
            // 
            this.gbExitCode.Controls.Add(this.rdbEASCii);
            this.gbExitCode.Controls.Add(this.rdbCRLF);
            this.gbExitCode.Controls.Add(this.rdbEXT);
            this.gbExitCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbExitCode.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gbExitCode.Location = new System.Drawing.Point(0, 0);
            this.gbExitCode.Name = "gbExitCode";
            this.gbExitCode.Size = new System.Drawing.Size(1189, 91);
            this.gbExitCode.TabIndex = 90;
            this.gbExitCode.TabStop = false;
            this.gbExitCode.Text = "Exit Code Of The Message";
            // 
            // rdbEASCii
            // 
            this.rdbEASCii.AutoSize = true;
            this.rdbEASCii.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbEASCii.Location = new System.Drawing.Point(837, 38);
            this.rdbEASCii.Name = "rdbEASCii";
            this.rdbEASCii.Size = new System.Drawing.Size(124, 28);
            this.rdbEASCii.TabIndex = 0;
            this.rdbEASCii.TabStop = true;
            this.rdbEASCii.Text = "ASCII(5Dh)";
            this.rdbEASCii.UseVisualStyleBackColor = true;
            // 
            // rdbCRLF
            // 
            this.rdbCRLF.AutoSize = true;
            this.rdbCRLF.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbCRLF.Location = new System.Drawing.Point(451, 38);
            this.rdbCRLF.Name = "rdbCRLF";
            this.rdbCRLF.Size = new System.Drawing.Size(206, 28);
            this.rdbCRLF.TabIndex = 0;
            this.rdbCRLF.TabStop = true;
            this.rdbCRLF.Text = "CR + LF(0Dh + 0Ah)";
            this.rdbCRLF.UseVisualStyleBackColor = true;
            // 
            // rdbEXT
            // 
            this.rdbEXT.AutoSize = true;
            this.rdbEXT.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbEXT.Location = new System.Drawing.Point(39, 38);
            this.rdbEXT.Name = "rdbEXT";
            this.rdbEXT.Size = new System.Drawing.Size(107, 28);
            this.rdbEXT.TabIndex = 0;
            this.rdbEXT.TabStop = true;
            this.rdbEXT.Text = "EXT(03h)";
            this.rdbEXT.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkGray;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.FlatAppearance.BorderSize = 2;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(11, 35);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(201, 46);
            this.btnSave.TabIndex = 94;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // FormOnlineSettings
            // 
            this.ClientSize = new System.Drawing.Size(1420, 740);
            this.Controls.Add(this.tlpConfiguration);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormOnlineSettings";
            this.Text = "Online Settings";
            this.tlpConfiguration.ResumeLayout(false);
            this.gbConnectingMethod.ResumeLayout(false);
            this.tlpConnectingMethod.ResumeLayout(false);
            this.tlpConnectingMethod.PerformLayout();
            this.gbConnectSetting_RS232C.ResumeLayout(false);
            this.gbConnectSetting_RS232C.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCOM)).EndInit();
            this.gbConnectSetting_TCPIP.ResumeLayout(false);
            this.gbConnectSetting_TCPIP.PerformLayout();
            this.palSubnetMark.ResumeLayout(false);
            this.palSubnetMark.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMask_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMask_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMask_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMask_2)).EndInit();
            this.panel37.ResumeLayout(false);
            this.panel37.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIP_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIP_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIP_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIP_2)).EndInit();
            this.gbStartCode.ResumeLayout(false);
            this.gbStartCode.PerformLayout();
            this.palIPAddress.ResumeLayout(false);
            this.palIPAddress.PerformLayout();
            this.gbLengthCode.ResumeLayout(false);
            this.gbLengthCode.PerformLayout();
            this.spcConfiguration.Panel1.ResumeLayout(false);
            this.spcConfiguration.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcConfiguration)).EndInit();
            this.spcConfiguration.ResumeLayout(false);
            this.gbExitCode.ResumeLayout(false);
            this.gbExitCode.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpConfiguration;
        private System.Windows.Forms.GroupBox gbConnectingMethod;
        private System.Windows.Forms.TableLayoutPanel tlpConnectingMethod;
        private System.Windows.Forms.RadioButton rdbTCPIP;
        private System.Windows.Forms.GroupBox gbConnectSetting_RS232C;
        private System.Windows.Forms.NumericUpDown nudCOM;
        private System.Windows.Forms.Label label159;
        private System.Windows.Forms.Label label160;
        private System.Windows.Forms.RadioButton rdbRS232;
        private System.Windows.Forms.GroupBox gbConnectSetting_TCPIP;
        private System.Windows.Forms.Panel palSubnetMark;
        private System.Windows.Forms.NumericUpDown nudMask_4;
        private System.Windows.Forms.NumericUpDown nudMask_3;
        private System.Windows.Forms.NumericUpDown nudMask_1;
        private System.Windows.Forms.NumericUpDown nudMask_2;
        private System.Windows.Forms.Label label161;
        private System.Windows.Forms.Label label162;
        private System.Windows.Forms.Label label163;
        private System.Windows.Forms.Panel panel37;
        private System.Windows.Forms.NumericUpDown nudIP_4;
        private System.Windows.Forms.NumericUpDown nudIP_3;
        private System.Windows.Forms.NumericUpDown nudIP_1;
        private System.Windows.Forms.NumericUpDown nudIP_2;
        private System.Windows.Forms.Label label164;
        private System.Windows.Forms.Label label165;
        private System.Windows.Forms.Label label166;
        private System.Windows.Forms.TextBox txbPort;
        private System.Windows.Forms.Label label167;
        private System.Windows.Forms.Label label168;
        private System.Windows.Forms.Label label169;
        private System.Windows.Forms.RadioButton rdbClient;
        private System.Windows.Forms.Label label170;
        private System.Windows.Forms.RadioButton rdbServer;
        private System.Windows.Forms.GroupBox gbStartCode;
        private System.Windows.Forms.RadioButton rdbASCII;
        private System.Windows.Forms.RadioButton rdbSOH;
        private System.Windows.Forms.GroupBox palIPAddress;
        private System.Windows.Forms.RadioButton rdbCSi;
        private System.Windows.Forms.RadioButton rdbCSih;
        private System.Windows.Forms.RadioButton rdbCShi;
        private System.Windows.Forms.GroupBox gbLengthCode;
        private System.Windows.Forms.RadioButton rdbLENi;
        private System.Windows.Forms.RadioButton rdbLENih;
        private System.Windows.Forms.RadioButton rdbLENhi;
        private System.Windows.Forms.SplitContainer spcConfiguration;
        private System.Windows.Forms.GroupBox gbExitCode;
        private System.Windows.Forms.RadioButton rdbEASCii;
        private System.Windows.Forms.RadioButton rdbCRLF;
        private System.Windows.Forms.RadioButton rdbEXT;
        private System.Windows.Forms.Button btnSave;
    }
}

namespace Adam.Menu.SystemSetting
{
    partial class FormDeviceManager
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
            this.gbNodeManager = new System.Windows.Forms.GroupBox();
            this.splitContainerNode = new System.Windows.Forms.SplitContainer();
            this.gbCondition = new System.Windows.Forms.GroupBox();
            this.lstNodeList = new System.Windows.Forms.ListBox();
            this.splitContainerSetting = new System.Windows.Forms.SplitContainer();
            this.lbDeviceNodeManager = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txbFirmwareVersion = new System.Windows.Forms.TextBox();
            this.txbModel = new System.Windows.Forms.TextBox();
            this.lbEquipmentModel = new System.Windows.Forms.Label();
            this.lbDeviceNodeName = new System.Windows.Forms.Label();
            this.lbDeviceNodeType = new System.Windows.Forms.Label();
            this.lbSerialNo = new System.Windows.Forms.Label();
            this.lbVendor = new System.Windows.Forms.Label();
            this.lbModel = new System.Windows.Forms.Label();
            this.lbFirmwareVersion = new System.Windows.Forms.Label();
            this.lbAddress = new System.Windows.Forms.Label();
            this.lbControllerID = new System.Windows.Forms.Label();
            this.cmbDeviceNodeType = new System.Windows.Forms.ComboBox();
            this.cmbVendor = new System.Windows.Forms.ComboBox();
            this.nudSerialNo = new System.Windows.Forms.NumericUpDown();
            this.txbAddress = new System.Windows.Forms.TextBox();
            this.txbDeviceNodeName = new System.Windows.Forms.TextBox();
            this.txbEquipmentModel = new System.Windows.Forms.TextBox();
            this.txbControllerID = new System.Windows.Forms.TextBox();
            this.lbDefaultAligner = new System.Windows.Forms.Label();
            this.lbAlternativeAligner = new System.Windows.Forms.Label();
            this.chbByPass = new System.Windows.Forms.CheckBox();
            this.lbRoute = new System.Windows.Forms.Label();
            this.chbActive = new System.Windows.Forms.CheckBox();
            this.txbDefaultAligner = new System.Windows.Forms.TextBox();
            this.txbAlternativeAligner = new System.Windows.Forms.TextBox();
            this.dgvRouteTable = new System.Windows.Forms.DataGridView();
            this.tlpButton = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbNodeManager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerNode)).BeginInit();
            this.splitContainerNode.Panel1.SuspendLayout();
            this.splitContainerNode.Panel2.SuspendLayout();
            this.splitContainerNode.SuspendLayout();
            this.gbCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSetting)).BeginInit();
            this.splitContainerSetting.Panel1.SuspendLayout();
            this.splitContainerSetting.Panel2.SuspendLayout();
            this.splitContainerSetting.SuspendLayout();
            this.lbDeviceNodeManager.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSerialNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRouteTable)).BeginInit();
            this.tlpButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbNodeManager
            // 
            this.gbNodeManager.Controls.Add(this.splitContainerNode);
            this.gbNodeManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbNodeManager.Location = new System.Drawing.Point(0, 0);
            this.gbNodeManager.Name = "gbNodeManager";
            this.gbNodeManager.Size = new System.Drawing.Size(1420, 740);
            this.gbNodeManager.TabIndex = 67;
            this.gbNodeManager.TabStop = false;
            this.gbNodeManager.Text = "Device node manager";
            // 
            // splitContainerNode
            // 
            this.splitContainerNode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerNode.Location = new System.Drawing.Point(3, 25);
            this.splitContainerNode.Name = "splitContainerNode";
            // 
            // splitContainerNode.Panel1
            // 
            this.splitContainerNode.Panel1.Controls.Add(this.gbCondition);
            // 
            // splitContainerNode.Panel2
            // 
            this.splitContainerNode.Panel2.Controls.Add(this.splitContainerSetting);
            this.splitContainerNode.Size = new System.Drawing.Size(1414, 712);
            this.splitContainerNode.SplitterDistance = 331;
            this.splitContainerNode.TabIndex = 0;
            // 
            // gbCondition
            // 
            this.gbCondition.Controls.Add(this.lstNodeList);
            this.gbCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCondition.Location = new System.Drawing.Point(0, 0);
            this.gbCondition.Name = "gbCondition";
            this.gbCondition.Size = new System.Drawing.Size(331, 712);
            this.gbCondition.TabIndex = 0;
            this.gbCondition.TabStop = false;
            this.gbCondition.Text = "Device node list";
            // 
            // lstNodeList
            // 
            this.lstNodeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstNodeList.FormattingEnabled = true;
            this.lstNodeList.ItemHeight = 20;
            this.lstNodeList.Location = new System.Drawing.Point(3, 25);
            this.lstNodeList.Name = "lstNodeList";
            this.lstNodeList.Size = new System.Drawing.Size(325, 684);
            this.lstNodeList.TabIndex = 0;
            this.lstNodeList.Click += new System.EventHandler(this.lstNodeList_Click);
            // 
            // splitContainerSetting
            // 
            this.splitContainerSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerSetting.Location = new System.Drawing.Point(0, 0);
            this.splitContainerSetting.Name = "splitContainerSetting";
            this.splitContainerSetting.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerSetting.Panel1
            // 
            this.splitContainerSetting.Panel1.Controls.Add(this.lbDeviceNodeManager);
            // 
            // splitContainerSetting.Panel2
            // 
            this.splitContainerSetting.Panel2.Controls.Add(this.tlpButton);
            this.splitContainerSetting.Size = new System.Drawing.Size(1079, 712);
            this.splitContainerSetting.SplitterDistance = 644;
            this.splitContainerSetting.TabIndex = 0;
            // 
            // lbDeviceNodeManager
            // 
            this.lbDeviceNodeManager.Controls.Add(this.tableLayoutPanel1);
            this.lbDeviceNodeManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDeviceNodeManager.Location = new System.Drawing.Point(0, 0);
            this.lbDeviceNodeManager.Name = "lbDeviceNodeManager";
            this.lbDeviceNodeManager.Size = new System.Drawing.Size(1079, 644);
            this.lbDeviceNodeManager.TabIndex = 0;
            this.lbDeviceNodeManager.TabStop = false;
            this.lbDeviceNodeManager.Text = "Device node setting";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.35974F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.64026F));
            this.tableLayoutPanel1.Controls.Add(this.txbFirmwareVersion, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.txbModel, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lbEquipmentModel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbDeviceNodeName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbDeviceNodeType, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbSerialNo, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbVendor, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbModel, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lbFirmwareVersion, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lbAddress, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.lbControllerID, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.cmbDeviceNodeType, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbVendor, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.nudSerialNo, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txbAddress, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.txbDeviceNodeName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txbEquipmentModel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txbControllerID, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.lbDefaultAligner, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.lbAlternativeAligner, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.chbByPass, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.lbRoute, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.chbActive, 1, 13);
            this.tableLayoutPanel1.Controls.Add(this.txbDefaultAligner, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.txbAlternativeAligner, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.dgvRouteTable, 1, 12);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 14;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1073, 616);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txbFirmwareVersion
            // 
            this.txbFirmwareVersion.Dock = System.Windows.Forms.DockStyle.Left;
            this.txbFirmwareVersion.Location = new System.Drawing.Point(200, 243);
            this.txbFirmwareVersion.Name = "txbFirmwareVersion";
            this.txbFirmwareVersion.Size = new System.Drawing.Size(470, 29);
            this.txbFirmwareVersion.TabIndex = 20;
            // 
            // txbModel
            // 
            this.txbModel.Dock = System.Windows.Forms.DockStyle.Left;
            this.txbModel.Location = new System.Drawing.Point(200, 203);
            this.txbModel.Name = "txbModel";
            this.txbModel.Size = new System.Drawing.Size(470, 29);
            this.txbModel.TabIndex = 19;
            // 
            // lbEquipmentModel
            // 
            this.lbEquipmentModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbEquipmentModel.Location = new System.Drawing.Point(3, 0);
            this.lbEquipmentModel.Name = "lbEquipmentModel";
            this.lbEquipmentModel.Size = new System.Drawing.Size(191, 40);
            this.lbEquipmentModel.TabIndex = 0;
            this.lbEquipmentModel.Text = "Equipment model";
            this.lbEquipmentModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbDeviceNodeName
            // 
            this.lbDeviceNodeName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDeviceNodeName.Location = new System.Drawing.Point(3, 40);
            this.lbDeviceNodeName.Name = "lbDeviceNodeName";
            this.lbDeviceNodeName.Size = new System.Drawing.Size(191, 40);
            this.lbDeviceNodeName.TabIndex = 1;
            this.lbDeviceNodeName.Text = "Device node name";
            this.lbDeviceNodeName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbDeviceNodeType
            // 
            this.lbDeviceNodeType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDeviceNodeType.Location = new System.Drawing.Point(3, 80);
            this.lbDeviceNodeType.Name = "lbDeviceNodeType";
            this.lbDeviceNodeType.Size = new System.Drawing.Size(191, 40);
            this.lbDeviceNodeType.TabIndex = 2;
            this.lbDeviceNodeType.Text = "Device node type";
            this.lbDeviceNodeType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbSerialNo
            // 
            this.lbSerialNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSerialNo.Location = new System.Drawing.Point(3, 120);
            this.lbSerialNo.Name = "lbSerialNo";
            this.lbSerialNo.Size = new System.Drawing.Size(191, 40);
            this.lbSerialNo.TabIndex = 3;
            this.lbSerialNo.Text = "Serial no";
            this.lbSerialNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbVendor
            // 
            this.lbVendor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbVendor.Location = new System.Drawing.Point(3, 160);
            this.lbVendor.Name = "lbVendor";
            this.lbVendor.Size = new System.Drawing.Size(191, 40);
            this.lbVendor.TabIndex = 4;
            this.lbVendor.Text = "Vendor";
            this.lbVendor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbModel
            // 
            this.lbModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbModel.Location = new System.Drawing.Point(3, 200);
            this.lbModel.Name = "lbModel";
            this.lbModel.Size = new System.Drawing.Size(191, 40);
            this.lbModel.TabIndex = 5;
            this.lbModel.Text = "Model";
            this.lbModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbFirmwareVersion
            // 
            this.lbFirmwareVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFirmwareVersion.Location = new System.Drawing.Point(3, 240);
            this.lbFirmwareVersion.Name = "lbFirmwareVersion";
            this.lbFirmwareVersion.Size = new System.Drawing.Size(191, 40);
            this.lbFirmwareVersion.TabIndex = 6;
            this.lbFirmwareVersion.Text = "Firmware version";
            this.lbFirmwareVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbAddress
            // 
            this.lbAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbAddress.Location = new System.Drawing.Point(3, 280);
            this.lbAddress.Name = "lbAddress";
            this.lbAddress.Size = new System.Drawing.Size(191, 40);
            this.lbAddress.TabIndex = 7;
            this.lbAddress.Text = "Address";
            this.lbAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbControllerID
            // 
            this.lbControllerID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbControllerID.Location = new System.Drawing.Point(3, 320);
            this.lbControllerID.Name = "lbControllerID";
            this.lbControllerID.Size = new System.Drawing.Size(191, 40);
            this.lbControllerID.TabIndex = 8;
            this.lbControllerID.Text = "Controller ID";
            this.lbControllerID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbDeviceNodeType
            // 
            this.cmbDeviceNodeType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDeviceNodeType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDeviceNodeType.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmbDeviceNodeType.FormattingEnabled = true;
            this.cmbDeviceNodeType.Location = new System.Drawing.Point(200, 83);
            this.cmbDeviceNodeType.Name = "cmbDeviceNodeType";
            this.cmbDeviceNodeType.Size = new System.Drawing.Size(470, 28);
            this.cmbDeviceNodeType.TabIndex = 11;
            this.cmbDeviceNodeType.SelectionChangeCommitted += new System.EventHandler(this.cmbDeviceNodeType_SelectionChangeCommitted);
            // 
            // cmbVendor
            // 
            this.cmbVendor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbVendor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbVendor.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmbVendor.FormattingEnabled = true;
            this.cmbVendor.Location = new System.Drawing.Point(200, 163);
            this.cmbVendor.Name = "cmbVendor";
            this.cmbVendor.Size = new System.Drawing.Size(470, 28);
            this.cmbVendor.TabIndex = 12;
            // 
            // nudSerialNo
            // 
            this.nudSerialNo.BackColor = System.Drawing.Color.White;
            this.nudSerialNo.Dock = System.Windows.Forms.DockStyle.Left;
            this.nudSerialNo.Enabled = false;
            this.nudSerialNo.Location = new System.Drawing.Point(200, 123);
            this.nudSerialNo.Name = "nudSerialNo";
            this.nudSerialNo.Size = new System.Drawing.Size(470, 29);
            this.nudSerialNo.TabIndex = 13;
            // 
            // txbAddress
            // 
            this.txbAddress.Dock = System.Windows.Forms.DockStyle.Left;
            this.txbAddress.Location = new System.Drawing.Point(200, 283);
            this.txbAddress.Name = "txbAddress";
            this.txbAddress.Size = new System.Drawing.Size(470, 29);
            this.txbAddress.TabIndex = 17;
            // 
            // txbDeviceNodeName
            // 
            this.txbDeviceNodeName.Dock = System.Windows.Forms.DockStyle.Left;
            this.txbDeviceNodeName.Location = new System.Drawing.Point(200, 43);
            this.txbDeviceNodeName.Name = "txbDeviceNodeName";
            this.txbDeviceNodeName.Size = new System.Drawing.Size(470, 29);
            this.txbDeviceNodeName.TabIndex = 18;
            // 
            // txbEquipmentModel
            // 
            this.txbEquipmentModel.BackColor = System.Drawing.Color.White;
            this.txbEquipmentModel.Dock = System.Windows.Forms.DockStyle.Left;
            this.txbEquipmentModel.Location = new System.Drawing.Point(200, 3);
            this.txbEquipmentModel.Name = "txbEquipmentModel";
            this.txbEquipmentModel.ReadOnly = true;
            this.txbEquipmentModel.Size = new System.Drawing.Size(470, 29);
            this.txbEquipmentModel.TabIndex = 21;
            // 
            // txbControllerID
            // 
            this.txbControllerID.BackColor = System.Drawing.Color.White;
            this.txbControllerID.Dock = System.Windows.Forms.DockStyle.Left;
            this.txbControllerID.Location = new System.Drawing.Point(200, 323);
            this.txbControllerID.Name = "txbControllerID";
            this.txbControllerID.ReadOnly = true;
            this.txbControllerID.Size = new System.Drawing.Size(470, 29);
            this.txbControllerID.TabIndex = 22;
            // 
            // lbDefaultAligner
            // 
            this.lbDefaultAligner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDefaultAligner.Location = new System.Drawing.Point(3, 400);
            this.lbDefaultAligner.Name = "lbDefaultAligner";
            this.lbDefaultAligner.Size = new System.Drawing.Size(191, 40);
            this.lbDefaultAligner.TabIndex = 24;
            this.lbDefaultAligner.Text = "Default aligner";
            this.lbDefaultAligner.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbAlternativeAligner
            // 
            this.lbAlternativeAligner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbAlternativeAligner.Location = new System.Drawing.Point(3, 440);
            this.lbAlternativeAligner.Name = "lbAlternativeAligner";
            this.lbAlternativeAligner.Size = new System.Drawing.Size(191, 40);
            this.lbAlternativeAligner.TabIndex = 25;
            this.lbAlternativeAligner.Text = "Alternative aligner";
            this.lbAlternativeAligner.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chbByPass
            // 
            this.chbByPass.AutoSize = true;
            this.chbByPass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chbByPass.Location = new System.Drawing.Point(200, 363);
            this.chbByPass.Name = "chbByPass";
            this.chbByPass.Size = new System.Drawing.Size(870, 34);
            this.chbByPass.TabIndex = 27;
            this.chbByPass.Text = "By pass";
            this.chbByPass.UseVisualStyleBackColor = true;
            // 
            // lbRoute
            // 
            this.lbRoute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbRoute.Location = new System.Drawing.Point(3, 480);
            this.lbRoute.Name = "lbRoute";
            this.lbRoute.Size = new System.Drawing.Size(191, 100);
            this.lbRoute.TabIndex = 26;
            this.lbRoute.Text = "Route";
            this.lbRoute.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chbActive
            // 
            this.chbActive.AutoSize = true;
            this.chbActive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chbActive.Location = new System.Drawing.Point(200, 583);
            this.chbActive.Name = "chbActive";
            this.chbActive.Size = new System.Drawing.Size(870, 30);
            this.chbActive.TabIndex = 9;
            this.chbActive.Text = "Active";
            this.chbActive.UseVisualStyleBackColor = true;
            // 
            // txbDefaultAligner
            // 
            this.txbDefaultAligner.BackColor = System.Drawing.Color.White;
            this.txbDefaultAligner.Location = new System.Drawing.Point(200, 403);
            this.txbDefaultAligner.Name = "txbDefaultAligner";
            this.txbDefaultAligner.ReadOnly = true;
            this.txbDefaultAligner.Size = new System.Drawing.Size(470, 29);
            this.txbDefaultAligner.TabIndex = 28;
            // 
            // txbAlternativeAligner
            // 
            this.txbAlternativeAligner.BackColor = System.Drawing.Color.White;
            this.txbAlternativeAligner.Location = new System.Drawing.Point(200, 443);
            this.txbAlternativeAligner.Name = "txbAlternativeAligner";
            this.txbAlternativeAligner.ReadOnly = true;
            this.txbAlternativeAligner.Size = new System.Drawing.Size(470, 29);
            this.txbAlternativeAligner.TabIndex = 29;
            // 
            // dgvRouteTable
            // 
            this.dgvRouteTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRouteTable.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvRouteTable.Location = new System.Drawing.Point(200, 483);
            this.dgvRouteTable.Name = "dgvRouteTable";
            this.dgvRouteTable.RowTemplate.Height = 24;
            this.dgvRouteTable.Size = new System.Drawing.Size(470, 94);
            this.dgvRouteTable.TabIndex = 30;
            // 
            // tlpButton
            // 
            this.tlpButton.ColumnCount = 5;
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpButton.Controls.Add(this.btnSave, 4, 0);
            this.tlpButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButton.Location = new System.Drawing.Point(0, 0);
            this.tlpButton.Name = "tlpButton";
            this.tlpButton.RowCount = 1;
            this.tlpButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpButton.Size = new System.Drawing.Size(1079, 64);
            this.tlpButton.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(863, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(213, 58);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FormDeviceManager
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1420, 740);
            this.Controls.Add(this.gbNodeManager);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDeviceManager";
            this.Text = "Device Manager";
            this.Load += new System.EventHandler(this.FormDeviceManager_Load);
            this.gbNodeManager.ResumeLayout(false);
            this.splitContainerNode.Panel1.ResumeLayout(false);
            this.splitContainerNode.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerNode)).EndInit();
            this.splitContainerNode.ResumeLayout(false);
            this.gbCondition.ResumeLayout(false);
            this.splitContainerSetting.Panel1.ResumeLayout(false);
            this.splitContainerSetting.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSetting)).EndInit();
            this.splitContainerSetting.ResumeLayout(false);
            this.lbDeviceNodeManager.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSerialNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRouteTable)).EndInit();
            this.tlpButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbNodeManager;
        private System.Windows.Forms.SplitContainer splitContainerNode;
        private System.Windows.Forms.GroupBox gbCondition;
        private System.Windows.Forms.ListBox lstNodeList;
        private System.Windows.Forms.SplitContainer splitContainerSetting;
        private System.Windows.Forms.GroupBox lbDeviceNodeManager;
        private System.Windows.Forms.TableLayoutPanel tlpButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbEquipmentModel;
        private System.Windows.Forms.Label lbDeviceNodeName;
        private System.Windows.Forms.Label lbDeviceNodeType;
        private System.Windows.Forms.Label lbSerialNo;
        private System.Windows.Forms.Label lbVendor;
        private System.Windows.Forms.Label lbModel;
        private System.Windows.Forms.Label lbFirmwareVersion;
        private System.Windows.Forms.Label lbAddress;
        private System.Windows.Forms.TextBox txbFirmwareVersion;
        private System.Windows.Forms.TextBox txbModel;
        private System.Windows.Forms.TextBox txbDeviceNodeName;
        private System.Windows.Forms.NumericUpDown nudSerialNo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbControllerID;
        private System.Windows.Forms.TextBox txbEquipmentModel;
        private System.Windows.Forms.ComboBox cmbDeviceNodeType;
        private System.Windows.Forms.ComboBox cmbVendor;
        private System.Windows.Forms.TextBox txbControllerID;
        private System.Windows.Forms.TextBox txbAddress;
        private System.Windows.Forms.Label lbDefaultAligner;
        private System.Windows.Forms.Label lbAlternativeAligner;
        private System.Windows.Forms.CheckBox chbByPass;
        private System.Windows.Forms.CheckBox chbActive;
        private System.Windows.Forms.TextBox txbDefaultAligner;
        private System.Windows.Forms.TextBox txbAlternativeAligner;
        private System.Windows.Forms.Label lbRoute;
        private System.Windows.Forms.DataGridView dgvRouteTable;
    }
}

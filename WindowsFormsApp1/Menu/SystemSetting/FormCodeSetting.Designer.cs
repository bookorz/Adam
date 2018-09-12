namespace Adam.Menu.SystemSetting
{
    partial class FormCodeSetting
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
            this.gbAlarmSetting = new System.Windows.Forms.GroupBox();
            this.spcAlarmSetting = new System.Windows.Forms.SplitContainer();
            this.gbCodeSettingCondition = new System.Windows.Forms.GroupBox();
            this.tlpAlarmCondition = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel17 = new System.Windows.Forms.TableLayoutPanel();
            this.txbCodeConditionDeviceType = new System.Windows.Forms.TextBox();
            this.lbCodeConditionDeviceType = new System.Windows.Forms.Label();
            this.lsbCodeConditionDeviceType = new System.Windows.Forms.ListBox();
            this.tlpAlarmCondition_1 = new System.Windows.Forms.TableLayoutPanel();
            this.txbCdoeConditionVendorCode = new System.Windows.Forms.TextBox();
            this.lbAlarmConditionVendorCode = new System.Windows.Forms.Label();
            this.lsbCodeConditionVendorCode = new System.Windows.Forms.ListBox();
            this.gbAlarmSettingData = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvCodeData = new System.Windows.Forms.DataGridView();
            this.gbAlarmSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcAlarmSetting)).BeginInit();
            this.spcAlarmSetting.Panel1.SuspendLayout();
            this.spcAlarmSetting.Panel2.SuspendLayout();
            this.spcAlarmSetting.SuspendLayout();
            this.gbCodeSettingCondition.SuspendLayout();
            this.tlpAlarmCondition.SuspendLayout();
            this.tableLayoutPanel17.SuspendLayout();
            this.tlpAlarmCondition_1.SuspendLayout();
            this.gbAlarmSettingData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCodeData)).BeginInit();
            this.SuspendLayout();
            // 
            // gbAlarmSetting
            // 
            this.gbAlarmSetting.Controls.Add(this.spcAlarmSetting);
            this.gbAlarmSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAlarmSetting.Location = new System.Drawing.Point(0, 0);
            this.gbAlarmSetting.Name = "gbAlarmSetting";
            this.gbAlarmSetting.Size = new System.Drawing.Size(1420, 740);
            this.gbAlarmSetting.TabIndex = 3;
            this.gbAlarmSetting.TabStop = false;
            this.gbAlarmSetting.Text = "Code Setting";
            // 
            // spcAlarmSetting
            // 
            this.spcAlarmSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcAlarmSetting.Location = new System.Drawing.Point(3, 25);
            this.spcAlarmSetting.Name = "spcAlarmSetting";
            // 
            // spcAlarmSetting.Panel1
            // 
            this.spcAlarmSetting.Panel1.Controls.Add(this.gbCodeSettingCondition);
            // 
            // spcAlarmSetting.Panel2
            // 
            this.spcAlarmSetting.Panel2.Controls.Add(this.gbAlarmSettingData);
            this.spcAlarmSetting.Size = new System.Drawing.Size(1414, 712);
            this.spcAlarmSetting.SplitterDistance = 333;
            this.spcAlarmSetting.TabIndex = 0;
            // 
            // gbCodeSettingCondition
            // 
            this.gbCodeSettingCondition.Controls.Add(this.tlpAlarmCondition);
            this.gbCodeSettingCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCodeSettingCondition.Location = new System.Drawing.Point(0, 0);
            this.gbCodeSettingCondition.Name = "gbCodeSettingCondition";
            this.gbCodeSettingCondition.Size = new System.Drawing.Size(333, 712);
            this.gbCodeSettingCondition.TabIndex = 0;
            this.gbCodeSettingCondition.TabStop = false;
            this.gbCodeSettingCondition.Text = "Condition";
            // 
            // tlpAlarmCondition
            // 
            this.tlpAlarmCondition.ColumnCount = 1;
            this.tlpAlarmCondition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAlarmCondition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpAlarmCondition.Controls.Add(this.tableLayoutPanel17, 0, 1);
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
            // tableLayoutPanel17
            // 
            this.tableLayoutPanel17.ColumnCount = 1;
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel17.Controls.Add(this.txbCodeConditionDeviceType, 0, 2);
            this.tableLayoutPanel17.Controls.Add(this.lbCodeConditionDeviceType, 0, 0);
            this.tableLayoutPanel17.Controls.Add(this.lsbCodeConditionDeviceType, 0, 1);
            this.tableLayoutPanel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel17.Location = new System.Drawing.Point(3, 231);
            this.tableLayoutPanel17.Name = "tableLayoutPanel17";
            this.tableLayoutPanel17.RowCount = 3;
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.55605F));
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.7444F));
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.69955F));
            this.tableLayoutPanel17.Size = new System.Drawing.Size(321, 222);
            this.tableLayoutPanel17.TabIndex = 1;
            // 
            // txbCodeConditionDeviceType
            // 
            this.txbCodeConditionDeviceType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbCodeConditionDeviceType.BackColor = System.Drawing.Color.White;
            this.txbCodeConditionDeviceType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbCodeConditionDeviceType.Location = new System.Drawing.Point(3, 160);
            this.txbCodeConditionDeviceType.Multiline = true;
            this.txbCodeConditionDeviceType.Name = "txbCodeConditionDeviceType";
            this.txbCodeConditionDeviceType.ReadOnly = true;
            this.txbCodeConditionDeviceType.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txbCodeConditionDeviceType.Size = new System.Drawing.Size(315, 50);
            this.txbCodeConditionDeviceType.TabIndex = 5;
            // 
            // lbCodeConditionDeviceType
            // 
            this.lbCodeConditionDeviceType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCodeConditionDeviceType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbCodeConditionDeviceType.Location = new System.Drawing.Point(3, 0);
            this.lbCodeConditionDeviceType.Name = "lbCodeConditionDeviceType";
            this.lbCodeConditionDeviceType.Size = new System.Drawing.Size(315, 27);
            this.lbCodeConditionDeviceType.TabIndex = 3;
            this.lbCodeConditionDeviceType.Text = "Device Type :";
            this.lbCodeConditionDeviceType.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lsbCodeConditionDeviceType
            // 
            this.lsbCodeConditionDeviceType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbCodeConditionDeviceType.FormattingEnabled = true;
            this.lsbCodeConditionDeviceType.ItemHeight = 20;
            this.lsbCodeConditionDeviceType.Location = new System.Drawing.Point(3, 30);
            this.lsbCodeConditionDeviceType.Name = "lsbCodeConditionDeviceType";
            this.lsbCodeConditionDeviceType.Size = new System.Drawing.Size(315, 124);
            this.lsbCodeConditionDeviceType.TabIndex = 4;
            this.lsbCodeConditionDeviceType.Click += new System.EventHandler(this.lsbCodeConditionVendorCode_Click);
            // 
            // tlpAlarmCondition_1
            // 
            this.tlpAlarmCondition_1.ColumnCount = 1;
            this.tlpAlarmCondition_1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAlarmCondition_1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpAlarmCondition_1.Controls.Add(this.txbCdoeConditionVendorCode, 0, 2);
            this.tlpAlarmCondition_1.Controls.Add(this.lbAlarmConditionVendorCode, 0, 0);
            this.tlpAlarmCondition_1.Controls.Add(this.lsbCodeConditionVendorCode, 0, 1);
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
            // txbCdoeConditionVendorCode
            // 
            this.txbCdoeConditionVendorCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbCdoeConditionVendorCode.BackColor = System.Drawing.Color.White;
            this.txbCdoeConditionVendorCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbCdoeConditionVendorCode.Location = new System.Drawing.Point(3, 160);
            this.txbCdoeConditionVendorCode.Multiline = true;
            this.txbCdoeConditionVendorCode.Name = "txbCdoeConditionVendorCode";
            this.txbCdoeConditionVendorCode.ReadOnly = true;
            this.txbCdoeConditionVendorCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txbCdoeConditionVendorCode.Size = new System.Drawing.Size(315, 50);
            this.txbCdoeConditionVendorCode.TabIndex = 5;
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
            // lsbCodeConditionVendorCode
            // 
            this.lsbCodeConditionVendorCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbCodeConditionVendorCode.FormattingEnabled = true;
            this.lsbCodeConditionVendorCode.ItemHeight = 20;
            this.lsbCodeConditionVendorCode.Location = new System.Drawing.Point(3, 30);
            this.lsbCodeConditionVendorCode.Name = "lsbCodeConditionVendorCode";
            this.lsbCodeConditionVendorCode.Size = new System.Drawing.Size(315, 124);
            this.lsbCodeConditionVendorCode.TabIndex = 4;
            this.lsbCodeConditionVendorCode.Click += new System.EventHandler(this.lsbCodeConditionVendorCode_Click);
            // 
            // gbAlarmSettingData
            // 
            this.gbAlarmSettingData.Controls.Add(this.btnSave);
            this.gbAlarmSettingData.Controls.Add(this.dgvCodeData);
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
            this.btnSave.Location = new System.Drawing.Point(848, 658);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(229, 48);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvCodeData
            // 
            this.dgvCodeData.AllowUserToAddRows = false;
            this.dgvCodeData.AllowUserToDeleteRows = false;
            this.dgvCodeData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCodeData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCodeData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCodeData.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvCodeData.Location = new System.Drawing.Point(3, 25);
            this.dgvCodeData.Name = "dgvCodeData";
            this.dgvCodeData.RowHeadersVisible = false;
            this.dgvCodeData.RowTemplate.Height = 24;
            this.dgvCodeData.Size = new System.Drawing.Size(1071, 625);
            this.dgvCodeData.TabIndex = 5;
            // 
            // FormCodeSetting
            // 
            this.ClientSize = new System.Drawing.Size(1420, 740);
            this.Controls.Add(this.gbAlarmSetting);
            this.Name = "FormCodeSetting";
            this.Load += new System.EventHandler(this.FormCodeSetting_Load);
            this.gbAlarmSetting.ResumeLayout(false);
            this.spcAlarmSetting.Panel1.ResumeLayout(false);
            this.spcAlarmSetting.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcAlarmSetting)).EndInit();
            this.spcAlarmSetting.ResumeLayout(false);
            this.gbCodeSettingCondition.ResumeLayout(false);
            this.tlpAlarmCondition.ResumeLayout(false);
            this.tableLayoutPanel17.ResumeLayout(false);
            this.tableLayoutPanel17.PerformLayout();
            this.tlpAlarmCondition_1.ResumeLayout(false);
            this.tlpAlarmCondition_1.PerformLayout();
            this.gbAlarmSettingData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCodeData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAlarmSetting;
        private System.Windows.Forms.SplitContainer spcAlarmSetting;
        private System.Windows.Forms.GroupBox gbCodeSettingCondition;
        private System.Windows.Forms.TableLayoutPanel tlpAlarmCondition;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel17;
        private System.Windows.Forms.TextBox txbCodeConditionDeviceType;
        private System.Windows.Forms.Label lbCodeConditionDeviceType;
        private System.Windows.Forms.ListBox lsbCodeConditionDeviceType;
        private System.Windows.Forms.TableLayoutPanel tlpAlarmCondition_1;
        private System.Windows.Forms.TextBox txbCdoeConditionVendorCode;
        private System.Windows.Forms.Label lbAlarmConditionVendorCode;
        private System.Windows.Forms.ListBox lsbCodeConditionVendorCode;
        private System.Windows.Forms.GroupBox gbAlarmSettingData;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvCodeData;
    }
}

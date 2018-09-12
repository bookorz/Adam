namespace Adam.Menu.SystemSetting
{
    partial class FormDIOSetting
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
            this.gbSetting = new System.Windows.Forms.GroupBox();
            this.spcSignalTowerSetting = new System.Windows.Forms.SplitContainer();
            this.gbCondition = new System.Windows.Forms.GroupBox();
            this.lsbCondition = new System.Windows.Forms.ListBox();
            this.gbSettingData = new System.Windows.Forms.GroupBox();
            this.tlpSettingData = new System.Windows.Forms.TableLayoutPanel();
            this.txbErrorCode = new System.Windows.Forms.TextBox();
            this.txbAbnormal = new System.Windows.Forms.TextBox();
            this.txbType = new System.Windows.Forms.TextBox();
            this.labDIOName = new System.Windows.Forms.Label();
            this.labAddress = new System.Windows.Forms.Label();
            this.labParameter = new System.Windows.Forms.Label();
            this.labType = new System.Windows.Forms.Label();
            this.labAbnormal = new System.Windows.Forms.Label();
            this.txbDIOName = new System.Windows.Forms.TextBox();
            this.txbParameter = new System.Windows.Forms.TextBox();
            this.nudAddress = new System.Windows.Forms.NumericUpDown();
            this.labErrorCode = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcSignalTowerSetting)).BeginInit();
            this.spcSignalTowerSetting.Panel1.SuspendLayout();
            this.spcSignalTowerSetting.Panel2.SuspendLayout();
            this.spcSignalTowerSetting.SuspendLayout();
            this.gbCondition.SuspendLayout();
            this.gbSettingData.SuspendLayout();
            this.tlpSettingData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAddress)).BeginInit();
            this.SuspendLayout();
            // 
            // gbSetting
            // 
            this.gbSetting.Controls.Add(this.spcSignalTowerSetting);
            this.gbSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSetting.Location = new System.Drawing.Point(0, 0);
            this.gbSetting.Name = "gbSetting";
            this.gbSetting.Size = new System.Drawing.Size(1420, 740);
            this.gbSetting.TabIndex = 0;
            this.gbSetting.TabStop = false;
            this.gbSetting.Text = "DIO Setting";
            // 
            // spcSignalTowerSetting
            // 
            this.spcSignalTowerSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcSignalTowerSetting.Location = new System.Drawing.Point(3, 25);
            this.spcSignalTowerSetting.Name = "spcSignalTowerSetting";
            // 
            // spcSignalTowerSetting.Panel1
            // 
            this.spcSignalTowerSetting.Panel1.Controls.Add(this.gbCondition);
            // 
            // spcSignalTowerSetting.Panel2
            // 
            this.spcSignalTowerSetting.Panel2.Controls.Add(this.gbSettingData);
            this.spcSignalTowerSetting.Size = new System.Drawing.Size(1414, 712);
            this.spcSignalTowerSetting.SplitterDistance = 333;
            this.spcSignalTowerSetting.TabIndex = 1;
            // 
            // gbCondition
            // 
            this.gbCondition.Controls.Add(this.lsbCondition);
            this.gbCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCondition.Location = new System.Drawing.Point(0, 0);
            this.gbCondition.Name = "gbCondition";
            this.gbCondition.Size = new System.Drawing.Size(333, 712);
            this.gbCondition.TabIndex = 0;
            this.gbCondition.TabStop = false;
            this.gbCondition.Text = "Condition";
            // 
            // lsbCondition
            // 
            this.lsbCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbCondition.FormattingEnabled = true;
            this.lsbCondition.ItemHeight = 20;
            this.lsbCondition.Location = new System.Drawing.Point(3, 25);
            this.lsbCondition.Name = "lsbCondition";
            this.lsbCondition.Size = new System.Drawing.Size(327, 684);
            this.lsbCondition.TabIndex = 5;
            this.lsbCondition.Click += new System.EventHandler(this.lsbCondition_Click);
            // 
            // gbSettingData
            // 
            this.gbSettingData.Controls.Add(this.tlpSettingData);
            this.gbSettingData.Controls.Add(this.btnSave);
            this.gbSettingData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSettingData.Location = new System.Drawing.Point(0, 0);
            this.gbSettingData.Name = "gbSettingData";
            this.gbSettingData.Size = new System.Drawing.Size(1077, 712);
            this.gbSettingData.TabIndex = 0;
            this.gbSettingData.TabStop = false;
            this.gbSettingData.Text = "Data";
            // 
            // tlpSettingData
            // 
            this.tlpSettingData.ColumnCount = 2;
            this.tlpSettingData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.95705F));
            this.tlpSettingData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.04295F));
            this.tlpSettingData.Controls.Add(this.txbErrorCode, 1, 5);
            this.tlpSettingData.Controls.Add(this.txbAbnormal, 1, 4);
            this.tlpSettingData.Controls.Add(this.txbType, 1, 3);
            this.tlpSettingData.Controls.Add(this.labDIOName, 0, 0);
            this.tlpSettingData.Controls.Add(this.labAddress, 0, 1);
            this.tlpSettingData.Controls.Add(this.labParameter, 0, 2);
            this.tlpSettingData.Controls.Add(this.labType, 0, 3);
            this.tlpSettingData.Controls.Add(this.labAbnormal, 0, 4);
            this.tlpSettingData.Controls.Add(this.txbDIOName, 1, 0);
            this.tlpSettingData.Controls.Add(this.txbParameter, 1, 2);
            this.tlpSettingData.Controls.Add(this.nudAddress, 1, 1);
            this.tlpSettingData.Controls.Add(this.labErrorCode, 0, 5);
            this.tlpSettingData.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpSettingData.Location = new System.Drawing.Point(3, 25);
            this.tlpSettingData.Name = "tlpSettingData";
            this.tlpSettingData.RowCount = 9;
            this.tlpSettingData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpSettingData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpSettingData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpSettingData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpSettingData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpSettingData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpSettingData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpSettingData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpSettingData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpSettingData.Size = new System.Drawing.Size(1071, 627);
            this.tlpSettingData.TabIndex = 7;
            // 
            // txbErrorCode
            // 
            this.txbErrorCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txbErrorCode.Dock = System.Windows.Forms.DockStyle.Left;
            this.txbErrorCode.Location = new System.Drawing.Point(281, 203);
            this.txbErrorCode.Name = "txbErrorCode";
            this.txbErrorCode.Size = new System.Drawing.Size(350, 29);
            this.txbErrorCode.TabIndex = 21;
            // 
            // txbAbnormal
            // 
            this.txbAbnormal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txbAbnormal.Dock = System.Windows.Forms.DockStyle.Left;
            this.txbAbnormal.Location = new System.Drawing.Point(281, 163);
            this.txbAbnormal.Name = "txbAbnormal";
            this.txbAbnormal.Size = new System.Drawing.Size(350, 29);
            this.txbAbnormal.TabIndex = 20;
            // 
            // txbType
            // 
            this.txbType.BackColor = System.Drawing.Color.White;
            this.txbType.Dock = System.Windows.Forms.DockStyle.Left;
            this.txbType.Location = new System.Drawing.Point(281, 123);
            this.txbType.Name = "txbType";
            this.txbType.ReadOnly = true;
            this.txbType.Size = new System.Drawing.Size(350, 29);
            this.txbType.TabIndex = 17;
            // 
            // labDIOName
            // 
            this.labDIOName.AutoSize = true;
            this.labDIOName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labDIOName.Location = new System.Drawing.Point(3, 0);
            this.labDIOName.Name = "labDIOName";
            this.labDIOName.Size = new System.Drawing.Size(272, 40);
            this.labDIOName.TabIndex = 0;
            this.labDIOName.Text = "DIO Name";
            this.labDIOName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labAddress
            // 
            this.labAddress.AutoSize = true;
            this.labAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labAddress.Location = new System.Drawing.Point(3, 40);
            this.labAddress.Name = "labAddress";
            this.labAddress.Size = new System.Drawing.Size(272, 40);
            this.labAddress.TabIndex = 1;
            this.labAddress.Text = "Address";
            this.labAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labParameter
            // 
            this.labParameter.AutoSize = true;
            this.labParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labParameter.Location = new System.Drawing.Point(3, 80);
            this.labParameter.Name = "labParameter";
            this.labParameter.Size = new System.Drawing.Size(272, 40);
            this.labParameter.TabIndex = 2;
            this.labParameter.Text = "Parameter";
            this.labParameter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labType
            // 
            this.labType.AutoSize = true;
            this.labType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labType.Location = new System.Drawing.Point(3, 120);
            this.labType.Name = "labType";
            this.labType.Size = new System.Drawing.Size(272, 40);
            this.labType.TabIndex = 3;
            this.labType.Text = "Type";
            this.labType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labAbnormal
            // 
            this.labAbnormal.AutoSize = true;
            this.labAbnormal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labAbnormal.Location = new System.Drawing.Point(3, 160);
            this.labAbnormal.Name = "labAbnormal";
            this.labAbnormal.Size = new System.Drawing.Size(272, 40);
            this.labAbnormal.TabIndex = 4;
            this.labAbnormal.Text = "Abnormal";
            this.labAbnormal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txbDIOName
            // 
            this.txbDIOName.BackColor = System.Drawing.Color.White;
            this.txbDIOName.Dock = System.Windows.Forms.DockStyle.Left;
            this.txbDIOName.Location = new System.Drawing.Point(281, 3);
            this.txbDIOName.Name = "txbDIOName";
            this.txbDIOName.ReadOnly = true;
            this.txbDIOName.Size = new System.Drawing.Size(350, 29);
            this.txbDIOName.TabIndex = 14;
            // 
            // txbParameter
            // 
            this.txbParameter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txbParameter.Dock = System.Windows.Forms.DockStyle.Left;
            this.txbParameter.Location = new System.Drawing.Point(281, 83);
            this.txbParameter.Name = "txbParameter";
            this.txbParameter.Size = new System.Drawing.Size(350, 29);
            this.txbParameter.TabIndex = 15;
            // 
            // nudAddress
            // 
            this.nudAddress.BackColor = System.Drawing.Color.White;
            this.nudAddress.Dock = System.Windows.Forms.DockStyle.Left;
            this.nudAddress.Enabled = false;
            this.nudAddress.Location = new System.Drawing.Point(281, 43);
            this.nudAddress.Name = "nudAddress";
            this.nudAddress.ReadOnly = true;
            this.nudAddress.Size = new System.Drawing.Size(350, 29);
            this.nudAddress.TabIndex = 16;
            // 
            // labErrorCode
            // 
            this.labErrorCode.AutoSize = true;
            this.labErrorCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labErrorCode.Location = new System.Drawing.Point(3, 200);
            this.labErrorCode.Name = "labErrorCode";
            this.labErrorCode.Size = new System.Drawing.Size(272, 40);
            this.labErrorCode.TabIndex = 19;
            this.labErrorCode.Text = "Error Code";
            this.labErrorCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // FormDIOSetting
            // 
            this.ClientSize = new System.Drawing.Size(1420, 740);
            this.Controls.Add(this.gbSetting);
            this.Name = "FormDIOSetting";
            this.Load += new System.EventHandler(this.FormDIOSetting_Load);
            this.gbSetting.ResumeLayout(false);
            this.spcSignalTowerSetting.Panel1.ResumeLayout(false);
            this.spcSignalTowerSetting.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcSignalTowerSetting)).EndInit();
            this.spcSignalTowerSetting.ResumeLayout(false);
            this.gbCondition.ResumeLayout(false);
            this.gbSettingData.ResumeLayout(false);
            this.tlpSettingData.ResumeLayout(false);
            this.tlpSettingData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAddress)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSetting;
        private System.Windows.Forms.SplitContainer spcSignalTowerSetting;
        private System.Windows.Forms.GroupBox gbCondition;
        private System.Windows.Forms.ListBox lsbCondition;
        private System.Windows.Forms.GroupBox gbSettingData;
        private System.Windows.Forms.TableLayoutPanel tlpSettingData;
        private System.Windows.Forms.TextBox txbParameter;
        private System.Windows.Forms.Label labDIOName;
        private System.Windows.Forms.Label labAddress;
        private System.Windows.Forms.Label labParameter;
        private System.Windows.Forms.Label labType;
        private System.Windows.Forms.Label labAbnormal;
        private System.Windows.Forms.TextBox txbDIOName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.NumericUpDown nudAddress;
        private System.Windows.Forms.TextBox txbType;
        private System.Windows.Forms.Label labErrorCode;
        private System.Windows.Forms.TextBox txbErrorCode;
        private System.Windows.Forms.TextBox txbAbnormal;
    }
}

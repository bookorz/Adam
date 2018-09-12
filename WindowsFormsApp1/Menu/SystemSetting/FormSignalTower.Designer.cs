namespace Adam.Menu.SystemSetting
{
    partial class FormSignalTower
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
            this.gbSignalTower = new System.Windows.Forms.GroupBox();
            this.spcSignalTowerSetting = new System.Windows.Forms.SplitContainer();
            this.gbCondition = new System.Windows.Forms.GroupBox();
            this.lsbCondition = new System.Windows.Forms.ListBox();
            this.gbSettingData = new System.Windows.Forms.GroupBox();
            this.tlpSettingData = new System.Windows.Forms.TableLayoutPanel();
            this.txbIsAlarm = new System.Windows.Forms.TextBox();
            this.labEqpStatus = new System.Windows.Forms.Label();
            this.labIsAlarm = new System.Windows.Forms.Label();
            this.labRad = new System.Windows.Forms.Label();
            this.labYellow = new System.Windows.Forms.Label();
            this.labGreen = new System.Windows.Forms.Label();
            this.labBlue = new System.Windows.Forms.Label();
            this.labBuzzer1 = new System.Windows.Forms.Label();
            this.labBuzzer2 = new System.Windows.Forms.Label();
            this.cmbYellow = new System.Windows.Forms.ComboBox();
            this.cmbRad = new System.Windows.Forms.ComboBox();
            this.cmbGreen = new System.Windows.Forms.ComboBox();
            this.cmbBlue = new System.Windows.Forms.ComboBox();
            this.cmbBuzzer1 = new System.Windows.Forms.ComboBox();
            this.cmbBuzzer2 = new System.Windows.Forms.ComboBox();
            this.txbEqpStatus = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbSignalTower.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcSignalTowerSetting)).BeginInit();
            this.spcSignalTowerSetting.Panel1.SuspendLayout();
            this.spcSignalTowerSetting.Panel2.SuspendLayout();
            this.spcSignalTowerSetting.SuspendLayout();
            this.gbCondition.SuspendLayout();
            this.gbSettingData.SuspendLayout();
            this.tlpSettingData.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSignalTower
            // 
            this.gbSignalTower.Controls.Add(this.spcSignalTowerSetting);
            this.gbSignalTower.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSignalTower.Location = new System.Drawing.Point(0, 0);
            this.gbSignalTower.Name = "gbSignalTower";
            this.gbSignalTower.Size = new System.Drawing.Size(1420, 740);
            this.gbSignalTower.TabIndex = 3;
            this.gbSignalTower.TabStop = false;
            this.gbSignalTower.Text = "Signal tower setting";
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
            this.spcSignalTowerSetting.TabIndex = 0;
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
            this.tlpSettingData.Controls.Add(this.txbIsAlarm, 1, 1);
            this.tlpSettingData.Controls.Add(this.labEqpStatus, 0, 0);
            this.tlpSettingData.Controls.Add(this.labIsAlarm, 0, 1);
            this.tlpSettingData.Controls.Add(this.labRad, 0, 2);
            this.tlpSettingData.Controls.Add(this.labYellow, 0, 3);
            this.tlpSettingData.Controls.Add(this.labGreen, 0, 4);
            this.tlpSettingData.Controls.Add(this.labBlue, 0, 5);
            this.tlpSettingData.Controls.Add(this.labBuzzer1, 0, 6);
            this.tlpSettingData.Controls.Add(this.labBuzzer2, 0, 7);
            this.tlpSettingData.Controls.Add(this.cmbYellow, 1, 3);
            this.tlpSettingData.Controls.Add(this.cmbRad, 1, 2);
            this.tlpSettingData.Controls.Add(this.cmbGreen, 1, 4);
            this.tlpSettingData.Controls.Add(this.cmbBlue, 1, 5);
            this.tlpSettingData.Controls.Add(this.cmbBuzzer1, 1, 6);
            this.tlpSettingData.Controls.Add(this.cmbBuzzer2, 1, 7);
            this.tlpSettingData.Controls.Add(this.txbEqpStatus, 1, 0);
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
            // txbIsAlarm
            // 
            this.txbIsAlarm.BackColor = System.Drawing.Color.White;
            this.txbIsAlarm.Dock = System.Windows.Forms.DockStyle.Left;
            this.txbIsAlarm.Location = new System.Drawing.Point(281, 43);
            this.txbIsAlarm.Name = "txbIsAlarm";
            this.txbIsAlarm.ReadOnly = true;
            this.txbIsAlarm.Size = new System.Drawing.Size(350, 29);
            this.txbIsAlarm.TabIndex = 15;
            // 
            // labEqpStatus
            // 
            this.labEqpStatus.AutoSize = true;
            this.labEqpStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labEqpStatus.Location = new System.Drawing.Point(3, 0);
            this.labEqpStatus.Name = "labEqpStatus";
            this.labEqpStatus.Size = new System.Drawing.Size(272, 40);
            this.labEqpStatus.TabIndex = 0;
            this.labEqpStatus.Text = "Equipment status";
            this.labEqpStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labIsAlarm
            // 
            this.labIsAlarm.AutoSize = true;
            this.labIsAlarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labIsAlarm.Location = new System.Drawing.Point(3, 40);
            this.labIsAlarm.Name = "labIsAlarm";
            this.labIsAlarm.Size = new System.Drawing.Size(272, 40);
            this.labIsAlarm.TabIndex = 1;
            this.labIsAlarm.Text = "Is alarm";
            this.labIsAlarm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labRad
            // 
            this.labRad.AutoSize = true;
            this.labRad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labRad.Location = new System.Drawing.Point(3, 80);
            this.labRad.Name = "labRad";
            this.labRad.Size = new System.Drawing.Size(272, 40);
            this.labRad.TabIndex = 2;
            this.labRad.Text = "Red";
            this.labRad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labYellow
            // 
            this.labYellow.AutoSize = true;
            this.labYellow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labYellow.Location = new System.Drawing.Point(3, 120);
            this.labYellow.Name = "labYellow";
            this.labYellow.Size = new System.Drawing.Size(272, 40);
            this.labYellow.TabIndex = 3;
            this.labYellow.Text = "Yellow";
            this.labYellow.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labGreen
            // 
            this.labGreen.AutoSize = true;
            this.labGreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labGreen.Location = new System.Drawing.Point(3, 160);
            this.labGreen.Name = "labGreen";
            this.labGreen.Size = new System.Drawing.Size(272, 40);
            this.labGreen.TabIndex = 4;
            this.labGreen.Text = "Green";
            this.labGreen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labBlue
            // 
            this.labBlue.AutoSize = true;
            this.labBlue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labBlue.Location = new System.Drawing.Point(3, 200);
            this.labBlue.Name = "labBlue";
            this.labBlue.Size = new System.Drawing.Size(272, 40);
            this.labBlue.TabIndex = 5;
            this.labBlue.Text = "Blue";
            this.labBlue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labBuzzer1
            // 
            this.labBuzzer1.AutoSize = true;
            this.labBuzzer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labBuzzer1.Location = new System.Drawing.Point(3, 240);
            this.labBuzzer1.Name = "labBuzzer1";
            this.labBuzzer1.Size = new System.Drawing.Size(272, 40);
            this.labBuzzer1.TabIndex = 6;
            this.labBuzzer1.Text = "Buzzer 1";
            this.labBuzzer1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labBuzzer2
            // 
            this.labBuzzer2.AutoSize = true;
            this.labBuzzer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labBuzzer2.Location = new System.Drawing.Point(3, 280);
            this.labBuzzer2.Name = "labBuzzer2";
            this.labBuzzer2.Size = new System.Drawing.Size(272, 40);
            this.labBuzzer2.TabIndex = 7;
            this.labBuzzer2.Text = "Buzzer 2";
            this.labBuzzer2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbYellow
            // 
            this.cmbYellow.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbYellow.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbYellow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmbYellow.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmbYellow.FormattingEnabled = true;
            this.cmbYellow.Location = new System.Drawing.Point(281, 123);
            this.cmbYellow.Name = "cmbYellow";
            this.cmbYellow.Size = new System.Drawing.Size(350, 28);
            this.cmbYellow.TabIndex = 9;
            // 
            // cmbRad
            // 
            this.cmbRad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmbRad.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmbRad.FormattingEnabled = true;
            this.cmbRad.Location = new System.Drawing.Point(281, 83);
            this.cmbRad.Name = "cmbRad";
            this.cmbRad.Size = new System.Drawing.Size(350, 28);
            this.cmbRad.TabIndex = 8;
            // 
            // cmbGreen
            // 
            this.cmbGreen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGreen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmbGreen.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmbGreen.FormattingEnabled = true;
            this.cmbGreen.Location = new System.Drawing.Point(281, 163);
            this.cmbGreen.Name = "cmbGreen";
            this.cmbGreen.Size = new System.Drawing.Size(350, 28);
            this.cmbGreen.TabIndex = 10;
            // 
            // cmbBlue
            // 
            this.cmbBlue.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBlue.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBlue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmbBlue.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmbBlue.FormattingEnabled = true;
            this.cmbBlue.Location = new System.Drawing.Point(281, 203);
            this.cmbBlue.Name = "cmbBlue";
            this.cmbBlue.Size = new System.Drawing.Size(350, 28);
            this.cmbBlue.TabIndex = 11;
            // 
            // cmbBuzzer1
            // 
            this.cmbBuzzer1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBuzzer1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBuzzer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmbBuzzer1.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmbBuzzer1.FormattingEnabled = true;
            this.cmbBuzzer1.Location = new System.Drawing.Point(281, 243);
            this.cmbBuzzer1.Name = "cmbBuzzer1";
            this.cmbBuzzer1.Size = new System.Drawing.Size(350, 28);
            this.cmbBuzzer1.TabIndex = 12;
            // 
            // cmbBuzzer2
            // 
            this.cmbBuzzer2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBuzzer2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBuzzer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmbBuzzer2.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmbBuzzer2.FormattingEnabled = true;
            this.cmbBuzzer2.Location = new System.Drawing.Point(281, 283);
            this.cmbBuzzer2.Name = "cmbBuzzer2";
            this.cmbBuzzer2.Size = new System.Drawing.Size(350, 28);
            this.cmbBuzzer2.TabIndex = 13;
            // 
            // txbEqpStatus
            // 
            this.txbEqpStatus.BackColor = System.Drawing.Color.White;
            this.txbEqpStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.txbEqpStatus.Location = new System.Drawing.Point(281, 3);
            this.txbEqpStatus.Name = "txbEqpStatus";
            this.txbEqpStatus.ReadOnly = true;
            this.txbEqpStatus.Size = new System.Drawing.Size(350, 29);
            this.txbEqpStatus.TabIndex = 14;
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
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FormSignalTower
            // 
            this.ClientSize = new System.Drawing.Size(1420, 740);
            this.Controls.Add(this.gbSignalTower);
            this.Name = "FormSignalTower";
            this.Load += new System.EventHandler(this.FormSignalTtower_Load);
            this.gbSignalTower.ResumeLayout(false);
            this.spcSignalTowerSetting.Panel1.ResumeLayout(false);
            this.spcSignalTowerSetting.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcSignalTowerSetting)).EndInit();
            this.spcSignalTowerSetting.ResumeLayout(false);
            this.gbCondition.ResumeLayout(false);
            this.gbSettingData.ResumeLayout(false);
            this.tlpSettingData.ResumeLayout(false);
            this.tlpSettingData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSignalTower;
        private System.Windows.Forms.SplitContainer spcSignalTowerSetting;
        private System.Windows.Forms.GroupBox gbCondition;
        private System.Windows.Forms.GroupBox gbSettingData;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListBox lsbCondition;
        private System.Windows.Forms.TableLayoutPanel tlpSettingData;
        private System.Windows.Forms.Label labEqpStatus;
        private System.Windows.Forms.Label labIsAlarm;
        private System.Windows.Forms.Label labRad;
        private System.Windows.Forms.Label labYellow;
        private System.Windows.Forms.Label labGreen;
        private System.Windows.Forms.Label labBlue;
        private System.Windows.Forms.Label labBuzzer1;
        private System.Windows.Forms.Label labBuzzer2;
        private System.Windows.Forms.TextBox txbIsAlarm;
        private System.Windows.Forms.ComboBox cmbYellow;
        private System.Windows.Forms.ComboBox cmbRad;
        private System.Windows.Forms.ComboBox cmbGreen;
        private System.Windows.Forms.ComboBox cmbBlue;
        private System.Windows.Forms.ComboBox cmbBuzzer1;
        private System.Windows.Forms.ComboBox cmbBuzzer2;
        private System.Windows.Forms.TextBox txbEqpStatus;
    }
}

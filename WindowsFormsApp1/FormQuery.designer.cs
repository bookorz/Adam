namespace GUI
{
    partial class FormQuery
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
            this.palData = new System.Windows.Forms.Panel();
            this.gdvData = new System.Windows.Forms.DataGridView();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.label84 = new System.Windows.Forms.Label();
            this.cbQueryType = new System.Windows.Forms.ComboBox();
            this.labTo = new System.Windows.Forms.Label();
            this.labFrom = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.gbCondition = new System.Windows.Forms.GroupBox();
            this.tlpCondition = new System.Windows.Forms.TableLayoutPanel();
            this.plButtonList = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdbExcel = new System.Windows.Forms.RadioButton();
            this.rdbCsv = new System.Windows.Forms.RadioButton();
            this.tlpConditionList = new System.Windows.Forms.TableLayoutPanel();
            this.cbLimitCnt = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labCondition1 = new System.Windows.Forms.Label();
            this.labCondition2 = new System.Windows.Forms.Label();
            this.labCondition3 = new System.Windows.Forms.Label();
            this.txbCondition1 = new System.Windows.Forms.TextBox();
            this.txbCondition2 = new System.Windows.Forms.TextBox();
            this.txbCondition3 = new System.Windows.Forms.TextBox();
            this.palData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvData)).BeginInit();
            this.gbCondition.SuspendLayout();
            this.tlpCondition.SuspendLayout();
            this.plButtonList.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tlpConditionList.SuspendLayout();
            this.SuspendLayout();
            // 
            // palData
            // 
            this.palData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.palData.Controls.Add(this.gdvData);
            this.palData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palData.Location = new System.Drawing.Point(0, 214);
            this.palData.Name = "palData";
            this.palData.Size = new System.Drawing.Size(1333, 493);
            this.palData.TabIndex = 66;
            // 
            // gdvData
            // 
            this.gdvData.AllowUserToDeleteRows = false;
            this.gdvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gdvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdvData.Location = new System.Drawing.Point(0, 0);
            this.gdvData.Name = "gdvData";
            this.gdvData.ReadOnly = true;
            this.gdvData.RowTemplate.Height = 24;
            this.gdvData.Size = new System.Drawing.Size(1329, 489);
            this.gdvData.TabIndex = 1;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.Color.DarkGray;
            this.btnExport.Enabled = false;
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExport.FlatAppearance.BorderSize = 2;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExport.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnExport.Location = new System.Drawing.Point(3, 18);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(149, 46);
            this.btnExport.TabIndex = 67;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.BackColor = System.Drawing.Color.DarkGray;
            this.btnQuery.Enabled = false;
            this.btnQuery.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnQuery.FlatAppearance.BorderSize = 2;
            this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnQuery.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnQuery.Location = new System.Drawing.Point(2, 3);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(149, 46);
            this.btnQuery.TabIndex = 68;
            this.btnQuery.Text = "Query";
            this.btnQuery.UseVisualStyleBackColor = false;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label84.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label84.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label84.Location = new System.Drawing.Point(3, 0);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(168, 45);
            this.label84.TabIndex = 79;
            this.label84.Text = "Query type";
            this.label84.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbQueryType
            // 
            this.cbQueryType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbQueryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQueryType.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbQueryType.FormattingEnabled = true;
            this.cbQueryType.Items.AddRange(new object[] {
            "Alarm Log",
            "User Action Log",
            "Process Job Log",
            "Process Wafer Log",
            "Command Log",
            "DIO Change Log"});
            this.cbQueryType.Location = new System.Drawing.Point(177, 3);
            this.cbQueryType.Name = "cbQueryType";
            this.cbQueryType.Size = new System.Drawing.Size(400, 35);
            this.cbQueryType.TabIndex = 77;
            this.cbQueryType.SelectedValueChanged += new System.EventHandler(this.cbQueryType_SelectedValueChanged);
            // 
            // labTo
            // 
            this.labTo.AutoSize = true;
            this.labTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labTo.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labTo.Location = new System.Drawing.Point(583, 45);
            this.labTo.Name = "labTo";
            this.labTo.Size = new System.Drawing.Size(168, 45);
            this.labTo.TabIndex = 76;
            this.labTo.Text = "To";
            this.labTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labFrom
            // 
            this.labFrom.AutoSize = true;
            this.labFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labFrom.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labFrom.Location = new System.Drawing.Point(3, 45);
            this.labFrom.Name = "labFrom";
            this.labFrom.Size = new System.Drawing.Size(168, 45);
            this.labFrom.TabIndex = 75;
            this.labFrom.Text = "From";
            this.labFrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpToDate
            // 
            this.dtpToDate.CalendarFont = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dtpToDate.CustomFormat = "yyyy-MM-dd";
            this.dtpToDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpToDate.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(757, 48);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(401, 35);
            this.dtpToDate.TabIndex = 74;
            this.dtpToDate.Value = new System.DateTime(2018, 5, 16, 13, 46, 34, 0);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CalendarFont = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dtpFromDate.CustomFormat = "yyyy-MM-dd";
            this.dtpFromDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpFromDate.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(177, 48);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(400, 35);
            this.dtpFromDate.TabIndex = 73;
            this.dtpFromDate.Value = new System.DateTime(2018, 5, 16, 13, 46, 34, 0);
            // 
            // gbCondition
            // 
            this.gbCondition.Controls.Add(this.tlpCondition);
            this.gbCondition.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbCondition.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gbCondition.Location = new System.Drawing.Point(0, 0);
            this.gbCondition.Name = "gbCondition";
            this.gbCondition.Size = new System.Drawing.Size(1333, 214);
            this.gbCondition.TabIndex = 67;
            this.gbCondition.TabStop = false;
            this.gbCondition.Text = "Condition";
            // 
            // tlpCondition
            // 
            this.tlpCondition.ColumnCount = 2;
            this.tlpCondition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87.94273F));
            this.tlpCondition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.05727F));
            this.tlpCondition.Controls.Add(this.plButtonList, 1, 0);
            this.tlpCondition.Controls.Add(this.tlpConditionList, 0, 0);
            this.tlpCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCondition.Location = new System.Drawing.Point(3, 25);
            this.tlpCondition.Name = "tlpCondition";
            this.tlpCondition.RowCount = 1;
            this.tlpCondition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCondition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 186F));
            this.tlpCondition.Size = new System.Drawing.Size(1327, 186);
            this.tlpCondition.TabIndex = 0;
            // 
            // plButtonList
            // 
            this.plButtonList.Controls.Add(this.panel1);
            this.plButtonList.Controls.Add(this.btnQuery);
            this.plButtonList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plButtonList.Location = new System.Drawing.Point(1170, 3);
            this.plButtonList.Name = "plButtonList";
            this.plButtonList.Size = new System.Drawing.Size(154, 180);
            this.plButtonList.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdbExcel);
            this.panel1.Controls.Add(this.rdbCsv);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Location = new System.Drawing.Point(0, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(154, 100);
            this.panel1.TabIndex = 69;
            // 
            // rdbExcel
            // 
            this.rdbExcel.AutoSize = true;
            this.rdbExcel.Location = new System.Drawing.Point(72, 70);
            this.rdbExcel.Name = "rdbExcel";
            this.rdbExcel.Size = new System.Drawing.Size(74, 24);
            this.rdbExcel.TabIndex = 69;
            this.rdbExcel.Text = "EXCEL";
            this.rdbExcel.UseVisualStyleBackColor = true;
            // 
            // rdbCsv
            // 
            this.rdbCsv.AutoSize = true;
            this.rdbCsv.Checked = true;
            this.rdbCsv.Location = new System.Drawing.Point(8, 70);
            this.rdbCsv.Name = "rdbCsv";
            this.rdbCsv.Size = new System.Drawing.Size(58, 24);
            this.rdbCsv.TabIndex = 68;
            this.rdbCsv.TabStop = true;
            this.rdbCsv.Text = "CSV";
            this.rdbCsv.UseVisualStyleBackColor = true;
            // 
            // tlpConditionList
            // 
            this.tlpConditionList.ColumnCount = 4;
            this.tlpConditionList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpConditionList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpConditionList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpConditionList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpConditionList.Controls.Add(this.cbLimitCnt, 3, 0);
            this.tlpConditionList.Controls.Add(this.label1, 2, 0);
            this.tlpConditionList.Controls.Add(this.dtpToDate, 3, 1);
            this.tlpConditionList.Controls.Add(this.cbQueryType, 1, 0);
            this.tlpConditionList.Controls.Add(this.labFrom, 0, 1);
            this.tlpConditionList.Controls.Add(this.dtpFromDate, 1, 1);
            this.tlpConditionList.Controls.Add(this.label84, 0, 0);
            this.tlpConditionList.Controls.Add(this.labCondition1, 0, 2);
            this.tlpConditionList.Controls.Add(this.labCondition2, 2, 2);
            this.tlpConditionList.Controls.Add(this.labCondition3, 0, 3);
            this.tlpConditionList.Controls.Add(this.txbCondition1, 1, 2);
            this.tlpConditionList.Controls.Add(this.txbCondition2, 3, 2);
            this.tlpConditionList.Controls.Add(this.txbCondition3, 1, 3);
            this.tlpConditionList.Controls.Add(this.labTo, 2, 1);
            this.tlpConditionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpConditionList.Location = new System.Drawing.Point(3, 3);
            this.tlpConditionList.Name = "tlpConditionList";
            this.tlpConditionList.RowCount = 4;
            this.tlpConditionList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpConditionList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpConditionList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpConditionList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpConditionList.Size = new System.Drawing.Size(1161, 180);
            this.tlpConditionList.TabIndex = 1;
            // 
            // cbLimitCnt
            // 
            this.cbLimitCnt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbLimitCnt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLimitCnt.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbLimitCnt.FormattingEnabled = true;
            this.cbLimitCnt.Items.AddRange(new object[] {
            "100",
            "500",
            "1000",
            "5000",
            "10000",
            "50000"});
            this.cbLimitCnt.Location = new System.Drawing.Point(757, 3);
            this.cbLimitCnt.Name = "cbLimitCnt";
            this.cbLimitCnt.Size = new System.Drawing.Size(401, 35);
            this.cbLimitCnt.TabIndex = 87;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(583, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 45);
            this.label1.TabIndex = 86;
            this.label1.Text = "Result Limit";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labCondition1
            // 
            this.labCondition1.AutoSize = true;
            this.labCondition1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labCondition1.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labCondition1.Location = new System.Drawing.Point(3, 90);
            this.labCondition1.Name = "labCondition1";
            this.labCondition1.Size = new System.Drawing.Size(168, 45);
            this.labCondition1.TabIndex = 80;
            this.labCondition1.Text = "Condition 1";
            this.labCondition1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labCondition1.Visible = false;
            // 
            // labCondition2
            // 
            this.labCondition2.AutoSize = true;
            this.labCondition2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labCondition2.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labCondition2.Location = new System.Drawing.Point(583, 90);
            this.labCondition2.Name = "labCondition2";
            this.labCondition2.Size = new System.Drawing.Size(168, 45);
            this.labCondition2.TabIndex = 81;
            this.labCondition2.Text = "Condition 2";
            this.labCondition2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labCondition2.Visible = false;
            // 
            // labCondition3
            // 
            this.labCondition3.AutoSize = true;
            this.labCondition3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labCondition3.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labCondition3.Location = new System.Drawing.Point(3, 135);
            this.labCondition3.Name = "labCondition3";
            this.labCondition3.Size = new System.Drawing.Size(168, 45);
            this.labCondition3.TabIndex = 82;
            this.labCondition3.Text = "Condition 3";
            this.labCondition3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labCondition3.Visible = false;
            // 
            // txbCondition1
            // 
            this.txbCondition1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbCondition1.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txbCondition1.Location = new System.Drawing.Point(177, 93);
            this.txbCondition1.Name = "txbCondition1";
            this.txbCondition1.Size = new System.Drawing.Size(400, 35);
            this.txbCondition1.TabIndex = 83;
            this.txbCondition1.Visible = false;
            // 
            // txbCondition2
            // 
            this.txbCondition2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbCondition2.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txbCondition2.Location = new System.Drawing.Point(757, 93);
            this.txbCondition2.Name = "txbCondition2";
            this.txbCondition2.Size = new System.Drawing.Size(401, 35);
            this.txbCondition2.TabIndex = 84;
            this.txbCondition2.Visible = false;
            // 
            // txbCondition3
            // 
            this.txbCondition3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbCondition3.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txbCondition3.Location = new System.Drawing.Point(177, 138);
            this.txbCondition3.Name = "txbCondition3";
            this.txbCondition3.Size = new System.Drawing.Size(400, 35);
            this.txbCondition3.TabIndex = 85;
            this.txbCondition3.Visible = false;
            // 
            // FormQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 707);
            this.Controls.Add(this.palData);
            this.Controls.Add(this.gbCondition);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormQuery";
            this.Text = "Information Query";
            this.Load += new System.EventHandler(this.FormQuery_Load);
            this.palData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdvData)).EndInit();
            this.gbCondition.ResumeLayout(false);
            this.tlpCondition.ResumeLayout(false);
            this.plButtonList.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tlpConditionList.ResumeLayout(false);
            this.tlpConditionList.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel palData;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label labTo;
        private System.Windows.Forms.Label labFrom;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.DataGridView gdvData;
        private System.Windows.Forms.ComboBox cbQueryType;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.GroupBox gbCondition;
        private System.Windows.Forms.TableLayoutPanel tlpCondition;
        private System.Windows.Forms.Panel plButtonList;
        private System.Windows.Forms.TableLayoutPanel tlpConditionList;
        private System.Windows.Forms.Label labCondition1;
        private System.Windows.Forms.Label labCondition2;
        private System.Windows.Forms.Label labCondition3;
        private System.Windows.Forms.TextBox txbCondition1;
        private System.Windows.Forms.TextBox txbCondition2;
        private System.Windows.Forms.TextBox txbCondition3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdbExcel;
        private System.Windows.Forms.RadioButton rdbCsv;
        private System.Windows.Forms.ComboBox cbLimitCnt;
        private System.Windows.Forms.Label label1;
    }
}
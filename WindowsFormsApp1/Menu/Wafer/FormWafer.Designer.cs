namespace Adam.Menu.Wafer
{
    partial class FormWafer
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
            this.WaferList_tv = new System.Windows.Forms.TreeView();
            this.gbSettingData = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tlpSettingData = new System.Windows.Forms.TableLayoutPanel();
            this.OCRFlag_ck = new System.Windows.Forms.CheckBox();
            this.AlignFlag_ck = new System.Windows.Forms.CheckBox();
            this.labDIOName = new System.Windows.Forms.Label();
            this.labAddress = new System.Windows.Forms.Label();
            this.labParameter = new System.Windows.Forms.Label();
            this.labType = new System.Windows.Forms.Label();
            this.labAbnormal = new System.Windows.Forms.Label();
            this.labErrorCode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.WaferInfo_gv = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.WaferID_tb = new System.Windows.Forms.TextBox();
            this.OCRResult_tb = new System.Windows.Forms.TextBox();
            this.NeedProcess_ck = new System.Windows.Forms.CheckBox();
            this.Position_cb = new System.Windows.Forms.ComboBox();
            this.ProcessFlag_ck = new System.Windows.Forms.CheckBox();
            this.Slot_cb = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcSignalTowerSetting)).BeginInit();
            this.spcSignalTowerSetting.Panel1.SuspendLayout();
            this.spcSignalTowerSetting.Panel2.SuspendLayout();
            this.spcSignalTowerSetting.SuspendLayout();
            this.gbCondition.SuspendLayout();
            this.gbSettingData.SuspendLayout();
            this.tlpSettingData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WaferInfo_gv)).BeginInit();
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
            this.gbSetting.Text = "Wafer";
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
            this.gbCondition.Controls.Add(this.WaferList_tv);
            this.gbCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCondition.Location = new System.Drawing.Point(0, 0);
            this.gbCondition.Name = "gbCondition";
            this.gbCondition.Size = new System.Drawing.Size(333, 712);
            this.gbCondition.TabIndex = 0;
            this.gbCondition.TabStop = false;
            this.gbCondition.Text = "List";
            // 
            // WaferList_tv
            // 
            this.WaferList_tv.Location = new System.Drawing.Point(7, 29);
            this.WaferList_tv.Name = "WaferList_tv";
            this.WaferList_tv.Size = new System.Drawing.Size(320, 674);
            this.WaferList_tv.TabIndex = 0;
            this.WaferList_tv.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.WaferList_tv_NodeMouseClick);
            // 
            // gbSettingData
            // 
            this.gbSettingData.Controls.Add(this.btnDelete);
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
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDelete.Location = new System.Drawing.Point(10, 658);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(229, 48);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tlpSettingData
            // 
            this.tlpSettingData.ColumnCount = 2;
            this.tlpSettingData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.95705F));
            this.tlpSettingData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.04295F));
            this.tlpSettingData.Controls.Add(this.OCRFlag_ck, 1, 4);
            this.tlpSettingData.Controls.Add(this.AlignFlag_ck, 1, 3);
            this.tlpSettingData.Controls.Add(this.labDIOName, 0, 0);
            this.tlpSettingData.Controls.Add(this.labAddress, 0, 1);
            this.tlpSettingData.Controls.Add(this.labParameter, 0, 2);
            this.tlpSettingData.Controls.Add(this.labType, 0, 3);
            this.tlpSettingData.Controls.Add(this.labAbnormal, 0, 4);
            this.tlpSettingData.Controls.Add(this.labErrorCode, 0, 5);
            this.tlpSettingData.Controls.Add(this.label1, 0, 6);
            this.tlpSettingData.Controls.Add(this.WaferInfo_gv, 1, 8);
            this.tlpSettingData.Controls.Add(this.label2, 0, 7);
            this.tlpSettingData.Controls.Add(this.WaferID_tb, 1, 0);
            this.tlpSettingData.Controls.Add(this.OCRResult_tb, 1, 7);
            this.tlpSettingData.Controls.Add(this.NeedProcess_ck, 1, 1);
            this.tlpSettingData.Controls.Add(this.Position_cb, 1, 5);
            this.tlpSettingData.Controls.Add(this.ProcessFlag_ck, 1, 2);
            this.tlpSettingData.Controls.Add(this.Slot_cb, 1, 6);
            this.tlpSettingData.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpSettingData.Location = new System.Drawing.Point(3, 25);
            this.tlpSettingData.Name = "tlpSettingData";
            this.tlpSettingData.RowCount = 10;
            this.tlpSettingData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpSettingData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpSettingData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpSettingData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpSettingData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpSettingData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpSettingData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpSettingData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpSettingData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpSettingData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSettingData.Size = new System.Drawing.Size(1071, 627);
            this.tlpSettingData.TabIndex = 7;
            // 
            // OCRFlag_ck
            // 
            this.OCRFlag_ck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.OCRFlag_ck.AutoSize = true;
            this.OCRFlag_ck.Location = new System.Drawing.Point(281, 163);
            this.OCRFlag_ck.Name = "OCRFlag_ck";
            this.OCRFlag_ck.Size = new System.Drawing.Size(15, 34);
            this.OCRFlag_ck.TabIndex = 29;
            this.OCRFlag_ck.UseVisualStyleBackColor = true;
            // 
            // AlignFlag_ck
            // 
            this.AlignFlag_ck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.AlignFlag_ck.AutoSize = true;
            this.AlignFlag_ck.Location = new System.Drawing.Point(281, 123);
            this.AlignFlag_ck.Name = "AlignFlag_ck";
            this.AlignFlag_ck.Size = new System.Drawing.Size(15, 34);
            this.AlignFlag_ck.TabIndex = 28;
            this.AlignFlag_ck.UseVisualStyleBackColor = true;
            // 
            // labDIOName
            // 
            this.labDIOName.AutoSize = true;
            this.labDIOName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labDIOName.Location = new System.Drawing.Point(3, 0);
            this.labDIOName.Name = "labDIOName";
            this.labDIOName.Size = new System.Drawing.Size(272, 40);
            this.labDIOName.TabIndex = 0;
            this.labDIOName.Text = "Wafer ID";
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
            this.labAddress.Text = "Need Process";
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
            this.labParameter.Text = "ProcessFlag";
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
            this.labType.Text = "Align Flag";
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
            this.labAbnormal.Text = "OCR Flag";
            this.labAbnormal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labErrorCode
            // 
            this.labErrorCode.AutoSize = true;
            this.labErrorCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labErrorCode.Location = new System.Drawing.Point(3, 200);
            this.labErrorCode.Name = "labErrorCode";
            this.labErrorCode.Size = new System.Drawing.Size(272, 40);
            this.labErrorCode.TabIndex = 19;
            this.labErrorCode.Text = "Position";
            this.labErrorCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 40);
            this.label1.TabIndex = 20;
            this.label1.Text = "Slot";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // WaferInfo_gv
            // 
            this.WaferInfo_gv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WaferInfo_gv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WaferInfo_gv.Location = new System.Drawing.Point(281, 323);
            this.WaferInfo_gv.Name = "WaferInfo_gv";
            this.WaferInfo_gv.ReadOnly = true;
            this.WaferInfo_gv.RowTemplate.Height = 24;
            this.WaferInfo_gv.Size = new System.Drawing.Size(787, 74);
            this.WaferInfo_gv.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(272, 40);
            this.label2.TabIndex = 23;
            this.label2.Text = "OCR Result";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // WaferID_tb
            // 
            this.WaferID_tb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.WaferID_tb.Location = new System.Drawing.Point(281, 3);
            this.WaferID_tb.Name = "WaferID_tb";
            this.WaferID_tb.Size = new System.Drawing.Size(185, 29);
            this.WaferID_tb.TabIndex = 22;
            // 
            // OCRResult_tb
            // 
            this.OCRResult_tb.Location = new System.Drawing.Point(281, 283);
            this.OCRResult_tb.Name = "OCRResult_tb";
            this.OCRResult_tb.Size = new System.Drawing.Size(185, 29);
            this.OCRResult_tb.TabIndex = 25;
            // 
            // NeedProcess_ck
            // 
            this.NeedProcess_ck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.NeedProcess_ck.AutoSize = true;
            this.NeedProcess_ck.Location = new System.Drawing.Point(281, 43);
            this.NeedProcess_ck.Name = "NeedProcess_ck";
            this.NeedProcess_ck.Size = new System.Drawing.Size(15, 34);
            this.NeedProcess_ck.TabIndex = 26;
            this.NeedProcess_ck.UseVisualStyleBackColor = true;
            // 
            // Position_cb
            // 
            this.Position_cb.FormattingEnabled = true;
            this.Position_cb.Location = new System.Drawing.Point(281, 203);
            this.Position_cb.Name = "Position_cb";
            this.Position_cb.Size = new System.Drawing.Size(185, 28);
            this.Position_cb.TabIndex = 30;
            this.Position_cb.TextChanged += new System.EventHandler(this.Position_cb_TextChanged);
            // 
            // ProcessFlag_ck
            // 
            this.ProcessFlag_ck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ProcessFlag_ck.AutoSize = true;
            this.ProcessFlag_ck.Location = new System.Drawing.Point(281, 83);
            this.ProcessFlag_ck.Name = "ProcessFlag_ck";
            this.ProcessFlag_ck.Size = new System.Drawing.Size(15, 34);
            this.ProcessFlag_ck.TabIndex = 27;
            this.ProcessFlag_ck.UseVisualStyleBackColor = true;
            // 
            // Slot_cb
            // 
            this.Slot_cb.FormattingEnabled = true;
            this.Slot_cb.Location = new System.Drawing.Point(281, 243);
            this.Slot_cb.Name = "Slot_cb";
            this.Slot_cb.Size = new System.Drawing.Size(185, 28);
            this.Slot_cb.TabIndex = 31;
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
            // FormWafer
            // 
            this.ClientSize = new System.Drawing.Size(1420, 740);
            this.Controls.Add(this.gbSetting);
            this.Name = "FormWafer";
            this.Load += new System.EventHandler(this.FormWafer_Load);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.FormWafer_Layout);
            this.gbSetting.ResumeLayout(false);
            this.spcSignalTowerSetting.Panel1.ResumeLayout(false);
            this.spcSignalTowerSetting.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcSignalTowerSetting)).EndInit();
            this.spcSignalTowerSetting.ResumeLayout(false);
            this.gbCondition.ResumeLayout(false);
            this.gbSettingData.ResumeLayout(false);
            this.tlpSettingData.ResumeLayout(false);
            this.tlpSettingData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WaferInfo_gv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSetting;
        private System.Windows.Forms.SplitContainer spcSignalTowerSetting;
        private System.Windows.Forms.GroupBox gbCondition;
        private System.Windows.Forms.GroupBox gbSettingData;
        private System.Windows.Forms.TableLayoutPanel tlpSettingData;
        private System.Windows.Forms.Label labDIOName;
        private System.Windows.Forms.Label labAddress;
        private System.Windows.Forms.Label labParameter;
        private System.Windows.Forms.Label labType;
        private System.Windows.Forms.Label labAbnormal;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label labErrorCode;
        private System.Windows.Forms.TreeView WaferList_tv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView WaferInfo_gv;
        private System.Windows.Forms.CheckBox OCRFlag_ck;
        private System.Windows.Forms.CheckBox AlignFlag_ck;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox WaferID_tb;
        private System.Windows.Forms.TextBox OCRResult_tb;
        private System.Windows.Forms.CheckBox NeedProcess_ck;
        private System.Windows.Forms.ComboBox Position_cb;
        private System.Windows.Forms.CheckBox ProcessFlag_ck;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox Slot_cb;
    }
}

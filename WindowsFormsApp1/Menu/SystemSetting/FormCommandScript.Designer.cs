namespace Adam.Menu.SystemSetting
{
    partial class FormCommandScript
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
            this.gbCommandScript = new System.Windows.Forms.GroupBox();
            this.tlpCommandScrip = new System.Windows.Forms.TableLayoutPanel();
            this.gbCondition = new System.Windows.Forms.GroupBox();
            this.lstConditionList = new System.Windows.Forms.ListBox();
            this.gbSetting = new System.Windows.Forms.GroupBox();
            this.tlpSetting = new System.Windows.Forms.TableLayoutPanel();
            this.txbFlag = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txbIndex = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txbValue = new System.Windows.Forms.TextBox();
            this.txbPosition = new System.Windows.Forms.TextBox();
            this.txbSlot = new System.Windows.Forms.TextBox();
            this.txbArm = new System.Windows.Forms.TextBox();
            this.txbMethod = new System.Windows.Forms.TextBox();
            this.txbFinishMethod = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmdCommandScriptID = new System.Windows.Forms.ComboBox();
            this.txbExcuteMethod = new System.Windows.Forms.TextBox();
            this.plbuttonArea = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbCommandScript.SuspendLayout();
            this.tlpCommandScrip.SuspendLayout();
            this.gbCondition.SuspendLayout();
            this.gbSetting.SuspendLayout();
            this.tlpSetting.SuspendLayout();
            this.plbuttonArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCommandScript
            // 
            this.gbCommandScript.Controls.Add(this.tlpCommandScrip);
            this.gbCommandScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCommandScript.Location = new System.Drawing.Point(0, 0);
            this.gbCommandScript.Name = "gbCommandScript";
            this.gbCommandScript.Size = new System.Drawing.Size(1420, 720);
            this.gbCommandScript.TabIndex = 0;
            this.gbCommandScript.TabStop = false;
            this.gbCommandScript.Text = "Command script";
            // 
            // tlpCommandScrip
            // 
            this.tlpCommandScrip.ColumnCount = 2;
            this.tlpCommandScrip.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.36467F));
            this.tlpCommandScrip.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.63533F));
            this.tlpCommandScrip.Controls.Add(this.gbCondition, 0, 0);
            this.tlpCommandScrip.Controls.Add(this.gbSetting, 1, 0);
            this.tlpCommandScrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCommandScrip.Location = new System.Drawing.Point(3, 25);
            this.tlpCommandScrip.Name = "tlpCommandScrip";
            this.tlpCommandScrip.RowCount = 1;
            this.tlpCommandScrip.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCommandScrip.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCommandScrip.Size = new System.Drawing.Size(1414, 692);
            this.tlpCommandScrip.TabIndex = 0;
            // 
            // gbCondition
            // 
            this.gbCondition.Controls.Add(this.lstConditionList);
            this.gbCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCondition.Location = new System.Drawing.Point(3, 3);
            this.gbCondition.Name = "gbCondition";
            this.gbCondition.Size = new System.Drawing.Size(310, 686);
            this.gbCondition.TabIndex = 1;
            this.gbCondition.TabStop = false;
            this.gbCondition.Text = "Condition";
            // 
            // lstConditionList
            // 
            this.lstConditionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstConditionList.FormattingEnabled = true;
            this.lstConditionList.ItemHeight = 20;
            this.lstConditionList.Location = new System.Drawing.Point(3, 25);
            this.lstConditionList.Name = "lstConditionList";
            this.lstConditionList.Size = new System.Drawing.Size(304, 658);
            this.lstConditionList.TabIndex = 0;
            this.lstConditionList.Click += new System.EventHandler(this.lstConditionList_Click);
            // 
            // gbSetting
            // 
            this.gbSetting.Controls.Add(this.tlpSetting);
            this.gbSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSetting.Location = new System.Drawing.Point(319, 3);
            this.gbSetting.Name = "gbSetting";
            this.gbSetting.Size = new System.Drawing.Size(1092, 686);
            this.gbSetting.TabIndex = 2;
            this.gbSetting.TabStop = false;
            this.gbSetting.Text = "Query and Setting";
            // 
            // tlpSetting
            // 
            this.tlpSetting.ColumnCount = 2;
            this.tlpSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.81685F));
            this.tlpSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.18315F));
            this.tlpSetting.Controls.Add(this.txbFlag, 1, 9);
            this.tlpSetting.Controls.Add(this.label10, 0, 9);
            this.tlpSetting.Controls.Add(this.txbIndex, 1, 8);
            this.tlpSetting.Controls.Add(this.label9, 0, 8);
            this.tlpSetting.Controls.Add(this.txbValue, 1, 7);
            this.tlpSetting.Controls.Add(this.txbPosition, 1, 6);
            this.tlpSetting.Controls.Add(this.txbSlot, 1, 5);
            this.tlpSetting.Controls.Add(this.txbArm, 1, 4);
            this.tlpSetting.Controls.Add(this.txbMethod, 1, 3);
            this.tlpSetting.Controls.Add(this.txbFinishMethod, 1, 2);
            this.tlpSetting.Controls.Add(this.label1, 0, 0);
            this.tlpSetting.Controls.Add(this.label2, 0, 1);
            this.tlpSetting.Controls.Add(this.label3, 0, 2);
            this.tlpSetting.Controls.Add(this.label4, 0, 3);
            this.tlpSetting.Controls.Add(this.label5, 0, 4);
            this.tlpSetting.Controls.Add(this.label6, 0, 5);
            this.tlpSetting.Controls.Add(this.label7, 0, 6);
            this.tlpSetting.Controls.Add(this.label8, 0, 7);
            this.tlpSetting.Controls.Add(this.cmdCommandScriptID, 1, 0);
            this.tlpSetting.Controls.Add(this.txbExcuteMethod, 1, 1);
            this.tlpSetting.Controls.Add(this.plbuttonArea, 1, 13);
            this.tlpSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSetting.Location = new System.Drawing.Point(3, 25);
            this.tlpSetting.Name = "tlpSetting";
            this.tlpSetting.RowCount = 14;
            this.tlpSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpSetting.Size = new System.Drawing.Size(1086, 658);
            this.tlpSetting.TabIndex = 3;
            // 
            // txbFlag
            // 
            this.txbFlag.Dock = System.Windows.Forms.DockStyle.Left;
            this.txbFlag.Location = new System.Drawing.Point(272, 363);
            this.txbFlag.Name = "txbFlag";
            this.txbFlag.Size = new System.Drawing.Size(300, 29);
            this.txbFlag.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(3, 360);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(263, 40);
            this.label10.TabIndex = 18;
            this.label10.Text = "Flag";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txbIndex
            // 
            this.txbIndex.Dock = System.Windows.Forms.DockStyle.Left;
            this.txbIndex.Location = new System.Drawing.Point(272, 323);
            this.txbIndex.Name = "txbIndex";
            this.txbIndex.Size = new System.Drawing.Size(300, 29);
            this.txbIndex.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 320);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(263, 40);
            this.label9.TabIndex = 16;
            this.label9.Text = "Index";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txbValue
            // 
            this.txbValue.Dock = System.Windows.Forms.DockStyle.Left;
            this.txbValue.Location = new System.Drawing.Point(272, 283);
            this.txbValue.Name = "txbValue";
            this.txbValue.Size = new System.Drawing.Size(300, 29);
            this.txbValue.TabIndex = 15;
            // 
            // txbPosition
            // 
            this.txbPosition.Dock = System.Windows.Forms.DockStyle.Left;
            this.txbPosition.Location = new System.Drawing.Point(272, 243);
            this.txbPosition.Name = "txbPosition";
            this.txbPosition.Size = new System.Drawing.Size(300, 29);
            this.txbPosition.TabIndex = 14;
            // 
            // txbSlot
            // 
            this.txbSlot.Dock = System.Windows.Forms.DockStyle.Left;
            this.txbSlot.Location = new System.Drawing.Point(272, 203);
            this.txbSlot.Name = "txbSlot";
            this.txbSlot.Size = new System.Drawing.Size(300, 29);
            this.txbSlot.TabIndex = 13;
            // 
            // txbArm
            // 
            this.txbArm.Dock = System.Windows.Forms.DockStyle.Left;
            this.txbArm.Location = new System.Drawing.Point(272, 163);
            this.txbArm.Name = "txbArm";
            this.txbArm.Size = new System.Drawing.Size(300, 29);
            this.txbArm.TabIndex = 12;
            // 
            // txbMethod
            // 
            this.txbMethod.Dock = System.Windows.Forms.DockStyle.Left;
            this.txbMethod.Location = new System.Drawing.Point(272, 123);
            this.txbMethod.Name = "txbMethod";
            this.txbMethod.Size = new System.Drawing.Size(300, 29);
            this.txbMethod.TabIndex = 11;
            // 
            // txbFinishMethod
            // 
            this.txbFinishMethod.Dock = System.Windows.Forms.DockStyle.Left;
            this.txbFinishMethod.Location = new System.Drawing.Point(272, 83);
            this.txbFinishMethod.Name = "txbFinishMethod";
            this.txbFinishMethod.Size = new System.Drawing.Size(300, 29);
            this.txbFinishMethod.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Command script ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(263, 40);
            this.label2.TabIndex = 1;
            this.label2.Text = "Excute Method";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(263, 40);
            this.label3.TabIndex = 2;
            this.label3.Text = "Finish Method";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(263, 40);
            this.label4.TabIndex = 3;
            this.label4.Text = "Method";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(263, 40);
            this.label5.TabIndex = 4;
            this.label5.Text = "Arm";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(263, 40);
            this.label6.TabIndex = 5;
            this.label6.Text = "Slot";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 240);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(263, 40);
            this.label7.TabIndex = 6;
            this.label7.Text = "Position";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 280);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(263, 40);
            this.label8.TabIndex = 7;
            this.label8.Text = "Value";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmdCommandScriptID
            // 
            this.cmdCommandScriptID.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdCommandScriptID.FormattingEnabled = true;
            this.cmdCommandScriptID.Location = new System.Drawing.Point(272, 3);
            this.cmdCommandScriptID.Name = "cmdCommandScriptID";
            this.cmdCommandScriptID.Size = new System.Drawing.Size(300, 28);
            this.cmdCommandScriptID.TabIndex = 8;
            // 
            // txbExcuteMethod
            // 
            this.txbExcuteMethod.Dock = System.Windows.Forms.DockStyle.Left;
            this.txbExcuteMethod.Location = new System.Drawing.Point(272, 43);
            this.txbExcuteMethod.Name = "txbExcuteMethod";
            this.txbExcuteMethod.Size = new System.Drawing.Size(300, 29);
            this.txbExcuteMethod.TabIndex = 9;
            // 
            // plbuttonArea
            // 
            this.plbuttonArea.Controls.Add(this.btnSave);
            this.plbuttonArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plbuttonArea.Location = new System.Drawing.Point(272, 523);
            this.plbuttonArea.Name = "plbuttonArea";
            this.plbuttonArea.Size = new System.Drawing.Size(811, 132);
            this.plbuttonArea.TabIndex = 21;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(644, 83);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(164, 46);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FormCommandScript
            // 
            this.ClientSize = new System.Drawing.Size(1420, 720);
            this.Controls.Add(this.gbCommandScript);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCommandScript";
            this.Text = "Configuration";
            this.Load += new System.EventHandler(this.FormConfiguration_Load);
            this.gbCommandScript.ResumeLayout(false);
            this.tlpCommandScrip.ResumeLayout(false);
            this.gbCondition.ResumeLayout(false);
            this.gbSetting.ResumeLayout(false);
            this.tlpSetting.ResumeLayout(false);
            this.tlpSetting.PerformLayout();
            this.plbuttonArea.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCommandScript;
        private System.Windows.Forms.TableLayoutPanel tlpCommandScrip;
        private System.Windows.Forms.GroupBox gbCondition;
        private System.Windows.Forms.ListBox lstConditionList;
        private System.Windows.Forms.GroupBox gbSetting;
        private System.Windows.Forms.TableLayoutPanel tlpSetting;
        private System.Windows.Forms.TextBox txbFlag;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txbIndex;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txbValue;
        private System.Windows.Forms.TextBox txbPosition;
        private System.Windows.Forms.TextBox txbSlot;
        private System.Windows.Forms.TextBox txbArm;
        private System.Windows.Forms.TextBox txbMethod;
        private System.Windows.Forms.TextBox txbFinishMethod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmdCommandScriptID;
        private System.Windows.Forms.TextBox txbExcuteMethod;
        private System.Windows.Forms.Panel plbuttonArea;
        private System.Windows.Forms.Button btnSave;
    }
}

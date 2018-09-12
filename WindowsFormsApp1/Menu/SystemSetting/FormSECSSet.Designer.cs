namespace Adam.Menu.SystemSetting
{
    partial class FormSECSSet
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("SECS-I (Default parameters)");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("SECS-I (Device default)");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("HSMS");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("SEMI E84");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("SECS", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbSettingSECS = new System.Windows.Forms.GroupBox();
            this.spcSECSSetting = new System.Windows.Forms.SplitContainer();
            this.gbSettingSECS_L = new System.Windows.Forms.GroupBox();
            this.tevSECSList = new System.Windows.Forms.TreeView();
            this.gbSettingSECS_R = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvSECSData = new System.Windows.Forms.DataGridView();
            this.SECSSettingGrid_Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SECSSettingGrid_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SECSSettingGrid_Range = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SECSSettingGrid_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbSettingSECS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcSECSSetting)).BeginInit();
            this.spcSECSSetting.Panel1.SuspendLayout();
            this.spcSECSSetting.Panel2.SuspendLayout();
            this.spcSECSSetting.SuspendLayout();
            this.gbSettingSECS_L.SuspendLayout();
            this.gbSettingSECS_R.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSECSData)).BeginInit();
            this.SuspendLayout();
            // 
            // gbSettingSECS
            // 
            this.gbSettingSECS.Controls.Add(this.spcSECSSetting);
            this.gbSettingSECS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSettingSECS.Location = new System.Drawing.Point(0, 0);
            this.gbSettingSECS.Name = "gbSettingSECS";
            this.gbSettingSECS.Size = new System.Drawing.Size(1420, 740);
            this.gbSettingSECS.TabIndex = 1;
            this.gbSettingSECS.TabStop = false;
            this.gbSettingSECS.Text = "SECS Setting";
            // 
            // spcSECSSetting
            // 
            this.spcSECSSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcSECSSetting.Location = new System.Drawing.Point(3, 25);
            this.spcSECSSetting.Name = "spcSECSSetting";
            // 
            // spcSECSSetting.Panel1
            // 
            this.spcSECSSetting.Panel1.Controls.Add(this.gbSettingSECS_L);
            // 
            // spcSECSSetting.Panel2
            // 
            this.spcSECSSetting.Panel2.Controls.Add(this.gbSettingSECS_R);
            this.spcSECSSetting.Size = new System.Drawing.Size(1414, 712);
            this.spcSECSSetting.SplitterDistance = 335;
            this.spcSECSSetting.TabIndex = 0;
            // 
            // gbSettingSECS_L
            // 
            this.gbSettingSECS_L.Controls.Add(this.tevSECSList);
            this.gbSettingSECS_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSettingSECS_L.Location = new System.Drawing.Point(0, 0);
            this.gbSettingSECS_L.Name = "gbSettingSECS_L";
            this.gbSettingSECS_L.Size = new System.Drawing.Size(335, 712);
            this.gbSettingSECS_L.TabIndex = 0;
            this.gbSettingSECS_L.TabStop = false;
            this.gbSettingSECS_L.Text = "List";
            // 
            // tevSECSList
            // 
            this.tevSECSList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tevSECSList.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.tevSECSList.Location = new System.Drawing.Point(3, 25);
            this.tevSECSList.Name = "tevSECSList";
            treeNode1.Name = "SECS_I_P";
            treeNode1.Text = "SECS-I (Default parameters)";
            treeNode2.Name = "SECS_I_D";
            treeNode2.Text = "SECS-I (Device default)";
            treeNode3.Name = "HSMS";
            treeNode3.Text = "HSMS";
            treeNode4.Name = "SEMI_E84";
            treeNode4.Text = "SEMI E84";
            treeNode5.Name = "SECSList";
            treeNode5.Text = "SECS";
            this.tevSECSList.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5});
            this.tevSECSList.Size = new System.Drawing.Size(329, 684);
            this.tevSECSList.TabIndex = 0;
            // 
            // gbSettingSECS_R
            // 
            this.gbSettingSECS_R.Controls.Add(this.btnSave);
            this.gbSettingSECS_R.Controls.Add(this.dgvSECSData);
            this.gbSettingSECS_R.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSettingSECS_R.Location = new System.Drawing.Point(0, 0);
            this.gbSettingSECS_R.Name = "gbSettingSECS_R";
            this.gbSettingSECS_R.Size = new System.Drawing.Size(1075, 712);
            this.gbSettingSECS_R.TabIndex = 1;
            this.gbSettingSECS_R.TabStop = false;
            this.gbSettingSECS_R.Text = "Settings";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(843, 658);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(229, 48);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // dgvSECSData
            // 
            this.dgvSECSData.AllowUserToAddRows = false;
            this.dgvSECSData.AllowUserToDeleteRows = false;
            this.dgvSECSData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSECSData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSECSData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SECSSettingGrid_Item,
            this.SECSSettingGrid_Value,
            this.SECSSettingGrid_Range,
            this.SECSSettingGrid_Description});
            this.dgvSECSData.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvSECSData.Location = new System.Drawing.Point(3, 25);
            this.dgvSECSData.Name = "dgvSECSData";
            this.dgvSECSData.RowTemplate.Height = 24;
            this.dgvSECSData.Size = new System.Drawing.Size(1069, 625);
            this.dgvSECSData.TabIndex = 0;
            // 
            // SECSSettingGrid_Item
            // 
            this.SECSSettingGrid_Item.DataPropertyName = "Item";
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.SECSSettingGrid_Item.DefaultCellStyle = dataGridViewCellStyle1;
            this.SECSSettingGrid_Item.Frozen = true;
            this.SECSSettingGrid_Item.HeaderText = "Item";
            this.SECSSettingGrid_Item.Name = "SECSSettingGrid_Item";
            this.SECSSettingGrid_Item.ReadOnly = true;
            this.SECSSettingGrid_Item.Width = 120;
            // 
            // SECSSettingGrid_Value
            // 
            this.SECSSettingGrid_Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SECSSettingGrid_Value.DataPropertyName = "Value";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.SECSSettingGrid_Value.DefaultCellStyle = dataGridViewCellStyle2;
            this.SECSSettingGrid_Value.FillWeight = 12F;
            this.SECSSettingGrid_Value.HeaderText = "Value";
            this.SECSSettingGrid_Value.Name = "SECSSettingGrid_Value";
            // 
            // SECSSettingGrid_Range
            // 
            this.SECSSettingGrid_Range.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SECSSettingGrid_Range.DataPropertyName = "Range";
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            this.SECSSettingGrid_Range.DefaultCellStyle = dataGridViewCellStyle3;
            this.SECSSettingGrid_Range.FillWeight = 12F;
            this.SECSSettingGrid_Range.HeaderText = "Range";
            this.SECSSettingGrid_Range.Name = "SECSSettingGrid_Range";
            this.SECSSettingGrid_Range.ReadOnly = true;
            // 
            // SECSSettingGrid_Description
            // 
            this.SECSSettingGrid_Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SECSSettingGrid_Description.DataPropertyName = "Description";
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            this.SECSSettingGrid_Description.DefaultCellStyle = dataGridViewCellStyle4;
            this.SECSSettingGrid_Description.FillWeight = 76F;
            this.SECSSettingGrid_Description.HeaderText = "Description";
            this.SECSSettingGrid_Description.Name = "SECSSettingGrid_Description";
            this.SECSSettingGrid_Description.ReadOnly = true;
            // 
            // FormSECSSet
            // 
            this.ClientSize = new System.Drawing.Size(1420, 740);
            this.Controls.Add(this.gbSettingSECS);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSECSSet";
            this.gbSettingSECS.ResumeLayout(false);
            this.spcSECSSetting.Panel1.ResumeLayout(false);
            this.spcSECSSetting.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcSECSSetting)).EndInit();
            this.spcSECSSetting.ResumeLayout(false);
            this.gbSettingSECS_L.ResumeLayout(false);
            this.gbSettingSECS_R.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSECSData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSettingSECS;
        private System.Windows.Forms.SplitContainer spcSECSSetting;
        private System.Windows.Forms.GroupBox gbSettingSECS_L;
        private System.Windows.Forms.TreeView tevSECSList;
        private System.Windows.Forms.GroupBox gbSettingSECS_R;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvSECSData;
        private System.Windows.Forms.DataGridViewTextBoxColumn SECSSettingGrid_Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn SECSSettingGrid_Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn SECSSettingGrid_Range;
        private System.Windows.Forms.DataGridViewTextBoxColumn SECSSettingGrid_Description;
    }
}

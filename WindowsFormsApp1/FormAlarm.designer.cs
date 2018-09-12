namespace Adam
{
    partial class FromAlarm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.AlarmList_gv = new System.Windows.Forms.DataGridView();
            this.ResetAll_bt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AlarmList_gv)).BeginInit();
            this.SuspendLayout();
            // 
            // AlarmList_gv
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.AlarmList_gv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.AlarmList_gv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AlarmList_gv.Location = new System.Drawing.Point(12, 12);
            this.AlarmList_gv.Name = "AlarmList_gv";
            this.AlarmList_gv.RowHeadersVisible = false;
            this.AlarmList_gv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.AlarmList_gv.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.AlarmList_gv.RowTemplate.Height = 24;
            this.AlarmList_gv.Size = new System.Drawing.Size(1070, 472);
            this.AlarmList_gv.TabIndex = 39;
            // 
            // ResetAll_bt
            // 
            this.ResetAll_bt.BackColor = System.Drawing.Color.Green;
            this.ResetAll_bt.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.ResetAll_bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResetAll_bt.ForeColor = System.Drawing.Color.White;
            this.ResetAll_bt.Location = new System.Drawing.Point(12, 490);
            this.ResetAll_bt.Name = "ResetAll_bt";
            this.ResetAll_bt.Size = new System.Drawing.Size(102, 30);
            this.ResetAll_bt.TabIndex = 40;
            this.ResetAll_bt.Text = "Reset All";
            this.ResetAll_bt.UseVisualStyleBackColor = false;
            this.ResetAll_bt.Click += new System.EventHandler(this.ResetAll_bt_Click);
            // 
            // AlarmFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(1094, 525);
            this.Controls.Add(this.ResetAll_bt);
            this.Controls.Add(this.AlarmList_gv);
            this.Name = "AlarmFrom";
            this.Text = "AlarmFrom";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlarmFrom_FormClosing);
            this.Load += new System.EventHandler(this.AlarmFrom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AlarmList_gv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView AlarmList_gv;
        public System.Windows.Forms.Button ResetAll_bt;
    }
}
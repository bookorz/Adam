namespace Adam.Menu.OCR
{
    partial class FormOCR
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Reload_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1515, 736);
            this.tabControl1.TabIndex = 1;
            // 
            // Reload_btn
            // 
            this.Reload_btn.Enabled = false;
            this.Reload_btn.Location = new System.Drawing.Point(1533, 12);
            this.Reload_btn.Name = "Reload_btn";
            this.Reload_btn.Size = new System.Drawing.Size(75, 37);
            this.Reload_btn.TabIndex = 2;
            this.Reload_btn.Text = "Reload";
            this.Reload_btn.UseVisualStyleBackColor = true;
            this.Reload_btn.Click += new System.EventHandler(this.Reload_btn_Click);
            // 
            // FormOCR
            // 
            this.ClientSize = new System.Drawing.Size(1620, 760);
            this.Controls.Add(this.Reload_btn);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormOCR";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormOCR_FormClosed);
            this.Load += new System.EventHandler(this.FormOCR_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button Reload_btn;
    }
}

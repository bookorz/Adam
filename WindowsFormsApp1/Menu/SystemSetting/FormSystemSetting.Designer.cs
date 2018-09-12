namespace Adam.Menu.SystemSetting
{
    partial class FormSystemSetting
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
            this.tbcSystemSetting = new System.Windows.Forms.TabControl();
            this.tbpDeviceManager = new System.Windows.Forms.TabPage();
            this.tbpCommandScript = new System.Windows.Forms.TabPage();
            this.tbpOnlineSettings = new System.Windows.Forms.TabPage();
            this.tbpAccountSetting = new System.Windows.Forms.TabPage();
            this.tbpSignalTtower = new System.Windows.Forms.TabPage();
            this.tbpSECSSetting = new System.Windows.Forms.TabPage();
            this.tbpAlarmEventSet = new System.Windows.Forms.TabPage();
            this.tbpCodeSetting = new System.Windows.Forms.TabPage();
            this.tbpDIOSetting = new System.Windows.Forms.TabPage();
            this.tbcSystemSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcSystemSetting
            // 
            this.tbcSystemSetting.Alignment = System.Windows.Forms.TabAlignment.Right;
            this.tbcSystemSetting.Controls.Add(this.tbpDeviceManager);
            this.tbcSystemSetting.Controls.Add(this.tbpCommandScript);
            this.tbcSystemSetting.Controls.Add(this.tbpOnlineSettings);
            this.tbcSystemSetting.Controls.Add(this.tbpAccountSetting);
            this.tbcSystemSetting.Controls.Add(this.tbpSignalTtower);
            this.tbcSystemSetting.Controls.Add(this.tbpSECSSetting);
            this.tbcSystemSetting.Controls.Add(this.tbpAlarmEventSet);
            this.tbcSystemSetting.Controls.Add(this.tbpCodeSetting);
            this.tbcSystemSetting.Controls.Add(this.tbpDIOSetting);
            this.tbcSystemSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcSystemSetting.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tbcSystemSetting.ItemSize = new System.Drawing.Size(40, 180);
            this.tbcSystemSetting.Location = new System.Drawing.Point(0, 0);
            this.tbcSystemSetting.Multiline = true;
            this.tbcSystemSetting.Name = "tbcSystemSetting";
            this.tbcSystemSetting.SelectedIndex = 0;
            this.tbcSystemSetting.Size = new System.Drawing.Size(1620, 760);
            this.tbcSystemSetting.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tbcSystemSetting.TabIndex = 92;
            this.tbcSystemSetting.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tbcSystemSetting_DrawItem);
            this.tbcSystemSetting.SelectedIndexChanged += new System.EventHandler(this.tbcSystemSetting_SelectedIndexChanged);
            // 
            // tbpDeviceManager
            // 
            this.tbpDeviceManager.BackColor = System.Drawing.SystemColors.Control;
            this.tbpDeviceManager.Location = new System.Drawing.Point(4, 4);
            this.tbpDeviceManager.Name = "tbpDeviceManager";
            this.tbpDeviceManager.Padding = new System.Windows.Forms.Padding(3);
            this.tbpDeviceManager.Size = new System.Drawing.Size(1432, 752);
            this.tbpDeviceManager.TabIndex = 0;
            this.tbpDeviceManager.Text = "Device manager";
            // 
            // tbpCommandScript
            // 
            this.tbpCommandScript.BackColor = System.Drawing.SystemColors.Control;
            this.tbpCommandScript.Location = new System.Drawing.Point(4, 4);
            this.tbpCommandScript.Name = "tbpCommandScript";
            this.tbpCommandScript.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCommandScript.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbpCommandScript.Size = new System.Drawing.Size(1432, 752);
            this.tbpCommandScript.TabIndex = 1;
            this.tbpCommandScript.Text = "Command script";
            // 
            // tbpOnlineSettings
            // 
            this.tbpOnlineSettings.BackColor = System.Drawing.SystemColors.Control;
            this.tbpOnlineSettings.Location = new System.Drawing.Point(4, 4);
            this.tbpOnlineSettings.Name = "tbpOnlineSettings";
            this.tbpOnlineSettings.Size = new System.Drawing.Size(1432, 752);
            this.tbpOnlineSettings.TabIndex = 3;
            this.tbpOnlineSettings.Text = "Online settings";
            // 
            // tbpAccountSetting
            // 
            this.tbpAccountSetting.BackColor = System.Drawing.SystemColors.Control;
            this.tbpAccountSetting.Location = new System.Drawing.Point(4, 4);
            this.tbpAccountSetting.Name = "tbpAccountSetting";
            this.tbpAccountSetting.Size = new System.Drawing.Size(1432, 752);
            this.tbpAccountSetting.TabIndex = 4;
            this.tbpAccountSetting.Text = "Account setting";
            // 
            // tbpSignalTtower
            // 
            this.tbpSignalTtower.Location = new System.Drawing.Point(4, 4);
            this.tbpSignalTtower.Name = "tbpSignalTtower";
            this.tbpSignalTtower.Padding = new System.Windows.Forms.Padding(3);
            this.tbpSignalTtower.Size = new System.Drawing.Size(1432, 752);
            this.tbpSignalTtower.TabIndex = 8;
            this.tbpSignalTtower.Text = "Signal tower set";
            this.tbpSignalTtower.UseVisualStyleBackColor = true;
            // 
            // tbpSECSSetting
            // 
            this.tbpSECSSetting.BackColor = System.Drawing.SystemColors.Control;
            this.tbpSECSSetting.Location = new System.Drawing.Point(4, 4);
            this.tbpSECSSetting.Name = "tbpSECSSetting";
            this.tbpSECSSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tbpSECSSetting.Size = new System.Drawing.Size(1432, 752);
            this.tbpSECSSetting.TabIndex = 5;
            this.tbpSECSSetting.Text = "SECS setting";
            // 
            // tbpAlarmEventSet
            // 
            this.tbpAlarmEventSet.BackColor = System.Drawing.SystemColors.Control;
            this.tbpAlarmEventSet.Location = new System.Drawing.Point(4, 4);
            this.tbpAlarmEventSet.Name = "tbpAlarmEventSet";
            this.tbpAlarmEventSet.Size = new System.Drawing.Size(1432, 752);
            this.tbpAlarmEventSet.TabIndex = 6;
            this.tbpAlarmEventSet.Text = "Alarm event";
            // 
            // tbpCodeSetting
            // 
            this.tbpCodeSetting.BackColor = System.Drawing.SystemColors.Control;
            this.tbpCodeSetting.Location = new System.Drawing.Point(4, 4);
            this.tbpCodeSetting.Name = "tbpCodeSetting";
            this.tbpCodeSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCodeSetting.Size = new System.Drawing.Size(1432, 752);
            this.tbpCodeSetting.TabIndex = 7;
            this.tbpCodeSetting.Text = "Code setting";
            // 
            // tbpDIOSetting
            // 
            this.tbpDIOSetting.BackColor = System.Drawing.SystemColors.Control;
            this.tbpDIOSetting.Location = new System.Drawing.Point(4, 4);
            this.tbpDIOSetting.Name = "tbpDIOSetting";
            this.tbpDIOSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tbpDIOSetting.Size = new System.Drawing.Size(1432, 752);
            this.tbpDIOSetting.TabIndex = 9;
            this.tbpDIOSetting.Text = "DIO Setting";
            // 
            // FormSystemSetting
            // 
            this.ClientSize = new System.Drawing.Size(1620, 760);
            this.Controls.Add(this.tbcSystemSetting);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSystemSetting";
            this.Text = "System Setting";
            this.Load += new System.EventHandler(this.FormSystemSetting_Load);
            this.tbcSystemSetting.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcSystemSetting;
        private System.Windows.Forms.TabPage tbpDeviceManager;
        private System.Windows.Forms.TabPage tbpCommandScript;
        private System.Windows.Forms.TabPage tbpOnlineSettings;
        private System.Windows.Forms.TabPage tbpAccountSetting;
        private System.Windows.Forms.TabPage tbpSECSSetting;
        private System.Windows.Forms.TabPage tbpAlarmEventSet;
        private System.Windows.Forms.TabPage tbpCodeSetting;
        private System.Windows.Forms.TabPage tbpSignalTtower;
        private System.Windows.Forms.TabPage tbpDIOSetting;
    }
}

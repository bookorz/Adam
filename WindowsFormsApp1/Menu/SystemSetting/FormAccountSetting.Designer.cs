namespace Adam.Menu.SystemSetting
{
    partial class FormAccountSetting
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
            this.palMenu = new System.Windows.Forms.Panel();
            this.tlpAccountMenu = new System.Windows.Forms.TableLayoutPanel();
            this.btnModifyUser = new System.Windows.Forms.Button();
            this.btnCreateUser = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.tlpAccount = new System.Windows.Forms.TableLayoutPanel();
            this.palContainer = new System.Windows.Forms.Panel();
            this.gbAccount = new System.Windows.Forms.GroupBox();
            this.tlpAccountCreate = new System.Windows.Forms.TableLayoutPanel();
            this.gbAccountCondition = new System.Windows.Forms.GroupBox();
            this.trvAccount = new System.Windows.Forms.TreeView();
            this.gbAccountSetting = new System.Windows.Forms.GroupBox();
            this.tlpAccountSetting = new System.Windows.Forms.TableLayoutPanel();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.txbUserName = new System.Windows.Forms.TextBox();
            this.labUserID = new System.Windows.Forms.Label();
            this.labUserName = new System.Windows.Forms.Label();
            this.labUserGroup = new System.Windows.Forms.Label();
            this.labUserPassword = new System.Windows.Forms.Label();
            this.chbActive = new System.Windows.Forms.CheckBox();
            this.txbUserID = new System.Windows.Forms.TextBox();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.labUserPasswordNewAgain = new System.Windows.Forms.Label();
            this.labUserPasswordNew = new System.Windows.Forms.Label();
            this.txbPasswordNew = new System.Windows.Forms.TextBox();
            this.txbPasswordNewAgain = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.palMenu.SuspendLayout();
            this.tlpAccountMenu.SuspendLayout();
            this.tlpAccount.SuspendLayout();
            this.palContainer.SuspendLayout();
            this.gbAccount.SuspendLayout();
            this.tlpAccountCreate.SuspendLayout();
            this.gbAccountCondition.SuspendLayout();
            this.gbAccountSetting.SuspendLayout();
            this.tlpAccountSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // palMenu
            // 
            this.palMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.palMenu.Controls.Add(this.tlpAccountMenu);
            this.palMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palMenu.Location = new System.Drawing.Point(3, 3);
            this.palMenu.Name = "palMenu";
            this.palMenu.Padding = new System.Windows.Forms.Padding(5);
            this.palMenu.Size = new System.Drawing.Size(1394, 82);
            this.palMenu.TabIndex = 20;
            // 
            // tlpAccountMenu
            // 
            this.tlpAccountMenu.ColumnCount = 7;
            this.tlpAccountMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpAccountMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpAccountMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpAccountMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpAccountMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpAccountMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpAccountMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpAccountMenu.Controls.Add(this.btnModifyUser, 0, 0);
            this.tlpAccountMenu.Controls.Add(this.btnCreateUser, 0, 0);
            this.tlpAccountMenu.Controls.Add(this.btnChangePassword, 2, 0);
            this.tlpAccountMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAccountMenu.Location = new System.Drawing.Point(5, 5);
            this.tlpAccountMenu.Name = "tlpAccountMenu";
            this.tlpAccountMenu.RowCount = 1;
            this.tlpAccountMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAccountMenu.Size = new System.Drawing.Size(1380, 68);
            this.tlpAccountMenu.TabIndex = 64;
            // 
            // btnModifyUser
            // 
            this.btnModifyUser.BackColor = System.Drawing.Color.Silver;
            this.btnModifyUser.Enabled = false;
            this.btnModifyUser.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnModifyUser.FlatAppearance.BorderSize = 2;
            this.btnModifyUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnModifyUser.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.btnModifyUser.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnModifyUser.Location = new System.Drawing.Point(200, 3);
            this.btnModifyUser.Name = "btnModifyUser";
            this.btnModifyUser.Size = new System.Drawing.Size(191, 59);
            this.btnModifyUser.TabIndex = 65;
            this.btnModifyUser.Text = "Modify User Account";
            this.btnModifyUser.UseVisualStyleBackColor = false;
            this.btnModifyUser.Click += new System.EventHandler(this.btnModifyUser_Click);
            // 
            // btnCreateUser
            // 
            this.btnCreateUser.BackColor = System.Drawing.Color.Silver;
            this.btnCreateUser.Enabled = false;
            this.btnCreateUser.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCreateUser.FlatAppearance.BorderSize = 2;
            this.btnCreateUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCreateUser.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.btnCreateUser.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCreateUser.Location = new System.Drawing.Point(3, 3);
            this.btnCreateUser.Name = "btnCreateUser";
            this.btnCreateUser.Size = new System.Drawing.Size(191, 59);
            this.btnCreateUser.TabIndex = 50;
            this.btnCreateUser.Text = "Create User Account";
            this.btnCreateUser.UseVisualStyleBackColor = false;
            this.btnCreateUser.Click += new System.EventHandler(this.btnCreateUser_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.BackColor = System.Drawing.Color.Silver;
            this.btnChangePassword.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnChangePassword.FlatAppearance.BorderSize = 2;
            this.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChangePassword.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.btnChangePassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnChangePassword.Location = new System.Drawing.Point(397, 3);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(191, 59);
            this.btnChangePassword.TabIndex = 66;
            this.btnChangePassword.Text = "Change User Password";
            this.btnChangePassword.UseVisualStyleBackColor = false;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // tlpAccount
            // 
            this.tlpAccount.ColumnCount = 1;
            this.tlpAccount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAccount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpAccount.Controls.Add(this.palMenu, 0, 0);
            this.tlpAccount.Controls.Add(this.palContainer, 0, 1);
            this.tlpAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAccount.Location = new System.Drawing.Point(10, 10);
            this.tlpAccount.Name = "tlpAccount";
            this.tlpAccount.RowCount = 2;
            this.tlpAccount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.57143F));
            this.tlpAccount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.42857F));
            this.tlpAccount.Size = new System.Drawing.Size(1400, 700);
            this.tlpAccount.TabIndex = 22;
            // 
            // palContainer
            // 
            this.palContainer.Controls.Add(this.gbAccount);
            this.palContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palContainer.Location = new System.Drawing.Point(3, 91);
            this.palContainer.Name = "palContainer";
            this.palContainer.Size = new System.Drawing.Size(1394, 606);
            this.palContainer.TabIndex = 21;
            // 
            // gbAccount
            // 
            this.gbAccount.Controls.Add(this.tlpAccountCreate);
            this.gbAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAccount.Enabled = false;
            this.gbAccount.Location = new System.Drawing.Point(0, 0);
            this.gbAccount.Name = "gbAccount";
            this.gbAccount.Size = new System.Drawing.Size(1394, 606);
            this.gbAccount.TabIndex = 65;
            this.gbAccount.TabStop = false;
            this.gbAccount.Text = "Account  setting";
            // 
            // tlpAccountCreate
            // 
            this.tlpAccountCreate.ColumnCount = 2;
            this.tlpAccountCreate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpAccountCreate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tlpAccountCreate.Controls.Add(this.gbAccountCondition, 0, 0);
            this.tlpAccountCreate.Controls.Add(this.gbAccountSetting, 1, 0);
            this.tlpAccountCreate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAccountCreate.Location = new System.Drawing.Point(3, 25);
            this.tlpAccountCreate.Name = "tlpAccountCreate";
            this.tlpAccountCreate.RowCount = 1;
            this.tlpAccountCreate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAccountCreate.Size = new System.Drawing.Size(1388, 578);
            this.tlpAccountCreate.TabIndex = 0;
            // 
            // gbAccountCondition
            // 
            this.gbAccountCondition.Controls.Add(this.trvAccount);
            this.gbAccountCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAccountCondition.Location = new System.Drawing.Point(3, 3);
            this.gbAccountCondition.Name = "gbAccountCondition";
            this.gbAccountCondition.Size = new System.Drawing.Size(341, 572);
            this.gbAccountCondition.TabIndex = 0;
            this.gbAccountCondition.TabStop = false;
            this.gbAccountCondition.Text = "Condition";
            // 
            // trvAccount
            // 
            this.trvAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvAccount.Location = new System.Drawing.Point(3, 25);
            this.trvAccount.Name = "trvAccount";
            this.trvAccount.Size = new System.Drawing.Size(335, 544);
            this.trvAccount.TabIndex = 0;
            this.trvAccount.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvAccount_AfterSelect);
            // 
            // gbAccountSetting
            // 
            this.gbAccountSetting.Controls.Add(this.tlpAccountSetting);
            this.gbAccountSetting.Controls.Add(this.btnSave);
            this.gbAccountSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAccountSetting.Location = new System.Drawing.Point(350, 3);
            this.gbAccountSetting.Name = "gbAccountSetting";
            this.gbAccountSetting.Size = new System.Drawing.Size(1035, 572);
            this.gbAccountSetting.TabIndex = 1;
            this.gbAccountSetting.TabStop = false;
            this.gbAccountSetting.Text = "Setting";
            // 
            // tlpAccountSetting
            // 
            this.tlpAccountSetting.ColumnCount = 2;
            this.tlpAccountSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.tlpAccountSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73F));
            this.tlpAccountSetting.Controls.Add(this.txbPassword, 1, 3);
            this.tlpAccountSetting.Controls.Add(this.txbUserName, 1, 1);
            this.tlpAccountSetting.Controls.Add(this.labUserID, 0, 0);
            this.tlpAccountSetting.Controls.Add(this.labUserName, 0, 1);
            this.tlpAccountSetting.Controls.Add(this.labUserGroup, 0, 2);
            this.tlpAccountSetting.Controls.Add(this.labUserPassword, 0, 3);
            this.tlpAccountSetting.Controls.Add(this.chbActive, 1, 8);
            this.tlpAccountSetting.Controls.Add(this.txbUserID, 1, 0);
            this.tlpAccountSetting.Controls.Add(this.cmbGroup, 1, 2);
            this.tlpAccountSetting.Controls.Add(this.labUserPasswordNewAgain, 0, 6);
            this.tlpAccountSetting.Controls.Add(this.labUserPasswordNew, 0, 5);
            this.tlpAccountSetting.Controls.Add(this.txbPasswordNew, 1, 5);
            this.tlpAccountSetting.Controls.Add(this.txbPasswordNewAgain, 1, 6);
            this.tlpAccountSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpAccountSetting.Location = new System.Drawing.Point(3, 25);
            this.tlpAccountSetting.Name = "tlpAccountSetting";
            this.tlpAccountSetting.RowCount = 10;
            this.tlpAccountSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpAccountSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpAccountSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpAccountSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpAccountSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpAccountSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpAccountSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpAccountSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpAccountSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpAccountSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpAccountSetting.Size = new System.Drawing.Size(1029, 491);
            this.tlpAccountSetting.TabIndex = 0;
            // 
            // txbPassword
            // 
            this.txbPassword.BackColor = System.Drawing.Color.White;
            this.txbPassword.Dock = System.Windows.Forms.DockStyle.Left;
            this.txbPassword.Location = new System.Drawing.Point(280, 123);
            this.txbPassword.MaxLength = 100;
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.PasswordChar = '*';
            this.txbPassword.Size = new System.Drawing.Size(354, 29);
            this.txbPassword.TabIndex = 8;
            // 
            // txbUserName
            // 
            this.txbUserName.BackColor = System.Drawing.Color.White;
            this.txbUserName.Dock = System.Windows.Forms.DockStyle.Left;
            this.txbUserName.Location = new System.Drawing.Point(280, 43);
            this.txbUserName.Name = "txbUserName";
            this.txbUserName.Size = new System.Drawing.Size(354, 29);
            this.txbUserName.TabIndex = 6;
            // 
            // labUserID
            // 
            this.labUserID.AutoSize = true;
            this.labUserID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labUserID.Location = new System.Drawing.Point(3, 0);
            this.labUserID.Name = "labUserID";
            this.labUserID.Size = new System.Drawing.Size(271, 40);
            this.labUserID.TabIndex = 0;
            this.labUserID.Text = "User ID";
            this.labUserID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labUserName
            // 
            this.labUserName.AutoSize = true;
            this.labUserName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labUserName.Location = new System.Drawing.Point(3, 40);
            this.labUserName.Name = "labUserName";
            this.labUserName.Size = new System.Drawing.Size(271, 40);
            this.labUserName.TabIndex = 1;
            this.labUserName.Text = "User name";
            this.labUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labUserGroup
            // 
            this.labUserGroup.AutoSize = true;
            this.labUserGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labUserGroup.Location = new System.Drawing.Point(3, 80);
            this.labUserGroup.Name = "labUserGroup";
            this.labUserGroup.Size = new System.Drawing.Size(271, 40);
            this.labUserGroup.TabIndex = 3;
            this.labUserGroup.Text = "Group";
            this.labUserGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labUserPassword
            // 
            this.labUserPassword.AutoSize = true;
            this.labUserPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labUserPassword.Location = new System.Drawing.Point(3, 120);
            this.labUserPassword.Name = "labUserPassword";
            this.labUserPassword.Size = new System.Drawing.Size(271, 40);
            this.labUserPassword.TabIndex = 2;
            this.labUserPassword.Text = "Password";
            this.labUserPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chbActive
            // 
            this.chbActive.AutoSize = true;
            this.chbActive.Location = new System.Drawing.Point(280, 323);
            this.chbActive.Name = "chbActive";
            this.chbActive.Size = new System.Drawing.Size(74, 24);
            this.chbActive.TabIndex = 4;
            this.chbActive.Text = "Active";
            this.chbActive.UseVisualStyleBackColor = true;
            // 
            // txbUserID
            // 
            this.txbUserID.BackColor = System.Drawing.Color.White;
            this.txbUserID.Dock = System.Windows.Forms.DockStyle.Left;
            this.txbUserID.Location = new System.Drawing.Point(280, 3);
            this.txbUserID.Name = "txbUserID";
            this.txbUserID.Size = new System.Drawing.Size(354, 29);
            this.txbUserID.TabIndex = 5;
            // 
            // cmbGroup
            // 
            this.cmbGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGroup.BackColor = System.Drawing.Color.White;
            this.cmbGroup.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(280, 83);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(354, 28);
            this.cmbGroup.TabIndex = 7;
            // 
            // labUserPasswordNewAgain
            // 
            this.labUserPasswordNewAgain.AutoSize = true;
            this.labUserPasswordNewAgain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labUserPasswordNewAgain.Location = new System.Drawing.Point(3, 240);
            this.labUserPasswordNewAgain.Name = "labUserPasswordNewAgain";
            this.labUserPasswordNewAgain.Size = new System.Drawing.Size(271, 40);
            this.labUserPasswordNewAgain.TabIndex = 10;
            this.labUserPasswordNewAgain.Text = "New password again";
            this.labUserPasswordNewAgain.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labUserPasswordNew
            // 
            this.labUserPasswordNew.AutoSize = true;
            this.labUserPasswordNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labUserPasswordNew.Location = new System.Drawing.Point(3, 200);
            this.labUserPasswordNew.Name = "labUserPasswordNew";
            this.labUserPasswordNew.Size = new System.Drawing.Size(271, 40);
            this.labUserPasswordNew.TabIndex = 9;
            this.labUserPasswordNew.Text = "New password";
            this.labUserPasswordNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txbPasswordNew
            // 
            this.txbPasswordNew.BackColor = System.Drawing.Color.White;
            this.txbPasswordNew.Location = new System.Drawing.Point(280, 203);
            this.txbPasswordNew.MaxLength = 100;
            this.txbPasswordNew.Name = "txbPasswordNew";
            this.txbPasswordNew.PasswordChar = '*';
            this.txbPasswordNew.Size = new System.Drawing.Size(354, 29);
            this.txbPasswordNew.TabIndex = 11;
            // 
            // txbPasswordNewAgain
            // 
            this.txbPasswordNewAgain.BackColor = System.Drawing.Color.White;
            this.txbPasswordNewAgain.Location = new System.Drawing.Point(280, 243);
            this.txbPasswordNewAgain.MaxLength = 100;
            this.txbPasswordNewAgain.Name = "txbPasswordNewAgain";
            this.txbPasswordNewAgain.PasswordChar = '*';
            this.txbPasswordNewAgain.Size = new System.Drawing.Size(354, 29);
            this.txbPasswordNewAgain.TabIndex = 12;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(861, 521);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(168, 45);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FormAccountSetting
            // 
            this.ClientSize = new System.Drawing.Size(1420, 720);
            this.Controls.Add(this.tlpAccount);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAccountSetting";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Account Setting";
            this.Load += new System.EventHandler(this.FormAccountSetting_Load);
            this.palMenu.ResumeLayout(false);
            this.tlpAccountMenu.ResumeLayout(false);
            this.tlpAccount.ResumeLayout(false);
            this.palContainer.ResumeLayout(false);
            this.gbAccount.ResumeLayout(false);
            this.tlpAccountCreate.ResumeLayout(false);
            this.gbAccountCondition.ResumeLayout(false);
            this.gbAccountSetting.ResumeLayout(false);
            this.tlpAccountSetting.ResumeLayout(false);
            this.tlpAccountSetting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel palMenu;
        private System.Windows.Forms.TableLayoutPanel tlpAccountMenu;
        private System.Windows.Forms.Button btnCreateUser;
        private System.Windows.Forms.TableLayoutPanel tlpAccount;
        private System.Windows.Forms.Panel palContainer;
        private System.Windows.Forms.GroupBox gbAccount;
        private System.Windows.Forms.TableLayoutPanel tlpAccountCreate;
        private System.Windows.Forms.GroupBox gbAccountCondition;
        private System.Windows.Forms.TreeView trvAccount;
        private System.Windows.Forms.GroupBox gbAccountSetting;
        private System.Windows.Forms.TableLayoutPanel tlpAccountSetting;
        private System.Windows.Forms.Label labUserID;
        private System.Windows.Forms.Label labUserName;
        private System.Windows.Forms.Label labUserPassword;
        private System.Windows.Forms.Label labUserGroup;
        private System.Windows.Forms.TextBox txbPassword;
        private System.Windows.Forms.TextBox txbUserName;
        private System.Windows.Forms.CheckBox chbActive;
        private System.Windows.Forms.TextBox txbUserID;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label labUserPasswordNewAgain;
        private System.Windows.Forms.Label labUserPasswordNew;
        private System.Windows.Forms.TextBox txbPasswordNew;
        private System.Windows.Forms.TextBox txbPasswordNewAgain;
        private System.Windows.Forms.Button btnModifyUser;
        private System.Windows.Forms.Button btnChangePassword;
    }
}

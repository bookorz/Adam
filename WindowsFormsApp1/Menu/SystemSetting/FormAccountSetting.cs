using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SANWA.Utility;
using System.Linq;

namespace Adam.Menu.SystemSetting
{
    public partial class FormAccountSetting : Form
    {
        public FormAccountSetting()
        {
            InitializeComponent();
        }

        private DataTable dtAccountGroup = new DataTable();
        private DataTable dtAccountUser = new DataTable();
        private DBUtil dBUtil = new DBUtil();

        private string strUserID = string.Empty;
        private string strUserName = string.Empty;
        private string strUserGroup = string.Empty;

        private void FormAccountSetting_Load(object sender, EventArgs e)
        {
            StringBuilder sbAllGroup = new StringBuilder();
            StringBuilder sbLowerGroup = new StringBuilder();
            Form form = null;
            Label Signal = null;

            try
            {
                form = Application.OpenForms["FormMain"];
                Signal = form.Controls.Find("lbl_login_id", true).FirstOrDefault() as Label;
                strUserID = Signal.Text;
                Signal = form.Controls.Find("lbl_login_name", true).FirstOrDefault() as Label;
                strUserName = Signal.Text;
                Signal = form.Controls.Find("lbl_login_group", true).FirstOrDefault() as Label;
                strUserGroup = Signal.Text;

                trvAccount.Nodes.Clear();

                UpdateUser(strUserID, null);
                UpdateGroup();

                if (dtAccountGroup.Rows.Count > 0)
                {
                    foreach (DataRow item in dtAccountGroup.Rows)
                    {
                        if (!trvAccount.Nodes.ContainsKey(item["user_group_id"].ToString()) && item["user_group_id"].ToString().Length > 0)
                        {
                            if (dtAccountUser.Rows[0]["user_group_id"].ToString().Equals(item["user_group_id"].ToString()))
                            {
                                trvAccount.Nodes.Add(item["user_group_id"].ToString(), item["user_group_id"].ToString());
                                trvAccount.Nodes[item["user_group_id"].ToString()].Tag = 0;
                            }
                        }

                        if (!trvAccount.Nodes.ContainsKey(item["lower_level_group_id"].ToString()) && item["lower_level_group_id"].ToString().Length > 0)
                        {
                            if (strUserGroup.Equals(item["user_group_id"].ToString()))
                            {
                                trvAccount.Nodes.Add(item["lower_level_group_id"].ToString(), item["lower_level_group_id"].ToString());
                                trvAccount.Nodes[item["lower_level_group_id"].ToString()].Tag = 0;

                                sbAllGroup.Append(item["user_group_id"].ToString());
                                sbAllGroup.Append(",");
                                sbAllGroup.Append(item["lower_level_group_id"].ToString());
                                sbAllGroup.Append(",");

                                sbLowerGroup.Append(item["lower_level_group_id"].ToString());
                                sbLowerGroup.Append(",");
                            }
                        }
                    }

                    if (strUserGroup.Equals("ADMIN"))
                    {
                        UpdateUser();
                        //trvAccount.Nodes.Add("CreateUser", "Create User");
                    }
                    else
                    {
                        UpdateUser(strUserID, "'" + sbLowerGroup.ToString().TrimEnd(',').Replace(",", "','") + "'");

                        //if (!strUserGroup.Equals("OP"))
                        //{
                        //    trvAccount.Nodes.Add("CreateUser", "Create User");
                        //}
                    }

                    if (dtAccountUser.Rows.Count > 0)
                    {
                        foreach (DataRow item in dtAccountUser.Rows)
                        {
                            if (trvAccount.Nodes.ContainsKey(item["user_group_id"].ToString()))
                            {
                                trvAccount.Nodes[item["user_group_id"].ToString()].Nodes.Add(item["user_id"].ToString(), item["user_id"].ToString() + " " + item["user_name"].ToString());
                                trvAccount.Nodes[item["user_group_id"].ToString()].Nodes[item["user_id"].ToString()].Tag = 1;
                            }
                        }
                    }


                    if (strUserGroup.Equals("ADMIN"))
                    {
                        cmbGroup.DataSource = dtAccountGroup.DefaultView.ToTable(true, new string[] { "user_group_id" });
                        cmbGroup.DisplayMember = "user_group_id";
                        cmbGroup.ValueMember = "user_group_id";
                        cmbGroup.SelectedIndex = -1;
                    }
                    else
                    {
                        cmbGroup.DataSource = dtAccountGroup.Select("user_group_id = '" + strUserGroup + "'").CopyToDataTable().DefaultView.ToTable(true, new string[] { "user_group_id" });
                        cmbGroup.DisplayMember = "user_group_id";
                        cmbGroup.ValueMember = "user_group_id";
                        cmbGroup.SelectedIndex = -1;
                    }

                    UIChange(strUserGroup);
                    //else if (strUserGroup.Equals("OP"))
                    //{
                    //    cmbGroup.DataSource = dtAccountGroup.Select("user_group_id = 'OP'").CopyToDataTable().DefaultView.ToTable(true, new string[] { "user_group_id" });
                    //    cmbGroup.DisplayMember = "user_group_id";
                    //    cmbGroup.ValueMember = "user_group_id";
                    //    cmbGroup.SelectedIndex = -1;
                    //}
                    //else
                    //{
                    //    cmbGroup.DataSource = dtAccountGroup.Select("user_group_id in ('" + sbAllGroup.ToString().Replace(",", "','") + "')").CopyToDataTable().DefaultView.ToTable(true, new string[] { "user_group_id" });
                    //    cmbGroup.DisplayMember = "user_group_id";
                    //    cmbGroup.ValueMember = "user_group_id";
                    //    cmbGroup.SelectedIndex = -1;
                    //}
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void trvAccount_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string[] strsNodes = null;

            try
            {
                strsNodes = ((TreeView)sender).SelectedNode.FullPath.Split(Convert.ToChar(92));

                if (strsNodes.Length >= 2)
                {
                    var query = (from a in dtAccountUser.AsEnumerable()
                                 where a.Field<string>("user_group_id") == strsNodes[0].ToString()
                                   && a.Field<string>("user_id") == strsNodes[strsNodes.Length - 1].Split(' ')[0].ToString()
                                 select a).ToList();

                    if (query.Count > 0)
                    {
                        txbUserID.Text = query[0]["user_id"].ToString();
                        txbUserName.Text = query[0]["user_name"].ToString();
                        txbPassword.Text = query[0]["password"].ToString();
                        cmbGroup.SelectedValue = query[0]["user_group_id"].ToString();
                        chbActive.Checked = query[0]["active"].ToString() == "Y" ? true : false;
                    }
                    else
                    {
                        txbUserID.Text = string.Empty;
                        txbUserName.Text = string.Empty;
                        txbPassword.Text = string.Empty;
                        cmbGroup.SelectedIndex = -1;
                        chbActive.Checked = false;
                    }
                }
                else
                {
                    txbUserID.Text = string.Empty;
                    txbUserName.Text = string.Empty;
                    txbPassword.Text = string.Empty;
                    cmbGroup.SelectedIndex = -1;
                    chbActive.Checked = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void UpdateUser(string UserID, string Group)
        {
            string strSqlAccount = string.Empty;
            Dictionary<string, object> keyValues = new Dictionary<string, object>();

            try
            {
                if (UserID == null)
                    return;

                if (Group != null)
                {
                    strSqlAccount = "select * from account where active = 'Y' and user_id = @user_id " +
                        "UNION " +
                        "select * from account where active = 'Y' and user_group_id IN (" + Group + ")";
                    keyValues.Add("@user_id", UserID);
                }
                else
                {
                    strSqlAccount = "select * from account where active = 'Y' and user_id = @user_id";
                    keyValues.Add("@user_id", UserID);
                }

                dtAccountUser = dBUtil.GetDataTable(strSqlAccount, keyValues);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void UpdateUser()
        {
            string strSqlAccount = string.Empty;

            try
            {
                strSqlAccount = "select * from account where active = 'Y'";
                dtAccountUser = dBUtil.GetDataTable(strSqlAccount, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void UpdateGroup()
        {
            string strSqlGroup = string.Empty;

            try
            {
                strSqlGroup = "SELECT a.user_group_id, a.user_group_name, b.lower_level_group_id " +
                    "FROM user_group a " +
                    "LEFT JOIN user_group_level b ON a.user_group_id = b.user_group_id " +
                    "WHERE a.active = 'Y'";
                dtAccountGroup = dBUtil.GetDataTable(strSqlGroup, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void UIChange(string Mode)
        {
            try
            {
                switch (Mode)
                {
                    case "ADMIN":
                        btnCreateUser.Enabled = true;
                        btnModifyUser.Enabled = true;
                        btnChangePassword.Enabled = true;
                        break;

                    default:
                        btnCreateUser.Enabled = false;
                        btnModifyUser.Enabled = false;
                        btnChangePassword.Enabled = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strSql = string.Empty;
            Dictionary<string, object> keyValues = new Dictionary<string, object>();

            try
            {
                if (btnCreateUser.BackColor == Color.RoyalBlue)
                {
                    if (txbUserID.Text.Trim().Equals(string.Empty) || txbUserName.Text.Trim().Equals(string.Empty) ||
                        txbPassword.Text.Trim().Equals(string.Empty) || cmbGroup.SelectedIndex == -1)
                    {
                        MessageBox.Show("Missing the data.", "Account Setting", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        return;
                    }

                    strSql = "INSERT INTO account " +
                        "(user_id, user_name, password, user_group_id, active, create_user, create_timestamp, modify_user, modify_timestamp) " +
                        "VALUES(@user_id, @user_name, MD5(@password), @user_group_id, @active, @create_user, NOW(), @modify_user, NOW())";

                    keyValues.Add("@user_id", txbUserID.Text.Trim());
                    keyValues.Add("@user_name", txbUserName.Text.Trim());
                    keyValues.Add("@password", txbPassword.Text.Trim());
                    keyValues.Add("@user_group_id", cmbGroup.SelectedValue.ToString());
                    keyValues.Add("@active", chbActive.Checked == true ? "Y" : "N");
                    keyValues.Add("@create_user", strUserID);
                    keyValues.Add("@modify_user", strUserID);
                }
                else if (btnModifyUser.BackColor == Color.RoyalBlue)
                {
                    if (txbUserID.Text.Trim().Equals(string.Empty) || txbUserName.Text.Trim().Equals(string.Empty) ||
                        txbPassword.Text.Trim().Equals(string.Empty) || cmbGroup.SelectedIndex == -1 )
                    {
                        MessageBox.Show("Missing the data.", "Account Setting", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        return;
                    }

                    strSql = "UPDATE account SET user_name = @user_name, " +
                                "user_group_id = @user_group_id," +
                                "active = @active, " +
                                "modify_user = @modify_user, " +
                                "modify_timestamp = NOW() " +
                                "WHERE user_id = @user_id ";

                    keyValues.Add("@user_id", txbUserID.Text.Trim());
                    keyValues.Add("@user_name", txbUserName.Text.Trim());
                    keyValues.Add("@user_group_id", cmbGroup.SelectedValue.ToString());
                    keyValues.Add("@active", chbActive.Checked == true ? "Y" : "N");
                    keyValues.Add("@modify_user", strUserID);
                }
                else if (btnChangePassword.BackColor == Color.RoyalBlue)
                {
                    if (txbUserID.Text.Trim().Equals(string.Empty) || txbUserName.Text.Trim().Equals(string.Empty) ||
                        txbPassword.Text.Trim().Equals(string.Empty) || cmbGroup.SelectedIndex == -1 || txbPasswordNew.Text.Trim().Equals(string.Empty)
                        || txbPasswordNewAgain.Text.Trim().Equals(string.Empty))
                    {
                        MessageBox.Show("Missing the data.", "Account Setting", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        return;
                    }

                    if (txbPasswordNew.Text.Trim().Equals(string.Empty) || txbPasswordNewAgain.Text.Trim().Equals(string.Empty))
                    {
                        MessageBox.Show("Missing the data.", "Account Setting", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        return;
                    }

                    if (!txbPasswordNew.Text.Trim().Equals(txbPasswordNewAgain.Text.Trim()))
                    {
                        MessageBox.Show("New password are different.", "Account Setting", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        return;
                    }

                    strSql = "UPDATE account SET PASSWORD = MD5(@password), " +
                                "modify_user = @modify_user, " +
                                "modify_timestamp = NOW() " +
                                "WHERE user_id = @user_id ";

                    keyValues.Add("@user_id", txbUserID.Text.Trim());
                    keyValues.Add("@password", txbPasswordNew.Text.Trim());
                    keyValues.Add("@modify_user", strUserID);
                }

                dBUtil.ExecuteNonQuery(strSql, keyValues);
                Adam.Util.SanwaUtil.addActionLog("Adam.Menu.SystemSetting", "FormAccountSetting", strUserID);
                MessageBox.Show("Done it.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                FormAccountSetting_Load(sender, e);

                gbAccount.Enabled = false;
                txbUserID.Text = string.Empty;
                txbUserID.BackColor = Color.White;
                txbUserName.Text = string.Empty;
                txbUserName.BackColor = Color.White;
                cmbGroup.SelectedIndex = -1;
                cmbGroup.BackColor = Color.White;
                txbPassword.Text = string.Empty;
                txbPassword.BackColor = Color.White;
                txbPasswordNew.Text = string.Empty;
                txbPasswordNew.BackColor = Color.White;
                txbPasswordNewAgain.Text = string.Empty;
                txbPasswordNewAgain.BackColor = Color.White;
                chbActive.Checked = false;
                chbActive.BackColor = SystemColors.Control;
                btnCreateUser.BackColor = Color.Silver;
                btnModifyUser.BackColor = Color.Silver;
                btnChangePassword.BackColor = Color.Silver;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            try
            {
                gbAccount.Enabled = true;
                trvAccount.Enabled = false;
                trvAccount.Refresh();
                trvAccount.SelectedNode = trvAccount.Nodes[0];

                txbUserID.Text = string.Empty;
                txbUserID.Enabled = true;
                txbUserID.BackColor = Color.LemonChiffon;
                txbUserName.Text = string.Empty;
                txbUserName.Enabled = true;
                txbUserName.BackColor = Color.LemonChiffon;
                cmbGroup.SelectedIndex = -1;
                cmbGroup.Enabled = true;
                cmbGroup.BackColor = Color.LemonChiffon;
                txbPassword.Text = string.Empty;
                txbPassword.Enabled = true;
                txbPassword.BackColor = Color.LemonChiffon;
                labUserPasswordNew.Enabled = false;
                labUserPasswordNewAgain.Enabled = false;
                txbPasswordNew.Enabled = false;
                txbPasswordNewAgain.Enabled = false;
                txbPasswordNew.BackColor = Color.White;
                txbPasswordNewAgain.BackColor = Color.White;
                chbActive.Checked = false;
                chbActive.Enabled = true;
                chbActive.BackColor = Color.LemonChiffon;

                btnCreateUser.BackColor = Color.RoyalBlue;
                btnModifyUser.BackColor = Color.Silver;
                btnChangePassword.BackColor = Color.Silver;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void btnModifyUser_Click(object sender, EventArgs e)
        {
            try
            {
                gbAccount.Enabled = true;
                trvAccount.Enabled = true;
                trvAccount.SelectedNode = trvAccount.Nodes[0];

                txbUserID.Text = string.Empty;
                txbUserID.Enabled = false;
                txbUserID.BackColor = Color.White;
                txbUserName.Text = string.Empty;
                txbUserName.Enabled = true;
                txbUserName.BackColor = Color.LemonChiffon;
                cmbGroup.SelectedIndex = -1;
                cmbGroup.Enabled = true;
                cmbGroup.BackColor = Color.LemonChiffon;
                txbPassword.Text = string.Empty;
                txbPassword.Enabled = false;
                txbPassword.BackColor = Color.White;
                labUserPasswordNew.Enabled = false;
                labUserPasswordNewAgain.Enabled = false;
                txbPasswordNew.Enabled = false;
                txbPasswordNewAgain.Enabled = false;
                txbPasswordNew.BackColor = Color.White;
                txbPasswordNewAgain.BackColor = Color.White;
                chbActive.Checked = false;
                chbActive.Enabled = true;
                chbActive.BackColor = Color.LemonChiffon;

                btnCreateUser.BackColor = Color.Silver;
                btnModifyUser.BackColor = Color.RoyalBlue;
                btnChangePassword.BackColor = Color.Silver;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                gbAccount.Enabled = true;
                trvAccount.Enabled = true;
                trvAccount.SelectedNode = trvAccount.Nodes[0];

                txbUserID.Text = string.Empty;
                txbUserID.Enabled = false;
                txbUserID.BackColor = Color.White;
                txbUserName.Text = string.Empty;
                txbUserName.Enabled = false;
                txbUserName.BackColor = Color.White;
                cmbGroup.SelectedIndex = -1;
                cmbGroup.Enabled = false;
                cmbGroup.BackColor = Color.White;
                txbPassword.Text = string.Empty;
                txbPassword.Enabled = false;
                txbPassword.BackColor = Color.White;
                labUserPasswordNew.Enabled = true;
                labUserPasswordNewAgain.Enabled = true;
                txbPasswordNew.Enabled = true;
                txbPasswordNewAgain.Enabled = true;
                txbPasswordNew.BackColor = Color.LemonChiffon;
                txbPasswordNewAgain.BackColor = Color.LemonChiffon;
                chbActive.Checked = false;
                chbActive.Enabled = false;
                chbActive.BackColor = SystemColors.Control;

                btnCreateUser.BackColor = Color.Silver;
                btnModifyUser.BackColor = Color.Silver;
                btnChangePassword.BackColor = Color.RoyalBlue;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}

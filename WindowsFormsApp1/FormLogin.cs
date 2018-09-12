using Adam.UI_Update.Authority;
using Adam.Util;
using log4net;
using SANWA.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormLogin : Form
    {
        //ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        ILog log = LogManager.GetLogger("Database");
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            Boolean result = false;
            //set SQL
            StringBuilder sql = new StringBuilder();
            sql.Append("\n SELECT user_id, user_name, user_group_id");
            sql.Append("\n   FROM account ");
            sql.Append("\n  WHERE user_id = @user_id ");
            sql.Append("\n    AND password = MD5(@password)");
            //set parameter
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("@user_id", tbUserID.Text);
            param.Add("@password", tbPassword.Text);
            //Query
            DBUtil dBUtil = new DBUtil();
            DataTableReader rs = dBUtil.GetDataReader(sql.ToString(), param);
            if (rs != null)
            {
                //Console.Write("\n ID:" + rs["user_id"] + " Password:" + rs["password"] + " MD5:" + rs["md5"]);

                string user_id = "";
                string user_name = "";
                string user_group_id = "";
                while (rs.Read())
                {
                    user_id = (string)rs["user_id"];
                    user_name = (string)rs["user_name"];
                    user_group_id = (string)rs["user_group_id"];
                    result = true;
                }
                rs.Close();
                if (result)
                {
                    AuthorityUpdate.UpdateLoginInfo(user_id, user_name, user_group_id);
                    string msg = "{\"user_id\": " + user_id + ", \"name\": \"" + user_name + "\", \"action\": \"Login\"}";
                    log.Info(msg);
                    //SanwaUtil.addActionLog("Authority", "Login", user_id);// add record to log_system_action
                    SanwaUtil.addActionLog("Authority", "Login", user_id, "使用者登錄");// add record to log_system_action
                    //log.Debug(msg);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please check data and login again.", "Login Fail");
                }
            }

        }

        private void FormLogin_Activated(object sender, EventArgs e)
        {
            tbUserID.Focus();
        }

        private void tbUserID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbUserID.Text.Trim().Equals(string.Empty))
                {
                    tbUserID.Focus();
                }

                if (tbUserID.Text.Trim().Equals(string.Empty))
                {
                    tbPassword.Focus();
                }

                btnLogin.Focus();
                btnLogin_Click(this, e);
            }
        }
    }
}

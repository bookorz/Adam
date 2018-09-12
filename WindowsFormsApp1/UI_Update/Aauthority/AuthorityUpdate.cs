using Adam.Util;
using log4net;
using SANWA.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adam.UI_Update.Authority
{
    class AuthorityUpdate
    {
        static ILog logger = LogManager.GetLogger(typeof(AuthorityUpdate));
        static DataTable dtAuthority;
        delegate void UpdateLogin(string Id, string Name, string Group);
        delegate void UpdateLogout();
        delegate void UpdateFuncEnable_D(string Form, string Control, string active);

        public static void UpdateLoginInfo(string Id, string Name, string Group)
        {
            try
            {
                Form form = Application.OpenForms["FormMain"];

                if (form == null)
                    return;
                
                if (form.InvokeRequired)
                {
                    UpdateLogin ph = new UpdateLogin(UpdateLoginInfo);
                    form.BeginInvoke(ph, Id, Name, Group);
                }
                else
                {
                    //lbl_login_name
                    Label lbl_login_id = form.Controls.Find( "lbl_login_id", true).FirstOrDefault() as Label;
                    Label lbl_login_name = form.Controls.Find("lbl_login_name", true).FirstOrDefault() as Label;
                    Label lbl_login_group = form.Controls.Find("lbl_login_group", true).FirstOrDefault() as Label;
                    Label lbl_login_date = form.Controls.Find("lbl_login_date", true).FirstOrDefault() as Label;
                    if (lbl_login_id != null)
                        lbl_login_id.Text = Id;
                    if (lbl_login_name != null)
                        lbl_login_name.Text = Name;
                    if (lbl_login_group != null)
                        lbl_login_group.Text = Group;
                    if (lbl_login_date != null)
                        lbl_login_date.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH：mm：ss");
                    Button btn = form.Controls.Find("btnLogInOut", true).FirstOrDefault() as Button;
                    btn.Text = "Logout";
                    //AuthorityUpdate.UpdateFuncAssign(Group);
                    AuthorityUpdate.UpdateFuncGroupEnable(Group);
                    
                }


            }
            catch
            {
                logger.Error("UpdateLoginInfo: Update fail.");
            }
        }

        public static void UpdateLogoutInfo()
        {
            try
            {
                Form form = Application.OpenForms["FormMain"];

                if (form == null)
                    return;

                if (form.InvokeRequired)
                {
                    UpdateLogout ph = new UpdateLogout(UpdateLogoutInfo);
                    form.BeginInvoke(ph);
                }
                else
                {
                    ILog log = LogManager.GetLogger("Database");
                    //lbl_login_name
                    Label lbl_login_id = form.Controls.Find("lbl_login_id", true).FirstOrDefault() as Label;
                    Label lbl_login_name = form.Controls.Find("lbl_login_name", true).FirstOrDefault() as Label;
                    Label lbl_login_group = form.Controls.Find("lbl_login_group", true).FirstOrDefault() as Label;
                    Label lbl_login_date = form.Controls.Find("lbl_login_date", true).FirstOrDefault() as Label;
                    string user_id = lbl_login_id.Text;
                    string user_name = lbl_login_name.Text;
                    if (lbl_login_id != null)
                        lbl_login_id.Text = "ID";
                    if (lbl_login_name != null)
                        lbl_login_name.Text = "Name";
                    if (lbl_login_group != null)
                        lbl_login_group.Text = "Group";
                    if (lbl_login_date != null)
                        lbl_login_date.Text = "";
                    Button btn = form.Controls.Find("btnLogInOut", true).FirstOrDefault() as Button;
                    btn.Text = "Login";
                    string msg = "{\"user_id\": " + user_id + ", \"name\": \"" + user_name + "\", \"action\": \"Logout\"}";
                    log.Info(msg);
                    //SanwaUtil.addActionLog("Authority", "Logout", user_id);// add record to log_system_action
                    SanwaUtil.addActionLog("Authority", "Logout", user_id, "使用者登出");// add record to log_system_action
                }
            }
            catch
            {
                logger.Error("UpdateLoginInfo: Update fail.");
            }
        }

        //public static void UpdateFuncGroupEnable(string Group)
        //{
        //    //set SQL
        //    StringBuilder sql = new StringBuilder();
        //    sql.Append("\n SELECT ugf.user_group_id, ugf.fun_id, ugf.active, f.fun_form, f.fun_ref");
        //    sql.Append("\n   FROM user_group_function ugf");
        //    sql.Append("\n   LEFT JOIN function f");
        //    sql.Append("\n     ON ugf.fun_id = f.fun_id");
        //    sql.Append("\n  WHERE user_group_id = @user_group_id ");
        //    //set parameter
        //    Dictionary<string, object> param = new Dictionary<string, object>();
        //    param.Add("@user_group_id", Group);
        //    //Query
        //    DBUtil dBUtil = new DBUtil();
        //    DataTableReader rs = dBUtil.GetDataReader(sql.ToString(), param);
        //    if (rs != null)
        //    {
        //        string fun_form = "";
        //        string fun_ref = "";
        //        string active = "";
        //        while (rs.Read())
        //        {
        //            fun_form = (string)rs["fun_form"];
        //            fun_ref = (string)rs["fun_ref"];
        //            active = (string)rs["active"];
        //            UpdateFuncAssign(fun_form, fun_ref, active);
        //        }
        //        rs.Close();
        //    }
        //}

        public static void UpdateFuncGroupEnable(string Group)
        {
            if(dtAuthority == null)
            {
                setDtAuthority();
            }
            DataTable dtTemp;
            DataView dvTemp;
            var query = (from t in dtAuthority.AsEnumerable()
                         where t.Field<string>("user_group_id") == Group
                         select t).ToList();
            if (query.Count > 0)
            {
                dtTemp = query.CopyToDataTable();
                dvTemp = dtTemp.DefaultView;

                string fun_form = "";
                string fun_ref = "";
                string active = "";
                for (int i = 0; i < dvTemp.Table.Rows.Count; i++)
                {
                    fun_form = (string)dvTemp.Table.Rows[i]["fun_form"];
                    fun_ref = (string)dvTemp.Table.Rows[i]["fun_ref"];
                    active = (string)dvTemp.Table.Rows[i]["active"];
                    UpdateFuncAssign(fun_form, fun_ref, active);
                }
            }
        }

        private static void setDtAuthority()
        {
            //set SQL
            StringBuilder sql = new StringBuilder();
            sql.Append("\n SELECT ugf.user_group_id, ugf.fun_id, ugf.active, f.fun_form, f.fun_ref");
            sql.Append("\n   FROM user_group_function ugf");
            sql.Append("\n   LEFT JOIN function f");
            sql.Append("\n     ON ugf.fun_id = f.fun_id");
            //sql.Append("\n  WHERE user_group_id = @user_group_id ");

            //set parameter
            Dictionary<string, object> param = new Dictionary<string, object>();
            //param.Add("@user_group_id", Group);

            //Query
            DBUtil dBUtil = new DBUtil();
            dtAuthority = dBUtil.GetDataTable(sql.ToString(), param);
        }

        public static void UpdateFuncAssign(string Form, string Control, string active)
        {
            try
            {
                Form form = Application.OpenForms[Form];

                if (form == null)
                    return;
                
                if (form.InvokeRequired)
                {
                    UpdateFuncEnable_D ph = new UpdateFuncEnable_D(UpdateFuncAssign);
                    form.BeginInvoke(ph, Form, Control, active);
                }
                else
                {
                    Control control = form.Controls.Find(Control, true).FirstOrDefault() as Control;
                    if(control != null)
                    {
                        switch (active)
                        {
                            case "Y":
                                control.Enabled = true;
                                break;
                            case "N":
                                control.Enabled = false;
                                break;
                        }
                    }
                }
            }
            catch
            {
                logger.Error("UpdateFuncAssign: Update fail.");
            }
        }

        public static bool getFuncEnable(string group_name, string fun_form, string fun_ref)
        {
            bool result = false;
            var query = (from t in dtAuthority.AsEnumerable()
                         where t.Field<string>("user_group_id") == group_name
                         && t.Field<string>("fun_form") == fun_form
                         && t.Field<string>("fun_ref") == fun_ref
                         && t.Field<string>("active") == "Y"
                         select t).ToList();
            if (query.Count > 0)
            {
                result = true;
            }
            return result;
        }
    }
}

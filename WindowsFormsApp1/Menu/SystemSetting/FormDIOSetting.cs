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
    public partial class FormDIOSetting : Adam.Menu.SystemSetting.FormSettingFram
    {
        public FormDIOSetting()
        {
            InitializeComponent();
        }

        private DataTable dtDIOSetting = new DataTable();
        private DBUtil dBUtil = new DBUtil();

        private void FormDIOSetting_Load(object sender, EventArgs e)
        {
            try
            {
                UpdateList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void UpdateList()
        {
            string strSql = string.Empty;

            try
            {
                strSql = "SELECT CONCAT(dioname, '-', `type`, '-', address) AS item, dioname, address, Parameter, `type`, abnormal, error_code " +
                    "FROM config_dio_point " +
                    "ORDER BY dioname, `type`, address ASC ";

                dtDIOSetting = dBUtil.GetDataTable(strSql, null);

                if (dtDIOSetting.Rows.Count > 0)
                {
                    lsbCondition.DataSource = dtDIOSetting;
                    lsbCondition.DisplayMember = "item";
                    lsbCondition.ValueMember = "item";
                    lsbCondition.SelectedIndex = -1;
                }
                else
                {
                    lsbCondition.DataSource = null;
                }

                txbDIOName.Text = string.Empty;
                nudAddress.Value = 0;
                txbParameter.Text = string.Empty;
                txbAbnormal.Text = string.Empty;
                txbType.Text = string.Empty;
                txbErrorCode.Text = string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void lsbCondition_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsbCondition.SelectedIndex >= 0)
                {
                    var query = (from a in dtDIOSetting.AsEnumerable()
                                 where a.Field<string>("dioname") == lsbCondition.Text.Split('-')[0].ToString()
                                 && a.Field<string>("type") == lsbCondition.Text.Split('-')[1].ToString()
                                 && a.Field<string>("address") == lsbCondition.Text.Split('-')[2].ToString()
                                 select a).ToList();

                    if (query.Count > 0)
                    {
                        txbDIOName.Text = query[0]["dioname"].ToString();
                        nudAddress.Value = Convert.ToInt32(query[0]["address"].ToString());
                        txbParameter.Text = query[0]["Parameter"].ToString();
                        txbAbnormal.Text = query[0]["abnormal"].ToString();
                        txbType.Text = query[0]["type"].ToString();
                        txbErrorCode.Text = query[0]["error_code"].ToString();
                    }
                    else
                    {
                        txbDIOName.Text = string.Empty;
                        nudAddress.Value = 0;
                        txbParameter.Text = string.Empty;
                        txbAbnormal.Text = string.Empty;
                        txbType.Text = string.Empty;
                        txbErrorCode.Text = string.Empty;
                    }
                }
                else
                {
                    txbDIOName.Text = string.Empty;
                    nudAddress.Value = 0;
                    txbParameter.Text = string.Empty;
                    txbAbnormal.Text = string.Empty;
                    txbType.Text = string.Empty;
                    txbErrorCode.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txbParameter.Text.Trim().ToString().Equals(string.Empty))
            {
                MessageBox.Show("Parameter is empty.", "Alart", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                txbParameter.Focus();
                return;
            }

            string strSql = string.Empty;
            Dictionary<string, object> keyValues = new Dictionary<string, object>();

            try
            {
                strSql = "UPDATE config_dio_point " +
                    "SET " +
                    "Parameter = @Parameter, " +
                    "abnormal = @abnormal, " +
                    "error_code = @error_code," +
                    "update_user = @update_user " +
                    "WHERE dioname = @dioname " +
                    "AND address = @address " +
                    "AND `type` = @type ";

                Form form = Application.OpenForms["FormMain"];
                Label Signal = form.Controls.Find("lbl_login_id", true).FirstOrDefault() as Label;

                keyValues.Add("@Parameter", txbParameter.Text.Trim().ToString());
                keyValues.Add("@abnormal", txbAbnormal.Text.Trim().ToString());
                keyValues.Add("@error_code", txbErrorCode.Text.Trim().ToString());
                keyValues.Add("@update_user", Signal.Text);
                keyValues.Add("@dioname", lsbCondition.Text.Split('-')[0].ToString());
                keyValues.Add("@address", lsbCondition.Text.Split('-')[2].ToString());
                keyValues.Add("@type", lsbCondition.Text.Split('-')[1].ToString());

                dBUtil.ExecuteNonQuery(strSql, keyValues);
                Adam.Util.SanwaUtil.addActionLog("Adam.Menu.SystemSetting", "FormDIOSetting", Signal.Text);
                MessageBox.Show("Done it.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                UpdateList();
                //改設定後套用
                FormMain.DIO.Initial();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}

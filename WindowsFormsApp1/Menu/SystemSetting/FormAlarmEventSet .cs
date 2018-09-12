using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Adam.Util;
using SANWA.Utility;
using System.Linq;

namespace Adam.Menu.SystemSetting
{
    public partial class FormAlarmEventSet : Form
    {
        public FormAlarmEventSet()
        {
            InitializeComponent();
        }

        private DBUtil dBUtil = new DBUtil();

        private void FormAlarmEventSet_Load(object sender, EventArgs e)
        {
            string strSql = string.Empty;
            DataTable dtTemp;
            Dictionary<string, object> keyValues = new Dictionary<string, object>();

            try
            {
                dtTemp = new DataTable();

                strSql = "SELECT list_type, list_id, CONCAT(list_name, ' - ', list_name_en) name, list_name, list_name_en, list_value, sort_sequence, active " +
                         "FROM config_list_item " +
                         "WHERE list_type = @list_type " +
                         "AND active = @active " +
                         "AND list_id <> @list_id " +
                         "ORDER BY sort_sequence ASC ";


                keyValues.Add("@list_type", "VENDOR_CODE");
                keyValues.Add("@active", "Y");
                keyValues.Add("@list_id", "NA");

                dtTemp = dBUtil.GetDataTable(strSql, keyValues);


                if (dtTemp.Rows.Count > 0)
                {
                    lsbAlarmConditionVendorCode.DataSource = dtTemp.Copy();
                    lsbAlarmConditionVendorCode.DisplayMember = "name";
                    lsbAlarmConditionVendorCode.ValueMember = "list_value";
                    lsbAlarmConditionVendorCode.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("list_item : VENDOR_CODE does not exist.", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }

                strSql = "SELECT list_type, list_id, CONCAT(list_name, ' - ', list_name_en) name, list_name, list_name_en, list_value, sort_sequence, active " +
                             "FROM config_list_item " +
                             "WHERE list_type = @list_type " +
                             "AND active = @active " +
                             "AND list_id <> @list_id " +
                             "ORDER BY sort_sequence ASC ";

                keyValues.Clear();
                keyValues.Add("@list_type", "DEVICE_TYPE");
                keyValues.Add("@active", "Y");
                keyValues.Add("@list_id", "NA");

                dtTemp = dBUtil.GetDataTable(strSql, keyValues);


                if (dtTemp.Rows.Count > 0)
                {
                    lsbAlarmConditionDeviceType.DataSource = dtTemp.Copy();
                    lsbAlarmConditionDeviceType.DisplayMember = "name";
                    lsbAlarmConditionDeviceType.ValueMember = "list_value";
                    lsbAlarmConditionDeviceType.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("list_item : DEVICE_TYPE does not exist.", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void lsbAlarmConditionVendorCode_Click(object sender, EventArgs e)
        {
            if (lsbAlarmConditionVendorCode.SelectedIndex < 0 || lsbAlarmConditionDeviceType.SelectedIndex < 0)
            {
                return;
            }

            string strSql = string.Empty;
            DataTable dtTemp;
            Dictionary<string, object> keyValues = new Dictionary<string, object>();

            try
            {
                if (lsbAlarmConditionVendorCode.SelectedIndex >= 0)
                {
                    dtTemp = new DataTable();

                    strSql = "SELECT node_type, vendor, model_no, category, code_type, code_id, code_name, code_desc, code_desc_en, active, is_stop " +
                        "FROM device_code " +
                        "WHERE category = 'ErrorCode' AND active = 'Y' " +
                        "AND vendor = @vendor " +
                        "AND node_type  = @node_type";

                    keyValues.Add("@vendor", lsbAlarmConditionVendorCode.SelectedValue.ToString().Equals("ICP_DAS") ? "SANWA" : lsbAlarmConditionVendorCode.SelectedValue.ToString());
                    keyValues.Add("@node_type", lsbAlarmConditionDeviceType.SelectedValue.ToString().Equals("DIO") ? "SYSTEM" : lsbAlarmConditionDeviceType.SelectedValue.ToString());

                    dtTemp = dBUtil.GetDataTable(strSql, keyValues);
                    dgvlsbAlarmData.AutoGenerateColumns = false;
                    dgvlsbAlarmData.DataSource = dtTemp;
                }
                else
                {
                    dgvlsbAlarmData.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((DataTable)dgvlsbAlarmData.DataSource == null || ((DataTable)dgvlsbAlarmData.DataSource).Rows.Count == 0)
            {
                MessageBox.Show("The grid data does not exist.", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            if (MessageBox.Show("Are you sure save the setting?", this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
            {
                return;
            }

            string strSql = string.Empty;
            StringBuilder sbTemp = new StringBuilder();
            Dictionary<string, object> keyValues = new Dictionary<string, object>();
            DataTable dtTemp = null;

            try
            {
                dtTemp = (DataTable)dgvlsbAlarmData.DataSource;

                strSql = "UPDATE device_code SET " +
                    "is_stop = '{0}' " +
                    "WHERE node_type = '{1}' " +
                    "AND vendor = '{2}' " +
                    "AND category = '{3}' " +
                    "AND code_id = '{4}' " +
                    ";";

                foreach (DataRow dr in dtTemp.Rows)
                {
                    sbTemp.AppendFormat(strSql, dr["is_stop"].ToString(), dr["node_type"].ToString(), dr["vendor"].ToString(), dr["category"].ToString(), dr["code_id"].ToString());
                }

                dBUtil.ExecuteNonQuery(sbTemp.ToString(), null);

                MessageBox.Show("Done it.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                Form form = Application.OpenForms["FormMain"];
                Label Signal = form.Controls.Find("lbl_login_id", true).FirstOrDefault() as Label;
                SanwaUtil.addActionLog("Adam.Menu.SystemSetting", "FormAlarmEventSet", Signal.Text);

                FormAlarmEventSet_Load(sender, e);
                dgvlsbAlarmData.DataSource = null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}

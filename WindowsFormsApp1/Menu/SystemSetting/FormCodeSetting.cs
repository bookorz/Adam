using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Adam.Util;
using SANWA.Utility;

namespace Adam.Menu.SystemSetting
{
    public partial class FormCodeSetting : Adam.Menu.SystemSetting.FormSettingFram
    {
        public FormCodeSetting()
        {
            InitializeComponent();
        }

        private DBUtil dBUtil = new DBUtil();

        private void FormCodeSetting_Load(object sender, EventArgs e)
        {
            string strSql = string.Empty;
            DataTable dtTemp;
            Dictionary<string, object> keyValues = new Dictionary<string, object>();
            Controlling controlling = new Controlling();


            try
            {
                dtTemp = new DataTable();

                strSql = "SELECT list_type, list_id, CONCAT(list_name, ' - ', list_name_en) name, list_name, list_name_en, list_value, sort_sequence, active " +
                         "FROM config_list_item  " +
                         "WHERE list_type in ('VENDOR_CODE', 'DEVICE_TYPE') " +
                         "AND active = @active " +
                         "AND list_id <> @list_id " +
                         "ORDER BY sort_sequence ASC ";

                keyValues.Add("@active", "Y");
                keyValues.Add("@list_id", "NA");

                dtTemp = dBUtil.GetDataTable(strSql, keyValues);


                if (dtTemp.Rows.Count > 0)
                {
                    controlling.ListBox_ItemChange(ref lsbCodeConditionVendorCode, dtTemp.Select("list_type = 'VENDOR_CODE'"), "name", "list_value");
                    lsbCodeConditionVendorCode.SelectedIndex = -1;

                    controlling.ListBox_ItemChange(ref lsbCodeConditionDeviceType, dtTemp.Select("list_type = 'DEVICE_TYPE'"), "name", "list_value");
                    lsbCodeConditionDeviceType.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("list_item : VENDOR_CODE and DEVICE_TYPE does not exist.", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void lsbCodeConditionVendorCode_Click(object sender, EventArgs e)
        {
            string strSql = string.Empty;
            DataTable dtTemp;
            Dictionary<string, object> keyValues = new Dictionary<string, object>();

            try
            {
                if (lsbCodeConditionVendorCode.SelectedIndex >= 0 && lsbCodeConditionDeviceType.SelectedIndex >= 0)
                {
                    dtTemp = new DataTable();

                    strSql = "SELECT node_type, vendor, model_no, category, code_type, code_id, code_name, code_desc, code_desc_en, active " +
                             "FROM device_code " +
                             "WHERE node_type = @node_type " +
                             "AND vendor = @vendor " +
                             "AND category = @category " +
                             "ORDER BY code_type ASC, code_id ASC";

                    keyValues.Add("@node_type", lsbCodeConditionDeviceType.SelectedValue.ToString());
                    keyValues.Add("@vendor", lsbCodeConditionVendorCode.SelectedValue.ToString());
                    keyValues.Add("@category", "Command");

                    dtTemp = dBUtil.GetDataTable(strSql, keyValues);
                    //dgvCodeData.AutoGenerateColumns = false;
                    dgvCodeData.DataSource = dtTemp;
                }
                else
                {
                    dgvCodeData.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SANWA.Utility;
using TransferControl.Management;
using Adam.UI_Update.OCR;
using log4net;

namespace Adam.Menu.SystemSetting
{
    public partial class FormDeviceManager : Form
    {
        public FormDeviceManager()
        {
            InitializeComponent();
        }

        private SANWA.Utility.config_equipment_model equipment_Model = new SANWA.Utility.config_equipment_model();
        private DataTable dtConfigNode = new DataTable();
        private DataTable dtRouteTable = new DataTable();
        private static readonly ILog logger = LogManager.GetLogger(typeof(FormDeviceManager));

        private void FormDeviceManager_Load(object sender, EventArgs e)
        {
            string strSql = string.Empty;
            Dictionary<string, object> keyValues = new Dictionary<string, object>();
            DBUtil dBUtil = new DBUtil();
            DataTable dtTemp = new DataTable();

            try
            {
                UpdateNodeList();

                if (equipment_Model.EquipmentModel == null)
                {
                    MessageBox.Show("查無 Equipment_Model 相關資料，請管理者確認組態等相關設定！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    txbEquipmentModel.Text = equipment_Model.EquipmentModel.equipment_model_type;

                    dtTemp = new DataTable();
                    strSql = "SELECT list_type, list_id, list_name, list_name_en, CASE WHEN list_value = 'DIO' THEN 'SYSTEM' ELSE list_value END list_value, sort_sequence " +
                                "FROM config_list_item " +
                                "WHERE list_type = 'DEVICE_TYPE'";
                    dtTemp = dBUtil.GetDataTable(strSql, null);

                    if (dtTemp.Rows.Count > 0)
                    {
                        cmbDeviceNodeType.DataSource = dtTemp;
                        cmbDeviceNodeType.DisplayMember = "list_name";
                        cmbDeviceNodeType.ValueMember = "list_value";
                        cmbDeviceNodeType.SelectedIndex = -1;
                    }
                    else
                    {
                        cmbDeviceNodeType.DataSource = null;
                    }
                }

            }
            catch (Exception ex)
            {
                //throw new Exception(ex.ToString());
                logger.Error(ex.StackTrace);
                MessageBox.Show(ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbDeviceNodeType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string strSql = string.Empty;
            Dictionary<string, object> keyValues = new Dictionary<string, object>();
            DBUtil dBUtil = new DBUtil();
            DataTable dtTemp = new DataTable();

            try
            {
                cmbVendor.DataSource = null;
                strSql = "SELECT vendor_id, CONCAT(vendor_name, ' - ', vendor_name_en) AS name, vendor_name, vendor_name_en, vendor_device " +
                         "FROM config_vendor " +
                         "WHERE vendor_device like @vendor_device ";
                keyValues.Add("@vendor_device", "%" + cmbDeviceNodeType.SelectedValue.ToString() + "%");
                dtTemp = dBUtil.GetDataTable(strSql, keyValues);

                if (dtTemp.Rows.Count > 0)
                {
                    cmbVendor.DataSource = dtTemp;
                    cmbVendor.DisplayMember = "name";
                    cmbVendor.ValueMember = "vendor_id";
                    cmbVendor.SelectedIndex = -1;
                }
                else
                {
                    cmbVendor.DataSource = null;
                }

                //dtTemp = new DataTable();
                //strSql = "SELECT (sn_no +1) AS sn_no, CONCAT(SUBSTRING(controller_id, 1, LENGTH(controller_id) - 2), LPAD(LTRIM(CAST(CONVERT(SUBSTRING(controller_id, LENGTH(controller_id) - 1, 2), INTEGER) + 1 AS CHAR)), 2, '0')) AS new_controller_id " +
                //    "FROM config_node " +
                //    "WHERE equipment_model_id = @equipment_model_id " +
                //    "AND node_type = @node_type " +
                //    "ORDER BY sn_no DESC";
                //keyValues.Add("@equipment_model_id", equipment_Model.EquipmentModel.equipment_model_id);
                //keyValues.Add("@node_type", cmbDeviceNodeType.SelectedValue.ToString());
                //dtTemp = dBUtil.GetDataTable(strSql, keyValues);

                //if (dtTemp.Rows.Count > 0)
                //{
                //    nudSerialNo.Value = Convert.ToInt32(dtTemp.Rows[0]["sn_no"].ToString());
                //    txbControllerID.Text = dtTemp.Rows[0]["new_controller_id"].ToString();
                //}
                //else
                //{
                //    nudSerialNo.Value = 0;
                //    txbControllerID.Text = string.Empty;
                //}

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void UpdateNodeList()
        {
            string strSql = string.Empty;
            Dictionary<string, object> keyValues = new Dictionary<string, object>();
            DBUtil dBUtil = new DBUtil();

            try
            {
                strSql = @"SELECT * 
                            FROM config_node
                            WHERE equipment_model_id = @equipment_model_id
                            ORDER BY node_id";
                keyValues.Add("@equipment_model_id", SANWA.Utility.Config.SystemConfig.Get().SystemMode);
                dtConfigNode = dBUtil.GetDataTable(strSql, keyValues);

                if (dtConfigNode.Rows.Count > 0)
                {
                    lstNodeList.DataSource = dtConfigNode;
                    lstNodeList.DisplayMember = "node_id";
                    lstNodeList.ValueMember = "node_id";
                    lstNodeList.SelectedIndex = -1;
                }
                else
                {
                    lstNodeList.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void lstNodeList_Click(object sender, EventArgs e)
        {
            DataTable dtTemp = new DataTable();

            try
            {
                var query = (from a in dtConfigNode.AsEnumerable()
                             where a.Field<string>("node_id") == lstNodeList.SelectedValue.ToString()
                             select a).ToList();

                if (query.Count == 0)
                {
                    dgvRouteTable.DataSource = null;
                    throw new RowNotInTableException();
                }
                else
                {
                    dtTemp = query.CopyToDataTable();

                    txbDeviceNodeName.Text = dtTemp.Rows[0]["node_id"].ToString();
                    txbDeviceNodeName.Tag = dtTemp.Rows[0]["node_id"].ToString();
                    cmbDeviceNodeType.SelectedValue = dtTemp.Rows[0]["node_type"].ToString();
                    cmbDeviceNodeType_SelectionChangeCommitted(sender, e);
                    nudSerialNo.Value = Convert.ToInt32(dtTemp.Rows[0]["sn_no"].ToString());
                    cmbVendor.SelectedValue = dtTemp.Rows[0]["vendor"].ToString();
                    txbModel.Text = dtTemp.Rows[0]["model_no"].ToString();
                    txbFirmwareVersion.Text = dtTemp.Rows[0]["firmware_ver"].ToString();
                    txbAddress.Text = dtTemp.Rows[0]["conn_address"].ToString();
                    txbControllerID.Text = dtTemp.Rows[0]["controller_id"].ToString();
                    chbActive.Checked = dtTemp.Rows[0]["enable_flg"].ToString() == "1" ? true : false;
                    txbDefaultAligner.Text = dtTemp.Rows[0]["default_aligner"].ToString();
                    txbAlternativeAligner.Text = dtTemp.Rows[0]["alternative_aligner"].ToString();
                    dtRouteTable = (DataTable)Newtonsoft.Json.JsonConvert.DeserializeObject(dtTemp.Rows[0]["route_table"].ToString(), (typeof(DataTable)));
                    dgvRouteTable.DataSource = dtRouteTable;

                    chbByPass.Checked = dtTemp.Rows[0]["bypass"].ToString() == "1" ? true : false;
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
            StringBuilder sbErrorMessage = new StringBuilder();
            Dictionary<string, object> keyValues = new Dictionary<string, object>();
            DBUtil dBUtil = new DBUtil();
            DataTable dtTemp = new DataTable();
            DataRow[] drsTemp;

            try
            {
                if (txbDeviceNodeName.Text.Trim().Equals(string.Empty) &&
                    cmbDeviceNodeType.SelectedIndex == -1 &&
                    nudSerialNo.Value == 0 &&
                    cmbVendor.SelectedIndex == -1 &&
                    txbModel.Text.Trim().Equals(string.Empty) &&
                    txbFirmwareVersion.Text.Trim().Equals(string.Empty) &&
                    txbAddress.Text.Trim().Equals(string.Empty) &&
                    txbControllerID.Text.Trim().Equals(string.Empty)
                    )
                {
                    MessageBox.Show("Miss input data in the form.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    return;
                }

                if (txbDeviceNodeName.Text.Trim().Equals(string.Empty) ||
                    cmbDeviceNodeType.SelectedIndex == -1 || cmbVendor.SelectedIndex == -1)
                {
                    MessageBox.Show("Miss input data in the form.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    return;
                }

                strSql = "select * from config_node where equipment_model_id = @equipment_model_id and node_type = @node_type order by node_id, sn_no";
                keyValues.Add("@equipment_model_id", SANWA.Utility.Config.SystemConfig.Get().SystemMode);
                keyValues.Add("@node_type", cmbDeviceNodeType.SelectedValue.ToString());
                dtTemp = dBUtil.GetDataTable(strSql, keyValues);

                if (dtTemp.Rows.Count > 0)
                {
                    if (dtTemp.Select("node_id in ('" + txbDeviceNodeName.Tag + "','" + cmbDeviceNodeType.Text + Convert.ToInt32(nudSerialNo.Value).ToString("D2") + "')").Length > 0)
                    {
                        sbErrorMessage.Append("Node ID exist.");
                        sbErrorMessage.AppendLine();
                    }

                    if (dtTemp.Select("sn_no = " + Convert.ToInt32(nudSerialNo.Value).ToString()).Length > 0)
                    {
                        sbErrorMessage.Append("Serial No exist.");
                        sbErrorMessage.AppendLine();
                    }

                    if (dtTemp.Select("controller_id = '" + txbControllerID.Text + "'").Length > 0)
                    {
                        sbErrorMessage.Append("Controller ID exist.");
                        sbErrorMessage.AppendLine();
                    }
                }

                if (sbErrorMessage.ToString().Length > 0)
                {
                    if (MessageBox.Show(sbErrorMessage.ToString() + "\r\n Do you want to overwrite???", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    {
                        return;
                    }
                }

                keyValues.Clear();

                strSql = "REPLACE INTO config_node " +
                    "(equipment_model_id, node_id, node_type, sn_no, vendor, model_no, firmware_ver, conn_address, controller_id, bypass, default_aligner, alternative_aligner, route_table, enable_flg, create_user, create_timestamp, modify_user, modify_timestamp) " +
                    "VALUES " +
                    "(@equipment_model_id, @node_id, @node_type, @sn_no, @vendor, @model_no, @firmware_ver, @conn_address, @controller_id, @bypass, @default_aligner, @alternative_aligner, @route_table, @enable_flg, @create_user, @create_timestamp, @modify_user, NOW())";

                keyValues.Add("@equipment_model_id", equipment_Model.EquipmentModel.equipment_model_id);
                keyValues.Add("@node_id", txbDeviceNodeName.Text.Trim());
                keyValues.Add("@node_type", cmbDeviceNodeType.SelectedValue.ToString());
                keyValues.Add("@sn_no", nudSerialNo.Value);
                keyValues.Add("@vendor", cmbVendor.SelectedValue.ToString());
                keyValues.Add("@model_no", txbModel.Text.Trim());
                keyValues.Add("@firmware_ver", txbFirmwareVersion.Text.Trim());
                keyValues.Add("@conn_address", txbAddress.Text.Trim());
                keyValues.Add("@controller_id", txbControllerID.Text.Trim());
                keyValues.Add("@enable_flg", chbActive.Checked ? 1 : 0);
                keyValues.Add("@default_aligner", txbDefaultAligner.Text.Trim());
                keyValues.Add("@alternative_aligner", txbAlternativeAligner.Text.Trim());
                keyValues.Add("@route_table", JsonConvert.SerializeObject(dtRouteTable, Formatting.Indented).Replace("\r\n", string.Empty));
                keyValues.Add("@bypass", chbByPass.Checked ? 1 : 0);

                drsTemp = dtTemp.Select("node_id = '" + cmbDeviceNodeType.Text + Convert.ToInt32(nudSerialNo.Value).ToString("D2") + "'");
                Form form = Application.OpenForms["FormMain"];
                Label Signal = form.Controls.Find("lbl_login_id", true).FirstOrDefault() as Label;

                if (drsTemp.Length > 0)
                {
                    keyValues.Add("@create_user", drsTemp[0]["create_user"].ToString());
                    keyValues.Add("@create_timestamp", Convert.ToDateTime(drsTemp[0]["create_timestamp"].ToString()).ToString("yyyy-MM-dd HH:mm:ss"));
                }
                else
                {
                    keyValues.Add("@create_user", Signal.Text);
                    strSql = strSql.Replace("@create_timestamp", "NOW()");
                }

                keyValues.Add("@modify_user", Signal.Text);

                dBUtil.ExecuteNonQuery(strSql, keyValues);
                MessageBox.Show("Done it.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                Adam.Util.SanwaUtil.addActionLog("Adam.Menu.SystemSetting", "FormCpmmandScript", Signal.Text);

                UpdateNodeList();
                ClearUI();

                //改設定後套用
                NodeManagement.LoadConfig();
                if (cmbDeviceNodeType.Text.Equals("OCR"))
                {
                    OCRUpdate.AssignForm();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void ClearUI()
        {
            txbDeviceNodeName.Text = string.Empty;
            txbDeviceNodeName.Tag = null;
            cmbDeviceNodeType.SelectedIndex = -1;
            nudSerialNo.Value = 0;
            cmbVendor.SelectedIndex = -1;
            txbModel.Text = string.Empty;
            txbFirmwareVersion.Text = string.Empty;
            txbAddress.Text = string.Empty;
            txbControllerID.Text = string.Empty;
            chbActive.Checked = false;
            txbDefaultAligner.Text = string.Empty;
            txbAlternativeAligner.Text = string.Empty;
            dgvRouteTable.DataSource = null;
            chbByPass.Checked = false;
        }
    }
}

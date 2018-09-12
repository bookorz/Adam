using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using SANWA.Utility;
using TransferControl.Management;

namespace Adam.Menu.SystemSetting
{
    public partial class FormCommandScript : Form
    {
        public FormCommandScript()
        {
            InitializeComponent();
        }

        private DataTable dtCommandType;

        private void FormConfiguration_Load(object sender, EventArgs e)
        {
            try
            {
                UpdateNodeList();
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
                strSql = "select *, concat(CommandScriptID, ',', `Index`) as CommandScriptIndex from config_command_script order by CommandScriptID asc, `Index` asc";
                keyValues.Add("@equipment_model_id", SANWA.Utility.Config.SystemConfig.Get().SystemMode);
                dtCommandType = dBUtil.GetDataTable(strSql, keyValues);

                if (dtCommandType.Rows.Count > 0)
                {
                    lstConditionList.DataSource = dtCommandType;
                    lstConditionList.DisplayMember = "CommandScriptIndex";
                    lstConditionList.ValueMember = "CommandScriptIndex";
                    lstConditionList.SelectedIndex = -1;

                    var query = (from a in dtCommandType.AsEnumerable()
                                 select a.Field<string>("CommandScriptID")).Distinct().ToList();

                    if (query.Count() > 0)
                    {
                        cmdCommandScriptID.Items.Clear();

                        foreach (var item in query)
                        {
                            cmdCommandScriptID.Items.Add(item.ToString());
                        }
                    }
                }
                else
                {
                    lstConditionList.DataSource = null;
                }


                cmdCommandScriptID.Text = string.Empty;
                txbExcuteMethod.Text = string.Empty;
                txbFinishMethod.Text = string.Empty;
                txbMethod.Text = string.Empty;
                txbArm.Text = string.Empty;
                txbSlot.Text = string.Empty;
                txbPosition.Text = string.Empty;
                txbValue.Text = string.Empty;
                txbIndex.Text = string.Empty;
                txbFlag.Text = string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void lstConditionList_Click(object sender, EventArgs e)
        {
            DataTable dtTemp = new DataTable();

            try
            {
                var query = (from a in dtCommandType.AsEnumerable()
                             where a.Field<string>("CommandScriptID") == lstConditionList.SelectedValue.ToString().Split(',')[0].ToString()
                               && a.Field<string>("Index") == lstConditionList.SelectedValue.ToString().Split(',')[1].ToString()
                             select a).ToList();

                if (query.Count > 0)
                {
                    dtTemp = query.CopyToDataTable();

                    cmdCommandScriptID.Text = dtTemp.Rows[0]["CommandScriptID"].ToString();
                    txbExcuteMethod.Text = dtTemp.Rows[0]["ExcuteMethod"].ToString();
                    txbFinishMethod.Text = dtTemp.Rows[0]["FinishMethod"].ToString();
                    txbMethod.Text = dtTemp.Rows[0]["Method"].ToString();
                    txbArm.Text = dtTemp.Rows[0]["Arm"].ToString();
                    txbSlot.Text = dtTemp.Rows[0]["Slot"].ToString();
                    txbPosition.Text = dtTemp.Rows[0]["Position"].ToString();
                    txbValue.Text = dtTemp.Rows[0]["Value"].ToString();
                    txbIndex.Text = dtTemp.Rows[0]["Index"].ToString();
                    txbFlag.Text = dtTemp.Rows[0]["Flag"].ToString();
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
                if (cmdCommandScriptID.Text.Trim().Equals(string.Empty) &&
                    txbIndex.Text.Trim().Equals(string.Empty)
                    )
                {
                    MessageBox.Show("Miss input data in the form.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    return;
                }

                strSql = "SELECT * " +
                    "FROM config_command_script " +
                    "WHERE CommandScriptID = @CommandScriptID ";

                keyValues.Add("@CommandScriptID", cmdCommandScriptID.Text.Trim());
                dtTemp = dBUtil.GetDataTable(strSql, keyValues);

                if (dtTemp.Rows.Count > 0)
                {
                    if (dtTemp.Select("Index = '" + txbIndex.Text.Trim() + "'" ).Length > 0)
                    {
                        sbErrorMessage.Append("Index exist.");
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

                strSql = "REPLACE INTO config_command_script " +
                    "(CommandScriptID, ExcuteMethod, FinishMethod, Method, Arm, Slot, Position, Value, `Index`, Flag) " +
                    "VALUES " +
                    "(@CommandScriptID, @ExcuteMethod, @FinishMethod, @Method, @Arm, @Slot, @Position, @Value, @Index, @Flag)";

                keyValues.Add("@CommandScriptID", cmdCommandScriptID.Text.Trim());
                keyValues.Add("@ExcuteMethod", txbExcuteMethod.Text.Trim());
                keyValues.Add("@FinishMethod", txbFinishMethod.Text.Trim());
                keyValues.Add("@Method", txbMethod.Text.Trim());
                keyValues.Add("@Arm", txbArm.Text.Trim());
                keyValues.Add("@Slot", txbSlot.Text.Trim());
                keyValues.Add("@Position", txbPosition.Text.Trim());
                keyValues.Add("@Value", txbValue.Text.Trim());
                keyValues.Add("@Index", txbIndex.Text.Trim());
                keyValues.Add("@Flag", txbFlag.Text.Trim());

                dBUtil.ExecuteNonQuery(strSql, keyValues);
                MessageBox.Show("Done it.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                Form form = Application.OpenForms["FormMain"];
                Label Signal = form.Controls.Find("lbl_login_id", true).FirstOrDefault() as Label;
                Adam.Util.SanwaUtil.addActionLog("Adam.Menu.SystemSetting", "FormCpmmandScript", Signal.Text);

                UpdateNodeList();
                //改設定後套用
                CommandScriptManagement.LoadConfig();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SANWA.Utility;
using System.Linq;
using Adam.UI_Update.Monitoring;

namespace Adam.Menu.SystemSetting
{
    public partial class FormSignalTower : Adam.Menu.SystemSetting.FormSettingFram
    {
        public FormSignalTower()
        {
            InitializeComponent();
        }

        private DataTable dtSignalTower = new DataTable();
        private DBUtil dBUtil = new DBUtil();

        private void FormSignalTtower_Load(object sender, EventArgs e)
        {

            DataTable dtTemp = new DataTable();
            string strSql = string.Empty;

            try
            {
                UpdateList();

                strSql = "SELECT * " +
                    "FROM config_list_item " +
                    "WHERE list_type = 'SIGNAL_LIGHT_TYPE' " +
                    "ORDER BY sort_sequence ASC; ";

                dtTemp = dBUtil.GetDataTable(strSql, null);

                if (dtSignalTower.Rows.Count > 0)
                {
                    cmbBlue.DataSource = dtTemp.Copy();
                    cmbBlue.ValueMember = "list_value";
                    cmbBlue.DisplayMember = "list_value";
                    cmbBlue.SelectedIndex = -1;

                    cmbGreen.DataSource = dtTemp.Copy();
                    cmbGreen.ValueMember = "list_value";
                    cmbGreen.DisplayMember = "list_value";
                    cmbGreen.SelectedIndex = -1;

                    cmbRad.DataSource = dtTemp.Copy();
                    cmbRad.ValueMember = "list_value";
                    cmbRad.DisplayMember = "list_value";
                    cmbRad.SelectedIndex = -1;

                    cmbYellow.DataSource = dtTemp.Copy();
                    cmbYellow.ValueMember = "list_value";
                    cmbYellow.DisplayMember = "list_value";
                    cmbYellow.SelectedIndex = -1;

                }
                else
                {
                    cmbBlue.DataSource = null;
                    cmbGreen.DataSource = null;
                    cmbRad.DataSource = null;
                    cmbYellow.DataSource = null;
                }

                strSql = "SELECT * " +
                        "FROM config_list_item " +
                        "WHERE list_type = 'SIGNAL_BUZZER_TYPE' " +
                        "ORDER BY sort_sequence ASC; ";

                dtTemp = dBUtil.GetDataTable(strSql, null);

                if (dtSignalTower.Rows.Count > 0)
                {
                    cmbBuzzer1.DataSource = dtTemp.Copy();
                    cmbBuzzer1.ValueMember = "list_value";
                    cmbBuzzer1.DisplayMember = "list_value";
                    cmbBuzzer1.SelectedIndex = -1;

                    cmbBuzzer2.DataSource = dtTemp.Copy();
                    cmbBuzzer2.ValueMember = "list_value";
                    cmbBuzzer2.DisplayMember = "list_value";
                    cmbBuzzer2.SelectedIndex = -1;
                }
                else
                {
                    cmbBlue.DataSource = null;
                    cmbGreen.DataSource = null;
                    cmbRad.DataSource = null;
                    cmbYellow.DataSource = null;
                }

                lsbCondition.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void lsbCondition_Click(object sender, EventArgs e)
        {
            txbEqpStatus.Text = string.Empty;
            txbIsAlarm.Text = string.Empty;
            cmbBlue.SelectedIndex = -1;
            cmbGreen.SelectedIndex = -1;
            cmbRad.SelectedIndex = -1;
            cmbYellow.SelectedIndex = -1;
            cmbBuzzer1.SelectedIndex = -1;
            cmbBuzzer2.SelectedIndex = -1;

            try
            {
                var query = (from a in dtSignalTower.AsEnumerable()
                             where a.Field<string>("eqp_status") == lsbCondition.Text.Split('-')[0].ToString()
                             && a.Field<UInt64>("is_alarm") == Convert.ToUInt64(lsbCondition.SelectedValue.ToString())
                             select a).ToList();

                if (query.Count > 0)
                {
                    txbEqpStatus.Text = query[0]["eqp_status"].ToString();
                    txbIsAlarm.Text = query[0]["is_alarm"].ToString();
                    cmbBlue.SelectedValue = query[0]["blue"].ToString();
                    cmbGreen.SelectedValue = query[0]["green"].ToString();
                    cmbRad.SelectedValue = query[0]["red"].ToString();
                    cmbYellow.SelectedValue = query[0]["orange"].ToString();
                    cmbBuzzer1.SelectedValue = query[0]["buzzer1"].ToString();
                    cmbBuzzer2.SelectedValue = query[0]["buzzer2"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((DataTable)lsbCondition.DataSource == null || ((DataTable)lsbCondition.DataSource).Rows.Count == 0)
            {
                MessageBox.Show("The grid data does not exist.", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            if (lsbCondition.SelectedIndex < 0)
            {
                MessageBox.Show("Choose the condition.", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            string strSql = string.Empty;
            Dictionary<string, object> keyValues = new Dictionary<string, object>();

            try
            {
                strSql = "UPDATE config_signal_tower " +
                    "SET red = @red, " +
                    "orange = @orange, " +
                    "green = @green, " +
                    "blue = @blue, " +
                    "buzzer1 = @buzzer1, " +
                    "buzzer2 = @buzzer2, " +
                    "update_user = @update_user, " +
                    "update_time = NOW() " +
                    "WHERE eqp_status  =  @eqp_status " +
                    "AND is_alarm = @is_alarm ";

                Form form = Application.OpenForms["FormMain"];
                Label Signal = form.Controls.Find("lbl_login_id", true).FirstOrDefault() as Label;

                keyValues.Add("@red", cmbRad.Text.ToString());
                keyValues.Add("@orange", cmbYellow.Text.ToString());
                keyValues.Add("@green", cmbGreen.Text.ToString());
                keyValues.Add("@blue", cmbBlue.Text.ToString());
                keyValues.Add("@buzzer1", cmbBuzzer1.Text.ToString());
                keyValues.Add("@buzzer2", cmbBuzzer2.Text.ToString());
                keyValues.Add("@update_user", Signal.Text);
                keyValues.Add("@eqp_status", lsbCondition.Text.Split('-')[0].ToString());
                keyValues.Add("@is_alarm", Convert.ToUInt64(lsbCondition.SelectedValue.ToString()));

                dBUtil.ExecuteNonQuery(strSql, keyValues);

                MessageBox.Show("Done it.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                Adam.Util.SanwaUtil.addActionLog("Adam.Menu.SystemSetting", "FormSignalTower", Signal.Text);

                UpdateList();

                txbEqpStatus.Text = string.Empty;
                txbIsAlarm.Text = string.Empty;
                cmbBlue.SelectedIndex = -1;
                cmbGreen.SelectedIndex = -1;
                cmbRad.SelectedIndex = -1;
                cmbYellow.SelectedIndex = -1;
                cmbBuzzer1.SelectedIndex = -1;
                cmbBuzzer2.SelectedIndex = -1;
                lsbCondition.SelectedIndex = -1;
                //改設定後套用
                NodeStatusUpdate.InitialSetting();
                NodeStatusUpdate.UpdateCurrentState(FormMain.RouteCtrl.EqpState);
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
                strSql = "select concat(eqp_status, '-', (case when is_alarm = 0 then 'Normal' else 'Alarm' end)) item, " +
                            "eqp_status, is_alarm, red, orange, green, blue, buzzer1, buzzer2 " +
                            "from config_signal_tower order by is_alarm, eqp_status asc ";

                dtSignalTower = dBUtil.GetDataTable(strSql, null);

                if (dtSignalTower.Rows.Count > 0)
                {
                    lsbCondition.DataSource = dtSignalTower;
                    lsbCondition.DisplayMember = "item";
                    lsbCondition.ValueMember = "is_alarm";
                }
                else
                {
                    lsbCondition.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}

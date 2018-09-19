using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SANWA.Utility;
using TransferControl.Management;
using System.Threading;
using System.Collections;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Adam
{
    public partial class FormTerminal : Form
    {
        private DataTable dtDeviceList = new DataTable();
        private DataTable dtCommandType = new DataTable();
        private DataTable dtCommand = new DataTable();
        private DataTable dtCommandParameter = new DataTable();
        private DataTable dtCommandAssembly = new DataTable();
        private Thread trRun;

        private List<TerminalJob> Jobs = new List<TerminalJob>();

        string strSql = string.Empty;
        bool JobLock = true;
        bool JobStart = true;

        public FormTerminal()
        {
            InitializeComponent();
        }

        private void FormTerminal_Load(object sender, EventArgs e)
        {
            DBUtil dBUtil = new DBUtil();

            try
            {
                strSql = "SELECT CONCAT(node_id, ',', conn_address) as node_id , node_type, sn_no, CONCAT(vendor, ',' ,node_type, ',', controller_id) as vendor, model_no, firmware_ver, conn_address, controller_id " +
                            "FROM config_node " +
                            "WHERE enable_flg = '1' AND node_type IN('ALIGNER', 'LOADPORT', 'ROBOT', 'OCR') " +
                            "AND equipment_model_id = '" + SANWA.Utility.Config.SystemConfig.Get().SystemMode + "'" +
                            "ORDER BY node_id, sn_no";

                dtDeviceList = dBUtil.GetDataTable(strSql, null);

                if (dtDeviceList.Rows.Count == 0)
                {
                    MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    this.Close();
                }
                else
                {
                    lsbDeviceName.DataSource = dtDeviceList;
                    lsbDeviceName.DisplayMember = "node_id";
                    lsbDeviceName.ValueMember = "vendor";
                    lsbDeviceName.SelectedIndex = -1;
                }

                dtCommandAssembly.Columns.Add("No");
                dtCommandAssembly.Columns.Add("Device_Name");
                dtCommandAssembly.Columns.Add("Controller_ID");
                dtCommandAssembly.Columns.Add("Vendor");
                dtCommandAssembly.Columns.Add("CommandShow");
                dtCommandAssembly.Columns.Add("Command");

                dgvCommandList.AutoGenerateColumns = false;
                dgvCommandList.DataSource = dtCommandAssembly;

                trRun = new Thread(CommandRun);
                trRun.IsBackground = true;

                trRun.Start();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void lsbDeviceName_Click(object sender, EventArgs e)
        {
            tlpAssemblyUI.Controls.Clear();
            txbManually.Text = string.Empty;

            if (lsbDeviceName.SelectedIndex < 0)
            {
                lsbCommandType.DataSource = null;
                lsbCommand.DataSource = null;
                txbNotice.Text = string.Empty;
                return;
            }

            lsbCommand.DataSource = null;
            txbNotice.Text = string.Empty;

            Dictionary<string, object> keyValues = new Dictionary<string, object>();
            DBUtil dBUtil = new DBUtil();

            try
            {
                if (dtCommandType == null)
                    dtCommandType = new DataTable();

                strSql = "SELECT DISTINCT code_type " +
                            "FROM device_code_params " +
                            "WHERE node_type = @node_type " +
                            "AND vendor = @vendor " +
                            "ORDER BY code_type, code_order, Parameters_Amount";

                keyValues.Add("@node_type", lsbDeviceName.SelectedValue.ToString().Split(',')[1].ToString());
                keyValues.Add("@vendor", lsbDeviceName.SelectedValue.ToString().Split(',')[0].ToString());

                dtCommandType = dBUtil.GetDataTable(strSql, keyValues);

                if (dtCommandType.Rows.Count == 0)
                    throw new DataException();
                else
                {
                    lsbCommandType.DataSource = dtCommandType;
                    lsbCommandType.DisplayMember = "code_type";
                    lsbCommandType.ValueMember = "code_type";
                    lsbCommandType.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void lsbCommandType_Click(object sender, EventArgs e)
        {
            tlpAssemblyUI.Controls.Clear();
            txbManually.Text = string.Empty;

            if (lsbCommandType.SelectedIndex < 0)
            {
                lsbCommand.DataSource = null;
                txbNotice.Text = string.Empty;
                return;
            }

            Dictionary<string, object> keyValues = new Dictionary<string, object>();
            DBUtil dBUtil = new DBUtil();

            try
            {
                if (dtCommand == null)
                    dtCommand = new DataTable();

                strSql = "SELECT DISTINCT code_id, code_name " +
                            "FROM device_code_params " +
                            "WHERE node_type = @node_type " +
                            "AND vendor = @vendor " +
                            "AND code_type = @code_type " +
                            "ORDER BY code_type, code_order, Parameters_Amount";

                keyValues.Add("@node_type", lsbDeviceName.SelectedValue.ToString().Split(',')[1].ToString());
                keyValues.Add("@vendor", lsbDeviceName.SelectedValue.ToString().Split(',')[0].ToString());
                keyValues.Add("@code_type", lsbCommandType.SelectedValue.ToString());

                dtCommand = dBUtil.GetDataTable(strSql, keyValues);

                if (dtCommand.Rows.Count == 0)
                    throw new DataException();
                else
                {
                    lsbCommand.DataSource = dtCommand;
                    lsbCommand.DisplayMember = "code_id";
                    lsbCommand.ValueMember = "code_name";
                    lsbCommand.SelectedIndex = -1;
                    txbNotice.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void lsbCommand_Click(object sender, EventArgs e)
        {
            if (lsbCommand.SelectedIndex < 0)
            {
                txbNotice.Text = string.Empty;
                return;
            }

            Dictionary<string, object> keyValues = new Dictionary<string, object>();
            DBUtil dBUtil = new DBUtil();

            try
            {
                txbNotice.Text = lsbCommand.SelectedValue.ToString();

                if (dtCommandParameter == null)
                    dtCommandParameter = new DataTable();

                strSql = "SELECT * , CONCAT(node_type, '_', vendor, '_', code_type, '_', code_id, '_', Parameter_Order) as UI_Name " +
                            "FROM device_code_params " +
                            "WHERE node_type = @node_type " +
                            "AND vendor = @vendor " +
                            "AND code_type = @code_type " +
                            "AND code_id = @code_id " +
                            "ORDER BY code_type, code_order, Parameters_Amount";

                keyValues.Add("@node_type", lsbDeviceName.SelectedValue.ToString().Split(',')[1].ToString());
                keyValues.Add("@vendor", lsbDeviceName.SelectedValue.ToString().Split(',')[0].ToString());
                keyValues.Add("@code_type", lsbCommandType.SelectedValue.ToString());
                keyValues.Add("@code_id", lsbCommand.Text);

                dtCommandParameter = dBUtil.GetDataTable(strSql, keyValues);

                if (dtCommandParameter.Rows.Count == 0)
                    throw new DataException();
                else
                {
                    CreateUI();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void CreateUI()
        {
            tlpAssemblyUI.Controls.Clear();
            txbManually.Text = string.Empty;

            if (dtCommandParameter.Rows.Count == 0)
                return;

            tlpAssemblyUI.Controls.Clear();
            txbManually.Text = string.Empty;
            Label lbTemp;
            ComboBox cmbTemp;
            NumericUpDown nudTemp;
            string[] strsTemp;
            string[] strsTemps;
            StringBuilder sbTemp;
            ContainerSet container = new ContainerSet();
            string strCommandFormatParameter = string.Empty;
            ToolTip toolTip = new ToolTip();

            try
            {
                sbTemp = new StringBuilder();

                foreach (DataRow dr in dtCommandParameter.Rows)
                {
                    if (dr["Parameter_ID"].ToString().Equals("Null"))
                    {
                        break;
                    }

                    lbTemp = new Label();
                    lbTemp.Name = dr["UI_Name"].ToString();
                    lbTemp.Dock = DockStyle.Fill;
                    lbTemp.Text = dr["Parameter_ID"].ToString();
                    lbTemp.TextAlign = ContentAlignment.MiddleRight;

                    toolTip.SetToolTip(lbTemp, dr["Parameter_Description"].ToString());
                    tlpAssemblyUI.Controls.Add(lbTemp);

                    if (dr["Data_Value"].ToString().Equals(string.Empty))
                    {
                        nudTemp = new NumericUpDown();
                        nudTemp.Maximum = Convert.ToInt32(dr["Max_Value"].ToString());
                        nudTemp.Minimum = Convert.ToInt32(dr["Min_Value"].ToString());
                        nudTemp.Value = Convert.ToInt32(dr["Default_Value"].ToString());
                        nudTemp.Dock = DockStyle.Fill;

                        if (Convert.ToInt32(dr["Values_length"].ToString()) > 1 && dr["Is_Fill"].ToString() == "Y")
                        {
                            sbTemp.Append(Convert.ToInt32(dr["Default_Value"].ToString()).ToString("D" + Convert.ToInt32(dr["Values_length"].ToString()).ToString()));
                            sbTemp.Append(",");
                            nudTemp.Tag = Convert.ToInt32(dr["Values_length"].ToString());
                        }
                        else
                        {
                            sbTemp.Append(dr["Default_Value"].ToString());
                            sbTemp.Append(",");
                        }

                        nudTemp.ValueChanged += new EventHandler(numericUpDown_ValueChanged);
                        toolTip.SetToolTip(nudTemp, dr["Parameter_Description"].ToString());
                        tlpAssemblyUI.Controls.Add(nudTemp);
                    }
                    else
                    {
                        strsTemp = dr["Data_Value"].ToString().Split(',');
                        cmbTemp = new ComboBox();
                        cmbTemp.Items.AddRange(strsTemp);
                        cmbTemp.Dock = DockStyle.Fill;
                        cmbTemp.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        cmbTemp.AutoCompleteSource = AutoCompleteSource.ListItems;
                        cmbTemp.SelectedIndex = 0;
                        sbTemp.Append(cmbTemp.Text.ToUpper().Equals("EMPTY") ? string.Empty : cmbTemp.Text);
                        sbTemp.Append(",");
                        cmbTemp.SelectedIndexChanged += new EventHandler(comboBox_DropDownClosed);
                        toolTip.SetToolTip(cmbTemp, dr["Parameter_Description"].ToString());
                        tlpAssemblyUI.Controls.Add(cmbTemp);

                    }
                }

                if (tlpAssemblyUI.Controls.Count == 0)
                {
                    switch (lsbDeviceName.SelectedValue.ToString().Split(',')[0].ToString())
                    {
                        case "SANWA":
                            txbManually.Text = string.Format(dtCommandParameter.Rows[0]["code_format"].ToString(), lsbDeviceName.Text.Split(',')[1].ToString(), string.Empty);
                            break;

                        case "TDK":
                            txbManually.Text = dtCommandParameter.Rows[0]["code_format"].ToString();
                            break;

                        case "ATEL":
                            txbManually.Text = string.Format(dtCommandParameter.Rows[0]["code_format"].ToString(), lsbDeviceName.Text.Split(',')[1].ToString());
                            break;

                        case "HST":
                        case "COGNEX":
                            txbManually.Text = dtCommandParameter.Rows[0]["code_format"].ToString();
                            break;
                    }
                }
                else
                {
                    switch (lsbDeviceName.SelectedValue.ToString().Split(',')[0].ToString())
                    {
                        case "SANWA":
                            txbManually.Text = string.Format(dtCommandParameter.Rows[0]["code_format"].ToString(), lsbDeviceName.Text.Split(',')[1].ToString(), string.Empty) + container.StringFormat(dtCommandParameter.Select(), sbTemp.ToString().TrimEnd(',').Split(','));
                            break;

                        case "TDK":
                            txbManually.Text = dtCommandParameter.Rows[0]["code_format"].ToString();
                            break;

                        case "ATEL":
                            strsTemps = (lsbDeviceName.Text.Split(',')[1].ToString() + "," + sbTemp.ToString().Substring(0, sbTemp.ToString().Length - 1)).Split(',');
                            txbManually.Text = string.Format(dtCommandParameter.Rows[0]["code_format"].ToString(), strsTemps);
                            break;

                        case "HST":
                        case "COGNEX":
                            txbManually.Text = string.Format(dtCommandParameter.Rows[0]["code_format"].ToString(), sbTemp.ToString().Substring(0, sbTemp.ToString().Length - 1).Split(','));
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void comboBox_DropDownClosed(object sender, EventArgs e)
        {
            FormulaCalculation();
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            FormulaCalculation();
        }

        private void FormulaCalculation()
        {
            string[] strsTemps;
            StringBuilder sbTemp;
            ContainerSet container = new ContainerSet();

            try
            {
                sbTemp = new StringBuilder();
                foreach (var item in tlpAssemblyUI.Controls)
                {
                    switch (item.GetType().FullName.Split('.')[item.GetType().FullName.Split('.').Length - 1].ToString())
                    {
                        case "ComboBox":
                            sbTemp.Append(((ComboBox)item).Text.ToUpper().Equals("EMPTY") ? string.Empty : ((ComboBox)item).Text);
                            sbTemp.Append(",");
                            break;

                        case "NumericUpDown":
                            if (((NumericUpDown)item).Tag == null)
                            {
                                sbTemp.Append(((NumericUpDown)item).Value.ToString());
                            }
                            else
                            {
                                sbTemp.Append(Convert.ToInt32(((NumericUpDown)item).Value).ToString("D" + ((NumericUpDown)item).Tag.ToString()));
                            }

                            sbTemp.Append(",");
                            break;
                    }
                }

                switch (lsbDeviceName.SelectedValue.ToString().Split(',')[0].ToString())
                {
                    case "SANWA":
                        txbManually.Text = string.Format(dtCommandParameter.Rows[0]["code_format"].ToString(), lsbDeviceName.Text.Split(',')[1].ToString(), string.Empty) + container.StringFormat(dtCommandParameter.Select(), sbTemp.ToString().TrimEnd(',').Split(','));
                        break;

                    case "ATEL":
                        strsTemps = (lsbDeviceName.Text.Split(',')[1].ToString() + "," + sbTemp.ToString().Substring(0, sbTemp.ToString().Length - 1)).Split(',');
                        txbManually.Text = string.Format(dtCommandParameter.Rows[0]["code_format"].ToString(), strsTemps);
                        break;

                    case "HST":
                    case "COGNEX":
                        txbManually.Text = string.Format(dtCommandParameter.Rows[0]["code_format"].ToString(), sbTemp.ToString().Substring(0, sbTemp.ToString().Length - 1).Split(','));
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txbManually.Text.Equals(string.Empty))
                return;

            string strDevice = string.Empty;
            SANWA.Utility.Encoder encoder;
            TerminalJob job = null;
            ArrayList alList = null;
            ArrayList alDeviceList = null;

            try
            {
                encoder = new SANWA.Utility.Encoder(lsbDeviceName.SelectedValue.ToString().Split(',')[0].ToString());

                job = new TerminalJob();
                alList = new ArrayList();
                alDeviceList = new ArrayList();
                alDeviceList.Add(lsbDeviceName.SelectedValue.ToString().Split(',')[2].ToString());

                switch (lsbDeviceName.SelectedValue.ToString().Split(',')[0].ToString())
                {
                    case "ATEL":
                    case "SANWA":

                        job.Active = true;
                        job.Device = alDeviceList;
                        job.IsError = new ArrayList();
                        job.Message = new ArrayList();
                        job.No = Jobs.Count + 1;
                        alList.Add(txbManually.Text + "\r");
                        job.List = alList;
                        Jobs.Add(job);
                        JobLock = false;

                        break;

                    case "KAWASAKI":

                        job.Active = true;
                        job.Device = alDeviceList;
                        job.IsError = new ArrayList();
                        job.Message = new ArrayList();
                        job.No = Jobs.Count + 1;
                        alList.Add(txbManually.Text + encoder.Robot.KawasakiCheckSum(txbManually.Text.Substring(1, txbManually.Text.IndexOf('>') + 1)) + "\r\n");
                        job.List = alList;
                        Jobs.Add(job);
                        JobLock = false;

                        break;

                    case "TDK":

                        job.Active = true;
                        job.Device = alDeviceList;
                        job.IsError = new ArrayList();
                        job.Message = new ArrayList();
                        job.No = Jobs.Count + 1;
                        alList.Add(encoder.LoadPort.TDK_A(txbManually.Text));
                        job.List = alList;
                        Jobs.Add(job);
                        JobLock = false;

                        break;

                    default:

                        job.Active = true;
                        job.Device = alDeviceList;
                        job.IsError = new ArrayList();
                        job.Message = new ArrayList();
                        job.No = Jobs.Count + 1;
                        alList.Add(txbManually.Text + "\r");
                        job.List = alList;
                        Jobs.Add(job);
                        JobLock = false;

                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                btnSend.Enabled = true;
            }
        }

        private void btnClearHistory_Click(object sender, EventArgs e)
        {
            Adam.UI_Update.Terminal.TerminalUpdate.UpdateReturnList("lsbHistory", string.Empty, true);
        }

        private void btnAppendlist_Click(object sender, EventArgs e)
        {
            if (txbManually.Text.Equals(string.Empty))
                return;

            DataRow drTemp;
            string strDevice = string.Empty;
            SANWA.Utility.Encoder encoder;

            try
            {
                encoder = new SANWA.Utility.Encoder(lsbDeviceName.SelectedValue.ToString().Split(',')[0].ToString());

                strDevice = lsbDeviceName.Text.ToUpper().Split(',')[0].ToString();
                drTemp = dtCommandAssembly.NewRow();
                drTemp["No"] = (dtCommandAssembly.Rows.Count + 1).ToString("D2"); ;
                drTemp["Device_Name"] = lsbDeviceName.Text.Split(',')[0].ToString();
                drTemp["Vendor"] = lsbDeviceName.SelectedValue.ToString();
                drTemp["CommandShow"] = txbManually.Text;
                drTemp["Controller_ID"] = lsbDeviceName.SelectedValue.ToString().Split(',')[2].ToString();

                switch (lsbDeviceName.SelectedValue.ToString().Split(',')[0].ToString())
                {
                    case "SANWA":
                    case "ATEL":

                        drTemp["Command"] = txbManually.Text + "\r";

                        break;

                    case "KAWASAKI":

                        drTemp["Command"] = txbManually.Text + encoder.Robot.KawasakiCheckSum(txbManually.Text.Substring(1, txbManually.Text.IndexOf('>') + 1));

                        break;

                    case "TDK":

                        drTemp["Command"] = encoder.LoadPort.TDK_A(txbManually.Text);
                         
                        break;
                }

                dtCommandAssembly.Rows.Add(drTemp);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dtCommandAssembly.Rows.Count > 0)
            {
                if (MessageBox.Show("Whether remove the list??", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    dtCommandAssembly.Clear();
                }
            }
        }

        private void CommandListReNo()
        {
            try
            {
                for (int i = 0; i < dtCommandAssembly.Rows.Count; i++)
                {
                    dtCommandAssembly.Rows[i]["No"] = (i + 1).ToString("D2");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void btnUP_Click(object sender, EventArgs e)
        {
            if (dgvCommandList.SelectedCells.Count == 0)
                return;

            ContainerSet containerSet;
            DataRowView currentDataRowView;

            int ii = 0;

            try
            {
                containerSet = new ContainerSet();

                ii = dgvCommandList.SelectedCells[0].OwningRow.Index;

                currentDataRowView = (DataRowView)dgvCommandList.Rows[ii].DataBoundItem;

                switch (((Button)sender).Tag.ToString())
                {
                    case "Down":
                        containerSet.MoveRow(ref dtCommandAssembly, currentDataRowView.Row, ContainerSet.DataTableMoveRow.Down);

                        dgvCommandList.ClearSelection();

                        if (ii + 1 < dgvCommandList.Rows.Count)
                        {
                            dgvCommandList.Rows[ii+1].Selected = true;
                        }
                        else
                        {
                            dgvCommandList.Rows[ii].Selected = true;
                        }
                        break;

                    case "UP":
                        containerSet.MoveRow(ref dtCommandAssembly, currentDataRowView.Row, ContainerSet.DataTableMoveRow.Up);

                        dgvCommandList.ClearSelection();

                        if (ii - 1 >= 0)
                        {
                            dgvCommandList.Rows[ii - 1].Selected = true;
                        }
                        else
                        {
                            dgvCommandList.Rows[ii].Selected = true;
                        }
                        break;
                }

                CommandListReNo();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int ii = 0;

            try
            {
                if (dgvCommandList.SelectedCells.Count > 0)
                {
                    ii = dgvCommandList.SelectedCells[0].OwningRow.Index;

                    if (ii >= 0)
                    {
                        dtCommandAssembly.Rows.RemoveAt(ii);
                        CommandListReNo();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void CommandRun()
        {
            try
            {
                while (JobStart)
                {
                    if (Jobs.Count > 0 && !JobLock)
                    {
                        Adam.UI_Update.Terminal.TerminalUpdate.UpdateButtonEnable("btnSend", false);
                        Adam.UI_Update.Terminal.TerminalUpdate.UpdateSplitButtonEnable("sbtnRun", false);
                                                     
                        foreach (TerminalJob item in Jobs)
                        {
                            if (item.Active)
                            {
                                Adam.UI_Update.Terminal.TerminalUpdate.UpdateLabelText("lbQueue", "Queue:" + (Jobs.Count - (int)item.No).ToString());

                                for (int i = 0; i < ((ArrayList)item.List).Count; i++)
                                {
                                    Adam.UI_Update.Terminal.TerminalUpdate.UpdateReturnList("lsbHistory", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ffffff") + "    " + ((ArrayList)item.Device)[i].ToString() + " <<  " + ((ArrayList)item.List)[i].ToString(), false);

                                    // * 回傳訊息處理 待處理
                                    ((ArrayList)item.Message).Add(ControllerManagement.Get(((ArrayList)item.Device)[i].ToString()).DoWorkSync(((ArrayList)item.List)[i].ToString(), ((ArrayList)item.List)[i].ToString().IndexOf("CMD") > 0 ? "CMD" : string.Empty));

                                    if (((ArrayList)item.Message)[i].ToString().IndexOf("FIN") > 0 || ((ArrayList)item.Message)[i].ToString().IndexOf("NAK") > 0)
                                    {
                                        if (!((ArrayList)item.Message)[i].ToString().Split(':')[2].ToString().Equals("00000000") || ((ArrayList)item.Message)[i].ToString().Equals("Command time out!"))
                                        {
                                            item.Active = false;
                                            btnStop_Click(this, null);
                                            Adam.UI_Update.Terminal.TerminalUpdate.UpdateReturnList("lsbHistory", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ffffff") + "    " + ((ArrayList)item.Device)[i].ToString() + " >>  " + ((ArrayList)item.Message)[i].ToString(), false);
                                            break;
                                        }
                                    }
                                    //((ArrayList)item.Message).Add("TEST");
                                    //Thread.Sleep(1000);
                                    Adam.UI_Update.Terminal.TerminalUpdate.UpdateReturnList("lsbHistory", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ffffff") + "    " + ((ArrayList)item.Device)[i].ToString() + " >>  " + ((ArrayList)item.Message)[i].ToString(), false);

                                    if (!item.Active)
                                    {
                                        break;
                                    }
                                }

                                item.Active = false;
                            }
                        }

                        for (int i = 0; i < Jobs.Count; i++)
                        {
                            if (!Jobs[i].Active)
                                Jobs.Remove(Jobs[i]);
                        }
                    }
                    else if (!JobLock)
                    {
                        Adam.UI_Update.Terminal.TerminalUpdate.UpdateLabelText("lbQueue", "Queue:" + Jobs.Count);
                        JobLock = true;
                        Adam.UI_Update.Terminal.TerminalUpdate.UpdateButtonEnable("btnSend", true);
                        Adam.UI_Update.Terminal.TerminalUpdate.UpdateSplitButtonEnable("sbtnRun", true);
                    }

                    if (!JobStart)
                        break;
                }
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.ToString());
            }
        }

        private void tsmtRunList_Click(object sender, EventArgs e)
        {
            if (dtCommandAssembly.Rows.Count == 0)
                return;

            TerminalJob job = null;
            ArrayList alList = null;
            ArrayList alDeviceList = null;

            try
            {
                job = new TerminalJob();
                alList = new ArrayList();
                alDeviceList = new ArrayList();
                job.Active = true;
                job.IsError = new ArrayList();
                job.Message = new ArrayList();
                job.No = Jobs.Count + 1;

                foreach (DataRow dr in dtCommandAssembly.Rows)
                {
                    alDeviceList.Add(dr["Controller_ID"].ToString());
                    alList.Add(dr["Command"].ToString());
                }

                job.Device = alDeviceList;
                job.List = alList;
                Jobs.Add(job);
                JobLock = false;

                MessageBox.Show("Send to queue.", "tsmtRunList_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void tsmtExcute_Click(object sender, EventArgs e)
        {
            if (dtCommandAssembly.Rows.Count == 0)
                return;

            int resultInt = 0;
            int startInt = 0;
            TerminalJob job = null;
            ArrayList alList = null;
            ArrayList alDeviceList = null;

            try
            {
                if(Int32.TryParse(tstbfrequency.Text, out resultInt))
                {
                    job = new TerminalJob();
                    alList = new ArrayList();
                    alDeviceList = new ArrayList();
                    job.Active = true;
                    job.IsError = new ArrayList();
                    job.Message = new ArrayList();

                    foreach (DataRow dr in dtCommandAssembly.Rows)
                    {
                        alDeviceList.Add(dr["Controller_ID"].ToString());
                        alList.Add(dr["Command"].ToString() + "\r");
                    }

                    job.List = alList;
                    job.Device = alDeviceList;

                    startInt = Jobs.Count;

                    for (int i = 1; i < resultInt + 1; i++)
                    {
                        job.No = i + startInt;
                        Jobs.Add(job.Copy());
                    }
                    JobLock = false;
                }

                MessageBox.Show("Send to queue.", "tsmtExcute_Click");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void tsmtRunStep_Click(object sender, EventArgs e)
        {
            int ii = 0;

            TerminalJob job = null;
            ArrayList alList = null;
            ArrayList alDeviceList = null;
            SANWA.Utility.Encoder encoder;

            try
            {
                if (dgvCommandList.SelectedCells.Count > 0)
                {
                    ii = dgvCommandList.SelectedCells[0].OwningRow.Index;

                    if (ii >= 0)
                    {
                        dgvCommandList.ClearSelection();
                        encoder = new SANWA.Utility.Encoder(dtCommandAssembly.Rows[ii]["vendor"].ToString().Split(',')[0].ToString());

                        job = new TerminalJob();
                        alList = new ArrayList();
                        alDeviceList = new ArrayList();
                        job.Active = true;
                        alDeviceList.Add(dtCommandAssembly.Rows[ii]["Controller_ID"].ToString());
                        job.Device = alDeviceList;
                        job.IsError = new ArrayList();
                        job.Message = new ArrayList();
                        job.No = Jobs.Count + 1;
                        alList.Add(dtCommandAssembly.Rows[ii]["Command"].ToString());
                        job.List = alList;
                        Jobs.Add(job);
                        JobLock = false;

                        if (ii + 1 < dgvCommandList.Rows.Count)
                        {
                            dgvCommandList.Rows[ii + 1].Selected = true;
                        }
                        else
                        {
                            dgvCommandList.Rows[ii].Selected = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvCommandList.Rows.Count == 0)
            {
                return;
            }

            SaveFileDialog saveFileDialog1;
            StreamWriter sw;

            try
            { 
                saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Title = "Save file";
                saveFileDialog1.InitialDirectory = ".\\";
                saveFileDialog1.Filter = "json files (*.json)|*.json";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    sw = new StreamWriter(saveFileDialog1.FileName.ToString());

                    sw.WriteLine(JsonConvert.SerializeObject(dtCommandAssembly, Formatting.Indented));

                    sw.Close();

                    MessageBox.Show("Done it.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception Message", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1;
            StreamReader myStream = null;

            try
            {
                openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "json files (*.json)|*.json";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string line = string.Empty;

                    using (myStream = new StreamReader(openFileDialog1.FileName))
                    {
                        line = myStream.ReadToEnd();
                    }

                    dtCommandAssembly = (DataTable)Newtonsoft.Json.JsonConvert.DeserializeObject(line, (typeof(DataTable)));
                    dgvCommandList.DataSource = dtCommandAssembly;

                    MessageBox.Show("Done it.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception Message", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (TerminalJob item in Jobs)
                {
                    item.Active = false;
                }

                Adam.UI_Update.Terminal.TerminalUpdate.UpdateLabelText("lbQueue", "Queue:0");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public class TerminalJob
        {
            public int No { get; set; }
            public ArrayList Device { get; set; }
            public ArrayList List { get; set; }
            public ArrayList Message { get; set; }
            public ArrayList IsError { get; set; }
            public bool Active { get; set; }

            public TerminalJob Copy()
            {
                TerminalJob jobNew = new TerminalJob();

                jobNew.Active = this.Active;
                jobNew.Device = this.Device;
                jobNew.IsError = this.IsError;
                jobNew.List = this.List;
                jobNew.Message = this.Message;
                jobNew.No = this.No;

                return jobNew;
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            JobLock = true;
            JobStart = false;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            JobLock = false;
        }

        private void FormTerminal_FormClosed(object sender, FormClosedEventArgs e)
        {
            trRun.Abort();
            JobStart = false;
            JobLock = true;
            Jobs.Clear();
            Jobs = null;
        }
    }
}
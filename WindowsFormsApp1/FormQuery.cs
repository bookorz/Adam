using log4net;
using MySql.Data.MySqlClient;
using NPOI;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using SANWA.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    
    public partial class FormQuery : Form
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(FormQuery));
        DataTable dataTable;
        string sqlScript = "";
        ToolTip toolTip1 = new ToolTip();
        ToolTip toolTip2 = new ToolTip();
        ToolTip toolTip3 = new ToolTip();

        public string getSqlContent(string scriptName)
        {
            StringBuilder sql = new StringBuilder();
            string[] lines = System.IO.File.ReadAllLines(@".\sql\" + scriptName + ".sql");
            foreach (string line in lines)
            {
                sql.Append(line);
            }

            return sql.ToString();
        }

        public FormQuery()
        {
            InitializeComponent();
            gdvData.MakeDoubleBuffered(true);
        }

        private DataTable dtCondition = new DataTable();

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DBUtil dBUtil = new DBUtil();

                //set parameter
                Dictionary<string, object> param = new Dictionary<string, object>();
                DateTime fromDt = this.dtpFromDate.Value;
                DateTime toDt = this.dtpToDate.Value;

                string cond_1 = txbCondition1.Text.Equals("") ? "%" : txbCondition1.Text;
                string cond_2 = txbCondition2.Text.Equals("") ? "%" : txbCondition2.Text;
                string cond_3 = txbCondition3.Text.Equals("") ? "%" : txbCondition3.Text;
                param.Add("@from_dt", fromDt.ToString("yyyy-MM-dd 00:00:00.000000"));
                param.Add("@to_dt", toDt.ToString("yyyy-MM-dd 23:59:59.999999"));
                param.Add("@cond_1", cond_1);
                param.Add("@cond_2", cond_2);
                param.Add("@cond_3", cond_3);
                param.Add("@limit", Int32.Parse(cbLimitCnt.Text));

                dataTable = dBUtil.GetDataTable(getSqlContent(sqlScript), param);
                gdvData.DataSource = dataTable;
                btnExport.Enabled = true;
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
                MessageBox.Show(ex.StackTrace, "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }            
        }

        private void DataTableToExcelFile(DataTable dt)
        {
            try
            {
                //建立Excel 2003檔案
                HSSFWorkbook wb = new HSSFWorkbook();
                Sheet ws;

                ////建立Excel 2007檔案
                //IWorkbook wb = new XSSFWorkbook();
                //ISheet ws;

                if (dt.TableName != string.Empty)
                {
                    ws = wb.CreateSheet(dt.TableName);
                }
                else
                {
                    ws = wb.CreateSheet("Sheet1");
                }

                ws.CreateRow(0);//第一行為欄位名稱
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    ws.GetRow(0).CreateCell(i).SetCellValue(dt.Columns[i].ColumnName);
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ws.CreateRow(i + 1);
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        ws.GetRow(i + 1).CreateCell(j).SetCellValue(dt.Rows[i][j].ToString());
                    }
                }

                string dirPath = @"d:\sanwa\export\";
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                string fileName = cbQueryType.Text + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_result.xls";
                FileStream file = new FileStream(dirPath + fileName, FileMode.Create);//產生檔案
                wb.Write(file);
                file.Close();

                Process.Start(dirPath + fileName);
                //OpenFileDialog dialog = new OpenFileDialog();
                //dialog.Title = "Open file";
                //dialog.InitialDirectory = "D:\\";
                //dialog.Filter = "xls files (*.*)|*.xls*";
                //if (dialog.ShowDialog() == DialogResult.OK)
                //{
                //    MessageBox.Show(dialog.FileName);
                //}
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
                MessageBox.Show(ex.StackTrace, "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        public void DataTableToCsvFile(DataTable dt)
        {
            try
            {
                string fileName = cbQueryType.Text + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_result.csv";
                string fullPath = @"d:\sanwa\export\" + fileName;
                FileInfo fi = new FileInfo(fullPath);
                if (!fi.Directory.Exists)
                {
                    fi.Directory.Create();
                }
                FileStream fs = new FileStream(fullPath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                //StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
                StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
                string data = "";
                //寫出列名稱
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    data += "\"" + dt.Columns[i].ColumnName.ToString() + "\"";
                    if (i < dt.Columns.Count - 1)
                    {
                        data += ",";
                    }
                }
                sw.WriteLine(data);
                //寫出各行數據
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data = "";
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        string str = dt.Rows[i][j].ToString();
                        str = string.Format("\"{0}\"", str).Replace("\r", "\\r").Replace("\n", "\\n");
                        data += str;
                        if (j < dt.Columns.Count - 1)
                        {
                            data += ",";
                        }
                    }
                    sw.WriteLine(data);
                }
                sw.Close();
                fs.Close();
                Process.Start(fullPath);
            }
            catch(Exception ex)
            {
                logger.Error(ex.StackTrace);
                MessageBox.Show(ex.StackTrace, "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if(rdbExcel.Checked)
                DataTableToExcelFile(dataTable);
            if (rdbCsv.Checked)
                DataTableToCsvFile(dataTable);
        }

        private void FormQuery_Load(object sender, EventArgs e)
        {
            try
            {
                ClearUI();
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
                MessageBox.Show(ex.StackTrace, "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void ClearUI()
        {
            cbQueryType.Text = string.Empty;
            dtpFromDate.Value = DateTime.Now.AddDays(-1);
            dtpToDate.Value = DateTime.Now;

            txbCondition1.Text = string.Empty;
            txbCondition2.Text = string.Empty;
            txbCondition3.Text = string.Empty;

            btnExport.Enabled = false;
            btnQuery.Enabled = false;
            this.labCondition1.Visible = false;
            this.labCondition2.Visible = false;
            this.labCondition3.Visible = false;
            this.txbCondition1.Visible = false;
            this.txbCondition2.Visible = false;
            this.txbCondition3.Visible = false;

            gdvData.DataSource = null;
            cbLimitCnt.SelectedItem = "1000";
        }
        
        private void setToolTip(ToolTip toolTip, Control control, string tip)
        {
            toolTip.SetToolTip(control, tip);
            //以下為提示視窗的設定(通常會設定的部分)
            //停滯多久顯示 Hint
            toolTip.AutomaticDelay = 100;
            //ToolTipIcon：設定顯示在提示視窗的圖示類型。
            toolTip.ToolTipIcon = ToolTipIcon.Info;
            //ForeColor：顧名思義就是前景顏色，你懂的!!XD
            toolTip.ForeColor = Color.Blue;
            //BackColor：顧名思義就是背景顏色，你也懂的!!XD
            toolTip.BackColor = Color.Gray;
            //AutoPopDelay：當游標停滯在控制項，顯示提示視窗的時間。(以毫秒為單位)
            toolTip.AutoPopDelay = 10000;
            //ToolTipTitle：設定提示視窗的標題。
            toolTip.ToolTipTitle = "Hint";
        }

        private void cbQueryType_SelectedValueChanged(object sender, EventArgs e)
        {
            //init
            ClearUI();
            switch (cbQueryType.SelectedItem)
            {
                case "Alarm Log":
                    sqlScript = "Alarm Log";
                    //this.labCondition1.Text = "User ID";
                    //setToolTip(toolTip1, txbCondition1, "Logged user id.");
                    //this.labCondition1.Visible = true;
                    //this.txbCondition1.Visible = true;
                    btnQuery.Enabled = true;
                    break;
                case "Process Job Log":
                    sqlScript = "Process Job Log";
                    this.labCondition1.Text = "Foup ID";
                    setToolTip(toolTip1, txbCondition1, "Foup id.");
                    this.labCondition1.Visible = true;
                    this.txbCondition1.Visible = true;
                    btnQuery.Enabled = true;
                    break;
                case "Process Wafer Log":
                    sqlScript = "Process Wafer Log";
                    this.labCondition1.Text = "Wafer ID";
                    setToolTip(toolTip1, txbCondition1, "Wafer ID");
                    this.labCondition2.Text = "From Foup ID";
                    setToolTip(toolTip2, txbCondition2, "Foup、SMIF、Cassette、Carrier ID");
                    this.labCondition3.Text = "To Foup ID";
                    setToolTip(toolTip3, txbCondition3, "Foup、SMIF、Cassette、Carrier ID");
                    this.labCondition1.Visible = true;
                    this.txbCondition1.Visible = true;
                    this.labCondition2.Visible = true;
                    this.txbCondition2.Visible = true;
                    this.labCondition3.Visible = true;
                    this.txbCondition3.Visible = true;
                    btnQuery.Enabled = true;
                    break;
                case "User Action Log":
                    sqlScript = "User Action Log";
                    this.labCondition1.Text = "User ID";
                    setToolTip(toolTip1,txbCondition1, "Logged user id.");
                    this.labCondition1.Visible = true;
                    this.txbCondition1.Visible = true;
                    btnQuery.Enabled = true;
                    break;
                case "Command Log":
                    sqlScript = "Command Log";
                    this.labCondition1.Text = "Device Type";
                    setToolTip(toolTip1, txbCondition1, "LoadPort,Robot,Aligner.");
                    this.labCondition2.Text = "Device Name";
                    setToolTip(toolTip2, txbCondition2, "LoadPort01~08,Robot01~02,Aligner01~02.");
                    this.labCondition1.Visible = true;
                    this.txbCondition1.Visible = true;
                    this.labCondition2.Visible = true;
                    this.txbCondition2.Visible = true;
                    btnQuery.Enabled = true;
                    break;
                case "DIO Change Log":
                    sqlScript = "DIO Change Log";
                    btnQuery.Enabled = true;
                    break;
                default:
                    MessageBox.Show("不支援的報表查詢!", "Info",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Asterisk);
                    break;
            }
           
        }

    }
    public static class ControlExtentions
    {
        public static void MakeDoubleBuffered(this Control control, bool setting)
        {
            Type controlType = control.GetType();
            PropertyInfo pi = controlType.GetProperty("DoubleBuffered",
            BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(control, setting, null);
        }
    }
}

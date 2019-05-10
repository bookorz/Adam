using Adam.Util;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using TransferControl.Controller;
using TransferControl.Management;

namespace Adam.Menu.Status
{
    public partial class FormStatus : Adam.Menu.FormFrame
    {

        private static readonly ILog logger = LogManager.GetLogger(typeof(FormStatus));
        //private static System.Timers.Timer aTimer;
        private Boolean isRefresh = false;


        public FormStatus()
        {
            InitializeComponent();
            vSBRobotStatus.Maximum = pbRobotState.Height;
            vSBAlignerStatus.Maximum = pbAlignerState.Height;
            vSBPortStatus.Maximum = pbPortState.Height;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void vSBRobotStatus_Scroll(object sender, ScrollEventArgs e)
        {
            pbRobotState.Top = -vSBRobotStatus.Value;
        }

        private void vSBAlignerStatus_Scroll(object sender, ScrollEventArgs e)
        {
            pbAlignerState.Top = -vSBAlignerStatus.Value;
        }

        private void vSBPortStatus_Scroll(object sender, ScrollEventArgs e)
        {
            pbPortState.Top = -vSBPortStatus.Value;
        }

        private void FormStatus_Leave(object sender, EventArgs e)
        {
            isRefresh = false;
        }

        private void FormStatus_Enter(object sender, EventArgs e)
        {
            isRefresh = true;
            //Thread t = new Thread(OnTimedRefresh);
            //t.Start();
            OnTimedRefresh();
        }

        private void OnTimedRefresh()
        {
            //while (isRefresh)
            //{
            //this.Cursor = Cursors.WaitCursor;
            getStatus();
            setStatus();
            //this.Cursor = Cursors.Default;
            //Thread.Sleep(30000);//30 秒更新一次
            //}
        }


        public void setStatus()
        {
            try
            {
                //clear old data
                dgvRstatus.Rows.Clear();
                dgvAstatus.Rows.Clear();
                dgvLstatus.Rows.Clear();
                Thread.Sleep(1000);//避免查詢指令尚未回來
                foreach (Node each in NodeManagement.GetList())
                {
                    string ctrl_status = ControllerManagement.Get(each.Controller) != null ? ControllerManagement.Get(each.Controller).Status : "";
                    if (ctrl_status.Equals("Connected") && each.ByPass == false)
                    {
                        if (each.Brand.ToUpper().Equals("KAWASAKI"))
                        {
                        }
                        else
                        {
                        }
                        String state = "";
                        switch (each.Type)
                        {
                            case "ROBOT":
                                DataGridViewRow robotRow = (DataGridViewRow)dgvRstatus.Rows[0].Clone();
                                robotRow.Cells[0].Value = each.Name;
                                state = ((RobotState)StateUtil.device[each.Name]).State;
                                for (int i = 1; i <= state.Length; i++)
                                {
                                    string value = state.Substring(i - 1, 1);
                                    robotRow.Cells[i].Value = value;
                                    robotRow.Cells[i].Style.BackColor = getStatusColor(value);
                                }
                                dgvRstatus.Rows.Add(robotRow);
                                break;
                            case "ALIGNER":
                                DataGridViewRow alignerRow = (DataGridViewRow)dgvAstatus.Rows[0].Clone();
                                alignerRow.Cells[0].Value = each.Name;
                                state = ((AlignerState)StateUtil.device[each.Name]).State;
                                for (int i = 1; i <= state.Length; i++)
                                {
                                    string value = state.Substring(i - 1, 1);
                                    alignerRow.Cells[i].Value = value;
                                    alignerRow.Cells[i].Style.BackColor = getStatusColor(value);
                                }
                                dgvAstatus.Rows.Add(alignerRow);
                                break;
                            case "LOADPORT":
                                DataGridViewRow portRow = (DataGridViewRow)dgvLstatus.Rows[0].Clone();
                                portRow.Cells[0].Value = each.Name;
                                state = ((LoadPortState)StateUtil.device[each.Name]).State;
                                for (int i = 1; i <= state.Length; i++)
                                {
                                    string value = state.Substring(i - 1, 1);
                                    portRow.Cells[i].Value = value;
                                    portRow.Cells[i].Style.BackColor = getStatusColor(value);
                                }
                                dgvLstatus.Rows.Add(portRow);
                                break;
                        }
                    }
                    else
                    {
                        ////continue;
                        ////do nothing 以下為假資料
                        //string[] states = new String[] { "0", "1", "2", "3", "A", "E", "?" };
                        //string state;
                        //int idx = 0;
                        //switch (each.Type)
                        //{
                        //    case "Robot":
                        //        DataGridViewRow robotRow = (DataGridViewRow)dgvRstatus.Rows[0].Clone();
                        //        robotRow.Cells[0].Value = each.Name;
                        //        for (int i = 1; i <= 32; i++)
                        //        {
                        //            idx = new Random(i).Next() % 7;
                        //            state = states[idx];
                        //            string value = state;
                        //            robotRow.Cells[i].Value = value;
                        //            robotRow.Cells[i].Style.BackColor = getStatusColor(value);
                        //        }
                        //        dgvRstatus.Rows.Add(robotRow);
                        //        break;
                        //    case "Aligner":
                        //        DataGridViewRow alignerRow = (DataGridViewRow)dgvAstatus.Rows[0].Clone();
                        //        alignerRow.Cells[0].Value = each.Name;
                        //        for (int i = 1; i <= 32; i++)
                        //        {
                        //            idx = new Random(i).Next() % 7;
                        //            state = states[idx];
                        //            string value = state;
                        //            alignerRow.Cells[i].Value = value;
                        //            alignerRow.Cells[i].Style.BackColor = getStatusColor(value);
                        //        }
                        //        dgvAstatus.Rows.Add(alignerRow);
                        //        break;
                        //    case "LoadPort":
                        //        DataGridViewRow portRow = (DataGridViewRow)dgvLstatus.Rows[0].Clone();
                        //        portRow.Cells[0].Value = each.Name;
                        //        for (int i = 1; i <= 20; i++)
                        //        {
                        //            idx = new Random(i).Next() % 7;
                        //            state = states[idx];
                        //            string value = state;
                        //            portRow.Cells[i].Value = state;
                        //            portRow.Cells[i].Style.BackColor = getStatusColor(value);
                        //        }
                        //        dgvLstatus.Rows.Add(portRow);
                        //        break;
                        //}
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error(e.StackTrace);
            }

        }

        private Color getStatusColor(string value)
        {
            Color bgColor = Color.White;
            switch (value)
            {
                case "0":
                    bgColor = Color.White;
                    break;
                case "1":
                    bgColor = Color.LightBlue;
                    break;
                case "2":
                    bgColor = Color.LightGreen;
                    break;
                case "3":
                    bgColor = Color.LightCyan;
                    break;
                case "A":
                    bgColor = Color.LightYellow;
                    break;
                case "E":
                    bgColor = Color.LightPink;
                    break;
                case "?":
                    bgColor = Color.LightGray;
                    break;
            }
            return bgColor;
        }

        public void getStatus()
        {

            StateUtil.Init();
            foreach (Node each in NodeManagement.GetList())
            {
                try
                {
                    string Message = "";
                    DeviceController Ctrl = ControllerManagement.Get(each.Controller);
                    //string ctrl_status = ControllerManagement.Get(each.Controller).Status;
                    string ctrl_status = ControllerManagement.Get(each.Controller) != null ? ControllerManagement.Get(each.Controller).Status : "";
                    if (ctrl_status.Equals("Connected") && each.ByPass == false )
                    {
                        string seq = "";
                        Transaction txn = new Transaction();
                        if (each.Brand.ToUpper().Equals("KAWASAKI"))
                        {
                            seq = Ctrl.GetNextSeq();
                        }
                        else
                        {
                            seq = "";
                        }
                        switch (each.Type)
                        {
                            case "ROBOT":
                                txn.Method = Transaction.Command.RobotType.GetStatus;
                                break;
                            case "ALIGNER":
                                txn.Method = Transaction.Command.AlignerType.GetStatus;
                                break;
                            case "LOADPORT":
                                txn.Method = Transaction.Command.LoadPortType.ReadStatus;
                                break;
                        }
                        txn.FormName = "FormStatus";
                        txn.AdrNo = each.AdrNo;
                        txn.Seq = seq;
                        if (!txn.Method.Equals(""))
                        {
                            each.SendCommand(txn, out Message);
                        }
                    }
                }
                catch (Exception e)
                {
                    logger.Error(e.StackTrace);
                }
            }

        }
    }
}

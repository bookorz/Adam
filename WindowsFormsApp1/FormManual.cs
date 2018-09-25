using Adam;
using Adam.UI_Update.Manual;
using Adam.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferControl.Management;

namespace GUI
{
    
    public partial class FormManual : Form
    {
        private string ActiveAligner { get; set; }
        Boolean isRobotMoveDown = false;//Get option 1
        Boolean isRobotMoveUp = false;//Put option 1
        public FormManual()
        {
            InitializeComponent();

        }

        private void FormManual_Load(object sender, EventArgs e)
        {
            Initialize();
            Update_Manual_Status();
        }

        public void Initialize()
        {
            foreach (Node port in NodeManagement.GetLoadPortList())
            {
                if (Cb_LoadPortSelect.Text.Equals(""))
                {
                    Cb_LoadPortSelect.Text = port.Name;
                }
                Cb_LoadPortSelect.Items.Add(port.Name);
            }
            ManualPortStatusUpdate.UpdateMapping(Cb_LoadPortSelect.Text, "?????????????????????????");
        }

        private void PortFunction_Click(object sender, EventArgs e)
        {
            Node port = NodeManagement.Get(Cb_LoadPortSelect.Text);
            Transaction txn = new Transaction();
            txn.FormName = "FormManual";
            if (port == null)
            {
                MessageBox.Show(Cb_LoadPortSelect.Text + " can't found!");
                return;
            }
            Button btn = (Button)sender;
            switch (btn.Name)
            {
                case "Btn_LOAD_A":
                    if (ChkWithSlotMap_A.Checked)
                    {
                        txn.Method = Transaction.Command.LoadPortType.MappingLoad;
                    }
                    else
                    {
                        txn.Method = Transaction.Command.LoadPortType.Load;
                    }
                    break;
                case "Btn_UNLOAD_A":
                    if (ChkWithSlotMap_A.Checked)
                    {
                        txn.Method = Transaction.Command.LoadPortType.MappingUnload;
                    }
                    else
                    {
                        txn.Method = Transaction.Command.LoadPortType.Unload;
                    }
                    break;
                case "Btn_Reset_A":
                    txn.Method = Transaction.Command.LoadPortType.Reset;
                    break;
                case "Btn_Initialize_A":
                    txn.Method = Transaction.Command.LoadPortType.InitialPos;
                    break;
                case "Btn_ForceInitial_A":
                    txn.Method = Transaction.Command.LoadPortType.ForceInitialPos;
                    break;
                case "Btn_UnClamp_A":
                    txn.Method = Transaction.Command.LoadPortType.UnClamp;
                    break;
                case "Btn_Clamp_A":
                    txn.Method = Transaction.Command.LoadPortType.Clamp;
                    break;
                case "Btn_UnDock_A":
                    txn.Method = Transaction.Command.LoadPortType.UnDock;
                    break;
                case "Btn_Dock_A":
                    txn.Method = Transaction.Command.LoadPortType.Dock;
                    break;
                case "Btn_VacuumOFF_A":
                    txn.Method = Transaction.Command.LoadPortType.VacuumOFF;
                    break;
                case "Btn_VacuumON_A":
                    txn.Method = Transaction.Command.LoadPortType.VacuumON;
                    break;
                case "Btn_LatchDoor_A":
                    txn.Method = Transaction.Command.LoadPortType.LatchDoor;
                    break;
                case "Btn_UnLatchDoor_A":
                    txn.Method = Transaction.Command.LoadPortType.UnLatchDoor;
                    break;
                case "Btn_DoorClose_A":
                    txn.Method = Transaction.Command.LoadPortType.DoorClose;
                    break;
                case "Btn_DoorOpen_A":
                    txn.Method = Transaction.Command.LoadPortType.DoorOpen;
                    break;
                case "Btn_DoorDown_A":
                    txn.Method = Transaction.Command.LoadPortType.DoorDown;
                    break;
                case "Btn_DoorUp_A":
                    txn.Method = Transaction.Command.LoadPortType.DoorUp;
                    break;
                case "Btn_ReadLED_A":
                    txn.Method = Transaction.Command.LoadPortType.GetLED;
                    break;
                case "Btn_ReadVersion_A":
                    txn.Method = Transaction.Command.LoadPortType.ReadVersion;
                    break;
                case "Btn_ReadStatus_A":
                    txn.Method = Transaction.Command.LoadPortType.ReadStatus;
                    break;
                case "Btn_Map_A":
                    txn.Method = Transaction.Command.LoadPortType.GetMapping;
                    break;
                case "Btn_MapperWaitPosition_A":
                    txn.Method = Transaction.Command.LoadPortType.MapperWaitPosition;
                    break;
                case "Btn_MapperStartPosition_A":
                    txn.Method = Transaction.Command.LoadPortType.MapperStartPosition;
                    break;
                case "Btn_MapperArmRetracted_A":
                    txn.Method = Transaction.Command.LoadPortType.MapperArmRetracted;
                    break;
                case "Btn_MapperArmStretch_A":
                    txn.Method = Transaction.Command.LoadPortType.MapperArmStretch;
                    break;
                case "Btn_MappingDown_A":
                    txn.Method = Transaction.Command.LoadPortType.MappingDown;
                    break;
            }
            if (!txn.Method.Equals(""))
            {
                ManualPortStatusUpdate.LockUI(true);
                port.SendCommand(txn);
            }
            else
            {
                MessageBox.Show("Command is empty!");
            }
        }

        private void Btn_ClearSlotResult_A_Click(object sender, EventArgs e)
        {
            ManualPortStatusUpdate.UpdateMapping(Cb_LoadPortSelect.Text, "?????????????????????????");
        }

        private void Btn_ClearMSG_A_Click(object sender, EventArgs e)
        {
            RTxt_Message_A.Clear();
        }

        private void Cb_LoadPortSelect_TextUpdate(object sender, EventArgs e)
        {
            LblLED_A.Text = "";
            LblVersion_A.Text = "";
            LblStatus_A.Text = "";
            RTxt_Message_A.Clear();
            ManualPortStatusUpdate.UpdateMapping(Cb_LoadPortSelect.Text, "?????????????????????????");
            for (int i = 0; i < 19; i++)
            {
                string Idx = (i + 1).ToString("00");
                Label StsLb = this.Controls.Find("Lab_StateCode_" + Idx + "_A", true).FirstOrDefault() as Label;
                StsLb.Text = "";
            }

        }


        private void AlignerFunction_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            String nodeName = "NA";
            String angle = "0";
            string speed = "0";
            if (btn.Name.IndexOf("A1") > 0)
            {
                nodeName = "ALIGNER01";
                if (cbA1Angle.Text.Equals(""))
                {
                    cbA1Angle.Text = "0";
                }
                if (udA1AngleOffset.Text.Equals(""))
                {
                    udA1AngleOffset.Text = "0";
                }
                angle = Convert.ToString(int.Parse(cbA1Angle.Text) + int.Parse(udA1AngleOffset.Text));
                speed = nudA1Speed.Text.Equals("100") ? "0" : nudA1Speed.Text;
            }
            if (btn.Name.IndexOf("A2") > 0)
            {
                nodeName = "ALIGNER02";
                if (cbA2Angle.Text.Equals(""))
                {
                    cbA2Angle.Text = "0";
                }
                if (udA2AngleOffset.Text.Equals(""))
                {
                    udA2AngleOffset.Text = "0";
                }
                angle = Convert.ToString(int.Parse(cbA2Angle.Text) + int.Parse(udA2AngleOffset.Text));
                speed = nudA2Speed.Text.Equals("100") ? "0" : nudA2Speed.Text;
            };
            this.ActiveAligner = nodeName;
            Node aligner = NodeManagement.Get(nodeName);
            Transaction[] txns = new Transaction[1];
            txns[0] = new Transaction();
            txns[0].FormName = "FormManual";
            if (aligner == null)
            {
                MessageBox.Show(nodeName + " can't found!");
                return;
            }
            String btnFuncName = btn.Name.Replace("A1", "").Replace("A2", ""); // A1 , A2 共用功能
            if (!btnFuncName.Equals("btnConn") && !btnFuncName.Equals("btnDisConn"))
            {
                string status = "";
                if (nodeName.Equals("ALIGNER01"))
                {
                    status = tbA1Status.Text;
                }
                if (nodeName.Equals("ALIGNER02"))
                {
                    status = tbA2Status.Text;
                }
                switch (status)
                {
                    case "Disconnected":
                    case "N/A":
                    case "":
                        MessageBox.Show("Please connect first.", "Error");
                        return;
                    default:
                        break;
                }
            }
            switch (btnFuncName)
            {
                case "btnConn":
                    //ControllerManagement.Get(aligner.Controller).Connect();
                    aligner.State = "";
                    SetFormEnable(false);
                    Thread.Sleep(500);//暫解
                    setAlignerStatus();
                    SetFormEnable(true);
                    return;
                case "btnDisConn":
                   // ControllerManagement.Get(aligner.Controller).Close();
                    aligner.State = "";
                    SetFormEnable(false);
                    Thread.Sleep(500);//暫解
                    setAlignerStatus();
                    SetFormEnable(true);
                    return;
                case "btnInit":
                    //txns = new Transaction[4];
                    //txns[0].Method = Transaction.Command.AlignerType.Reset;
                    //txns[1].Method = Transaction.Command.AlignerType.AlignerOrigin;
                    //txns[2].Method = Transaction.Command.AlignerType.AlignerServo;
                    //txns[3].Method = Transaction.Command.AlignerType.AlignerHome;
                    break;
                case "btnOrg":
                    txns[0].Method = Transaction.Command.AlignerType.AlignerOrigin;
                    break;
                case "btnHome":
                    txns[0].Method = Transaction.Command.AlignerType.AlignerHome;
                    break;
                case "btnServoOn":
                    txns[0].Method = Transaction.Command.AlignerType.AlignerServo;
                    txns[0].Value = "1";
                    break;
                case "btnServoOff":
                    txns[0].Method = Transaction.Command.AlignerType.AlignerServo;
                    txns[0].Value = "0";
                    break;
                case "btnVacuOn":
                    txns[0].Method = Transaction.Command.AlignerType.WaferHold;
                    txns[0].Arm = "1";
                    break;
                case "btnVacuOff":
                    txns[0].Method = Transaction.Command.AlignerType.WaferRelease;
                    txns[0].Arm = "1";
                    break;
                case "btnChgSpeed":
                    txns[0].Method = Transaction.Command.AlignerType.AlignerSpeed;
                    txns[0].Value = speed;
                    break;
                case "btnReset":
                    txns[0].Method = Transaction.Command.AlignerType.Reset;
                    break;
                case "btnAlign":
                    txns[0].Method = Transaction.Command.AlignerType.Align;                   
                    txns[0].Value = angle;
                    break;
                case "btnChgMode":
                    int mode = -1;
                    if (btn.Name.IndexOf("A1") > 0)
                    {
                        mode = cbA1Mode.SelectedIndex;
                    }
                    if (btn.Name.IndexOf("A2") > 0)
                    {
                        mode = cbA2Mode.SelectedIndex;
                    }
                    if (mode < 0)
                    {
                        MessageBox.Show(" Insufficient information, please select mode!", "Invalid Mode");
                        return;
                    }
                    txns[0].Method = Transaction.Command.AlignerType.AlignerMode;
                    txns[0].Value = Convert.ToString(mode);
                    break;
            }
            if (!txns[0].Method.Equals(""))
            {
                aligner.SendCommand(txns[0]);
            }
            else
            {
                MessageBox.Show("Command is empty!");
            }
            SetFormEnable(false);
            setAlignerStatus();
        }

        private void SetFormEnable(bool enable)
        {
            if (enable)
            {
                this.Cursor = Cursors.Default;
                tbcManual.Enabled = true;
            }
            else
            {
                this.Cursor = Cursors.WaitCursor;
                tbcManual.Enabled = false;
            }
        }

        private void MotionFunction_Click(object sender, EventArgs e)
        {
            Boolean isRobotActive = false;
            Button btn = (Button)sender;
            String nodeName = null ;
            if (tbcManual.SelectedTab.Text.Equals("Robot"))
            {
                isRobotActive = true;
                nodeName = rbR1.Checked ? "ROBOT01" : "ROBOT02";
            }
            if (tbcManual.SelectedTab.Text.Equals("Aligner"))
                nodeName = this.ActiveAligner;
            Node node = NodeManagement.Get(nodeName);
            Transaction txn = new Transaction();
            txn = new Transaction();
            txn.FormName = "FormManual";
            switch (btn.Name)
            {
                case "btnStop":
                    if (node.Brand.ToUpper().Equals("KAWASAKI"))
                    {
                        SetFormEnable(true);
                        return;
                    }
                    else
                    {
                        txn.Method = isRobotActive ? Transaction.Command.RobotType.Stop: Transaction.Command.AlignerType.Stop;
                        //txn.Value = "0";//減速停止
                        txn.Value = "1";//立即停止
                        SetFormEnable(true);
                    }
                    break;
                case "btnPause":
                    txn.Method = isRobotActive ? Transaction.Command.RobotType.Pause : Transaction.Command.AlignerType.Pause;
                    break;
                case "btnContinue":
                    txn.Method = isRobotActive ? Transaction.Command.RobotType.Continue : Transaction.Command.AlignerType.Continue;
                    break;
            }
            if (!txn.Method.Equals(""))
            {
                node.SendCommand(txn);
            }
            else
            {
                MessageBox.Show("Command is empty!");
            }
        }
        private void RobotFunction_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            if (!btn.Name.Equals("btnRConn") && !btn.Name.Equals("btnRConn"))
            {
                switch (tbRStatus.Text)
                {
                    case "Disconnected":
                    case "N/A":
                    case "":
                        MessageBox.Show("Please connect first.", "Error");
                        return;
                    default:
                        break;
                }
            }

            if (EightInch_rb.Checked)
            {
                if(cbRA1Arm.Text.Equals("Both") || cbRA2Arm.Text.Equals("Both"))
                {
                    MessageBox.Show("200MM not surport Both arm.", "Error");
                    return;
                }
            }
            
            String nodeName = rbR1.Checked ? "ROBOT01" : "ROBOT02";
            Node robot = NodeManagement.Get(nodeName);
            Transaction[] txns = new Transaction[1];
            
            txns[0] = new Transaction();
            txns[0].FormName = "FormManual";
            SetFormEnable(false);
            string WaferSize = "";
            if (EightInch_rb.Checked)
            {
                WaferSize = "200MM";
            }else if (TwelveInch_rb.Checked)
            {
                WaferSize = "300MM";
            }
            switch (btn.Name)
            {
                case "btnRGet":
                case "btnRPut":
                case "btnRGetWait":
                case "btnRPutWait":
                case "btnRMoveDown":
                case "btnRMoveUp":
                case "btnRPutPut":
                case "btnRPutGet":
                case "btnRGetPut":
                case "btnRGetGet":
                    if (WaferSize.Equals(""))
                    {
                        MessageBox.Show("請選擇Wafer大小");
                        return;
                    }
                    break;
            }

            switch (btn.Name)
            {
                case "btnRConn":
                    try
                    {
                        //ControllerManagement.Get(robot.Controller).Close();
                        //ControllerManagement.Get(robot.Controller).Connect();
                        robot.State = "";
                        Thread.Sleep(500);//暫解
                        setRobotStatus();
                        SetFormEnable(true);
                    }
                    catch (Exception e1)
                    {
                    }
                    return;
                case "btnRDisConn":
                    try
                    {
                        //ControllerManagement.Get(robot.Controller).Close();
                        robot.State = "";
                        Thread.Sleep(500);//暫解
                        setRobotStatus();
                        SetFormEnable(true);
                    }
                    catch (Exception e1)
                    {
                    }
                    return;
                case "btnRInit":
                    //txns[0].Method = Transaction.Command.LoadPortType.MappingDown;
                    isRobotMoveDown = false;//Get option 1
                    isRobotMoveUp = false;//Put option 1
                    break;
                case "btnROrg":
                    txns[0].Method = Transaction.Command.RobotType.RobotOrginSearch;
                    isRobotMoveDown = false;//Get option 1
                    isRobotMoveUp = false;//Put option 1
                    break;
                case "btnRHome":
                    if(robot.Brand.ToUpper().Equals("SANWA"))
                        txns[0].Method = Transaction.Command.RobotType.RobotHomeSafety;//20180607 RobotHome => RobotHomeSafety
                    else 
                        txns[0].Method = Transaction.Command.RobotType.RobotHomeA;//Kawasaki home A
                    isRobotMoveDown = false;//Get option 1
                    isRobotMoveUp = false;//Put option 1
                    break;
                case "btnRChgSpeed":
                    txns[0].Method = Transaction.Command.RobotType.RobotSpeed;
                    txns[0].Value = nudRSpeed.Text.Equals("100") ? "0" : nudRSpeed.Text;
                    break;
                //上臂
                case "btnRRVacuOn":
                    txns[0].Method = Transaction.Command.RobotType.WaferHold;
                    txns[0].Arm = "1";
                    break;
                case "btnRRVacuOff":
                    txns[0].Method = Transaction.Command.RobotType.WaferRelease;
                    txns[0].Arm = "1";
                    break;
                //下臂
                case "btnRLVacuOn":
                    txns[0].Method = Transaction.Command.RobotType.WaferHold;
                    txns[0].Arm = "2";
                    break;
                case "btnRLVacuOff":
                    txns[0].Method = Transaction.Command.RobotType.WaferRelease;
                    txns[0].Arm = "2";
                    break;
                case "btnRGet":
                    if (cbRA1Point.Text == "" || cbRA1Slot.Text == "" || cbRA1Arm.Text == "")
                    {
                        MessageBox.Show(" Insufficient information, please select source!", "Invalid source");
                        return;
                    }
                    if (isRobotMoveDown)
                        txns[0].Method = Transaction.Command.RobotType.GetAfterWait;
                    else
                        txns[0].Method = Transaction.Command.RobotType.Get;
                    txns[0].Position = cbRA1Point.Text;
                    txns[0].Arm = SanwaUtil.GetArmID(cbRA1Arm.Text);
                    txns[0].Slot = cbRA1Slot.Text;
                    isRobotMoveDown = false;//Get option 1
                    isRobotMoveUp = false;//Put option 1
                    break;
                case "btnRPut":
                    if (cbRA2Point.Text == "" || cbRA2Slot.Text == "" || cbRA2Arm.Text == "")
                    {
                        MessageBox.Show(" Insufficient information, please select destination!", "Invalid destination");
                        return;
                    }
                    if (isRobotMoveUp)
                        txns[0].Method = Transaction.Command.RobotType.PutBack;
                    else
                        txns[0].Method = Transaction.Command.RobotType.Put;
                    txns[0].Position = cbRA2Point.Text;
                    txns[0].Arm = SanwaUtil.GetArmID(cbRA2Arm.Text);
                    txns[0].Slot = cbRA2Slot.Text;
                    isRobotMoveDown = false;//Get option 1
                    isRobotMoveUp = false;//Put option 1
                    break;
                case "btnRGetWait":
                    if (cbRA1Point.Text == "" || cbRA1Slot.Text == "" || cbRA1Arm.Text == "")
                    {
                        MessageBox.Show(" Insufficient information, please select source!", "Invalid source");
                        return;
                    }
                    txns[0].Method = Transaction.Command.RobotType.GetWait;
                    txns[0].Position = cbRA1Point.Text;
                    txns[0].Arm = SanwaUtil.GetArmID(cbRA1Arm.Text);
                    txns[0].Slot = cbRA1Slot.Text;
                    break;
                case "btnRPutWait":
                    if (cbRA2Point.Text == "" || cbRA2Slot.Text == "" || cbRA2Arm.Text == "")
                    {
                        MessageBox.Show(" Insufficient information, please select destination!", "Invalid destination");
                        return;
                    }
                    txns[0].Method = Transaction.Command.RobotType.PutWait;
                    txns[0].Position = cbRA2Point.Text;
                    txns[0].Arm = SanwaUtil.GetArmID(cbRA2Arm.Text);
                    txns[0].Slot = cbRA2Slot.Text;
                    break;
                case "btnRMoveDown":
                    isRobotMoveDown = true;
                    txns[0].Method = Transaction.Command.RobotType.WaitBeforeGet;//GET option 1
                    txns[0].Position = cbRA1Point.Text;
                    txns[0].Arm = SanwaUtil.GetArmID(cbRA1Arm.Text);
                    txns[0].Slot = cbRA1Slot.Text;
                    break;
                case "btnRMoveUp":
                    isRobotMoveUp = true;
                    txns[0].Method = Transaction.Command.RobotType.WaitBeforePut;//Put option 1
                    txns[0].Position = cbRA2Point.Text;
                    txns[0].Arm = SanwaUtil.GetArmID(cbRA2Arm.Text);
                    txns[0].Slot = cbRA2Slot.Text;
                    break;
                case "btnRChgMode":
                    if (cbRMode.SelectedIndex < 0)
                    {
                        MessageBox.Show(" Insufficient information, please select mode!", "Invalid Mode");
                        return;
                    }
                    txns[0].Method = Transaction.Command.RobotType.RobotMode;
                    txns[0].Value = Convert.ToString(cbRMode.SelectedIndex);
                    break;
                case "btnRPutPut":
                    if(GetScriptVar() == null)
                    {
                        MessageBox.Show(" Insufficient information, please select source or destination!", "Invalid source or destination");
                        return;
                    }
                    else
                    {
                        robot.ExcuteScript("RobotManualPutPut", "FormManual-Script", GetScriptVar(), WaferSize);
                        return;
                    }
                case "btnRGetGet":
                    if (GetScriptVar() == null)
                    {
                        MessageBox.Show(" Insufficient information, please select source or destination!", "Invalid source or destination");
                        return;
                    }
                    else
                    {
                        robot.ExcuteScript("RobotManualGetGet", "FormManual-Script", GetScriptVar(), WaferSize);
                        return;
                    }
                case "btnRGetPut":
        
                    if (GetScriptVar() == null)
                    {
                        MessageBox.Show(" Insufficient information, please select source or destination!", "Invalid source or destination");
                        return;
                    }
                    else
                    {
                        robot.ExcuteScript("RobotManualGetPut", "FormManual-Script", GetScriptVar(), WaferSize);
                        return;
                    }
                case "btnRPutGet":
                
                    if (GetScriptVar() == null)
                    {
                        MessageBox.Show(" Insufficient information, please select source or destination!", "Invalid source or destination");
                        return;
                    }
                    else
                    {
                        robot.ExcuteScript("RobotManualPutGet", "FormManual-Script", GetScriptVar(), WaferSize);
                        return;
                    }
                case "btnRReset":
                    txns[0].Method = Transaction.Command.RobotType.Reset;
                    break;
                case "btnRServoOn":
                    txns[0].Method = Transaction.Command.RobotType.RobotServo;
                    txns[0].Value = "1";
                    break;
                case "btnRServoOff":
                    txns[0].Method = Transaction.Command.RobotType.RobotServo;
                    txns[0].Value = "0";
                    break;
            }
            if (!txns[0].Method.Equals(""))
            {
                txns[0].RecipeID = WaferSize;
                robot.SendCommand(txns[0]);
            }
            else
            {
                MessageBox.Show("Command is empty!");
            }
            SetFormEnable(false); 
            Update_Manual_Status();// steven mark test
        }

        private Dictionary<string, string> GetScriptVar()
        {
            Dictionary<string, string> vars = new Dictionary<string, string>();
            if(cbRA1Arm.SelectedIndex  < 0 || cbRA1Slot.SelectedIndex < 0 || cbRA1Point.SelectedIndex < 0)
            {
                return null;
            }
            if (cbRA2Arm.SelectedIndex < 0 || cbRA2Slot.SelectedIndex < 0 || cbRA2Point.SelectedIndex < 0)
            {
                return null;
            }
            vars.Clear();
            vars.Add("@cbRA1Arm", SanwaUtil.GetArmID(cbRA1Arm.Text));
            vars.Add("@cbRA1Slot", cbRA1Slot.Text);
            vars.Add("@cbRA1Point", cbRA1Point.Text);
            vars.Add("@cbRA2Arm", SanwaUtil.GetArmID(cbRA2Arm.Text));
            vars.Add("@cbRA2Slot", cbRA2Slot.Text);
            vars.Add("@cbRA2Point", cbRA2Point.Text);
            return vars;
        }

        private void setRobotStatus()
        {
            Control[] controls = new Control[] { tbRError, tbRLVacuSolenoid, tbRLwaferSensor, tbRRVacuSolenoid, tbRRwaferSensor, nudRSpeed, tbRStatus };
            foreach (Control control in controls)
            {
                control.Text = "";
                control.BackColor = Color.WhiteSmoke;
            }
            String nodeName = rbR1.Checked ? "ROBOT01" : "ROBOT02";
            SetDeviceStatus(nodeName);
            if (tbRStatus.Text.Equals("N/A") || tbRStatus.Text.Equals("Disconnected") || tbRStatus.Text.Equals("") || tbRStatus.Text.Equals("Connecting"))
            {
                return;//連線狀態下才執行
            }
            //向Robot 詢問狀態
            Node robot = NodeManagement.Get(nodeName);
            String script_name = robot.Brand.ToUpper().Equals("SANWA") ? "RobotStateGet" : "RobotStateGet(Kawasaki)";
            robot.ExcuteScript(script_name, "FormManual");

        }


        private void setAlignerStatus()
        {
            Control[] controls = new Control[] { tbA1Error, tbA1Status, tbA1VacSolenoid, tbA1WaferSensor, tbA1WaferSensor, tbA2Error, tbA2Status, tbA2VacSolenoid, tbA2WaferSensor, tbA2WaferSensor, nudA1Speed, nudA2Speed };
            foreach (Control control in controls)
            {
                control.Text = "";
                control.BackColor = Color.WhiteSmoke;
            }
            SetDeviceStatus("ALIGNER01");
            SetDeviceStatus("ALIGNER02");
            Node aligner1 = NodeManagement.Get("ALIGNER01");
            Node aligner2 = NodeManagement.Get("ALIGNER02");

            //向Aligner 詢問狀態
            if (!tbA1Status.Text.Equals("N/A") && !tbA1Status.Text.Equals("Disconnected") && !tbA1Status.Text.Equals(""))
            {
                String script_name = aligner1.Brand.ToUpper().Equals("SANWA")?"AlignerStateGet":"AlignerStateGet(Kawasaki)";
                aligner1.ExcuteScript(script_name, "FormManual"); ;//連線狀態下才執行
            }
            if (!tbA2Status.Text.Equals("N/A") && !tbA2Status.Text.Equals("Disconnected") && !tbA2Status.Text.Equals(""))
            {
                String script_name = aligner2.Brand.ToUpper().Equals("SANWA") ? "AlignerStateGet" : "AlignerStateGet(Kawasaki)";
                aligner2.ExcuteScript(script_name, "FormManual"); ;//連線狀態下才執行
            }
        }

        private void SetDeviceStatus(string name)
        {
            Node node = NodeManagement.Get(name);
            if (node == null)
                return;
            string status = node.State != "" ? node.State : "N/A";
            string ctrl_status = ControllerManagement.Get(node.Controller) != null? ControllerManagement.Get(node.Controller).Status : "N/A";
            //string ctrl_status = ControllerManagement.Get(node.Controller).Status;
            if (!ctrl_status.Equals("Connected"))
            {
                status = ctrl_status;// 如果 Controller 非已連線狀態，NODE 狀態改抓 Controller 的狀態   
            }
            //if (status.Equals("N/A") && ControllerManagement.Get(node.Controller) != null)
            //    status = ctrl_status // 如果 NODE 無狀態，改抓 Controller 的狀態     
            TextBox tbStatus = null;
            switch (name)
            {
                case "ROBOT01":
                case "ROBOT02":
                    tbStatus = tbRStatus;
                    break;
                case "ALIGNER01":
                    tbStatus = tbA1Status;
                    break;
                case "ALIGNER02":
                    tbStatus = tbA2Status;
                    break;
            }
            if (tbStatus == null)
                return;
            tbStatus.Text = status;
            Color color = new Color();
            switch (tbStatus.Text)
            {
                case "RUN":
                    color = Color.Lime;
                    break;
                case "IDLE":
                    color = Color.Yellow;
                    break;
                case "Connected":
                    color = Color.LightBlue;
                    break;
                case "Connecting":
                    color = Color.LightSeaGreen;
                    break;
                case "Disconnected":
                case "N/A":
                    color = Color.LightGray;
                    break;
            }
            tbStatus.BackColor = color;
        }

        private void FormManual_EnabledChanged(object sender, EventArgs e)
        {
            //Update_Manual_Status();
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            Update_Manual_Status();
        }

        private void tbcManual_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tbcManual.SelectedTab.Text)
            {
                case "Robot":
                case "Aligner":
                    pnlMotionStop.Visible = true;
                    break;
                default:
                    pnlMotionStop.Visible = false;
                    break;
            }
            Update_Manual_Status();
        }

        private void Update_Manual_Status()
        {
            if (tbcManual.SelectedTab.Text.Equals("Robot"))
                setRobotStatus();
            if (tbcManual.SelectedTab.Text.Equals("Aligner"))
                setAlignerStatus();
        }

        private void btnRAreaSwap_Click(object sender, EventArgs e)
        {
            //A1 => temp
            int tempPoint = cbRA1Point.SelectedIndex;
            int tempSlot = cbRA1Slot.SelectedIndex;
            int tempArm = cbRA1Arm.SelectedIndex;
            //A2 => A1
            cbRA1Point.SelectedIndex = cbRA2Point.SelectedIndex;
            cbRA1Slot.SelectedIndex = cbRA2Slot.SelectedIndex;
            cbRA1Arm.SelectedIndex = cbRA2Arm.SelectedIndex;
            //temp => A2
            cbRA2Point.SelectedIndex = tempPoint;
            cbRA2Slot.SelectedIndex = tempSlot;
            cbRA2Arm.SelectedIndex = tempArm;
        }

        private void cbRA1Point_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void tableLayoutPanel23_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            TransferJob job = new TransferJob("LOADPORT02","");
            job.doTransfer();
        }
    }
}

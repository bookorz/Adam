using SANWA.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TransferControl.Engine;
using TransferControl.Management;
using TransferControl.Parser;
using log4net.Config;
using Adam.UI_Update.Monitoring;
using log4net;
using Adam.UI_Update.Manual;
using Adam.UI_Update.OCR;
using Adam.UI_Update.WaferMapping;
using System.Threading;
using Adam.UI_Update.Authority;
using DIOControl;
using Adam.UI_Update.Layout;
using Adam.UI_Update.Alarm;
using GUI;
using Adam.UI_Update.Running;
using System.Linq;
using System.Collections.Concurrent;
using Adam.Util;
using Adam.UI_Update.Communications;

namespace Adam
{
    public partial class FormMain : Form, IUserInterfaceReport, IDIOTriggerReport
    {
        public static RouteControl RouteCtrl;
        public static DIO DIO;
        public static AlarmMapping AlmMapping;
        private static readonly ILog logger = LogManager.GetLogger(typeof(FormMain));

        FromAlarm alarmFrom = new FromAlarm();
        private Menu.Monitoring.FormMonitoring formMonitoring = new Menu.Monitoring.FormMonitoring();
        private Menu.Communications.FormCommunications formCommunications = new Menu.Communications.FormCommunications();
        private Menu.WaferMapping.FormWaferMapping formWafer = new Menu.WaferMapping.FormWaferMapping();
        private Menu.Status.FormStatus formStatus = new Menu.Status.FormStatus();
        private Menu.OCR.FormOCR formOCR = new Menu.OCR.FormOCR();
        private Menu.SystemSetting.FormSystemSetting formSystem = new Menu.SystemSetting.FormSystemSetting();
        private Menu.RunningScreen.FormRunningScreen formTestMode = new Menu.RunningScreen.FormRunningScreen();
        private Menu.Wafer.FormWafer WaferForm = new Menu.Wafer.FormWafer();


        public FormMain()
        {
            InitializeComponent();
            XmlConfigurator.Configure();
            Initialize();
            RouteCtrl = new RouteControl(this);
            DIO = new DIO(this);

            AlmMapping = new AlarmMapping();

            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Location = new System.Drawing.Point(-200, 0);

            SanwaUtil.addPartition();
            SanwaUtil.dropPartition();
            ThreadPool.QueueUserWorkItem(new WaitCallback(DBUtil.consumeSqlCmd));

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

        private void Initialize()
        {


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Int32 oldWidth = this.Width;
            Int32 oldHeight = this.Height;

            this.WindowState = FormWindowState.Normal;
            this.Width = 1;
            this.Height = 1;

            Control[] ctrlForm = new Control[] { formMonitoring, formCommunications, formWafer, formStatus, formOCR, formTestMode, WaferForm, formSystem };

            try
            {
                for (int i = 0; i < ctrlForm.Length; i++)
                {
                    ((Form)ctrlForm[i]).TopLevel = false;
                    tbcMian.TabPages[i].Controls.Add(((Form)ctrlForm[i]));
                    ((Form)ctrlForm[i]).Show();
                    tbcMian.SelectTab(i);
                }

                tbcMian.SelectTab(0);
                alarmFrom.Hide();
                alarmFrom.Show();

                alarmFrom.Hide();



            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            //Thread.Sleep(2000);

            if (SplashScreen.Instance != null)
            {
                SplashScreen.Instance.BeginInvoke(new MethodInvoker(SplashScreen.Instance.Dispose));
                SplashScreen.Instance = null;
            }
            this.Width = oldWidth;
            this.Height = oldHeight;
            this.WindowState = FormWindowState.Maximized;
            DIO.Connect();
            AuthorityUpdate.UpdateFuncGroupEnable("INIT");//init 權限
            RouteCtrl.ConnectAll();
            //ThreadPool.QueueUserWorkItem(new WaitCallback(RouteCtrl.ConnectAll));
            this.Width = oldWidth;
            this.Height = oldHeight;
            this.WindowState = FormWindowState.Maximized;


        }

        private void LoadPort01_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ((DataGridView)sender).ClearSelection();
        }

        private void btnLogInOut_Click(object sender, EventArgs e)
        {
            switch (btnLogInOut.Text)
            {
                case "Login":
                    GUI.FormLogin formLogin = new GUI.FormLogin();
                    formLogin.ShowDialog();
                    break;
                case "Logout":
                    AuthorityUpdate.UpdateLogoutInfo();
                    //disable authroity function
                    AuthorityUpdate.UpdateFuncGroupEnable("INIT");
                    ((TabControl)formSystem.Controls["tbcSystemSetting"]).SelectTab(0);
                    break;
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormAlarmHis form4 = new FormAlarmHis();
            form4.Text = "Message History";
            form4.label21.Text = "Message History";
            form4.Show();
        }

        private void bBBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAlarmHis form4 = new FormAlarmHis();
            form4.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            string strMsg = "This equipment performs the initialization and origin search OK?\r\n" + "This equipment will be initalized, each axis will return to home position.\r\n" + "Check the condition of the wafer.";
            if (MessageBox.Show(strMsg, "Initialize", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {

                foreach (Node each in NodeManagement.GetList())
                {
                    each.InitialComplete = false;
                    switch (each.Type.ToUpper())
                    {
                        case "ROBOT":
                            each.ExcuteScript("RobotInit", "Initialize");
                            break;
                        case "ALIGNER":
                            each.ExcuteScript("AlignerInit", "Initialize");
                            break;
                        case "LOADPORT":
                            each.ExcuteScript("LoadPortInit", "Initialize");
                            break;
                    }
                }
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            string strMsg = "Move to Home position. OK?";
            if (MessageBox.Show(strMsg, "Org.Back", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                Transaction txn = new Transaction();
                txn.Method = Transaction.Command.RobotType.RobotHome;
                NodeManagement.Get("Robot01").SendCommand(txn);
                txn = new Transaction();
                txn.Method = Transaction.Command.RobotType.RobotHome;
                NodeManagement.Get("Robot02").SendCommand(txn);
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            string strMsg = "Switching to manual mode.\r\n" + "In this mode, your operation may damage the equipment.\r\n" + "Suffcient cautions are required for your operation.";
            //if (MessageBox.Show(strMsg, "Manual", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification) == DialogResult.OK)
            //{
            GUI.FormManual formManual = new GUI.FormManual();
            formManual.Show();
            //}
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            FormUnitCtrlData form2 = new FormUnitCtrlData();
            form2.ShowDialog();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            FormTransTest form3 = new FormTransTest();
            form3.ShowDialog();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            UI_TEST.IO iO = new UI_TEST.IO();
            iO.ShowDialog();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            UI_TEST.LLSetting lLSetting = new UI_TEST.LLSetting();
            lLSetting.ShowDialog();
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI_TEST.Setting setting = new UI_TEST.Setting();
            setting.ShowDialog();
        }

        private void terminalToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormTerminal formTerminal = new FormTerminal();
            formTerminal.ShowDialog();
        }

        private void btnTeach_Click(object sender, EventArgs e)
        {
            UI_TEST.Teaching teaching = new UI_TEST.Teaching();
            teaching.ShowDialog();
        }

        private void btnVersion_Click(object sender, EventArgs e)
        {
            GUI.FormVersion formVersion = new GUI.FormVersion();
            formVersion.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            GUI.FormLogSave formLogSave = new GUI.FormLogSave();
            formLogSave.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FromAlarm alarmFrom = new FromAlarm();
            alarmFrom.Text = "MessageFrom";
            alarmFrom.BackColor = Color.Blue;
            alarmFrom.ResetAll_bt.Enabled = false;
            alarmFrom.ShowDialog();
        }

        private void aAAToolStripMenuItem_Click(object sender, EventArgs e)
        {

            alarmFrom.Visible = true;
        }

        public void On_Command_Excuted(Node Node, Transaction Txn, ReturnMessage Msg)
        {
            logger.Debug("On_Command_Excuted");

            Transaction txn = new Transaction();

            if (Txn.Method == Transaction.Command.LoadPortType.Reset)
            {
                AlarmUpdate.UpdateAlarmList(AlarmManagement.GetAll());
            }

            switch (Node.Type)
            {
                case "LOADPORT":
                    switch (Txn.Method)
                    {
                        case Transaction.Command.LoadPortType.GetMapping:

                        case Transaction.Command.LoadPortType.Unload:
                        case Transaction.Command.LoadPortType.MappingUnload:
                        case Transaction.Command.LoadPortType.DoorUp:
                        case Transaction.Command.LoadPortType.InitialPos:
                        case Transaction.Command.LoadPortType.ForceInitialPos:
                            WaferAssignUpdate.RefreshMapping(Node.Name);
                            MonitoringUpdate.UpdateNodesJob(Node.Name);
                            break;
                    }
                    break;
            }

            switch (Txn.FormName)
            {
                case "FormStatus":
                    Util.StateUtil.UpdateSTS(Node.Name, Msg.Value);
                    break;
                case "PauseProcedure":

                    break;
                case "FormManual":
                    switch (Node.Type)
                    {
                        case "LOADPORT":
                            if (!Txn.CommandType.Equals("MOV"))
                            {
                                ManualPortStatusUpdate.LockUI(false);
                            }
                            ManualPortStatusUpdate.UpdateLog(Node.Name, Msg.Command + " Excuted");
                            switch (Txn.Method)
                            {
                                case Transaction.Command.LoadPortType.ReadVersion:
                                    ManualPortStatusUpdate.UpdateVersion(Node.Name, Msg.Value);
                                    break;
                                case Transaction.Command.LoadPortType.GetLED:
                                    ManualPortStatusUpdate.UpdateLED(Node.Name, Msg.Value);
                                    break;
                                case Transaction.Command.LoadPortType.ReadStatus:
                                    ManualPortStatusUpdate.UpdateStatus(Node.Name, Msg.Value);
                                    break;
                                case Transaction.Command.LoadPortType.GetCount:

                                    break;
                                case Transaction.Command.LoadPortType.GetMapping:
                                    ManualPortStatusUpdate.UpdateMapping(Node.Name, Msg.Value);
                                    break;
                            }
                            break;
                        case "OCR":
                            switch (Txn.Method)
                            {
                                case Transaction.Command.OCRType.GetOnline:
                                    //OCRUpdate.UpdateOCRStatus(Node.Name, Msg.Value);
                                    break;
                            }
                            break;
                        case "ROBOT":
                            switch (Txn.Method)
                            {
                                case Transaction.Command.RobotType.RobotSpeed:
                                case Transaction.Command.RobotType.RobotMode:
                                case Transaction.Command.RobotType.Reset:
                                case Transaction.Command.RobotType.RobotServo:
                                    //case Transaction.Command.RobotType.Stop:
                                    //case Transaction.Command.RobotType.Pause:
                                    //case Transaction.Command.RobotType.Continue:
                                    Thread.Sleep(1000);
                                    //向Robot 詢問狀態
                                    Node robot = NodeManagement.Get(Node.Name);
                                    String script_name = robot.Brand.ToUpper().Equals("SANWA") ? "RobotStateGet" : "RobotStateGet(Kawasaki)";
                                    robot.ExcuteScript(script_name, "FormManual");
                                    ManualRobotStatusUpdate.UpdateGUI(Txn, Node.Name, Msg.Value);//update 手動功能畫面 
                                    break;
                                case Transaction.Command.RobotType.GetSpeed:
                                case Transaction.Command.RobotType.GetRIO:
                                case Transaction.Command.RobotType.GetError:
                                case Transaction.Command.RobotType.GetMode:
                                case Transaction.Command.RobotType.GetStatus:
                                case Transaction.Command.RobotType.GetSV:
                                    ManualRobotStatusUpdate.UpdateGUI(Txn, Node.Name, Msg.Value);//update 手動功能畫面
                                    break;
                                case Transaction.Command.RobotType.GetCombineStatus:
                                    ManualRobotStatusUpdate.UpdateGUI(Txn, Node.Name, Msg.Command);//update 手動功能畫面
                                    break;
                            }
                            break;
                        case "ALIGNER":
                            switch (Txn.Method)
                            {
                                case Transaction.Command.AlignerType.AlignerSpeed:
                                case Transaction.Command.AlignerType.AlignerMode:
                                case Transaction.Command.AlignerType.Reset:
                                case Transaction.Command.AlignerType.AlignerServo:
                                    Thread.Sleep(500);
                                    //向Aligner 詢問狀態
                                    Node aligner = NodeManagement.Get(Node.Name);
                                    String script_name = aligner.Brand.ToUpper().Equals("SANWA") ? "AlignerStateGet" : "AlignerStateGet(Kawasaki)";
                                    aligner.ExcuteScript(script_name, "FormManual");
                                    ManualAlignerStatusUpdate.UpdateGUI(Txn, Node.Name, Msg.Value);//update 
                                    break;
                                case Transaction.Command.AlignerType.GetMode:
                                case Transaction.Command.AlignerType.GetSV:
                                case Transaction.Command.AlignerType.GetStatus:
                                case Transaction.Command.AlignerType.GetSpeed:
                                case Transaction.Command.AlignerType.GetRIO:
                                case Transaction.Command.AlignerType.GetError:
                                    ManualAlignerStatusUpdate.UpdateGUI(Txn, Node.Name, Msg.Value);//update 手動功能畫面
                                    break;
                                case Transaction.Command.RobotType.GetCombineStatus:
                                    ManualAlignerStatusUpdate.UpdateGUI(Txn, Node.Name, Msg.Command);//update 手動功能畫面
                                    break;
                            }
                            break;

                    }
                    break;
                case "InitialFinish":
                    switch (Node.Type)
                    {
                        case "LOADPORT":
                            switch (Txn.Method)
                            {

                                case Transaction.Command.LoadPortType.ReadStatus:
                                    MessageParser parser = new MessageParser(Node.Brand);
                                    Dictionary<string, string> content = parser.ParseMessage(Txn.Method, Msg.Value);
                                    bool CheckResult = true;
                                    foreach (KeyValuePair<string, string> each in content)
                                    {
                                        switch (each.Key)
                                        {
                                            case "FOUP Clamp Status":
                                                if (!each.Value.Equals("Open"))
                                                {
                                                    CheckResult = false;
                                                }
                                                break;
                                            case "Latch Key Status":
                                                if (!each.Value.Equals("Close"))
                                                {
                                                    CheckResult = false;
                                                }
                                                break;
                                            case "Cassette Presence":
                                                if (!each.Value.Equals("Normal position"))
                                                {
                                                    CheckResult = false;
                                                }
                                                break;
                                            case "Door Position":
                                                if (!each.Value.Equals("Close position"))
                                                {
                                                    CheckResult = false;
                                                }
                                                break;
                                            case "Equipment Status":
                                                if (each.Value.Equals("Fatal error"))
                                                {
                                                    CheckResult = false;
                                                }
                                                break;
                                        }
                                    }
                                    if (CheckResult)
                                    {
                                        Node.FoupReady = true;
                                        Node.ExcuteScript("LoadPortFoupIn", "LoadPortFoup","", true);

                                    }
                                    else
                                    {
                                        Node.FoupReady = false;
                                        Node.ExcuteScript("LoadPortFoupOut", "LoadPortFoup", "", true);
                                        On_Node_State_Changed(Node, "Ready To Load");
                                    }
                                    break;
                            }
                            break;
                    }
                    break;
                default:

                    break;
            }
        }

        public void On_Command_Error(Node Node, Transaction Txn, ReturnMessage Msg)
        {
            switch (Txn.FormName)
            {
                case "FormManual":
                    switch (Node.Type)
                    {
                        case "LOADPORT":
                            ManualPortStatusUpdate.LockUI(false);
                            break;

                    }
                    break;
            }
            logger.Debug("On_Command_Error");
            AlarmInfo CurrentAlarm = new AlarmInfo();
            CurrentAlarm.NodeName = Node.Name;
            CurrentAlarm.AlarmCode = Msg.Value;
            CurrentAlarm.NeedReset = true;
            try
            {

                AlarmMessage Detail = AlmMapping.Get(Node.Brand, Node.Type, CurrentAlarm.AlarmCode);

                CurrentAlarm.SystemAlarmCode = Detail.CodeID;
                CurrentAlarm.Desc = Detail.Code_Cause;
                CurrentAlarm.EngDesc = Detail.Code_Cause_English;
                CurrentAlarm.Type = Detail.Code_Type;
                CurrentAlarm.IsStop = Detail.IsStop;
                if (CurrentAlarm.IsStop)
                {
                    RouteCtrl.Stop();
                }
            }
            catch (Exception e)
            {
                CurrentAlarm.Desc = "未定義";
                logger.Error(Node.Controller + "-" + Node.AdrNo + "(GetAlarmMessage)" + e.Message + "\n" + e.StackTrace);
            }
            CurrentAlarm.TimeStamp = DateTime.Now;

            AlarmManagement.Add(CurrentAlarm);

            AlarmUpdate.UpdateAlarmList(AlarmManagement.GetAll());
            AlarmUpdate.UpdateAlarmHistory(AlarmManagement.GetHistory());

        }

        public void On_Command_Finished(Node Node, Transaction Txn, ReturnMessage Msg)
        {
            logger.Debug("On_Command_Finished");
            //Transaction txn = new Transaction();
            switch (Txn.FormName)
            {

                case "FormManual":

                    switch (Node.Type)
                    {
                        case "LOADPORT":

                            ManualPortStatusUpdate.UpdateLog(Node.Name, Msg.Command + " Finished");
                            ManualPortStatusUpdate.LockUI(false);

                            break;

                        case "ROBOT":
                            ManualRobotStatusUpdate.UpdateGUI(Txn, Node.Name, Msg.Value);//update 手動功能畫面
                            break;
                        case "ALIGNER":
                            ManualAlignerStatusUpdate.UpdateGUI(Txn, Node.Name, Msg.Value);//update 手動功能畫面
                            break;
                    }
                    break;
                default:
                    switch (Node.Type)
                    {
                        case "LOADPORT":
                            switch (Txn.Method)
                            {

                            }
                            break;
                        case "OCR":
                            switch (Txn.Method)
                            {
                                case Transaction.Command.OCRType.Read:
                                    OCRUpdate.UpdateOCRRead(Node.Name, Msg.Value, Txn.TargetJobs[0]);

                                    break;
                            }
                            break;
                    }
                    break;
            }
        }

        public void On_Command_TimeOut(Node Node, Transaction Txn)
        {
            logger.Debug("On_Command_TimeOut");
            AlarmInfo CurrentAlarm = new AlarmInfo();
            CurrentAlarm.NodeName = Node.Name;
            CurrentAlarm.AlarmCode = "00200002";
            CurrentAlarm.NeedReset = false;
            try
            {

                AlarmMessage Detail = AlmMapping.Get("SANWA", Node.Type, CurrentAlarm.AlarmCode);

                CurrentAlarm.SystemAlarmCode = Detail.CodeID;
                CurrentAlarm.Desc = Detail.Code_Cause;
                CurrentAlarm.EngDesc = Detail.Code_Cause_English;
                CurrentAlarm.Type = Detail.Code_Type;
                CurrentAlarm.IsStop = Detail.IsStop;
                if (CurrentAlarm.IsStop)
                {
                    RouteCtrl.Stop();
                }
            }
            catch (Exception e)
            {
                CurrentAlarm.Desc = "未定義";
                logger.Error(Node.Controller + "-" + Node.AdrNo + "(GetAlarmMessage)" + e.Message + "\n" + e.StackTrace);
            }
            CurrentAlarm.TimeStamp = DateTime.Now;
            AlarmManagement.Add(CurrentAlarm);
            AlarmUpdate.UpdateAlarmList(AlarmManagement.GetAll());
            AlarmUpdate.UpdateAlarmHistory(AlarmManagement.GetHistory());
        }

        public void On_Event_Trigger(Node Node, ReturnMessage Msg)
        {
            logger.Debug("On_Event_Trigger");


            Transaction txn = new Transaction();
            switch (Node.Type)
            {
                case "LOADPORT":
                    ManualPortStatusUpdate.UpdateLog(Node.Name, Msg.Command + " Trigger");
                    switch (Msg.Command)
                    {
                        case "MANSW":
                            if (Node.FoupReady)
                            {
                                Node.ExcuteScript("LoadPortMapping", "MANSW", "", true);
                            }
                            break;
                        case "PODON":
                            //檢查LoadPort狀態
                            txn.Method = Transaction.Command.LoadPortType.ReadStatus;
                            txn.FormName = "";
                            Node.SendCommand(txn);

                            break;
                        case "PODOF":
                            Node.FoupReady = false;
                            Node.ExcuteScript("LoadPortFoupOut", "LoadPortFoup", "", true);
                            On_Node_State_Changed(Node, "Ready To Load");
                            break;
                    }
                    break;
            }

        }

        public void On_Node_State_Changed(Node Node, string Status)
        {
            logger.Debug("On_Node_State_Changed");
            NodeStatusUpdate.UpdateNodeState(Node.Name, Status);
            switch (Node.Name)
            {
                case "ROBOT01":
                case "ROBOT02":
                    ManualRobotStatusUpdate.UpdateRobotStatus(Node.Name, Status);//update 手動功能畫面
                    break;
                case "ALIGNER01":
                case "ALIGNER02":
                    ManualAlignerStatusUpdate.UpdateAlignerStatus(Node.Name, Status);//update 手動功能畫面
                    break;
            }
        }

        public void On_Eqp_State_Changed(string OldStatus, string NewStatus)
        {
            NodeStatusUpdate.UpdateCurrentState(NewStatus);
            StateRecord.EqpStateUpdate("Sorter", OldStatus, NewStatus);
        }

        public void On_Controller_State_Changed(string Device_ID, string Status)
        {

            ConnectionStatusUpdate.UpdateControllerStatus(Device_ID, Status);

            if (Status.Equals("Connected"))
            {
                //當Loadport連線成功，檢查狀態，進行燈號顯示
                var findPort = from port in NodeManagement.GetLoadPortList()
                               where port.Controller.Equals(Device_ID) && !port.ByPass && port.Type.Equals("LOADPORT")
                               select port;

                foreach (Node port in findPort)
                {
                    port.ExcuteScript("LoadPortFoupOut", "LoadPortFoup", "", true);
                }
                CommunicationsUpdate.UpdateConnection(Device_ID, true);
            }
            else
            {
                CommunicationsUpdate.UpdateConnection(Device_ID, false);
            }


            logger.Debug("On_Controller_State_Changed");
        }

        public void On_Port_Begin(string PortName, string FormName)
        {
            logger.Debug("On_Port_Begin");

            WaferAssignUpdate.RefreshMapping(PortName);
            WaferAssignUpdate.RefreshMapping(NodeManagement.Get(PortName).DestPort);
            try
            {
                switch (FormName)
                {
                    case "Running":
                        MonitoringUpdate.UpdateUseState(PortName, true);
                        WaferAssignUpdate.UpdateUseState(PortName, true);
                        break;

                }
            }
            catch (Exception e)
            {
                logger.Error(e.StackTrace);
            }
        }

        public void On_Port_Finished(string PortName, string FormName)
        {
            logger.Debug("On_Port_Finished");
            try
            {

                WaferAssignUpdate.RefreshMapping(PortName);
                WaferAssignUpdate.RefreshMapping(NodeManagement.Get(PortName).DestPort);
                Node Port = NodeManagement.Get(PortName);
                Node DestPort = NodeManagement.Get(Port.DestPort);
                switch (FormName)
                {
                    case "Running":
                        //RunningUpdate.UpdateUseState(PortName, false);
                        MonitoringUpdate.UpdateUseState(PortName, false);
                        WaferAssignUpdate.UpdateUseState(PortName, false);
                        if (!Port.ByPass)
                        {
                            Port.ExcuteScript("LoadPortUnloadAndLoad", "Running_Port_Finished");
                            DestPort.ExcuteScript("LoadPortUnloadAndLoad", "Running_Port_Finished");
                        }
                        else
                        {
                            RunningUpdate.ReverseRunning(Port.Name);
                        }
                        //RunningUpdate.ReverseRunning(PortName);

                        break;
                    default:
                        Port.ExcuteScript("LoadPortUnload", "Port_Finished");
                        break;
                }
            }
            catch (Exception e)
            {
                logger.Error(e.StackTrace);
            }
        }

        public void On_Task_Finished(string FormName, string LapsedTime, int LapsedWfCount, int LapsedLotCount)
        {
            logger.Debug("On_Task_Finished");
            //NodeStatusUpdate.UpdateCurrentState("Idle");
            try
            {
                RunningUpdate.UpdateRunningInfo("LapsedTime", LapsedTime);
                RunningUpdate.UpdateRunningInfo("TransCount", "-1");
                RunningUpdate.UpdateRunningInfo("LapsedWfCount", LapsedWfCount.ToString());
                RunningUpdate.UpdateRunningInfo("LapsedLotCount", LapsedLotCount.ToString());
                RunningUpdate.UpdateRunningInfo("WPH", (LapsedWfCount / Convert.ToDouble(LapsedTime) * 3600).ToString());
                MonitoringUpdate.UpdateWPH(Math.Round((LapsedWfCount / Convert.ToDouble(LapsedTime) * 3600), 1).ToString());
                foreach(Node port in NodeManagement.GetLoadPortList())
                {
                    WaferAssignUpdate.ResetAssignCM(port.Name,true);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.StackTrace);
            }

        }

        public void On_Mode_Changed(string Mode)
        {
            logger.Debug("On_Mode_Changed");

            ConnectionStatusUpdate.UpdateModeStatus(Mode);
            RunningUpdate.UpdateModeStatus(Mode);
            foreach (Node port in NodeManagement.GetLoadPortList())
            {
                WaferAssignUpdate.RefreshMapping(port.Name);
                if (Mode.Equals("Stop"))
                {
                    WaferAssignUpdate.ResetAssignCM(port.Name,true);
                }
            }
            
        }

        public void On_Job_Location_Changed(Job Job)
        {
            logger.Debug("On_Job_Location_Changed");
            MonitoringUpdate.UpdateJobMove(Job.Job_Id);
            if (Job.Position.ToUpper().Equals("ALIGNER01"))
            {
                Job.DefaultOCR = "OCR01";
            }
            if (Job.Position.ToUpper().Equals("ALIGNER02"))
            {
                Job.DefaultOCR = "OCR02";
            }
        }

        public void On_Script_Finished(Node Node, string ScriptName, string FormName)
        {
            logger.Debug("On_Script_Finished: " + Node.Name + " Script:" + ScriptName + " Finished, Form name:" + FormName);
            switch (FormName)
            {
                case "Initialize":
                   
                    Node.InitialObject();
                    Node.InitialComplete = true;
                    switch (Node.Type)
                    {
                        case "ROBOT":
                        case "ALIGNER":
                            Node.State = "Idle";
                            break;
                        case "LOADPORT":
                            Node.State = "Ready To Load";
                            break;
                    }
                    if (!NodeManagement.IsNeedInitial())
                    {
                        NodeStatusUpdate.UpdateCurrentState("Idle");
                        ConnectionStatusUpdate.UpdateInitial(true.ToString());
                        foreach (Node port in NodeManagement.GetLoadPortList())
                        {
                            if (!port.ByPass)
                            {
                                Transaction txn = new Transaction();
                                txn.Method = Transaction.Command.LoadPortType.ReadStatus;
                                txn.FormName = "InitialFinish";
                                port.SendCommand(txn);
                            }
                        }
                    }
                    break;
                case "FormManual-Script":

                    switch (Node.Type)
                    {
                        case "ROBOT":
                            ManualRobotStatusUpdate.UpdateGUI(new Transaction(), Node.Name, "");//update 手動功能畫面
                            break;
                    }
                    break;

                case "Running_Port_Finished":
                    if (ScriptName.Equals("LoadPortUnloadAndLoad"))
                    {
                        Node Port;
                        Node DestPort;

                        Node.PortUnloadAndLoadFinished = true;
                        if (!Node.DestPort.Equals(""))
                        {
                            Port = Node;
                            DestPort = NodeManagement.Get(Node.DestPort);
                            // SpinWait.SpinUntil(() => (Port.IsMapping && Port.JobList.Count!=0 && DestPort.IsMapping && DestPort.JobList.Count != 0) || RouteCtrl.GetMode().Equals("Stop") , 99999999);

                            SpinWait.SpinUntil(() => (Port.PortUnloadAndLoadFinished && DestPort.PortUnloadAndLoadFinished) || RouteCtrl.GetMode().Equals("Stop"), 99999999);

                            if (!RouteCtrl.GetMode().Equals("Stop") && Port.PortUnloadAndLoadFinished && DestPort.PortUnloadAndLoadFinished)
                            {
                                Port.PortUnloadAndLoadFinished = false;
                                DestPort.PortUnloadAndLoadFinished = false;
                                RunningUpdate.ReverseRunning(Port.Name);
                            }
                        }
                        //else
                        //{
                        //    var findPort = from port in NodeManagement.GetLoadPortList()
                        //                   where port.DestPort.Equals(Node.Name)
                        //                   select port;

                        //    if (findPort.Count() != 0)
                        //    {
                        //        Port = findPort.First();
                        //        DestPort = Node;
                        //        //SpinWait.SpinUntil(() => (Port.IsMapping && Port.JobList.Count != 0 && DestPort.IsMapping && DestPort.JobList.Count != 0) || RouteCtrl.GetMode().Equals("Stop"), 99999999);

                        //        //SpinWait.SpinUntil(() => (Port.IsMapping && DestPort.IsMapping) || RouteCtrl.GetMode().Equals("Stop"), 99999999);
                        //        if (!RouteCtrl.GetMode().Equals("Stop") && Port.PortUnloadAndLoadFinished && DestPort.PortUnloadAndLoadFinished)
                        //        {

                        //            RunningUpdate.ReverseRunning(Port.Name);

                        //        }

                        //    }
                        //}

                    }

                    break;
            }
        }

        //private void vSBRobotStatus_Scroll(object sender, ScrollEventArgs e)
        //{
        //    //pbRobotState.Top = -vSBRobotStatus.Value;
        //}

        //private void vSBAlignerStatus_Scroll(object sender, ScrollEventArgs e)
        //{
        //    //pbAlignerState.Top = -vSBAlignerStatus.Value;
        //}

        //private void vSBPortStatus_Scroll(object sender, ScrollEventArgs e)
        //{
        //    //pbPortState.Top = -vSBPortStatus.Value;
        //}






        public void On_Connection_Status_Report(string DIOName, string Status)
        {
            ConnectionStatusUpdate.UpdateControllerStatus(DIOName, Status);
        }


        public void On_Data_Chnaged(string Parameter, string Value)
        {
            DIOUpdate.UpdateDIOStatus(Parameter, Value);

        }

        public void On_Alarm_Happen(string DIOName, string ErrorCode)
        {

            AlarmInfo CurrentAlarm = new AlarmInfo();
            CurrentAlarm.NodeName = DIOName;
            CurrentAlarm.AlarmCode = ErrorCode;
            CurrentAlarm.NeedReset = false;
            try
            {

                AlarmMessage Detail = AlmMapping.Get("SANWA", "SYSTEM", CurrentAlarm.AlarmCode);

                CurrentAlarm.SystemAlarmCode = Detail.CodeID;
                CurrentAlarm.Desc = Detail.Code_Cause;
                CurrentAlarm.EngDesc = Detail.Code_Cause_English;
                CurrentAlarm.Type = Detail.Code_Type;
                CurrentAlarm.IsStop = Detail.IsStop;
                if (CurrentAlarm.IsStop)
                {
                    RouteCtrl.Stop();
                }
            }
            catch (Exception e)
            {
                CurrentAlarm.Desc = "未定義";
                logger.Error(DIOName + "(GetAlarmMessage)" + e.Message + "\n" + e.StackTrace);
            }
            CurrentAlarm.TimeStamp = DateTime.Now;
            AlarmManagement.Add(CurrentAlarm);
            AlarmUpdate.UpdateAlarmList(AlarmManagement.GetAll());
            AlarmUpdate.UpdateAlarmHistory(AlarmManagement.GetHistory());
        }

        public void On_Connection_Error(string DIOName, string ErrorMsg)
        {
            //斷線 發ALARM
            logger.Debug("On_Error_Occurred");
            AlarmInfo CurrentAlarm = new AlarmInfo();
            CurrentAlarm.NodeName = DIOName;
            CurrentAlarm.AlarmCode = "00200001";
            CurrentAlarm.NeedReset = false;
            try
            {

                AlarmMessage Detail = AlmMapping.Get("SANWA", "DIO", CurrentAlarm.AlarmCode);

                CurrentAlarm.SystemAlarmCode = Detail.CodeID;
                CurrentAlarm.Desc = Detail.Code_Cause;
                CurrentAlarm.EngDesc = Detail.Code_Cause_English;
                CurrentAlarm.Type = Detail.Code_Type;
                CurrentAlarm.IsStop = Detail.IsStop;
                if (CurrentAlarm.IsStop)
                {
                    RouteCtrl.Stop();
                }
            }
            catch (Exception e)
            {
                CurrentAlarm.Desc = "未定義";
                logger.Error(DIOName + "(GetAlarmMessage)" + e.Message + "\n" + e.StackTrace);
            }
            CurrentAlarm.TimeStamp = DateTime.Now;
            AlarmManagement.Add(CurrentAlarm);
            AlarmUpdate.UpdateAlarmList(AlarmManagement.GetAll());
            AlarmUpdate.UpdateAlarmHistory(AlarmManagement.GetHistory());
        }





        private void Signal_MouseClick(object sender, MouseEventArgs e)
        {
            switch ((sender as Button).Name)
            {
                case "RED_Signal":
                    if (DIO.GetIO("OUT", "RED").ToUpper().Equals("TRUE"))
                    {
                        DIO.SetIO("RED", "False");
                    }
                    else
                    {
                        DIO.SetIO("RED", "True");
                    }
                    break;
                case "ORANGE_Signal":
                    if (DIO.GetIO("OUT", "ORANGE").ToUpper().Equals("TRUE"))
                    {
                        DIO.SetIO("ORANGE", "False");
                    }
                    else
                    {
                        DIO.SetIO("ORANGE", "True");
                    }
                    break;
                case "GREEN_Signal":
                    if (DIO.GetIO("OUT", "GREEN").ToUpper().Equals("TRUE"))
                    {
                        DIO.SetIO("GREEN", "False");
                    }
                    else
                    {
                        DIO.SetIO("GREEN", "True");
                    }
                    break;
                case "BLUE_Signal":
                    if (DIO.GetIO("OUT", "BLUE").ToUpper().Equals("TRUE"))
                    {
                        DIO.SetIO("BLUE", "False");
                    }
                    else
                    {
                        DIO.SetIO("BLUE", "True");
                    }
                    break;
                case "BUZZER1_Signal":
                    if (DIO.GetIO("OUT", "BUZZER1").ToUpper().Equals("TRUE"))
                    {
                        DIO.SetIO("BUZZER1", "False");
                    }
                    else
                    {
                        DIO.SetIO("BUZZER1", "True");
                    }
                    break;
                case "BUZZER2_Signal":
                    if (DIO.GetIO("OUT", "BUZZER2").ToUpper().Equals("TRUE"))
                    {
                        DIO.SetIO("BUZZER2", "False");
                    }
                    else
                    {
                        DIO.SetIO("BUZZER2", "True");
                    }
                    break;
            }
        }

        private void Conn_gv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 1:
                    switch (e.Value)
                    {
                        case "Connecting":
                            e.CellStyle.BackColor = Color.Yellow;
                            e.CellStyle.ForeColor = Color.Black;
                            break;
                        case "Connected":
                            e.CellStyle.BackColor = Color.Green;
                            e.CellStyle.ForeColor = Color.White;
                            break;
                        default:
                            e.CellStyle.BackColor = Color.Red;
                            e.CellStyle.ForeColor = Color.White;
                            break;

                    }
                    break;

            }
        }

        private void Connection_btn_Click(object sender, EventArgs e)
        {

            //if (Connection_btn.Tag.ToString() == "Offline")
            //{
            //    RouteCtrl.ConnectAll();

            //    ConnectionStatusUpdate.UpdateOnlineStatus("Connecting");
            //}
            //else
            //{
            //    RouteCtrl.DisconnectAll();
            //    ConnectionStatusUpdate.UpdateOnlineStatus("Offline");
            //}

        }

        private void Mode_btn_Click(object sender, EventArgs e)
        {

            if (Mode_btn.Tag.ToString() == "Manual")
            {

                //if (Connection_btn.Tag.ToString() == "Offline")
                //{
                //    MessageBox.Show("尚未連線");
                //    return;
                //}




                if (AlarmManagement.HasCritical())
                {
                    MessageBox.Show("關鍵Alarm尚未解除");
                }
                else
                {
                    if (NodeManagement.IsNeedInitial())
                    {
                        ConnectionStatusUpdate.UpdateInitial(false.ToString());
                        MessageBox.Show("請先執行Initial");
                    }
                    else
                    {

                        ConnectionStatusUpdate.UpdateInitial(false.ToString());
                        NodeStatusUpdate.UpdateCurrentState(NodeManagement.GetCurrentState());
                        RouteCtrl.Start("Running");
                        //ConnectionStatusUpdate.UpdateModeStatus("Start");


                    }
                }
            }
            else
            {
                RouteCtrl.Stop();
                //ConnectionStatusUpdate.UpdateModeStatus("Manual");

                ConnectionStatusUpdate.UpdateInitial(false.ToString());
            }
        }

        public void On_InterLock_Report(Node Node, bool InterLock)
        {
            //throw new NotImplementedException();
        }

        private void Pause_btn_Click(object sender, EventArgs e)
        {
            if (RouteCtrl.GetMode().Equals("Start"))
            {

                RouteCtrl.Pause();
                NodeStatusUpdate.UpdateCurrentState("Run");
                Pause_btn.Text = "Continue";

            }
            else if (RouteCtrl.GetMode().Equals("Pause"))
            {
                RouteCtrl.Continue();
                NodeStatusUpdate.UpdateCurrentState("Idle");
                Pause_btn.Text = "Pause";
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            FormQuery form = new FormQuery();
            form.Show();
        }


        private void tbcMian_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcMian.SelectedTab.Text.Equals("Status"))
            {
                formStatus.Focus();
            }
        }

        private void menuMaintenace_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            foreach (ToolStripMenuItem item in menuMaintenace.Items)
            {
                string user_group = lbl_login_group.Text;
                string fun_form = "FormMain";
                string fun_ref = item.Name;
                Boolean enable = AuthorityUpdate.getFuncEnable(user_group, fun_form, fun_ref);
                item.Enabled = enable;
            }
        }

        private void Conn_gv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

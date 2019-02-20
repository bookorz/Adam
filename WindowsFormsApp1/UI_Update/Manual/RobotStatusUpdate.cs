using Adam.Util;
using log4net;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferControl.Management;

namespace Adam.UI_Update.Manual
{
    class ManualRobotStatusUpdate
    {
        static ILog logger = LogManager.GetLogger(typeof(ManualRobotStatusUpdate));
        //delegate void ShowMessage(string str);
        delegate void UpdateGUI_D(Transaction txn, string name, string msg);
        delegate void UpdateStatus_D(string device);
        delegate void UpdateRobotStatus_D(string name, string status);

        public static void UpdateGUI(Transaction txn, string name, string msg)
        {
            try
            {
                string method = txn.Method;
                Form manual = Application.OpenForms["FormManual"];

                if (manual == null)
                    return;

                if (manual.InvokeRequired)
                {
                    UpdateGUI_D ph = new UpdateGUI_D(UpdateGUI);
                    manual.BeginInvoke(ph, txn, name, msg);
                }
                else
                {
                    switch (method)
                    {
                        case Transaction.Command.RobotType.GetStatus:
                            StateUtil.UpdateSTS(name, msg);
                            break;
                        case Transaction.Command.RobotType.GetCombineStatus:
                            StateUtil.UpdateCombineStatus(name, msg);
                            break;
                        case Transaction.Command.RobotType.GetSpeed:
                            StateUtil.UpdateSP(name, msg);
                            break;
                        case Transaction.Command.RobotType.GetRIO:
                            StateUtil.UpdateRIO(name, msg);
                            break;
                        case Transaction.Command.RobotType.GetError:
                            StateUtil.UpdateError(name, msg);
                            break;
                        case Transaction.Command.RobotType.GetMode:
                            StateUtil.UpdateMode(name, msg);
                            break;
                        case Transaction.Command.RobotType.GetSV:
                            StateUtil.UpdateSV(name, msg);
                            break;
                        default:
                            //manual.Cursor = Cursors.Default;
                            //Control tbcManual = manual.Controls.Find("tbcManual", true).FirstOrDefault() as Control;
                            //tbcManual.Enabled = true;
                            return;
                    }
                    UpdateStatus(name);
                }
            }
            catch (Exception e)
            {
                logger.Error("Robot Manual Function: fail.");
                Console.WriteLine("Exception caught: {0}", e);
            }
        }

        public static void UpdateStatus(string device)
        {
            Form manual = Application.OpenForms["FormManual"];

            if (manual == null)
                return;

            if (manual.InvokeRequired)
            {
                UpdateStatus_D ph = new UpdateStatus_D(UpdateStatus);
                manual.BeginInvoke(ph, device);
            }
            else
            {
                StateUtil.Init();
                RobotState robot = StateUtil.GetDeviceState(device) != null ? (RobotState)StateUtil.GetDeviceState(device) : null;
                if (robot == null)
                {
                    return;
                }
                
                Control nudRSpeed = manual.Controls.Find("nudRSpeed", true).FirstOrDefault() as Control;
                if (nudRSpeed != null)
                {
                    try
                    {
                        nudRSpeed.Text = robot.Speed.Equals("00") ? "100" : Int32.Parse(robot.Speed).ToString();
                    }
                    catch (Exception)
                    {
                        nudRSpeed.Text = robot.Speed;
                    }
                   
                }
                Control tbRRwaferSensor = manual.Controls.Find("tbRRwaferSensor", true).FirstOrDefault() as Control;
                if (tbRRwaferSensor != null)
                {
                    tbRRwaferSensor.Text = robot.Present_R.Equals("1") ? "ON" : "OFF";
                    Color color = new Color();
                    switch (tbRRwaferSensor.Text)
                    {
                        case "OFF":
                            color = Color.MintCream;
                            break;
                        case "ON":
                            color = Color.LightGreen;
                            break;
                        default:
                            color = Color.White;
                            break;
                    }
                    tbRRwaferSensor.BackColor = color;
                }
                Control tbRRVacuSolenoid = manual.Controls.Find("tbRRVacuSolenoid", true).FirstOrDefault() as Control;
                if (tbRRVacuSolenoid != null)
                {
                    tbRRVacuSolenoid.Text = robot.Vacuum_R.Equals("1") ? "ON" : "OFF"; Color color = new Color();
                    switch (tbRRVacuSolenoid.Text)
                    {
                        case "OFF":
                            color = Color.MintCream;
                            break;
                        case "ON":
                            color = Color.LightGreen;
                            break;
                        default:
                            color = Color.White;
                            break;
                    }
                    tbRRVacuSolenoid.BackColor = color;
                }
                Control tbRLwaferSensor = manual.Controls.Find("tbRLwaferSensor", true).FirstOrDefault() as Control;
                if (tbRLwaferSensor != null)
                {
                    tbRLwaferSensor.Text = robot.Present_L.Equals("1") ? "ON" : "OFF"; Color color = new Color();
                    switch (tbRLwaferSensor.Text)
                    {
                        case "OFF":
                            color = Color.MintCream;
                            break;
                        case "ON":
                            color = Color.LightGreen;
                            break;
                        default:
                            color = Color.White;
                            break;
                    }
                    tbRLwaferSensor.BackColor = color;
                }
                Control tbRLVacuSolenoid = manual.Controls.Find("tbRLVacuSolenoid", true).FirstOrDefault() as Control;
                if (tbRLVacuSolenoid != null)
                {
                    tbRLVacuSolenoid.Text = robot.Vacuum_L.Equals("1") ? "ON" : "OFF"; Color color = new Color();
                    switch (tbRLVacuSolenoid.Text)
                    {
                        case "OFF":
                            color = Color.MintCream;
                            break;
                        case "ON":
                            color = Color.LightGreen;
                            break;
                        default:
                            color = Color.White;
                            break;
                    }
                    tbRLVacuSolenoid.BackColor = color;
                }
                string state = robot.State != null ? robot.State.Trim() : "";
                Control tbRServo = manual.Controls.Find("tbRServo", true).FirstOrDefault() as Control;
                if (tbRServo != null)
                {
                    tbRServo.Text = robot.Servo;
                    Color color = new Color();
                    switch (tbRServo.Text)
                    {
                        case "OFF":
                            color = Color.MintCream;
                            break;
                        case "ON":
                            color = Color.LightGreen;
                            break;
                        default:
                            color = Color.White;
                            break;
                    }
                    tbRServo.BackColor = color;
                }
                Control tbRError = manual.Controls.Find("tbRError", true).FirstOrDefault() as Control;
                if (tbRError != null)
                {
                    tbRError.Text = robot.Error;
                }
                ComboBox cbRMode = manual.Controls.Find("cbRMode", true).FirstOrDefault() as ComboBox;
                if (cbRMode != null)
                {
                    switch(robot.Mode.ToUpper())
                    {
                        case "REAL":
                            cbRMode.SelectedIndex = 0;//kawasaki
                            break;
                        case "SIMU":
                            cbRMode.SelectedIndex = 1;//kawasaki
                            break;
                        case "":
                            cbRMode.SelectedIndex = -1;
                            break;
                        default:
                            cbRMode.SelectedIndex = Int32.Parse(robot.Mode);
                            break;
                    }
                    
                }
            }
                
        }

        public static void UpdateRobotStatus(string name, string status)
        {
            Form manual = Application.OpenForms["FormManual"];

            if (manual == null)
                return;

            if (manual.InvokeRequired)
            {
                UpdateRobotStatus_D ph = new UpdateRobotStatus_D(UpdateRobotStatus);
                manual.BeginInvoke(ph, name, status);
            }
            else
            {
                StateUtil.Init();
                RobotState robot = StateUtil.GetDeviceState(name) != null ? (RobotState)StateUtil.GetDeviceState(name) : null;
                if (robot == null)
                {
                    return;
                }
                //update robot status           
                TextBox tbRStatus = manual.Controls.Find("tbRStatus", true).FirstOrDefault() as TextBox;
                tbRStatus.Text = status;
                switch (status)
                {
                    case "RUN":
                        tbRStatus.BackColor = Color.Lime;
                        break;
                    case "IDLE":
                        tbRStatus.BackColor = Color.Yellow;
                        break;
                }
            }
                
        }

        public static void UpdateRobotConnection(string name, string status)
        {
            Form manual = Application.OpenForms["FormManual"];

            if (manual == null)
                return;

            TextBox tb = manual.Controls.Find("RobotConnection_tb", true).FirstOrDefault() as TextBox;
            if (tb == null)
                return;

            if (tb.InvokeRequired)
            {
                UpdateRobotStatus_D ph = new UpdateRobotStatus_D(UpdateRobotConnection);
                tb.BeginInvoke(ph, name, status);
            }
            else
            {
                tb.Text = status;
               
            }

        }

        
        
    }
}

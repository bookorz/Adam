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
    class ManualAlignerStatusUpdate
    {
        static ILog logger = LogManager.GetLogger(typeof(ManualAlignerStatusUpdate));
        //delegate void ShowMessage(string str);
        delegate void UpdateGUI_D(Transaction txn, string name, string msg);
        delegate void UpdateStatus_D(string device);
        delegate void UpdateAlignerStatus_D(string name, string status);

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
                        case Transaction.Command.AlignerType.GetStatus:
                            StateUtil.UpdateSTS(name, msg);
                            break;
                        case Transaction.Command.RobotType.GetCombineStatus:
                            StateUtil.UpdateCombineStatus(name, msg);
                            break;
                        case Transaction.Command.AlignerType.GetSpeed:
                            StateUtil.UpdateSP(name, msg);
                            break;
                        case Transaction.Command.AlignerType.GetRIO:
                            StateUtil.UpdateRIO(name, msg);
                            break;
                        case Transaction.Command.AlignerType.GetError:
                            StateUtil.UpdateError(name, msg);
                            break;
                        case Transaction.Command.AlignerType.GetMode:
                            StateUtil.UpdateMode(name, msg);
                            break;
                        case Transaction.Command.AlignerType.GetSV:
                            StateUtil.UpdateSV(name, msg);
                            break;
                        default:
                            manual.Cursor = Cursors.Default;
                            Control tbcManual = manual.Controls.Find("tbcManual", true).FirstOrDefault() as Control;
                            tbcManual.Enabled = true;
                            return;
                    }
                    UpdateStatus(name);
                }
            }
            catch(Exception e)
            {
                logger.Error("Aligner Manual Function: fail.");
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
                AlignerState aligner = StateUtil.GetDeviceState(device) != null ? (AlignerState)StateUtil.GetDeviceState(device) : null;
                if (aligner == null)
                {
                    return;
                }

                Control tbStatus = null;
                Control tbServo = null;
                Control tbWaferSensor = null;
                Control tbVacSolenoid = null;
                NumericUpDown nudSpeed = null;
                Control tbError = null;
                ComboBox cbMode = null;

                if (device.Equals("ALIGNER01"))
                {
                    tbStatus = manual.Controls.Find("tbA1Status", true).FirstOrDefault() as Control;
                    tbServo = manual.Controls.Find("tbA1Servo", true).FirstOrDefault() as Control;
                    tbWaferSensor = manual.Controls.Find("tbA1WaferSensor", true).FirstOrDefault() as Control;
                    tbVacSolenoid = manual.Controls.Find("tbA1VacSolenoid", true).FirstOrDefault() as Control;
                    nudSpeed = manual.Controls.Find("nudA1Speed", true).FirstOrDefault() as NumericUpDown;
                    tbError = manual.Controls.Find("tbA1Error", true).FirstOrDefault() as Control;
                    cbMode = manual.Controls.Find("cbA1Mode", true).FirstOrDefault() as ComboBox;
                }
                else if (device.Equals("ALIGNER02"))
                {
                    tbStatus = manual.Controls.Find("tbA2Status", true).FirstOrDefault() as Control;
                    tbServo = manual.Controls.Find("tbA2Servo", true).FirstOrDefault() as Control;
                    tbWaferSensor = manual.Controls.Find("tbA2WaferSensor", true).FirstOrDefault() as Control;
                    tbVacSolenoid = manual.Controls.Find("tbA2VacSolenoid", true).FirstOrDefault() as Control;
                    nudSpeed = manual.Controls.Find("nudA2Speed", true).FirstOrDefault() as NumericUpDown;
                    tbError = manual.Controls.Find("tbA2Error", true).FirstOrDefault() as Control;
                    cbMode = manual.Controls.Find("cbA2Mode", true).FirstOrDefault() as ComboBox;
                }

                
                if (tbServo != null)
                {
                    tbServo.Text = aligner.Servo;
                    Color color = new Color();
                    switch (tbServo.Text)
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
                    tbServo.BackColor = color;
                }
                if (tbWaferSensor != null)
                {
                    tbWaferSensor.Text = aligner.Present.Equals("1") ? "ON" : "OFF";
                    Color color = new Color();
                    switch (tbWaferSensor.Text)
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
                    tbWaferSensor.BackColor = color;
                }
                if (tbVacSolenoid != null)
                {
                    tbVacSolenoid.Text = aligner.Vacuum.Equals("1") ? "ON" : "OFF";
                    Color color = new Color();
                    switch (tbVacSolenoid.Text)
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
                    tbVacSolenoid.BackColor = color;
                }
                if (nudSpeed != null)
                {
                    try
                    {
                        nudSpeed.Text = aligner.Speed.Equals("00") ? "100" : Int32.Parse(aligner.Speed).ToString();
                    }
                    catch (Exception)
                    {
                        nudSpeed.Text = aligner.Speed;
                    }
                    
                }
                if (tbError != null)
                {
                    tbError.Text = aligner.Error;
                }
                if (cbMode != null)
                {
                    switch (aligner.Mode.ToUpper())
                    {
                        case "REAL":
                            cbMode.SelectedIndex = 0;//kawasaki
                            break;
                        case "SIMU":
                            cbMode.SelectedIndex = 1;//kawasaki
                            break;
                        case "":
                            cbMode.SelectedIndex = -1;
                            break;
                        default:
                            cbMode.SelectedIndex = Int32.Parse(aligner.Mode);
                            break;
                    }
                }
            }
                

        }

        public static void UpdateAlignerStatus(string name, string status)
        {
            Form manual = Application.OpenForms["FormManual"];

            if (manual == null)
                return;

            if (manual.InvokeRequired)
            {
                UpdateAlignerStatus_D ph = new UpdateAlignerStatus_D(UpdateAlignerStatus);
                manual.BeginInvoke(ph, name, status);
            }
            else
            {
                StateUtil.Init();
                AlignerState aligner = StateUtil.GetDeviceState(name) != null ? (AlignerState)StateUtil.GetDeviceState(name) : null;
                if (aligner == null)
                {
                    return;
                }
                //update robot status
                switch (name)
                {
                    case "Aligner01":
                        Control tbA1Status = manual.Controls.Find("tbA1Status", true).FirstOrDefault() as Control;
                        tbA1Status.Text = status;
                        switch (status)
                        {
                            case "RUN":
                                tbA1Status.BackColor = Color.Lime;
                                break;
                            case "IDLE":
                                tbA1Status.BackColor = Color.Yellow;
                                break;
                        }
                        break;
                    case "Aligner02":
                        Control tbA2Status = manual.Controls.Find("tbA2Status", true).FirstOrDefault() as Control;
                        tbA2Status.Text = status;
                        switch (status)
                        {
                            case "RUN":
                                tbA2Status.BackColor = Color.Lime;
                                break;
                            case "IDLE":
                                tbA2Status.BackColor = Color.Yellow;
                                break;
                        }
                        break;
                }
            }
                
        }

        public static void UpdateAlignerConnection(string name, string status)
        {
            Form manual = Application.OpenForms["FormManual"];

            if (manual == null)
                return;

            TextBox tb = manual.Controls.Find(name + "Connection_tb", true).FirstOrDefault() as TextBox;
            if (tb == null)
                return;

            if (tb.InvokeRequired)
            {
                UpdateAlignerStatus_D ph = new UpdateAlignerStatus_D(UpdateAlignerConnection);
                tb.BeginInvoke(ph, name, status);
            }
            else
            {
                tb.Text = status;

            }

        }

    }
}

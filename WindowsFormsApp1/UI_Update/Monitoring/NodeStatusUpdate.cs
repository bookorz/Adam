using log4net;
using Newtonsoft.Json;
using SANWA.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferControl.Management;

namespace Adam.UI_Update.Monitoring
{
    class NodeStatusUpdate
    {
        static ILog logger = LogManager.GetLogger(typeof(NodeStatusUpdate));
        delegate void UpdateNode(string Device_ID, string State);
        delegate void UpdateState(string State);
        static List<Setting> SignalSetting;
        class Setting
        {
            public string Eqp_Status { get; set; }
            public bool Is_Alarm { get; set; }
            public string Red { get; set; }
            public string Orange { get; set; }
            public string Blue { get; set; }
            public string Green { get; set; }
            public string Buzzer1 { get; set; }
            public string Buzzer2 { get; set; }
        }

        public static void InitialSetting()
        {
            DBUtil dBUtil = new DBUtil();

            string Sql = @"select * from config_signal_tower";
            DataTable dt = dBUtil.GetDataTable(Sql, null);

            string str_json = JsonConvert.SerializeObject(dt, Formatting.Indented);
            SignalSetting = JsonConvert.DeserializeObject<List<Setting>>(str_json);

        }

        public static void UpdateNodeState(string Device_ID, string State)
        {
            try
            {
                Form form = Application.OpenForms["FormMain"];
                TextBox State_tb;
                if (form == null)
                    return;

                State_tb = form.Controls.Find(Device_ID + "_State", true).FirstOrDefault() as TextBox;
                if (State_tb == null)
                    return;

                if (State_tb.InvokeRequired)
                {
                    UpdateNode ph = new UpdateNode(UpdateNodeState);
                    State_tb.BeginInvoke(ph, Device_ID, State);
                }
                else
                {
                    State_tb.Text = State;
                    switch (State)
                    {
                        case "Run":
                            State_tb.BackColor = Color.Lime;
                            //UpdateCurrentState();
                            break;
                        case "Idle":
                            State_tb.BackColor = Color.Orange;
                            //UpdateCurrentState();
                            break;
                        case "Ready To Load":
                            State_tb.BackColor = Color.DarkGray;
                            break;
                        case "Load Complete":
                            State_tb.BackColor = Color.Green;
                            break;
                        case "Ready To UnLoad":
                            State_tb.BackColor = Color.DarkOrange;
                            break;
                        case "UnLoad Complete":
                            State_tb.BackColor = Color.Blue;
                            break;
                        case "Alarm":
                            State_tb.BackColor = Color.Red;
                            //UpdateCurrentState();
                            break;
                    }

                }


            }
            catch
            {
                logger.Error("UpdateControllerStatus: Update fail.");
            }
        }

        public static void UpdateCurrentState(string State)
        {
            try
            {
                Form form = Application.OpenForms["FormMain"];

                if (form == null)
                    return;

                Button state_btn = form.Controls.Find("CurrentState_btn", true).FirstOrDefault() as Button;

                if (state_btn == null)
                    return;

                if (state_btn.InvokeRequired)
                {
                    UpdateState ph = new UpdateState(UpdateCurrentState);
                    state_btn.BeginInvoke(ph, State);
                }
                else
                {
                    if (SignalSetting == null)
                    {
                        InitialSetting();
                    }
                    state_btn.Text = State;
                    Dictionary<string, string> Params = new Dictionary<string, string>();

                    var findSetting = from Setting in SignalSetting
                                      where Setting.Eqp_Status.Equals(State.ToUpper()) && Setting.Is_Alarm == (AlarmManagement.GetAll().Count!=0)
                                      select Setting;

                    if (findSetting.Count() != 0)
                    {
                        Setting each = findSetting.First();
                        if (!each.Blue.Equals("BLINK"))
                        {
                            Params.Add("BLUE", each.Blue);
                        }
                        else
                        {
                            FormMain.DIO.SetBlink("BLUE", "True");
                        }
                        if (!each.Green.Equals("BLINK"))
                        {
                            Params.Add("GREEN", each.Green);
                        }
                        else
                        {
                            FormMain.DIO.SetBlink("GREEN", "True");
                        }
                        if (!each.Red.Equals("BLINK"))
                        {
                            Params.Add("RED", each.Red);
                        }
                        else
                        {
                            FormMain.DIO.SetBlink("RED", "True");
                        }
                        if (!each.Orange.Equals("BLINK"))
                        {
                            Params.Add("ORANGE", each.Orange);
                        }
                        else
                        {
                            FormMain.DIO.SetBlink("ORANGE", "True");
                        }

                        FormMain.DIO.SetIO(Params);
                    }

                }


            }
            catch (Exception e)
            {
                logger.Error("UpdateCurrentState: Update fail.:" + e.StackTrace);
            }
        }

    }
}

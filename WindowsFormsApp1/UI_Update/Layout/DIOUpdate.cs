using log4net;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adam.UI_Update.Layout
{
    class DIOUpdate
    {
        static ILog logger = LogManager.GetLogger(typeof(DIOUpdate));
        delegate void UpdateDIO(string Parameter, string Value);
        delegate void GetBool();

      
        
        public static void UpdateDIOStatus(string Parameter, string Value)
        {
            try
            {
                Form form = Application.OpenForms["FormMain"];

                if (form == null)
                    return;

                Button Signal = form.Controls.Find(Parameter + "_Signal", true).FirstOrDefault() as Button;
               
                if (Signal == null)
                    return;

                if (Signal.InvokeRequired)
                {
                    UpdateDIO ph = new UpdateDIO(UpdateDIOStatus);
                    Signal.BeginInvoke(ph, Parameter, Value);
                }
                else
                {

                    switch (Parameter)
                    {
                        case "RED":
                        case "ORANGE":
                        case "GREEN":
                        case "BLUE":
                            if (Value.ToUpper().Equals("TRUE"))
                            {
                                switch (Parameter)
                                {
                                    case "RED":
                                        Signal.BackColor = Color.Red;
                                        break;
                                    case "ORANGE":
                                        Signal.BackColor = Color.DarkOrange;
                                        break;
                                    case "GREEN":
                                        Signal.BackColor = Color.Green;
                                        break;
                                    case "BLUE":
                                        Signal.BackColor = Color.Blue;
                                        break;
                                }
                            }
                            else
                            {
                                Signal.BackColor = Color.Silver;
                            }
                            break;
                        case "BUZZER1":
                        case "BUZZER2":
                            if (Value.ToUpper().Equals("TRUE"))
                            {
                                Signal.BackColor = Color.Yellow;
                            }
                            else
                            {
                                Signal.BackColor = Color.Silver;
                            }
                            break;
                        default:
                            switch (Value.ToUpper())
                            {
                                case "TRUE":
                                    Signal.BackColor = Color.Lime;
                                    break;
                                case "FALSE":
                                    Signal.BackColor = Color.Red;
                                    break;
                                case "BLINK":
                                    if(Signal.BackColor == Color.Red)
                                    {
                                        Signal.BackColor = Color.DimGray;
                                    }
                                    else
                                    {
                                        Signal.BackColor = Color.Red;
                                    }
                                    break;
                            }
                            break;
                    }


                }


            }
            catch(Exception e)
            {
                logger.Error("UpdateDIOStatus: Update fail.");
            }
        }

        public static void UpdateSignalTower(string Parameter, string Value)
        {
            try
            {
                Form form = Application.OpenForms["FormMain"];

                if (form == null)
                    return;



                if (form.InvokeRequired)
                {
                    UpdateDIO ph = new UpdateDIO(UpdateSignalTower);
                    form.BeginInvoke(ph, Parameter, Value);
                }
                else
                {
                    Panel Signal = form.Controls.Find(Parameter + "_St", true).FirstOrDefault() as Panel;
                    if (Signal == null)
                        return;
                    if (Value.ToUpper().Equals("TRUE"))
                    {
                        switch (Parameter)
                        {
                            case "Red":
                                Signal.BackColor = Color.Red;
                                break;
                            case "Orange":
                                Signal.BackColor = Color.DarkOrange;
                                break;
                            case "Green":
                                Signal.BackColor = Color.Green;
                                break;
                            case "Blue":
                                Signal.BackColor = Color.Blue;
                                break;
                        }
                    }
                    else
                    {
                        Signal.BackColor = Color.Silver;
                    }
                }


            }
            catch
            {
                logger.Error("UpdateSignalTower: Update fail.");
            }
        }
    }
}

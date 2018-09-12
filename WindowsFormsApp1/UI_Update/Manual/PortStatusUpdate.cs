using log4net;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adam.UI_Update.Manual
{
    class ManualPortStatusUpdate
    {
        static ILog logger = LogManager.GetLogger(typeof(ManualPortStatusUpdate));
        delegate void UpdateData(string NodeNAme, string Data);
        delegate void UpdateLock(bool Enable);

        public static void LockUI(bool Enable)
        {
            try
            {
                Form form = Application.OpenForms["FormManual"];
                TabControl Tab;
                if (form == null)
                    return;

                Tab = form.Controls.Find("tbcManual", true).FirstOrDefault() as TabControl;
                if (Tab == null)
                    return;

                if (Tab.InvokeRequired)
                {
                    UpdateLock ph = new UpdateLock(LockUI);
                    Tab.BeginInvoke(ph, Enable);
                }
                else
                {
                    Tab.Enabled = !Enable;

                }


            }
            catch
            {
                logger.Error("LockUI: Update fail.");
            }
        }

        public static void UpdateLog(string NodeName, string Data)
        {
            try
            {
                Form form = Application.OpenForms["FormManual"];
                ComboBox portName;
                if (form == null)
                    return;

                portName = form.Controls.Find("Cb_LoadPortSelect", true).FirstOrDefault() as ComboBox;
                if (portName == null)
                    return;

                if (portName.InvokeRequired)
                {
                    UpdateData ph = new UpdateData(UpdateLog);
                    portName.BeginInvoke(ph, NodeName, Data);
                }
                else
                {
                    if (portName.Text.Equals(NodeName))
                    {
                        RichTextBox LOG = form.Controls.Find("RTxt_Message_A", true).FirstOrDefault() as RichTextBox;
                        if (LOG == null)
                            return;
                        LOG.AppendText(Data+"\n");
                        LOG.ScrollToCaret();
                    }

                }


            }
            catch
            {
                logger.Error("UpdateControllerStatus: Update fail.");
            }
        }

        public static void UpdateVersion(string NodeName, string Data)
        {
            try
            {
                Form form = Application.OpenForms["FormManual"];
                ComboBox portName;
                if (form == null)
                    return;

                portName = form.Controls.Find("Cb_LoadPortSelect", true).FirstOrDefault() as ComboBox;
                if (portName == null)
                    return;

                if (portName.InvokeRequired)
                {
                    UpdateData ph = new UpdateData(UpdateVersion);
                    portName.BeginInvoke(ph, NodeName, Data);
                }
                else
                {
                    if (portName.Text.Equals(NodeName))
                    {
                        Label VER = form.Controls.Find("LblVersion_A", true).FirstOrDefault() as Label;
                        if (VER == null)
                            return;
                        VER.Text = Data;
                    }

                }


            }
            catch
            {
                logger.Error("UpdateControllerStatus: Update fail.");
            }
        }

        public static void UpdateStatus(string NodeName, string Data)
        {
            try
            {
                Form form = Application.OpenForms["FormManual"];
                ComboBox portName;
                if (form == null)
                    return;

                portName = form.Controls.Find("Cb_LoadPortSelect", true).FirstOrDefault() as ComboBox;
                if (portName == null)
                    return;

                if (portName.InvokeRequired)
                {
                    UpdateData ph = new UpdateData(UpdateStatus);
                    portName.BeginInvoke(ph, NodeName, Data);
                }
                else
                {
                    if (portName.Text.Equals(NodeName))
                    {
                        Label STS = form.Controls.Find("LblStatus_A", true).FirstOrDefault() as Label;
                        if (STS == null)
                            return;
                        STS.Text = Data;

                        for (int i = 0; i < 19; i++)
                        {
                            string Idx = (i + 1).ToString("00");
                            Label StsLb = form.Controls.Find("Lab_StateCode_" + Idx + "_A", true).FirstOrDefault() as Label;
                            string Sts = "";
                            switch (Idx)
                            {                              
                                case "01":
                                    switch (Data[i])
                                    {
                                        case '0':
                                            Sts = "Normal";
                                            break;
                                        case 'A':
                                            Sts = "Recoverable error";
                                            break;
                                        case 'E':
                                            Sts = "Fatal error";
                                            break;
                                    }
                                    break;
                                case "02":
                                    switch (Data[i])
                                    {
                                        case '0':
                                            Sts = "Online";
                                            break;
                                        case '1':
                                            Sts = "Teaching";
                                            break;                                       
                                    }
                                    break;
                                case "03":
                                    switch (Data[i])
                                    {
                                        case '0':
                                            Sts = "Unexecuted";
                                            break;
                                        case '1':
                                            Sts = "Executed";
                                            break;
                                    }
                                    break;
                                case "04":
                                    switch (Data[i])
                                    {
                                        case '0':
                                            Sts = "Stopped";
                                            break;
                                        case '1':
                                            Sts = "Operating";
                                            break;
                                    }
                                    break;
                                case "05":
                                case "06":
                                    Sts = Data[i].ToString();
                                    break;
                                case "07":
                                    switch (Data[i])
                                    {
                                        case '0':
                                            Sts = "None";
                                            break;
                                        case '1':
                                            Sts = "Normal position";
                                            break;
                                        case '2':
                                            Sts = "Error load";
                                            break;
                                    }
                                    break;
                                case "08":
                                    switch (Data[i])
                                    {
                                        case '0':
                                            Sts = "Open";
                                            break;
                                        case '1':
                                            Sts = "Close";
                                            break;
                                        case '?':
                                            Sts = "Not defined";
                                            break;
                                    }
                                    break;
                                case "09":
                                    switch (Data[i])
                                    {
                                        case '0':
                                            Sts = "Open";
                                            break;
                                        case '1':
                                            Sts = "Close";
                                            break;
                                        case '?':
                                            Sts = "Not defined";
                                            break;
                                    }
                                    break;
                                case "10":
                                    switch (Data[i])
                                    {
                                        case '0':
                                            Sts = "OFF";
                                            break;
                                        case '1':
                                            Sts = "ON";
                                            break;                                        
                                    }
                                    break;
                                case "11":
                                    switch (Data[i])
                                    {
                                        case '0':
                                            Sts = "Open position";
                                            break;
                                        case '1':
                                            Sts = "Close position";
                                            break;
                                        case '?':
                                            Sts = "Not defined";
                                            break;
                                    }
                                    break;
                                case "12":
                                    switch (Data[i])
                                    {
                                        case '0':
                                            Sts = "Blocked.";
                                            break;
                                        case '1':
                                            Sts = "Unblocked.";
                                            break;
                                    }
                                    break;
                                case "13":
                                    switch (Data[i])
                                    {
                                        case '0':
                                            Sts = "Up position";
                                            break;
                                        case '1':
                                            Sts = "Down position";
                                            break;
                                        case '2':
                                            Sts = "Start position";
                                            break;
                                        case '3':
                                            Sts = "End position";
                                            break;
                                        case '?':
                                            Sts = "Not defined";
                                            break;
                                    }
                                    break;
                                case "14":
                                    switch (Data[i])
                                    {
                                        case '0':
                                            Sts = "Undock position";
                                            break;
                                        case '1':
                                            Sts = "Dock position";
                                            break;
                                        case '?':
                                            Sts = "Not defined";
                                            break;
                                    }
                                    break;
                                case "15":
                                    switch (Data[i])
                                    {
                                        case '0':
                                            Sts = "Open";
                                            break;
                                        case '1':
                                            Sts = "Close";
                                            break;
                                        case '?':
                                            Sts = "Not defined";
                                            break;
                                    }
                                    break;
                                case "16":
                                    switch (Data[i])
                                    {
                                        case '0':
                                            Sts = "Retract position";
                                            break;
                                        case '1':
                                            Sts = "Mapping position";
                                            break;
                                        case '?':
                                            Sts = "Not defined";
                                            break;
                                    }
                                    break;
                                case "17":
                                    switch (Data[i])
                                    {
                                        case '0':
                                            Sts = "ON";
                                            break;
                                        case '1':
                                            Sts = "OFF";
                                            break;
                                        case '?':
                                            Sts = "Not defined";
                                            break;
                                    }
                                    break;
                                case "18":
                                    switch (Data[i])
                                    {
                                        case '0':
                                            Sts = "Unexecuted";
                                            break;
                                        case '1':
                                            Sts = "Normal end";
                                            break;
                                        case '2':
                                            Sts = "Abnormal end";
                                            break;
                                    }
                                    break;
                                case "19":
                                    switch (Data[i])
                                    {
                                        case '0':
                                            Sts = "Enable";
                                            break;
                                        case '1':
                                        case '2':
                                        case '3':
                                            Sts = "Disable";
                                            break;
                                    }
                                    break;
                            }

                            StsLb.Text = Sts;

                        }
                    }
                }


            }
            catch
            {
                logger.Error("UpdateControllerStatus: Update fail.");
            }
        }

        public static void UpdateLED(string NodeName, string Data)
        {
            try
            {
                Form form = Application.OpenForms["FormManual"];
                ComboBox portName;
                if (form == null)
                    return;

                portName = form.Controls.Find("Cb_LoadPortSelect", true).FirstOrDefault() as ComboBox;
                if (portName == null)
                    return;

                if (portName.InvokeRequired)
                {
                    UpdateData ph = new UpdateData(UpdateLED);
                    portName.BeginInvoke(ph, NodeName, Data);
                }
                else
                {
                    if (portName.Text.Equals(NodeName))
                    {
                        Label LED = form.Controls.Find("LblLED_A", true).FirstOrDefault() as Label;
                        if (LED == null)
                            return;
                        LED.Text = Data;
                    }

                }


            }
            catch
            {
                logger.Error("UpdateControllerStatus: Update fail.");
            }
        }

        public static void UpdateMapping(string NodeName, string Data)
        {
            try
            {
                Form form = Application.OpenForms["FormManual"];
                ComboBox portName;
                if (form == null)
                    return;

                portName = form.Controls.Find("Cb_LoadPortSelect", true).FirstOrDefault() as ComboBox;
                if (portName == null)
                    return;

                if (portName.InvokeRequired)
                {
                    UpdateData ph = new UpdateData(UpdateMapping);
                    portName.BeginInvoke(ph, NodeName, Data);
                }
                else
                {
                    if (portName.Text.Equals(NodeName))
                    {
                        for (int i = Data.Length - 1; i >= 0; i--)
                        {
                            string Slot = (i + 1).ToString("00");
                            Label slotLb = form.Controls.Find("Lab_A_Slot_" + Slot, true).FirstOrDefault() as Label;

                            switch (Data[i])
                            {
                                case '0':
                                    slotLb.Text = "No wafer";
                                    slotLb.BackColor = Color.Silver;
                                    break;
                                case '1':
                                    slotLb.Text = "Wafer";
                                    slotLb.BackColor = Color.Lime;
                                    break;
                                case '2':
                                    slotLb.Text = "Crossed";
                                    slotLb.BackColor = Color.Red;
                                    break;
                                case '?':
                                    slotLb.Text = "Undefined";
                                    slotLb.BackColor = Color.Silver;
                                    break;
                                case 'W':
                                    slotLb.Text = "Overlapping";
                                    slotLb.BackColor = Color.Red;
                                    break;
                            }
                        }
                    }

                }


            }
            catch
            {
                logger.Error("UpdateControllerStatus: Update fail.");
            }
        }
    }
}

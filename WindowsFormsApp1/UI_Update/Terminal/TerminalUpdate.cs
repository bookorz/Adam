using log4net;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferControl.Management;

namespace Adam.UI_Update.Terminal
{
    class TerminalUpdate
    {
        static ILog logger = LogManager.GetLogger(typeof(TerminalUpdate));
        delegate void UpdateReturn(string UIName, string Message, bool ClearItems);
        delegate void UpdateLabel(string UIName, string Message);
        delegate void UpdateButton(string UIName, bool blStatus);
        delegate void UpdateSplitButton(string UIName, bool blStatus);

        public static void UpdateReturnList(string UIName, string Message, bool ClearItems)
        {
            ListBox lsbTemp;
            Form form;

            try
            {
                form = Application.OpenForms["FormTerminal"];
                
                if (form == null)
                    return;

                lsbTemp = form.Controls.Find(UIName, true).FirstOrDefault() as ListBox;

                if (lsbTemp == null)
                    return;

                if (lsbTemp.InvokeRequired)
                {
                    UpdateReturn ph = new UpdateReturn(UpdateReturnList);

                    lsbTemp.BeginInvoke(ph, UIName, Message, ClearItems);
                }
                else
                {
                    if (ClearItems)
                    {
                        lsbTemp.Items.Clear();
                    }
                    else
                    {
                        lsbTemp.Items.Insert(0, Message);
                        lsbTemp.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("UpdateReturnList: Update fail." + e.Message + "\n" + e.StackTrace);
            }
        }

        public static void UpdateLabelText(string UIName, string Message)
        {
            Label lbTemp;
            Form form;

            try
            {
                form = Application.OpenForms["FormTerminal"];

                if (form == null)
                    return;

                lbTemp = form.Controls.Find(UIName, true).FirstOrDefault() as Label;

                if (lbTemp == null)
                    return;

                if (lbTemp.InvokeRequired)
                {
                    UpdateLabel ph = new UpdateLabel(UpdateLabelText);

                    lbTemp.BeginInvoke(ph, UIName, Message);
                }
                else
                {
                    lbTemp.Text = Message;
                }
            }
            catch (Exception e)
            {
                logger.Error("UpdateLabelText: Update fail." + e.Message + "\n" + e.StackTrace);
            }
        }

        public static void UpdateButtonEnable(string UIName, bool blStatus)
        {
            Button btnTemp;
            Form form;

            try
            {
                form = Application.OpenForms["FormTerminal"];

                if (form == null)
                    return;

                btnTemp = form.Controls.Find(UIName, true).FirstOrDefault() as Button;

                if (btnTemp == null)
                    return;

                if (btnTemp.InvokeRequired)
                {
                    UpdateButton ph = new UpdateButton(UpdateButtonEnable);

                    btnTemp.BeginInvoke(ph, UIName, blStatus);
                }
                else
                {
                    btnTemp.Enabled = blStatus;
                }
            }
            catch (Exception e)
            {
                logger.Error("UpdateButtonEnable: Update fail." + e.Message + "\n" + e.StackTrace);
            }
        }

        public static void UpdateSplitButtonEnable(string UIName, bool blStatus)
        {
            Button btnTemp;
            Form form;

            try
            {
                form = Application.OpenForms["FormTerminal"];

                if (form == null)
                    return;

                btnTemp = form.Controls.Find(UIName, true).FirstOrDefault() as Button;

                if (btnTemp == null)
                    return;

                if (btnTemp.InvokeRequired)
                {
                    UpdateSplitButton ph = new UpdateSplitButton(UpdateSplitButtonEnable);

                    btnTemp.BeginInvoke(ph, UIName, blStatus);
                }
                else
                {
                    btnTemp.Enabled = blStatus;
                }
            }
            catch (Exception e)
            {
                logger.Error("UpdateButtonEnable: Update fail." + e.Message + "\n" + e.StackTrace);
            }
        }
    }
}

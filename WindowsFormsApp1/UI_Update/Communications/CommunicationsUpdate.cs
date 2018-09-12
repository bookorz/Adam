using Adam.Menu.Communications;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adam.UI_Update.Communications
{
    public class CommunicationsUpdate
    {
        static ILog logger = LogManager.GetLogger(typeof(CommunicationsUpdate));

        delegate void UpdateConnectStatus(string ControllerName, bool Status);


        public static void UpdateConnection(string ControllerName, bool Status)
        {
            try
            {
                Form form = Application.OpenForms["FormCommunications"];
                RadioButton W;
                if (form == null)
                    return;
                if (Status)
                {
                    W = form.Controls.Find("Connect_rb", true).FirstOrDefault() as RadioButton;
                }
                else
                {
                    W = form.Controls.Find("Disconnect_rb", true).FirstOrDefault() as RadioButton;
                }
            
                if (W == null)
                    return;

                if (W.InvokeRequired)
                {
                    UpdateConnectStatus ph = new UpdateConnectStatus(UpdateConnection);
                    W.BeginInvoke(ph, ControllerName,Status);
                }
                else
                {
                    if (FormCommunications.ControllerID.Equals(ControllerName))
                    {
                        W.Checked = true;
                    }

                }
            }
            catch
            {
                logger.Error("UpdateWPH: Update fail.");
            }
        }
    }
}

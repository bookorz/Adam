using Adam.UI_Update.Monitoring;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferControl.Management;

namespace Adam.Menu.RunningScreen
{
    public partial class FormRunningScreen : Adam.Menu.FormFrame
    {

        public static int TransCount = 0;

        public FormRunningScreen()
        {
            InitializeComponent();
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            if (Start_btn.Tag == null)
            {
                Start_btn.Tag = "Stop";
            }
            if (Start_btn.Tag.Equals("Start"))
            {
                
                //FormMain.RouteCtrl.Stop();



            }
            else
            {
                
            }

        }

        private void RunningSpeed_cb_TextChanged(object sender, EventArgs e)
        {
            ChangeSpeed();
        }

        private void ChangeSpeed()
        {
            string sp = RunningSpeed_cb.Text.Replace("%", "");
            if (sp.Equals("100"))
            {
                sp = "0";
            }
            foreach (Node node in NodeManagement.GetList())
            {
                string Message = "";
                if (node.Type.Equals("ROBOT"))
                {
                    Transaction txn = new Transaction();
                    txn.Method = Transaction.Command.RobotType.RobotSpeed;
                    txn.Value = sp;
                    txn.FormName = "Running";
                    node.SendCommand(txn, out Message);
                }
                else
                if (node.Type.Equals("ALIGNER"))
                {
                    Transaction txn = new Transaction();
                    txn.Method = Transaction.Command.AlignerType.AlignerSpeed;
                    txn.Value = sp;
                    txn.FormName = "Running";
                    node.SendCommand(txn, out Message);
                }
            }
        }
    }
}

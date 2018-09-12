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
                FormMain.RouteCtrl.Stop();
                //FormMain.RouteCtrl.Stop();



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
                    var findByPass = from node in NodeManagement.GetList()
                                     where node.ByPass
                                     select node;

                    if (findByPass.Count() != 0)
                    {
                        string msg = "";
                        foreach (Node node in findByPass)
                        {
                            msg += node.Name + "\n";
                        }
                        msg += "\n為By pass 模式，確定要繼續?";

                        if (MessageBox.Show(msg, "警告", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        {
                            return;
                        }
                    }

                    FormMain.RouteCtrl.Start("Running");
                }

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
                if (node.Type.Equals("ROBOT"))
                {
                    Transaction txn = new Transaction();
                    txn.Method = Transaction.Command.RobotType.RobotSpeed;
                    txn.Value = sp;
                    txn.FormName = "Running";
                    node.SendCommand(txn);
                }
                else
                if (node.Type.Equals("ALIGNER"))
                {
                    Transaction txn = new Transaction();
                    txn.Method = Transaction.Command.AlignerType.AlignerSpeed;
                    txn.Value = sp;
                    txn.FormName = "Running";
                    node.SendCommand(txn);
                }
            }
        }
    }
}

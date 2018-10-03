using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adam.UI_Update.Monitoring
{
    class ConnectionStatusUpdate
    {
        static ILog logger = LogManager.GetLogger(typeof(ConnectionStatusUpdate));
        static List<TabPage> hiddenPages = new List<TabPage>();
        class ConnectState
        {

            public string Device_ID { get; set; }
            public string Connection_Status { get; set; }
        }

        delegate void UpdateController(string Device_ID, string Status);
        delegate void UpdateOnline(string Status);

        public static void UpdateInitial(string Status)
        {
            try
            {
                Form form = Application.OpenForms["FormMain"];
                Button Init;
                if (form == null)
                    return;

                Init = form.Controls.Find("Initial_btn", true).FirstOrDefault() as Button;
                if (Init == null)
                    return;

                if (Init.InvokeRequired)
                {
                    UpdateOnline ph = new UpdateOnline(UpdateInitial);
                    Init.BeginInvoke(ph, Status);
                }
                else
                {
                    if (Status.ToUpper().Equals("TRUE"))
                    {
                        Init.BackColor = Color.Lime;
                    }
                    else
                    {
                        Init.BackColor = Color.Red;
                    }

                }


            }
            catch
            {
                logger.Error("UpdateInitial: Update fail.");
            }
        }

        public static void UpdateModeStatus(string Status)
        {
            try
            {
                Form form = Application.OpenForms["FormMain"];
                Button Mode;
                if (form == null)
                    return;

                Mode = form.Controls.Find("Mode_btn", true).FirstOrDefault() as Button;
                if (Mode == null)
                    return;

                if (Mode.InvokeRequired)
                {
                    UpdateOnline ph = new UpdateOnline(UpdateModeStatus);
                    Mode.BeginInvoke(ph, Status);
                }
                else
                {
                    switch (Status)
                    {
                        case "Running":
                        case "Start":
                            Mode.Tag = Status;
                            Mode.Text = Status;
                            Mode.BackColor = Color.Lime;
                            Button btnMaintence = form.Controls.Find("btnMaintence", true).FirstOrDefault() as Button;
                            if (btnMaintence != null)
                            {
                                btnMaintence.Text = Status+" Mode";
                                btnMaintence.BackColor = Color.Red;
                                btnMaintence.Enabled = false;
                            }
                            Button btnTeach = form.Controls.Find("btnTeach", true).FirstOrDefault() as Button;
                            if (btnTeach != null)
                            {
                                btnTeach.Enabled = false;
                            }
                            TabControl tbcMian = form.Controls.Find("tbcMian", true).FirstOrDefault() as TabControl;
                            if (tbcMian != null)
                            {
                                EnablePage(tbcMian.TabPages[6], false, form);
                            }
                            Button Pause_btn = form.Controls.Find("Pause_btn", true).FirstOrDefault() as Button;
                            if (Pause_btn != null)
                            {
                                Pause_btn.Enabled = true;
                            }

                           

                            break;
                        case "Stop":
                            btnMaintence = form.Controls.Find("btnMaintence", true).FirstOrDefault() as Button;
                            if (btnMaintence != null)
                            {
                                btnMaintence.Text = "Maintenance Mode";
                                btnMaintence.BackColor = Color.WhiteSmoke;
                                btnMaintence.Enabled = true;
                            }
                            btnTeach = form.Controls.Find("btnTeach", true).FirstOrDefault() as Button;
                            if (btnTeach != null)
                            {
                                btnTeach.Enabled = true;
                            }
                            
                            EnablePage(hiddenPages[0], true, form);
                            
                            Mode.Tag = "Manual";
                            Mode.Text = "Manual";
                            Mode.BackColor = Color.Orange;
                            //Mode.Enabled = false;

                            
                            break;
                        

                         
                    }

                }


            }
            catch
            {
                logger.Error("UpdateOnlineStatus: Update fail.");
            }
        }

        private static void EnablePage(TabPage page, bool enable,Form form)
        {
            TabControl tbcMian = form.Controls.Find("tbcMian", true).FirstOrDefault() as TabControl;
            if (tbcMian != null)
            {
                if (enable)
                {

                    tbcMian.TabPages.Add(page);
                    hiddenPages.Remove(page);
                }
                else
                {
                    tbcMian.TabPages.Remove(page);
                    hiddenPages.Add(page);
                }
            }
        }

        public static void UpdateOnlineStatus(string Status)
        {
            try
            {
                Form form = Application.OpenForms["FormMain"];
                Button Online;
                if (form == null)
                    return;

                Online = form.Controls.Find("Connection_btn", true).FirstOrDefault() as Button;
                if (Online == null)
                    return;

                if (Online.InvokeRequired)
                {
                    UpdateOnline ph = new UpdateOnline(UpdateOnlineStatus);
                    Online.BeginInvoke(ph, Status);
                }
                else
                {
                    switch (Status)
                    {
                        case "Online":
                            Online.Tag = "Online";
                            Online.Text = "Online";
                            Online.BackColor = Color.Lime;
                            break;
                        case "Connecting":
                            Online.Tag = "Connecting";
                            Online.Text = "Connecting";
                            Online.BackColor = Color.Orange;
                            break;
                        case "Offline":
                            Online.Text = "Offline";
                            Online.Tag = "Offline";
                            Online.BackColor = Color.Red;
                            break;
                    }

                }


            }
            catch
            {
                logger.Error("UpdateOnlineStatus: Update fail.");
            }
        }

        public static void UpdateControllerStatus(string Device_ID, string Status)
        {
            try
            {
                Form form = Application.OpenForms["FormMain"];
                DataGridView Conn_gv;
                if (form == null)
                    return;

                Conn_gv = form.Controls.Find("Conn_gv", true).FirstOrDefault() as DataGridView;
                if (Conn_gv == null)
                    return;

                if (Conn_gv.InvokeRequired)
                {
                    UpdateController ph = new UpdateController(UpdateControllerStatus);
                    Conn_gv.BeginInvoke(ph, Device_ID, Status);
                }
                else
                {
                    if (Conn_gv.DataSource == null)
                    {
                        //Conn_gv.DataSource = new List<ConnectState>();
                        Conn_gv.DataSource = new BindingList<ConnectState>();
                    }
                    //List<ConnectState> connList = (List<ConnectState>)Conn_gv.DataSource;
                    BindingList<ConnectState> connList = (BindingList<ConnectState>)Conn_gv.DataSource;

                    var find = from Ctrl in connList
                               where Ctrl.Device_ID.Equals(Device_ID)
                               select Ctrl;

                    if (find.Count() == 0)
                    {
                        ConnectState con = new ConnectState();
                        con.Device_ID = Device_ID;
                        con.Connection_Status = Status;
                        connList.Add(con);
                    }
                    else
                    {
                        find.First().Connection_Status = Status;
                    }
                    //connList.Sort((x, y) => { return x.Device_ID.CompareTo(y.Device_ID); });
                    connList = new BindingList<ConnectState>(connList.OrderBy(x => x.Device_ID).ToList());// fix System.IndexOutOfRangeException
                    Conn_gv.DataSource = null;
                    Conn_gv.DataSource = connList;
                    //Conn_gv.Refresh();
                    // Conn_gv.ClearSelection();

                }


            }
            catch
            {
                logger.Error("UpdateControllerStatus: Update fail.");
            }
        }

        public static void UpdateDIOStatus(string Device_ID, string Status)
        {
            try
            {
                Form form = Application.OpenForms["FormMain"];
                DataGridView Conn_gv;
                if (form == null)
                    return;

                Conn_gv = form.Controls.Find("DIO_gv", true).FirstOrDefault() as DataGridView;
                if (Conn_gv == null)
                    return;

                if (Conn_gv.InvokeRequired)
                {
                    UpdateController ph = new UpdateController(UpdateDIOStatus);
                    Conn_gv.BeginInvoke(ph, Device_ID, Status);
                }
                else
                {
                    if (Conn_gv.DataSource == null)
                    {
                        Conn_gv.DataSource = new List<ConnectState>();
                    }
                    List<ConnectState> connList = (List<ConnectState>)Conn_gv.DataSource;

                    var find = from Ctrl in connList
                               where Ctrl.Device_ID.Equals(Device_ID)
                               select Ctrl;

                    if (find.Count() == 0)
                    {
                        ConnectState con = new ConnectState();
                        con.Device_ID = Device_ID;
                        con.Connection_Status = Status;
                        connList.Add(con);
                    }
                    else
                    {
                        find.First().Connection_Status = Status;
                    }
                    connList.Sort((x, y) => { return x.Device_ID.CompareTo(y.Device_ID); });
                    Conn_gv.DataSource = null;
                    Conn_gv.DataSource = connList;
                    //Conn_gv.Refresh();
                    Conn_gv.ClearSelection();
                }


            }
            catch
            {
                logger.Error("UpdateControllerStatus: Update fail.");
            }
        }
    }
}

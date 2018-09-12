using Adam.UI_Update.Monitoring;
using log4net;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferControl.Management;

namespace Adam.UI_Update.Alarm
{
    class AlarmUpdate
    {
        static ILog logger = LogManager.GetLogger(typeof(AlarmUpdate));
        delegate void UpdateAlarm(List<AlarmInfo> AlarmList);
        delegate void UpdateSignal(string Name, string Signal);
        delegate void UpdateMsg(string Msg);

       

        

        public static void UpdateAlarmList(List<AlarmInfo> AlarmList)
        {
            try
            {

                Form form = Application.OpenForms["AlarmFrom"];
                DataGridView AlarmList_gv;
                
                   
                
                if (form == null)
                    return;


                AlarmList_gv = form.Controls.Find("AlarmList_gv", true).FirstOrDefault() as DataGridView;
                if (AlarmList_gv == null)
                    return;

                if (AlarmList_gv.InvokeRequired)
                {
                    UpdateAlarm ph = new UpdateAlarm(UpdateAlarmList);

                    AlarmList_gv.BeginInvoke(ph, AlarmList);

                }
                else
                {

                    //JobList_gv.DataSource = null;
                    AlarmList_gv.DataSource = AlarmList.ToList();

                    //Conn_gv.Refresh();
                    AlarmList_gv.ClearSelection();
                    AlarmList_gv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    NodeStatusUpdate.UpdateCurrentState(FormMain.RouteCtrl.EqpState);
                    if (AlarmList.Count() != 0)
                    {
                       
                        form.Visible = true;
                        
                    }
                    else
                    {
                        
                        form.Visible = false;
                    }
                }


            }
            catch (Exception e)
            {
                logger.Error("UpdateAlarmList: Update fail." + e.Message + "\n" + e.StackTrace);
            }

        }

        public static void UpdateAlarmHistory(List<AlarmInfo> AlarmList)
        { 
            try
            {
                Form form = Application.OpenForms["FormAlarmHis"];
                DataGridView AlarmList_gv;
                
                if (form == null)
                    return;


                AlarmList_gv = form.Controls.Find("AlarmHistory_gv", true).FirstOrDefault() as DataGridView;
                if (AlarmList_gv == null)
                    return;

                if (AlarmList_gv.InvokeRequired)
                {
                    UpdateAlarm ph = new UpdateAlarm(UpdateAlarmHistory);
                    AlarmList_gv.BeginInvoke(ph, AlarmList);
                }
                else
                {

                    //JobList_gv.DataSource = null;
                    AlarmList_gv.DataSource = AlarmList;

                    //Conn_gv.Refresh();
                    AlarmList_gv.ClearSelection();
                    AlarmList_gv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }


            }
            catch (Exception e)
            {
                logger.Error("UpdateAlarmHistory: Update fail." + e.Message + "\n" + e.StackTrace);
            }

        }
    }
}

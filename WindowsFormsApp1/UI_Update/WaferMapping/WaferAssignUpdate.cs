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

namespace Adam.UI_Update.WaferMapping
{
    class WaferAssignUpdate
    {
        static ILog logger = LogManager.GetLogger(typeof(WaferAssignUpdate));
        delegate void UpdatePort(string PortName, string Mapping);
        delegate void UpdatePortMapping(string PortName);
        delegate void UpdatePortUsed(string PortName, bool Used);
        delegate void UpdateAssign(string PortName, string Mapping,bool Enable);

        public static void UpdateUseState(string PortName, bool used)
        {
            try
            {
                Form form = Application.OpenForms["FormWaferMapping"];
                Label Used;
                if (form == null)
                    return;

                Used = form.Controls.Find(PortName + "_Use", true).FirstOrDefault() as Label;
                if (Used == null)
                    return;

                if (Used.InvokeRequired)
                {
                    UpdatePortUsed ph = new UpdatePortUsed(UpdateUseState);
                    Used.BeginInvoke(ph, PortName, used);
                }
                else
                {
                    if (used)
                    {
                        Used.Text = "Used";
                        Used.BackColor = Color.Green;
                        Used.ForeColor = Color.White;
                    }
                    else
                    {
                        Used.Text = "Not Used";
                        Used.BackColor = Color.DimGray;
                        Used.ForeColor = Color.White;
                    }

                }
            }
            catch
            {
                logger.Error("UpdateUseState: Update fail.");
            }
        }

        public static void RefreshMapping(string PortName)
        {
            try
            {
                Form form = Application.OpenForms["FormWaferMapping"];
                DataGridView Port_gv;
                if (form == null)
                    return;

                Port_gv = form.Controls.Find(PortName + "Assign_Gv", true).FirstOrDefault() as DataGridView;
                if (Port_gv == null)
                    return;

                if (Port_gv.InvokeRequired)
                {
                    UpdatePortMapping ph = new UpdatePortMapping(RefreshMapping);
                    Port_gv.BeginInvoke(ph, PortName);
                }
                else
                {

                    Node port = NodeManagement.Get(PortName);

                    foreach(Job each in port.JobList.Values.ToList())
                    {
                        each.RecipeID = "300MM";
                    }
                    
                    List<Job> tmp = port.JobList.Values.ToList();
                    tmp.Sort((x, y) => { return -Convert.ToInt16(x.Slot).CompareTo(Convert.ToInt16(y.Slot)); });
                    Port_gv.DataSource = tmp;
                    Port_gv.Columns["Slot"].Width = 25;
                    Port_gv.Columns["Slot"].HeaderText = "S";
                    Port_gv.Columns["Host_Job_Id"].Width = 75;
                    Port_gv.Columns["DisplayDestination"].Width = 55;
                    Port_gv.Columns["DestinationSlot"].Width = 30;
                    Port_gv.Columns["Offset"].Visible = false;
                    Port_gv.Columns["Angle"].Visible = false;
                    Port_gv.Columns["Job_Id"].Visible = false;
                    Port_gv.Columns["Destination"].Visible = false;
                    Port_gv.Columns["ProcessFlag"].Visible = false;
                    //Port_gv.Columns["Piority"].Visible = false;
                    Port_gv.Columns["AlignerFlag"].Visible = false;
                    Port_gv.Columns["OCRFlag"].Visible = false;
                    Port_gv.Columns["AlignerFinished"].Visible = false;
                    Port_gv.Columns["OCRFinished"].Visible = false;
                    Port_gv.Columns["Position"].Visible = false;
                    Port_gv.Columns["FromPort"].Visible = false;
                    Port_gv.Columns["LastNode"].Visible = false;
                    Port_gv.Columns["CurrentState"].Visible = false;
                    Port_gv.Columns["WaitToDo"].Visible = false;
                    //Port_gv.Columns["FetchRobot"].Visible = false;
                    Port_gv.Columns["ProcessNode"].Visible = false;
                    Port_gv.Columns["MapFlag"].Visible = false;
                    Port_gv.Columns["DisplayDestination"].HeaderText = "Dest";
                    Port_gv.Columns["DestinationSlot"].HeaderText = "DS";
                    Port_gv.Columns["Host_Job_Id"].HeaderText = "ID";
                    Port_gv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10);
                    Port_gv.Columns["NeedProcess"].Visible = false;
                    Port_gv.Columns["OCRImgPath"].Visible = false;
                    Port_gv.Columns["OCRScore"].Visible = false;
                    Port_gv.Columns["LastSlot"].Visible = false;
                    Port_gv.Columns["FromPortSlot"].Visible = false;
                    Port_gv.Columns["AssignTime"].Visible = false;

                    //MonitoringUpdate.UpdateNodesJob(PortName);

                }


            }
            catch (Exception e)
            {
                logger.Error("UpdateLoadPortMapping: Update fail:" + e.StackTrace);
            }
        }

        public static void UpdateLoadPortMapping(string PortName, string Mapping)
        {
            try
            {
                Form form = Application.OpenForms["FormWaferMapping"];
                DataGridView Port_gv;
                if (form == null)
                    return;

                Port_gv = form.Controls.Find(PortName + "Assign_Gv", true).FirstOrDefault() as DataGridView;
                if (Port_gv == null)
                    return;

                if (Port_gv.InvokeRequired)
                {
                    UpdatePort ph = new UpdatePort(UpdateLoadPortMapping);
                    Port_gv.BeginInvoke(ph, PortName, Mapping);
                }
                else
                {

                    Node port = NodeManagement.Get(PortName);
                    //List<Job> MappingData = new List<Job>();
                    //port.IsMapping = true;
                    if (Mapping.Equals(""))
                    {
                        foreach (Job eachJob in port.JobList.Values)
                        {
                            JobManagement.Remove(eachJob.Job_Id);
                        }
                        port.JobList.Clear();
                        port.ReserveList.Clear();
                        JobManagement.ClearAssignJobByPort(port.Name);
                    }
                    else
                    {
                        int currentIdx = 1;
                        for (int i = 0; i < Mapping.Length; i++)
                        {
                            Job wafer = new Job();
                            wafer.Slot = (i + 1).ToString();
                            wafer.FromPort = PortName;
                            wafer.FromPortSlot = wafer.Slot;
                            wafer.Position = PortName;
                            wafer.AlignerFlag = false;
                            wafer.RecipeID = "300MM";
                            string Slot = (i + 1).ToString("00");
                            switch (Mapping[i])
                            {
                                case '0':
                                    wafer.Job_Id = "No wafer";
                                    wafer.Host_Job_Id = wafer.Job_Id;
                                    //MappingData.Add(wafer);
                                    break;
                                case '1':
                                    while (true)
                                    {
                                        wafer.Job_Id = "Wafer" + currentIdx.ToString("00");
                                        wafer.Host_Job_Id = wafer.Job_Id;
                                        wafer.MapFlag = true;
                                        if (JobManagement.Add(wafer.Job_Id, wafer))
                                        {

                                            //MappingData.Add(wafer);
                                            break;
                                        }
                                        currentIdx++;
                                    }

                                    break;
                                case '2':
                                    wafer.Job_Id = "Crossed";
                                    wafer.Host_Job_Id = wafer.Job_Id;
                                    wafer.MapFlag = true;
                                    //MappingData.Add(wafer);
                                    break;
                                case '?':
                                    wafer.Job_Id = "Undefined";
                                    wafer.Host_Job_Id = wafer.Job_Id;
                                    wafer.MapFlag = true;
                                    //MappingData.Add(wafer);
                                    break;
                                case 'W':
                                    wafer.Job_Id = "Double";
                                    wafer.Host_Job_Id = wafer.Job_Id;
                                    wafer.MapFlag = true;
                                    //MappingData.Add(wafer);
                                    break;
                            }
                            if (!port.AddJob(wafer.Slot, wafer))
                            {
                                Job org = port.GetJob(wafer.Slot);
                                JobManagement.Remove(org.Job_Id);
                                port.RemoveJob(wafer.Slot);
                                port.AddJob(wafer.Slot, wafer);
                            }
                        }
                    }
                    List<Job> tmp = port.JobList.Values.ToList();
                    tmp.Sort((x, y) => { return -Convert.ToInt16(x.Slot).CompareTo(Convert.ToInt16(y.Slot)); });
                    Port_gv.DataSource = tmp;
                    Port_gv.Columns["Slot"].Width = 25;
                    Port_gv.Columns["Slot"].HeaderText = "S";
                    Port_gv.Columns["Host_Job_Id"].Width = 75;
                    Port_gv.Columns["DisplayDestination"].Width = 55;
                    Port_gv.Columns["DestinationSlot"].Width = 30;
                    Port_gv.Columns["Offset"].Visible = false;
                    Port_gv.Columns["Angle"].Visible = false;
                    Port_gv.Columns["Job_Id"].Visible = false;
                    Port_gv.Columns["Destination"].Visible = false;
                    Port_gv.Columns["ProcessFlag"].Visible = false;
                    // Port_gv.Columns["Piority"].Visible = false;
                    Port_gv.Columns["AlignerFlag"].Visible = false;
                    Port_gv.Columns["OCRFlag"].Visible = false;
                    Port_gv.Columns["AlignerFinished"].Visible = false;
                    Port_gv.Columns["OCRFinished"].Visible = false;
                    Port_gv.Columns["Position"].Visible = false;
                    Port_gv.Columns["FromPort"].Visible = false;
                    Port_gv.Columns["LastNode"].Visible = false;
                    Port_gv.Columns["CurrentState"].Visible = false;
                    Port_gv.Columns["WaitToDo"].Visible = false;
                    //Port_gv.Columns["FetchRobot"].Visible = false;
                    Port_gv.Columns["ProcessNode"].Visible = false;
                    Port_gv.Columns["MapFlag"].Visible = false;
                    Port_gv.Columns["DisplayDestination"].HeaderText = "Dest";
                    Port_gv.Columns["DestinationSlot"].HeaderText = "DS";
                    Port_gv.Columns["Host_Job_Id"].HeaderText = "ID";
                    Port_gv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10);
                    Port_gv.Columns["NeedProcess"].Visible = false;
                    Port_gv.Columns["OCRImgPath"].Visible = false;
                    Port_gv.Columns["OCRScore"].Visible = false;
                    Port_gv.Columns["LastSlot"].Visible = false;
                    Port_gv.Columns["FromPortSlot"].Visible = false;
                    Port_gv.Columns["AssignTime"].Visible = false;

                    MonitoringUpdate.UpdateNodesJob(PortName);
                    port.IsMapping = true;
                }


            }
            catch (Exception e)
            {
                logger.Error("UpdateLoadPortMapping: Update fail:" + e.StackTrace);
            }
        }

        public static void UpdateLoadPortMode(string PortName, string Mode)
        {
            try
            {
                Form form = Application.OpenForms["FormWaferMapping"];
                Label Port_Mode;
                if (form == null)
                    return;

                Port_Mode = form.Controls.Find(PortName + "State_lb", true).FirstOrDefault() as Label;
                if (Port_Mode == null)
                    return;

                if (Port_Mode.InvokeRequired)
                {
                    UpdatePort ph = new UpdatePort(UpdateLoadPortMapping);
                    Port_Mode.BeginInvoke(ph, PortName, Mode);
                }
                else
                {
                    NodeManagement.Get(PortName).Mode = Mode;
                    Port_Mode.Text = PortName + "  [" + Mode + "]";

                }
            }
            catch (Exception e)
            {
                logger.Error("UpdateLoadPortMode: Update fail:" + e.StackTrace);
            }
        }

        public static void UpdateAssignCM(string FromPort, string ToPort,bool Enable)
        {
            try
            {
                Form form = Application.OpenForms["FormWaferMapping"];
                if (form == null)
                    return;
                Button fromPort = form.Controls.Find(FromPort + "_ASCM", true).FirstOrDefault() as Button;
                if (fromPort == null)
                    return;
                if (fromPort.InvokeRequired)
                {
                    UpdateAssign ph = new UpdateAssign(UpdateAssignCM);
                    fromPort.BeginInvoke(ph, FromPort, ToPort);
                }
                else
                {
                    DataGridView FromPort_gv = form.Controls.Find(FromPort + "Assign_Gv", true).FirstOrDefault() as DataGridView;
                    if (FromPort_gv != null)
                    {
                        FromPort_gv.Enabled = Enable;
                    }

                    DataGridView ToPort_gv = form.Controls.Find(ToPort + "Assign_Gv", true).FirstOrDefault() as DataGridView;
                    if (ToPort_gv != null)
                    {
                        ToPort_gv.Enabled = Enable;
                    }
                    fromPort.Enabled = Enable;
                    if (!Enable)
                    {
                        fromPort.BackColor = Color.Green;
                        fromPort.ForeColor = Color.White;
                    }
                    else
                    {
                        fromPort.BackColor = Color.Gainsboro;
                        fromPort.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("UpdateAssignCM: Update fail:" + e.StackTrace);
            }
        }

        public static void ResetAssignCM(string Port, bool Enable)
        {
            try
            {
                Form form = Application.OpenForms["FormWaferMapping"];
                if (form == null)
                    return;
                Button fromPort = form.Controls.Find(Port + "_ASCM", true).FirstOrDefault() as Button;
                if (fromPort == null)
                    return;
                if (fromPort.InvokeRequired)
                {
                    UpdatePortUsed ph = new UpdatePortUsed(ResetAssignCM);
                    fromPort.BeginInvoke(ph, Port, Enable);
                }
                else
                {
                    DataGridView FromPort_gv = form.Controls.Find(Port + "Assign_Gv", true).FirstOrDefault() as DataGridView;
                    if (FromPort_gv != null)
                    {
                        FromPort_gv.Enabled = Enable;
                    }

                   
                    fromPort.Enabled = Enable;
                    if (!Enable)
                    {
                        fromPort.Text = "Assign Cancel";
                        fromPort.BackColor = Color.Green;
                        fromPort.ForeColor = Color.White;
                    }
                    else
                    {
                        fromPort.Text = "Assign Complete";
                        fromPort.BackColor = Color.Gainsboro;
                        fromPort.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("UpdateAssignCM: Update fail:" + e.StackTrace);
            }
        }
    }
}

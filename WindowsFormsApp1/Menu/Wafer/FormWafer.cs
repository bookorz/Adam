using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SANWA.Utility;
using System.Linq;
using TransferControl.Management;
using Adam.UI_Update.Monitoring;

namespace Adam.Menu.Wafer
{
    public partial class FormWafer : Adam.Menu.SystemSetting.FormSettingFram
    {
        public FormWafer()
        {
            InitializeComponent();
        }

        private void FormWafer_Load(object sender, EventArgs e)
        {

        }






        private void FormWafer_Layout(object sender, LayoutEventArgs e)
        {
            WaferList_tv.Nodes.Clear();
            Position_cb.Items.Clear();

            foreach (Node node in NodeManagement.GetList())
            {
                if (!node.Type.Equals("OCR"))
                {
                    TreeNode each = new TreeNode(node.Name);

                    Position_cb.Items.Add(node.Name);
                    List<Job> jobList = node.JobList.Values.ToList();
                    jobList.Sort((x, y) => { return Convert.ToInt16(x.Slot).CompareTo(Convert.ToInt16(y.Slot)); });
                    foreach (Job j in jobList)
                    {
                        if (JobManagement.Get(j.Job_Id) != null)
                        {
                            each.Nodes.Add(j.Job_Id, j.Job_Id + "(Slot-" + j.Slot + ")");

                        }
                    }
                    WaferList_tv.Nodes.Add(each);
                }
            }
        }

        private void WaferList_tv_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Job job = JobManagement.Get(e.Node.Name);
            if (job != null)
            {
                WaferID_tb.Text = job.Job_Id;
                NeedProcess_ck.Checked = job.NeedProcess;
                ProcessFlag_ck.Checked = job.ProcessFlag;
                AlignFlag_ck.Checked = job.AlignerFlag;
                OCRFlag_ck.Checked = job.OCRFlag;
                Position_cb.Text = job.Position.ToUpper();
                Slot_cb.Text = job.Slot;
                OCRResult_tb.Text = job.Host_Job_Id;
                List<Job> tmp = new List<Job>();
                tmp.Add(job);
                WaferInfo_gv.DataSource = tmp;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Job job = JobManagement.Get(WaferID_tb.Text);
            if (job != null)
            {
                //job.Job_Id = WaferID_tb.Text;
                job.NeedProcess = NeedProcess_ck.Checked;
                job.ProcessFlag = ProcessFlag_ck.Checked;
                job.AlignerFlag = AlignFlag_ck.Checked;
                job.OCRFlag = OCRFlag_ck.Checked;
                Node NewPosition = NodeManagement.Get(Position_cb.Text);
                if (NewPosition != null)
                {
                    Job tmp;
                    if (!job.Position.ToUpper().Equals(Position_cb.Text) || !job.Slot.Equals(Slot_cb.Text))
                    {
                        if (NewPosition.JobList.TryAdd(Slot_cb.Text, job))
                        {
                            Node OrgPosition = NodeManagement.Get(job.Position);
                            if (OrgPosition != null)
                            {

                                OrgPosition.JobList.TryRemove(job.Slot, out tmp);
                                job.LastNode = job.Position;
                                job.LastSlot = job.Slot;

                                job.Position = Position_cb.Text;
                                job.Slot = Slot_cb.Text;

                                MonitoringUpdate.UpdateJobMove(job.Job_Id);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Wafer is Exist in new Position");
                            Position_cb.Text = job.Position;
                            Slot_cb.Text = job.Slot;
                        }
                    }
                }



                job.Host_Job_Id = OCRResult_tb.Text;
                MessageBox.Show("成功");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Job job = JobManagement.Get(WaferID_tb.Text);
            if (job != null)
            {
                Node OrgPosition = NodeManagement.Get(job.Position);
                Job tmp;
                OrgPosition.JobList.TryRemove(job.Slot, out tmp);
                job.LastNode = job.Position;
                job.LastSlot = job.Slot;
                job.Position = "";
                job.Slot = "";
                MonitoringUpdate.UpdateJobMove(job.Job_Id);

                JobManagement.Remove(tmp.Job_Id);
                ClearForm();
                MessageBox.Show("成功");
            }
        }

        private void ClearForm()
        {
            WaferID_tb.Text = "";
            NeedProcess_ck.Checked = false;
            ProcessFlag_ck.Checked = false;
            AlignFlag_ck.Checked = false;
            OCRFlag_ck.Checked = false;
            Position_cb.Text = "";
            Slot_cb.Text = "";
            OCRResult_tb.Text = "";
            List<Job> tmp = new List<Job>();

            WaferInfo_gv.DataSource = tmp;
        }

        private void Position_cb_TextChanged(object sender, EventArgs e)
        {
            int slotCnt = 0;
            if (Position_cb.Text.IndexOf("ALIGNER") != -1)
            {
                Slot_cb.Text = "1";
                slotCnt = 1;
            }
            else if (Position_cb.Text.IndexOf("ROBOT") != -1)
            {
                if(Slot_cb.Text != "1" || Slot_cb.Text != "2")
                {
                    Slot_cb.Text = "1";
                }
                slotCnt = 2;
            }
            else
            {
                slotCnt = 25;
            }
            Slot_cb.Items.Clear();
            for(int i = 0;i< slotCnt; i++)
            {
                Slot_cb.Items.Add((i+1).ToString());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TransferControl.Management;
using System.Linq;

namespace Adam.Menu.Monitoring
{
    public partial class FormMonitoring : Adam.Menu.FormFrame
    {
        public FormMonitoring()
        {
            InitializeComponent();
        }

       
        private void LoadPort_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 1:
                    List<Job> JobList = (sender as DataGridView).DataSource as List<Job>;
                    
                    switch (JobList[e.RowIndex].NeedProcess)
                    {
                        case true:  
                            e.CellStyle.BackColor = Color.Green;
                            e.CellStyle.ForeColor = Color.White;
                            break;

                    }

                    switch (e.Value)
                    {
                        case "No wafer":
                            e.CellStyle.BackColor = Color.Gray;
                            e.CellStyle.ForeColor = Color.White;
                            break;
                        case "Crossed":
                        case "Undefined":
                        case "Double":
                            e.CellStyle.BackColor = Color.Red;
                            e.CellStyle.ForeColor = Color.White;
                            break;
                       

                    }
                    break;

            }
        }

        private void label142_Click(object sender, EventArgs e)
        {

        }

        private void label140_Click(object sender, EventArgs e)
        {

        }

        private void label138_Click(object sender, EventArgs e)
        {

        }

        private void label136_Click(object sender, EventArgs e)
        {

        }

        private void label134_Click(object sender, EventArgs e)
        {

        }

        private void label132_Click(object sender, EventArgs e)
        {

        }

        private void label130_Click(object sender, EventArgs e)
        {

        }

        private void label128_Click(object sender, EventArgs e)
        {

        }

        private void label126_Click(object sender, EventArgs e)
        {

        }

        private void label124_Click(object sender, EventArgs e)
        {

        }

        private void label122_Click(object sender, EventArgs e)
        {

        }

        private void label120_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label118_Click(object sender, EventArgs e)
        {

        }

        private void Slot_Click(object sender, EventArgs e)
        {

            string[] ary = (sender as Label).Name.Split('_');
            if (ary.Length == 3)
            {
                string Port = ary[0];
                string Slot = ary[2];
                Node p = NodeManagement.Get(Port);
                if (p != null)
                {
                    Job j;
                    if(p.JobList.TryGetValue(Slot,out j))
                    {
                        if(j.OCRImgPath == "")
                        {
                            MessageBox.Show("未找到OCR紀錄");
                        }
                        else
                        {
                            OCRResult form2 = new OCRResult(j);
                            form2.ShowDialog();
                            //// open image in default viewer
                            //System.Diagnostics.Process.Start(j.OCRImgPath);
                        }
                    }
                    else
                    {
                        MessageBox.Show("未找到Wafer");
                    }
                }

            }
        }

        private void OCR01_Pic_DoubleClick(object sender, EventArgs e)
        {
            OCRResult form2 = new OCRResult((sender as PictureBox).Tag as Job);
            form2.ShowDialog();
        }

        private void OCR02_Pic_DoubleClick(object sender, EventArgs e)
        {
            OCRResult form2 = new OCRResult((sender as PictureBox).Tag as Job);
            form2.ShowDialog();
        }

        private void OCR02Read_Tb_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string Message = "";
            Transaction t = new Transaction();
            Node ocr2 = NodeManagement.Get("OCR02");
            t.Method = Transaction.Command.OCRType.ReadConfig;
            t.Value = "0";
            ocr2.SendCommand(t,out Message);
        }

        private void OCR02ReadT7_Tb_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string Message = "";
            Transaction t = new Transaction();
            Node ocr2 = NodeManagement.Get("OCR02");
            t.Method = Transaction.Command.OCRType.ReadConfig;
            t.Value = "1";
            ocr2.SendCommand(t, out Message);
        }

        private void Ocr2_lb_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string Message = "";
            Transaction t = new Transaction();
            Node ocr2 = NodeManagement.Get("OCR02");
            t.Method = Transaction.Command.OCRType.Read;
           
            ocr2.SendCommand(t, out Message);
        }

        private void Ocr1_lb_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string Message = "";
            Transaction t = new Transaction();
            Node ocr1 = NodeManagement.Get("OCR01");
            t.Method = Transaction.Command.OCRType.Read;

            ocr1.SendCommand(t, out Message);
        }

        private void Node_Disable_Click(object sender, EventArgs e)
        {
            string NodeName = (sender as CheckBox).Name.Replace("_disable_ck", "");
            Node node = NodeManagement.Get(NodeName);
            node.SetEnable(!((sender as CheckBox).Checked));

        }
        
        private void Cycle_btn_Click(object sender, EventArgs e)
        {
            FormMain.cycleRun = true;
            Node LD = null;
            Node ULD = null;
            foreach(Node port in NodeManagement.GetLoadPortList())
            {
                if (LD == null)
                {
                    if (port.Enable)
                    {
                        LD = port;
                        continue;
                    }
                }
                else
                {
                    if (port.Enable)
                    {
                        ULD = port;
                        break;
                    }
                }
            }
            if (LD != null && ULD != null)
            {
                var AvailableSlots = from eachSlot in LD.JobList.Values.ToList()
                                     where eachSlot.MapFlag && !eachSlot.ErrPosition
                                     select eachSlot;
                if (AvailableSlots.Count() == 0)
                {
                    AvailableSlots = from eachSlot in ULD.JobList.Values.ToList()
                                     where eachSlot.MapFlag && !eachSlot.ErrPosition
                                     select eachSlot;
                    if (AvailableSlots.Count() == 0)
                    {
                        return;
                    }
                    else
                    {
                        string ULDName = LD.Name;
                        LD = NodeManagement.Get(ULD.Name);
                        ULD = NodeManagement.Get(ULDName);
                    }
                }

                List<Job> LD_Jobs = LD.JobList.Values.ToList();
                LD_Jobs.Sort((x, y) => { return -Convert.ToInt32(x.Slot).CompareTo(Convert.ToInt32(y.Slot)); });

                List<Job> ULD_Jobs = ULD.JobList.Values.ToList();
                ULD_Jobs.Sort((x, y) => { return Convert.ToInt32(x.Slot).CompareTo(Convert.ToInt32(y.Slot)); });

                foreach (Job wafer in LD_Jobs)
                {
                    if (!wafer.MapFlag || wafer.ErrPosition)
                    {
                        continue;
                    }
                    bool isAssign = false;
                    foreach (Job Slot in ULD_Jobs)
                    {
                        if (!Slot.MapFlag && !Slot.ErrPosition && !Slot.IsAssigned)
                        {
                            wafer.NeedProcess = true;
                            wafer.ProcessFlag = false;
                            wafer.AssignPort(ULD.Name, Slot.Slot);
                            isAssign = true;
                            Slot.IsAssigned = true;
                            break;
                        }
                    }
                    if (!isAssign)
                    {
                        break;
                    }
                }

                FormMain.xfe.Start(LD.Name);
            }
        }

        private void Stop_btn_Click(object sender, EventArgs e)
        {
            FormMain.cycleRun = false;
        }
    }
}

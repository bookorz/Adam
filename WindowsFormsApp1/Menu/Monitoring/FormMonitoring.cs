using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TransferControl.Management;

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
    }
}

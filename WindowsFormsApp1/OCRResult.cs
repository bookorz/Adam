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

namespace Adam
{
    public partial class OCRResult : Form
    {
        Job _Job;

        public OCRResult(Job Job)
        {
            _Job = Job;
            InitializeComponent();
        }

        private void OCRResult_Load(object sender, EventArgs e)
        {
            if (_Job != null)
            {
                OCR_Img.Image = Image.FromFile(_Job.OCRImgPath);
                WaferID.Text = "Wafer ID:" + _Job.Host_Job_Id;
                OCR_Score.Text = "Score:" + _Job.OCRScore;
            }
            else
            {
                MessageBox.Show("Wafer 紀錄不存在");
            }
        }
    }
}

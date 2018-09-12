using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormVersion : Form
    {
        public FormVersion()
        {
            InitializeComponent();
        }

        private void FormVersion_Load(object sender, EventArgs e)
        {
            try
            {
                Ver_lb.Text = "Version " + System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString() + " (2018)";
            }
            catch
            {
                Ver_lb.Text = "Version 開發程式階段 (2018)";
            }
        }
    
    }
}

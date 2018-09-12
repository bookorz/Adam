using Adam.UI_Update.Alarm;
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
    public partial class FormAlarmHis : Form
    {
        public FormAlarmHis()
        {
            InitializeComponent();

            
        }

        private void FormAlarmHis_Load(object sender, EventArgs e)
        {
            From.Value = DateTime.Now.AddDays(-1);
            To.Value = DateTime.Now;
            AlarmUpdate.UpdateAlarmHistory(AlarmManagement.GetHistory(From.Value, To.Value));
        }
    }
}

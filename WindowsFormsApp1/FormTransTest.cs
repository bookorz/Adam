using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adam
{
    public partial class FormTransTest : Form
    {
        public FormTransTest()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            DataTable dtLoadPort01 = new DataTable();
            DataTable dtLoadPort02= new DataTable();
            DataRow dr;

            dtLoadPort01.Columns.Add("Slot");
            dtLoadPort01.Columns.Add("Wafer_ID");

            for (int i = 25; i > 0; i--)
            {
                dr = dtLoadPort01.NewRow();
                dr["Slot"] = (i).ToString();
                dr["Wafer_ID"] = string.Empty;
                dtLoadPort01.Rows.Add(dr);
            }

            dtLoadPort02.Columns.Add("Slot");
            dtLoadPort02.Columns.Add("Wafer_ID");

            for (int i = 25; i > 0; i--)
            {
                dr = dtLoadPort02.NewRow();
                dr["Slot"] = (i).ToString();
                dr["Wafer_ID"] = string.Empty;
                dtLoadPort02.Rows.Add(dr);
            }

            dataGridView1.DataSource = dtLoadPort02;
            dataGridView3.DataSource = dtLoadPort01;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_TEST
{
    public partial class Teaching : Form
    {
        public Teaching()
        {
            InitializeComponent();

            List<Position> table = new List<Position>();
            Position p = new Position();
            p.X = "-000505550";
            p.Y = "+000404985";
            p.Z = "+000007405";
            p.D = "+000089966";
            table.Add(p);
             p = new Position();
            p.X = "-000505550";
            p.Y = "+000404985";
            p.Z = "+000007405";
            p.D = "+000089966";
            table.Add(p);
             p = new Position();
            p.X = "-000505550";
            p.Y = "+000404985";
            p.Z = "+000007405";
            p.D = "+000089966";
            table.Add(p);
            dataGridView1.DataSource = table;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        public class Position
        {
            public string X { get; set; }
            public string Y { get; set; }
            public string Z { get; set; }
            public string D { get; set; }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
            {
                this.dataGridView1.Rows[e.RowIndex].HeaderCell.Value = "Current Position";
            }
            if (e.RowIndex == 1)
            {
                this.dataGridView1.Rows[e.RowIndex].HeaderCell.Value = "Teaching Position";
            }
            if (e.RowIndex == 2)
            {
                this.dataGridView1.Rows[e.RowIndex].HeaderCell.Value = "";
            }
        }
    }
}

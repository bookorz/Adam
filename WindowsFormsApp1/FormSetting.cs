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
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
            List<test> ttt = new List<test>();
            test t = new test();
            t.Parameter = "IP Adress";
            t.Value = "192.168.0.127";
            ttt.Add(t);
            t = new test();
            t.Parameter = "Port";
            t.Value = "23";
            ttt.Add(t);
            t = new test();
            t.Parameter = "Servo";
            t.Value = "On";
            ttt.Add(t);
            t = new test();
            t.Parameter = "Mode";
            t.Value = "Normal";
            ttt.Add(t);
            t = new test();
            t.Parameter = "Speed";
            t.Value = "0";
            ttt.Add(t);
            dataGridView1.DataSource = ttt;
            dataGridView1.Rows[1].HeaderCell.Value = "Current Position";
            

            //LLSetting tt = new LLSetting();
            //tt.Show();

            //Teaching t1 = new Teaching();
            //t1.Show();
        }
        public class test
        {
            public string Parameter { get; set; }
            public string Value { get; set; }
        }
    }
}

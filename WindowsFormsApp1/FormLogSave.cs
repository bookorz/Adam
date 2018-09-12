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
    public partial class FormLogSave : Form
    {
        public FormLogSave()
        {
            InitializeComponent();
            TreeNode tNode;
            tNode = treeView1.Nodes.Add("C:\\Sanwa\\");

            treeView1.Nodes[0].Nodes.Add("SYSTEM LOG");
            treeView1.Nodes[0].Nodes[0].Nodes.Add("SYS_20180516.log");
            treeView1.Nodes[0].Nodes[0].Nodes.Add("SYS_20180516_001.log");
            treeView1.Nodes[0].Nodes[0].Nodes.Add("SYS_20180516_002.log");

            treeView1.Nodes[0].Nodes.Add("DEVICE LOG");
            treeView1.Nodes[0].Nodes[1].Nodes.Add("DEVICE_ROBOT1_20180516.log");
            treeView1.Nodes[0].Nodes[1].Nodes.Add("DEVICE_ROBOT1_20180516_001.log");
            treeView1.Nodes[0].Nodes[1].Nodes.Add("DEVICE_ALIGNER1_20180516.log");
            treeView1.Nodes[0].Nodes[1].Nodes.Add("DEVICE_ALIGNER1_20180516_001.log");
            treeView1.Nodes[0].Nodes[1].Nodes.Add("DEVICE_ALIGNER2_20180516.log");
            treeView1.Nodes[0].Nodes[1].Nodes.Add("DEVICE_ALIGNER2_20180516_001.log");

            treeView1.Nodes[0].Nodes.Add("ALARM LOG");
            treeView1.Nodes[0].Nodes[2].Nodes.Add("ALARM_20180516.log");
            treeView1.Nodes[0].Nodes[2].Nodes.Add("ALARM_20180516_001.log");

            treeView1.Nodes[0].Nodes.Add("CONFIG");
            treeView1.Nodes[0].Nodes[3].Nodes.Add("CONFIG.ini");

            tNode.ExpandAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}

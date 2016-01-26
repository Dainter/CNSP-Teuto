using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNSP.Core;
using CNSP.Platform;

namespace CNSP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NationNode node1 = new NationNode("普鲁士王国");
            DistrictNode node2 = new DistrictNode("勃兰登堡");
            DistrictNode node3 = new DistrictNode("东普鲁士");
            node1.Merger(node2);
            node1.Merger(node3);
            node1.ShowTerritory();

            return;
        }
    }
}

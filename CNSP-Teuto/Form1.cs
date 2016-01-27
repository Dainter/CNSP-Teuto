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
            string strTerritory;
            NationNode node1 = new NationNode("普鲁士王国");
            DistrictNode node2 = new DistrictNode("勃兰登堡");
            DistrictNode node3 = new DistrictNode("东普鲁士");
            DistrictNode node4 = new DistrictNode("西普鲁士");
            
            node1.Merger(node2);
            node1.Merger(node3);
            node1.Merger(node4);

            strTerritory = node1.ShowTerritory();
            NationNode node5 = new NationNode("瑞典王国");
            DistrictNode node6 = new DistrictNode("波美拉尼亚");
            node5.Merger(node6);
            strTerritory = node5.ShowTerritory();

            node5.Cession(node6);
            strTerritory = node5.ShowTerritory();
            node1.Merger(node6);
            strTerritory = node1.ShowTerritory();
            return;
        }
    }
}

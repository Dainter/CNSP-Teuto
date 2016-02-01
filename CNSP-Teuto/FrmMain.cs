using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using CNSP.Core.Graph;
using CNSP.Core.Edge;
using CNSP.Core.Node;
using CNSP.Platform;
using CNSP.Platform.IO;

namespace CNSP
{
    public partial class FrmMain : Form
    {
        Empire china;
        Graphics GraFore;             //全局变量，网络图形对象
        Bitmap imgFore;                  //全局变量，网络图像
        const int PicWidth = 581;         //全局变量，图像宽度
        const int PicHeight = 482;        //全局变量，图像高度

        public FrmMain()
        {
            InitializeComponent();
        }

        public void GraphicReset()
        {
            int x, y;
            //主窗体重置
            x = MainLayout.Location.X + TabMain.Location.X + PanelPic.Location.X + PicWidth + 40;
            y = MainLayout.Location.Y + TabMain.Location.Y + PanelPic.Location.Y + PicHeight + 78;
            this.MaximumSize = new Size(x, y);
            //地图重置
            if (imgFore != null)
            {
                imgFore.Dispose();
            }
            imgFore = new Bitmap(PicWidth, PicHeight);
            GraFore = Graphics.FromImage(imgFore);
            GraFore.SmoothingMode = SmoothingMode.HighQuality;
            china.DrawMap(ref GraFore);
            PicCam.Image = imgFore;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            china = new Empire();
            //XmlDocument doc = china.EmpireData.ToXML();
            //doc.Save("1.xml");
            china.Round();
            return;
        }

        private void StartTimer_Tick(object sender, EventArgs e)
        {
            GraphicReset();
            NationList_Load();
            StartTimer.Enabled = false;
        }

        private void NationList_Load()
        {
            NationList.Items.Clear();
            foreach (NationNode node in china.Nations)
            {
                NationList.Items.Add(node.Name);
            }
        }

        private void NationList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NationList.SelectedIndex > -1)
            {
                //更新国家信息
                ArmyBox.Text = china.Nations[NationList.SelectedIndex].Army.ToString();
                MoneyBox.Text = china.Nations[NationList.SelectedIndex].Money.ToString();
                //更新辖地信息
                DistrictList_Load(china.Nations[NationList.SelectedIndex]);
            }
        }

        private void DistrictList_Load(NationNode nation)
        {
            DistrictList.Items.Clear();
            foreach (DistrictNode node in nation.Districts)
            {
                DistrictList.Items.Add(node.Name);
            }
        }

        private void DistrictList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DistrictList.SelectedIndex > -1)
            {
                NationNode nation = china.Nations[NationList.SelectedIndex];
                DistrictInfo_Load(nation.Districts[DistrictList.SelectedIndex]);
            }
        }

        private void DistrictInfo_Load(DistrictNode dist)
        {
            DistPopu.Text = dist.Population.ToString();
            DistArgi.Text = dist.Harvest.ToString();
            DistComm.Text = dist.Commerce.ToString();
            DistTrade.Text = dist.Trade.ToString();
 
        }

        /*
        void Network_Init()
        {

        }
        
        void Add(int iStart, int iEnd)
        {
            AddEdge(iStart, iEnd);
        }

        void AddEdge(int iStart, int iEnd)
        {
            IfCoreNode nodeStart, nodeEnd;
            RuleEdge newEdge = new RuleEdge();
            nodeStart = china.GetNodeAtIndex(iStart);
            nodeEnd = china.GetNodeAtIndex(iEnd);
            china.AddEdge(nodeStart, nodeEnd, newEdge);
        }

        void Save(Graph zhanguo)
        {
            XmlDocument doc = zhanguo.ToXML();
            doc.Save("1.xml");
        }

        Graph Read()
        {
            IfIOStrategy reader = new XMLStrategy();
            return reader.ReadFile("0.xml");
        }*/
    }
}

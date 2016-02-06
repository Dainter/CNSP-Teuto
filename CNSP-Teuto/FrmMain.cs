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

            //Network_Init();
            //XmlDocument doc = china.EmpireData.ToXML();
            //doc.Save("1.xml");
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
                PopulationBox.Text = china.Nations[NationList.SelectedIndex].Population.ToString();
                MoneyBox.Text = china.Nations[NationList.SelectedIndex].Money.ToString();
                ArmyBox.Text = china.Nations[NationList.SelectedIndex].Army.ToString();
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

        private void Round()
        {
            china.Round();
            //每回合结束后的统计
            Statistic();
        }

        private void Statistic()
        {
            china.Statistic(ref PopuRankBox, "人口");
            china.Statistic(ref DistRankBox, "地区");
            china.Statistic(ref MoneyRankBox, "经济");
            china.Statistic(ref ArmyRankBox, "兵力");
        }

        private void RoundTimer_Tick(object sender, EventArgs e)
        {
            Round();
        }

        private void StartMI_Click(object sender, EventArgs e)
        {
            if (RoundTimer.Enabled == false)
            {
                RoundTimer.Enabled = true;
            }
        }

        private void PauseMI_Click(object sender, EventArgs e)
        {
            if (RoundTimer.Enabled == true)
            {
                RoundTimer.Enabled = false;
            }
        }

        private void ResetMI_Click(object sender, EventArgs e)
        {
            if (RoundTimer.Enabled == true)
            {
                RoundTimer.Enabled = false;
            }
            china = new Empire();
            GraphicReset();
            NationList_Load();
        }

        
        void Network_Init()
        {
            Add(53,52);

            Add(54, 52);
            Add(54, 53);

            Add(55, 52);
            Add(55, 53);
            Add(55, 54);

            Add(56, 52);
            Add(56, 53);
            Add(56, 54);
            Add(56, 55);

            Add(57, 52);
            Add(57, 53);
            Add(57, 54);
            Add(57, 55);
            Add(57, 56);

            Add(58, 52);
            Add(58, 53);
            Add(58, 54);
            Add(58, 55);
            Add(58, 56);
            Add(58, 57);

            Add(59, 52);
            Add(59, 53);
            Add(59, 54);
            Add(59, 55);
            Add(59, 56);
            Add(59, 57);
            Add(59, 58);

            Add(60, 52);
            Add(60, 53);
            Add(60, 54);
            Add(60, 55);
            Add(60, 56);
            Add(60, 57);
            Add(60, 58);
            Add(60, 59);

            Add(61, 52);
            Add(61, 53);
            Add(61, 54);
            Add(61, 55);
            Add(61, 56);
            Add(61, 57);
            Add(61, 58);
            Add(61, 59);
            Add(61, 60);
        }
        
        void Add(int iStart, int iEnd)
        {
            AddEdge(iEnd, iStart);
            AddEdge(iStart, iEnd);
        }

        void AddEdge(int iStart, int iEnd)
        {
            IfCoreNode nodeStart, nodeEnd;
            DiplomacyEdge newEdge = new DiplomacyEdge();
            nodeStart = china.EmpireData.GetNodeAtIndex(iStart);
            nodeEnd = china.EmpireData.GetNodeAtIndex(iEnd);
            china.EmpireData.AddEdge(nodeStart, nodeEnd, newEdge);
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
        }
    }
}

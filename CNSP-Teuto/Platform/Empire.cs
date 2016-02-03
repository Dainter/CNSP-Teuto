using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using CNSP.Core.Graph;
using CNSP.Core.Node;
using CNSP.Core.Edge;
using CNSP.Core.User;
using CNSP.Platform.IO;

namespace CNSP.Platform
{
    public class Empire
    {
        int intRound;                               //回合计数器
        public Graph EmpireData;            //图数据库对象
        List<KingNode> KingsList;           //国王列表
        List<NationNode> NationsList;   //国家列表
        List<DistrictNode> DistrictsList;   //地区列表
        //属性///////////////////////
        public List<NationNode> Nations
        {
            get
            {
                return NationsList;
            }
        }
        public List<KingNode> Leaders
        {
            get
            {
                return KingsList;
            }
        }

        //方法//////////////////////
        public Empire()
        {
            EmpireData = new Graph();
            IfIOStrategy reader = new XMLStrategy();
            //读入数据库
            EmpireData = reader.ReadFile("0.xml");
            intRound = 1;
            //所有节点初始化
            Initialize();
        }
        //初始化，生成节点
        public void Initialize()
        {
            KingsList = new List<KingNode>();
            NationsList = new List<NationNode>();
            DistrictsList = new List<DistrictNode>();
            foreach (IfCoreNode curNode in EmpireData.Nodes)
            {
                switch (curNode.Type.Type)
                {
                    case NodeTypeEnum.CharKing:
                        KingsList.Add((KingNode)curNode);
                        break;
                    case NodeTypeEnum.Nation:
                        NationsList.Add((NationNode)curNode);
                        break;
                    case NodeTypeEnum.District:
                        DistrictsList.Add((DistrictNode)curNode);
                        break;
                    default:
                        break;
                }
            }
            //领袖初始化
            foreach (KingNode kNode in KingsList)
            {
                kNode.MakePolicy();
            }
            //国家初始化
            foreach (NationNode nNode in NationsList)
            {
                nNode.Initialize();
            }
        }
        //绘制地图
        public void DrawMap(ref Graphics graMap)
        {
            Point locStart, locEnd;
            Pen LinePen;
            Image nodeImage;

            LinePen = new Pen(Brushes.Gray);
            LinePen.Width = 1;
            foreach (IfCoreEdge edge in EmpireData.Edges)
            {
                //绘制地区之间连边
                if (edge.Type.Type == EdgeTypeEnum.Connect)
                {
                    locStart = edge.Start.Location;
                    locEnd = edge.End.Location;
                    graMap.DrawLine(LinePen, locStart, locEnd);
                }
            }
            LinePen.Dispose();
            //绘制所有地区节点
            foreach (DistrictNode curNode in this.DistrictsList)
            {
                nodeImage = DrawNode(curNode, curNode.Nation);
                graMap.DrawImage(nodeImage,
                                   new Point(curNode.Location.X - nodeImage.Width / 2,
                                               curNode.Location.Y - nodeImage.Height / 2));
            }
        }
        //绘制节点
        Image DrawNode(DistrictNode dNode, NationNode nNode)
        {
            Pen frame;					//显示变量 边框画笔
            Image img;                  //返回Image
            Graphics gGraphic;      //绘制目标图元
            SolidBrush fore, back;				//显示变量 背景色刷
            int intRand;                    //半径

            intRand = 12;
            //新建位图，存放节点图像
            img = new Bitmap(intRand * 2 + 1, intRand * 2 + 1);
            gGraphic = Graphics.FromImage(img);
            gGraphic.SmoothingMode = SmoothingMode.HighQuality;//平滑处理
            //填充圆形
            back = new SolidBrush(nNode.BackColor);
            gGraphic.FillEllipse(back, 0, 0, intRand * 2, intRand * 2);
            //外围边框绘制
            frame = new Pen(nNode.FrameColor);
            gGraphic.DrawEllipse(frame, 0, 0, 2 * intRand, 2 * intRand);
            //绘制前景字符串
            fore = new SolidBrush(nNode.ForeColor);
            gGraphic.DrawString(dNode.Name, new Font("Times New Roman", 7), fore,  1,  7);
            return img;
        }
        //每年操作
        public void Round()
        {
            //执行各国的回合
            foreach(NationNode node in this.NationsList)
            {
                node.Round(intRound);
            }

        }
        //数据统计与排序
        public void Statistic(ref ListBox curListBox, string sOption)
        {
            switch (sOption)
            {
                case "人口":
                    NationsList.Sort(NationNode.CompareNationsByPopulation);
                    break;
                case "地区":
                    NationsList.Sort(NationNode.CompareNationsByDistrict);
                    break;
                case "经济":
                    NationsList.Sort(NationNode.CompareNationsByMoney);
                    break;
                case "兵力":
                    NationsList.Sort(NationNode.CompareNationsByArmy);
                    break;
                default:
                    break;
            }
            LoadRankResult(ref curListBox, sOption);
            NationsList.Sort(NationNode.CompareNationsByNumber);
        }
        //载入排序结果
        private void LoadRankResult(ref ListBox curListBox, string sOption)
        {
            curListBox.Items.Clear();
            foreach (NationNode node in NationsList)
            {
                switch (sOption)
                {
                    case "人口":
                        curListBox.Items.AddRange(new object[] { node.Name + " "+node.Population.ToString()});
                        break;
                    case "地区":
                        curListBox.Items.AddRange(new object[] { node.Name + " " + node.Districts.Count.ToString() });
                        break;
                    case "经济":
                        curListBox.Items.AddRange(new object[] { node.Name + " " + node.Money.ToString() });
                        break;
                    case "兵力":
                        curListBox.Items.AddRange(new object[] { node.Name + " " + node.Army.ToString() });
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

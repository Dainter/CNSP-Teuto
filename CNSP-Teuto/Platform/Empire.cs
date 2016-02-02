using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Drawing;
using System.Drawing.Drawing2D;
using CNSP.Core.Graph;
using CNSP.Core.Node;
using CNSP.Core.Edge;
using CNSP.Core.User;
using CNSP.Platform.IO;

namespace CNSP.Platform
{
    public class Empire
    {
        int intRound;
        public Graph EmpireData;
        List<KingNode> KingsList;
        List<NationNode> NationsList;
        List<DistrictNode> DistrictsList;
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
            EmpireData = reader.ReadFile("0.xml");
            intRound = 1;
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
                if (edge.Type.Type == EdgeTypeEnum.Connect)
                {
                    locStart = edge.Start.Location;
                    locEnd = edge.End.Location;
                    graMap.DrawLine(LinePen, locStart, locEnd);
                }
            }
            LinePen.Dispose();
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
            foreach(NationNode node in this.NationsList)
            {
                node.PreRound(intRound);
            }
            Statistic();
        }

        private void Statistic()
        {
            NationsList.Sort(NationNode.CompareNationsByPopulation);
            NationsList.Sort(NationNode.CompareNationsByDistrict);
            NationsList.Sort(NationNode.CompareNationsByMoney);
            NationsList.Sort(NationNode.CompareNationsByArmy);
            NationsList.Sort(NationNode.CompareNationsByNumber);
        }
    }
}

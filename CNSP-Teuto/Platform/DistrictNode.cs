using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;
using CNSP.Core.Node;
using CNSP.Core.Edge;
using CNSP.Core.User;

namespace CNSP.Platform
{
    public class DistrictNode : Node
    {
        string strName;
        int intPolulation;
        double dubHarvest;
        double dubCommerce;
        double dubTrade;
        //属性///////////////////////////////
        public string Name
        {
            get
            {
                return strName;
            }
        }
        public NationNode Nation
        {
            get
            {
                return this.BelongTo();
            }
        }
        public double Harvest
        {
            get
            {
                return dubHarvest;
            }
        }
        public double Commerce
        {
            get
            {
                return dubCommerce;
            }
        }
        public double Trade
        {
            get
            {
                return dubTrade;
            }
        }
        public int Population
        {
            get
            {
                return intPolulation;
            }
        }
        //方法///////////////////////////////
        //构造函数
        public DistrictNode(string sName, int iPopu):base(new NodeType(NodeTypeEnum.District))
        {
            if (sName == null)
            {
                sName = "叛军城镇";
            }
            strName = sName;
            dubHarvest = iPopu;
            dubCommerce = iPopu;
            intPolulation = iPopu;
        }
        //构造函数- xml
        public DistrictNode(XmlElement xNode)
            : base(new NodeType(NodeTypeEnum.District), xNode)
        {
            this.strName = GetText(xNode, "Name");
            this.intPolulation = Convert.ToInt32(GetText(xNode, "Population"));
            this.dubHarvest = this.intPolulation;
            this.dubCommerce = this.intPolulation;
        }
        //将节点数据保存为xml格式
        public override XmlElement XMLoutput(ref XmlDocument doc)
        {
            XmlElement curNode;
            XmlElement name_xml, population_xml;
            XmlText name_txt, population_txt;

            curNode = base.XMLoutput(ref doc);

            //节点度
            name_xml = doc.CreateElement("Name");
            population_xml = doc.CreateElement("Population");

            name_txt = doc.CreateTextNode(this.Name.ToString());               //创建各属性的文本元素
            population_txt = doc.CreateTextNode(this.Population.ToString());

            name_xml.AppendChild(name_txt);                                    //将标题元素赋予文本内容
            population_xml.AppendChild(population_txt);

            curNode.AppendChild(name_xml);                                   //向当前节点中加入各属性节点
            curNode.AppendChild(population_xml); 

            return curNode;
        }
        //节点初始化
        public void Initialize(double dubArgiRate, double dubCommRate)
        {
            int iPiece = NeighborInPeace().Count;
            dubHarvest = intPolulation * dubArgiRate;
            dubCommerce = intPolulation * dubCommRate;
            if (iPiece == 0)
            {
                dubTrade = 0;
                return;
            }
            dubTrade = dubCommerce / (iPiece * 1.0);
            return;
        }
        //返回节点所属国家
        NationNode BelongTo()
        {
            foreach (IfCoreEdge curEdge in this.InBound)
            {
                if (curEdge.Type.Type == EdgeTypeEnum.Rule)
                {
                    return (NationNode)curEdge.Start;
                }
            }
            return null;
        }
        //返回处于中立关系的地区列表
        List<DistrictNode> NeighborInPeace()
        {
            List<DistrictNode> ResultList = new List<DistrictNode>();
            foreach (IfCoreEdge edge in this.OutBound)
            {
                if (edge.Type.Type == EdgeTypeEnum.Connect)
                {
                    ResultList.Add((DistrictNode)(edge.End));
                }
            }
            return ResultList;
        }
        //人口增殖 返回征兵数
        public int PopulationBreed(double dubBreed, double dubDraft)
        {
            int intDraft;

            intDraft = Convert.ToInt32(intPolulation * dubDraft);
            intPolulation = Convert.ToInt32(intPolulation * (1.0 + dubBreed)) - intDraft;
            return intDraft;
        }
        //商业交换 返回税收数
        public double Economy(double dubArgiRate, double dubCommRate, double dubTaxRate)
        {
            double dubTax;
            int iPiece = NeighborInPeace().Count;
            dubHarvest = intPolulation * dubArgiRate;
            dubCommerce = intPolulation * dubCommRate;
            foreach (DistrictNode node in NeighborInPeace())
            {
                dubCommerce += node.Trade;
            }
            dubTax = dubCommerce * dubTaxRate;
            dubCommerce -= dubTax;
            if (iPiece == 0)
            {
                dubTrade = 0;
            }
            else
            {
                dubTrade = dubCommerce / (iPiece * 1.0);
            }
            return dubTax;
        }
        //

    }
}

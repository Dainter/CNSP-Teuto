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
        int intHarvest;
        int intCommerce;
        int intPolulation;
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
        public int Harvest
        {
            get
            {
                return intHarvest;
            }
        }
        public int Commerce
        {
            get
            {
                return intCommerce;
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
            intHarvest = iPopu;
            intCommerce = iPopu;
            intPolulation = iPopu;
        }
        //构造函数- xml
        public DistrictNode(XmlElement xNode)
            : base(new NodeType(NodeTypeEnum.District), xNode)
        {
            this.strName = GetText(xNode, "Name");
            this.intPolulation = Convert.ToInt32(GetText(xNode, "Population"));
            this.intHarvest = this.intPolulation;
            this.intCommerce = this.intPolulation;
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

    }
}

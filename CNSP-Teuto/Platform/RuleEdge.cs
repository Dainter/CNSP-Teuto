using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using CNSP.Core.Node;
using CNSP.Core.Edge;
using CNSP.Core.User;

namespace CNSP.Platform
{
    public class RuleEdge:Edge//统治关系连边类
    {
        double dubLoyalty;
        
        //属性///////////////////////////////
        public double Loyalty
        {
            get
            {
                return dubLoyalty;
            }
        }

        //方法///////////////////////////////
        //构造函数
        public RuleEdge()
            : base(new EdgeType(EdgeTypeEnum.Rule))
        {
            dubLoyalty = 1.0;
        }
        //构造函数-xml
        public RuleEdge(XmlElement xNode)
            : base(new EdgeType(EdgeTypeEnum.Rule), xNode)
        {
            string strLoyalty = GetText(xNode, "Loyalty");
            if (strLoyalty == "")
            {
                dubLoyalty = 1.0;
            }
            else
            {
                dubLoyalty = Convert.ToDouble(strLoyalty);
            }
            
        }

        //将连边数据保存为xml格式
        public override XmlElement XMLoutput(ref XmlDocument doc)
        {
            XmlElement curNode;
            XmlElement Loyalty_xml;
            XmlText Loyalty_txt;

            curNode = base.XMLoutput(ref doc);

            //节点度
            Loyalty_xml = doc.CreateElement("Loyalty");

            Loyalty_txt = doc.CreateTextNode(this.Loyalty.ToString());               //创建各属性的文本元素

            Loyalty_xml.AppendChild(Loyalty_txt);                                    //将标题元素赋予文本内容

            curNode.AppendChild(Loyalty_xml);                                   //向当前节点中加入各属性节点


            return curNode;
        }

    }
}

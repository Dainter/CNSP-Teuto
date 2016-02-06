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
    public class DiplomacyEdge : Edge//外交关系连边
    {
        string strDiplomacyState;
        //属性
        public string State
        {
            get
            {
                return strDiplomacyState;
            }
        }
         //构造函数
        public DiplomacyEdge(string sDipState = "")
            : base(new EdgeType(EdgeTypeEnum.Diplomacy))
        {
            switch (sDipState)
            {
                case "中立":
                case "敌对":
                case "联盟":
                    strDiplomacyState = sDipState;
                    break;
                default:
                    strDiplomacyState = "中立";
                    break;
            }
        }
        //构造函数- xml
        public DiplomacyEdge(XmlElement xNode)
            : base(new EdgeType(EdgeTypeEnum.Diplomacy), xNode)
        {
            string sDipState = GetText(xNode, "Diplomacy");
            switch (sDipState)
            {
                case "中立":
                case "敌对":
                case "联盟":
                    this.strDiplomacyState = sDipState;
                    break;
                default:
                    this.strDiplomacyState = "中立";
                    break;
            }
        }
        //将连边数据保存为xml格式
        public override XmlElement XMLoutput(ref XmlDocument doc)
        {
            XmlElement state_xml;
            XmlText state_txt;

            XmlElement curEdge = base.XMLoutput(ref doc);

            state_xml = doc.CreateElement("Diplomacy");

            state_txt = doc.CreateTextNode(this.State);               //创建各属性的文本元素

            state_xml.AppendChild(state_txt);                                    //将标题元素赋予文本内容

            curEdge.AppendChild(state_xml);                                   //向当前节点中加入各属性节点

            return curEdge;
        }
    }
}

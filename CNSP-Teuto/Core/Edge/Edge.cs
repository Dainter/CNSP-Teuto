using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using CNSP.Core.Node;
using CNSP.Core.User;

namespace CNSP.Core.Edge
{
    public class Edge : IfCoreEdge//图数据库连边类：负责存储网络连边信息
    {
        //共享变量
        static int intMaxEdgeNum = 0;
        //成员变量
        int intEdgeNum;
        IfCoreNode nodeStart;//连边起点
        IfCoreNode nodeEnd;//连边终点
        EdgeType edgeType;//连边类型

        //属性//////////////////////////
        public int Number
        {
            get
            {
                return intEdgeNum;
            }
        }
        public IfCoreNode Start
        {
            get
            {
                return nodeStart;
            }
            set
            {
                nodeStart = value; 
            }
        }
        public IfCoreNode End
        {
            get
            {
                return nodeEnd;
            }
            set
            {
                nodeEnd = value;
            }
        }
        public EdgeType Type
        {
            get
            {
                return edgeType;
            }
        }
        //方法/////////////////////////
        //连边类Edge构造函数
        public Edge(EdgeType newType)//构造函数 对三个变量进行赋值
        {
            this.intEdgeNum = intMaxEdgeNum;
            this.edgeType = newType;
            intMaxEdgeNum++;
        }
        //连边类Edge构造函数
        public Edge(EdgeType newType, XmlElement xNode)//构造函数 对三个变量进行赋值
        {
            this.intEdgeNum = intMaxEdgeNum;
            this.edgeType = newType;
            intMaxEdgeNum++;
        }

        //工具函数，从xml节点中读取某个标签的InnerText
        protected string GetText(XmlElement curNode, string sLabel)
        {
            if (curNode == null)
            {
                return "";
            }
            //遍历当前XML的所有子标签
            foreach (XmlElement xNode in curNode.ChildNodes)
            {
                if (xNode.Name == sLabel)
                {//返回标签内容一致的内部数据
                    return xNode.InnerText;
                }
            }
            return "";
        }

        //将连边数据保存为xml格式
        public virtual XmlElement XMLoutput(ref XmlDocument doc)
        {
            XmlElement curEdge = doc.CreateElement("Edge");         //创建连边元素
            XmlElement type_xml, Start_xml, End_xml;
            XmlText type_txt, Start_txt, End_txt;

            //节点度
            type_xml = doc.CreateElement("EdgeType");
            //节点位置
            Start_xml = doc.CreateElement("Start");
            End_xml = doc.CreateElement("End");

            type_txt = doc.CreateTextNode(this.Type.ToString());               //创建各属性的文本元素
            Start_txt = doc.CreateTextNode(this.Start.SaveIndex.ToString());
            End_txt = doc.CreateTextNode(this.End.SaveIndex.ToString());


            type_xml.AppendChild(type_txt);                                    //将标题元素赋予文本内容
            Start_xml.AppendChild(Start_txt);
            End_xml.AppendChild(End_txt);

            curEdge.AppendChild(type_xml);                                   //向当前节点中加入各属性节点
            curEdge.AppendChild(Start_xml);
            curEdge.AppendChild(End_xml);

            return curEdge;
        }
    }
}

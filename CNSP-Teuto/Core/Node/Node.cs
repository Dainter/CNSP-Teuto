using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml;
using CNSP.Core.Edge;
using CNSP.Core.User;

namespace CNSP.Core.Node
{
    public class Node:IfCoreNode//图数据库节点类：负责存储单一网络节点的信息，并向上层类提供功能接口函数
    {
        //共享变量
        static int intMaxNodeNum = 0;
        //成员变量
        int intNodeNum;                           //节点编号
        NodeType nodeType;
        List<IfCoreEdge> OutLink;       //连边 使用字典结构存放（目标节点号，连边对象）
        List<IfCoreEdge> InLink;
        Point potLoc;                        //节点位置
        int intSaveIndex;
        //属性///////////////////////////////
        public int Number
        {
            get
            {
                return intNodeNum;
            }
        }
        public NodeType Type
        {
            get
            {
                return nodeType;
            }
        }
        public int Degree
        {
            get
            {
                return OutLink.Count;
            }
        }
        public Point Location
        {
            get
            {
                return potLoc;
            }
            set
            {
                potLoc = value;
            }
        }
        public List<IfCoreEdge> OutBound
        {
            get
            {
                return OutLink;
            }
        }
        public List<IfCoreEdge> InBound
        {
            get
            {
                return InLink;
            }
        }
        public int SaveIndex
        {
            get
            {
                return intSaveIndex;
            }
            set
            {
                intSaveIndex = value;
            }
        }
        //方法///////////////////////////////
        //节点类Node构造函数
        public Node (NodeType newType)    
        {
            this.intNodeNum = intMaxNodeNum;
            this.potLoc = new Point(0,0);
            this.nodeType = newType;
            this.intSaveIndex = this.intNodeNum;
            OutLink = new List<IfCoreEdge>();
            InLink = new List<IfCoreEdge>();
            intMaxNodeNum++;
        }

        //xml构造函数
        public Node(NodeType newType, XmlElement xNode)
        {
            string xPos, yPos;
            int intX, intY;
            this.intNodeNum = intMaxNodeNum;
            xPos = GetText(xNode, "Xpos");
            yPos = GetText(xNode, "Ypos");
            intX = Convert.ToInt32(xPos);
            intY = Convert.ToInt32(yPos);
            this.potLoc = new Point(intX, intY);
            this.nodeType = newType;
            this.intSaveIndex = this.intNodeNum;
            OutLink = new List<IfCoreEdge>();
            InLink = new List<IfCoreEdge>();
            intMaxNodeNum++;
        }
        
        //工具函数，从xml节点中读取某个标签的InnerText
        protected string GetText(XmlElement curNode, string sLabel)
        {
            if (curNode == null)
            {
                return "";
            }
            foreach (XmlElement xNode in curNode.ChildNodes)
            {
                if (xNode.Name == sLabel)
                {
                    return xNode.InnerText;
                }
            }
            return "";
        }

        //增加连边
        public bool AddEdge(IfCoreEdge newEdge)
        {
            if (newEdge == null)
            {
                return false;
            }
            if (newEdge.Start.Number != intNodeNum || newEdge.End.Number == intNodeNum)//检测条件：当前节点与目标节点不相连，且目标节点不是当前节点
            {
                return false;
            }
            if (OutBoundContainsEdge(newEdge) == true)
            {
                return false;
            }
            OutLink.Add(newEdge);   //向Links中加入新项目  
            return true;
        }

        //Inbound边注册
        public bool RegisterInbound(IfCoreEdge newEdge)
        {
            if (newEdge == null)
            {
                return false;
            }
            if (newEdge.End.Number != intNodeNum || newEdge.Start.Number == intNodeNum)//检测条件：当前节点与目标节点不相连，且目标节点不是当前节点
            {
                return false;
            }
            if (InBoundContainsEdge(newEdge) == true)
            {
                return false;
            }
            InLink.Add(newEdge);
            return true;
        }

        //去除连边
        public bool RemoveEdge(IfCoreEdge curEdge)
        {
            if (curEdge == null)
            {
                return false;
            }
            if (curEdge.Start.Number != intNodeNum || curEdge.End.Number == intNodeNum)//检测条件：当前节点与目标节点不相连，且目标节点不是当前节点
            {
                return false;
            }
            if (OutBoundContainsEdge(curEdge) == false)
            {
                return false;
            }
            OutLink.Remove(curEdge);
            return true;
        }

        //清除所有连边,返回被清除的边列表
        public List<IfCoreEdge> ClearEdge()
        {
            List<IfCoreEdge> EdgeList = new List<IfCoreEdge>();
            foreach (IfCoreEdge edge in this.OutBound)
            {
                edge.End.UnRegisterInbound(edge);
                edge.Start = null;
                edge.End = null;
                EdgeList.Add(edge);
            }
            this.OutBound.Clear();
            foreach (IfCoreEdge edge in this.InBound)
            {
                edge.Start.RemoveEdge(edge);
                edge.Start = null;
                edge.End = null;
                EdgeList.Add(edge);
            }
            this.InBound.Clear();
            return EdgeList;
        }

        //Inbound注销
        public bool UnRegisterInbound(IfCoreEdge curEdge)
        {
            if (curEdge == null)
            {
                return false;
            }
            if (curEdge.End.Number != intNodeNum || curEdge.Start.Number == intNodeNum)//检测条件：当前节点与目标节点不相连，且目标节点不是当前节点
            {
                return false;
            }
            if (InBoundContainsEdge(curEdge) == false)
            {
                return false;
            }
            InLink.Remove(curEdge);
            return true;

        }

        //返回OutBound是否包含和目标节点间的连边
        bool OutBoundContainsEdge(IfCoreEdge newEdge)
        {
            if (OutLink.Contains(newEdge))
            {
                return true;
            }
            foreach (IfCoreEdge edge in OutLink)
            {
                if (edge.End.Number == newEdge.End.Number)
                {
                    return true;
                }
            }
            return false;
        }

        //返回InBound是否包含和目标节点间的连边
        bool InBoundContainsEdge(IfCoreEdge newEdge)
        {
            if (InLink.Contains(newEdge))
            {
                return true;
            }
            foreach (IfCoreEdge edge in InLink)
            {
                if (edge.Start.Number == newEdge.Start.Number)
                {
                    return true;
                }
            }
            return false;
        }

        //将节点数据保存为xml格式
        public virtual XmlElement XMLoutput(ref XmlDocument doc)
        {
            XmlElement curNode = doc.CreateElement("Node");
            XmlElement type_xml, x_xml, y_xml;
            XmlText type_txt, x_txt, y_txt;

            curNode.SetAttribute("num", this.SaveIndex.ToString());                   //创建各属性的Tag元素
            //节点类型
            type_xml = doc.CreateElement("NodeType");
            //节点位置
            x_xml = doc.CreateElement("Xpos");
            y_xml = doc.CreateElement("Ypos");

            type_txt = doc.CreateTextNode(this.Type.ToString());               //创建各属性的文本元素
            x_txt = doc.CreateTextNode(this.Location.X.ToString());
            y_txt = doc.CreateTextNode(this.Location.Y.ToString());


            type_xml.AppendChild(type_txt);                                    //将标题元素赋予文本内容
            x_xml.AppendChild(x_txt);
            y_xml.AppendChild(y_txt);

            curNode.AppendChild(type_xml);                                   //向当前节点中加入各属性节点
            curNode.AppendChild(x_xml);
            curNode.AppendChild(y_xml);

            return curNode;
        }
    }
}

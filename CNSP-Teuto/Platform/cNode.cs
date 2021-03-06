using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D; 
using System.Xml;
using CNSP.Core;

namespace CNSP.Platform
{
    public class cNode:IfPlatform//复杂网络节点类：负责存储单一网络节点的信息，并向上层类提供功能接口函数
    {
        //成员变量
        Node node;
        //属性///////////////////////////////
        int IfPlatform.Number
        {
            get
            {
                return this.node.Number;
            }
        }
        int IfPlatform.Degree
        {
            get
            {
                return this.node.Degree;
            }
        }
        Point IfPlatform.Location
        {
            get
            {
                return this.node.Location;
            }
            set
            {
                this.node.Location = value;
            }
        }
        //方法///////////////////////////////
        public cNode(int iNum)    //构造函数：新建
        {
            this.node = new Node(iNum);
        }
        //增加连边
        bool IfPlatform.AddEdge(int iTarget, int iValue)
        {
            return this.node.AddEdge(iTarget, iValue);
        }

        //删除连边
        bool IfPlatform.DecEdge(int iTarget)
        {
            return this.node.DecEdge(iTarget);
        }

        //获取指定连边权重
        int IfPlatform.GetWeight(int iTarget)
        {
            if (node.ContainsEdge(iTarget) == true)
            {
                return node.ValueOfEdge(iTarget);
            }
            return 0;
        }

        //检查是否包含和某个节点间连边
        bool IfPlatform.Contains(int iTarget)
        {
            return this.node.ContainsEdge(iTarget);
        }
        //返回枚举器，foreach语句使用
        NodeEnumerator IfPlatform.GetEnumerator()
        {
            return this.node.GetEnumerator();
        }
        //从xml数据中生成节点
        void IfPlatform.XMLinput(XmlElement xNode, int intNumOffset)
        {
            XmlNode degree_xml, x_xml, y_xml, edges_xml;
            Node newNode;
            int intNum, x, y, tar, value;

            intNum = Convert.ToInt32(xNode.Attributes.GetNamedItem("num").Value) - intNumOffset;
            newNode = new Node(intNum);                                            //新建节点
            degree_xml = x_xml = y_xml = edges_xml = null;
            foreach (XmlNode curNode in xNode.ChildNodes)       //节点位置设置
            {
                if (curNode.Name == "Degree")//节点度
                {
                    degree_xml = curNode;
                }
                if (curNode.Name == "Xpos")//节点位置
                {
                    x_xml = curNode;
                }
                if (curNode.Name == "Ypos")
                {
                    y_xml = curNode;
                }
                if (curNode.Name == "Edges")//获取连边列表
                {
                    edges_xml = curNode;
                }
            }
            if (x_xml == null || y_xml == null || edges_xml == null)
            {
                return;
            }
            x = Convert.ToInt32(x_xml.InnerText);
            y = Convert.ToInt32(y_xml.InnerText);
            newNode.Location = new Point(x, y);
            
            foreach (XmlNode edge in edges_xml.ChildNodes)                                     //遍历连边列表
            {
                tar = Convert.ToInt32(edge.Attributes.GetNamedItem("Target").Value) - intNumOffset;//读出目标节点
                value = Convert.ToInt32(edge.InnerText);                           //读出连边权重
                newNode.AddEdge(tar, value);                                        //加入连边
            }
            this.node = newNode;
        }
        
        //将节点数据保存为xml格式
        XmlElement IfPlatform.XMLoutput(ref XmlDocument doc)
        {
            XmlElement curNode = doc.CreateElement("Node");
            XmlElement degree_xml, x_xml, y_xml, edges_xml;
            XmlText deg_txt, x_txt, y_txt;

            curNode.SetAttribute("num", this.node.Number.ToString());                   //创建各属性的Tag元素
            //节点度
            degree_xml = doc.CreateElement("Degree");
            //节点位置
            x_xml = doc.CreateElement("Xpos");
            y_xml = doc.CreateElement("Ypos");
            //节点连边
            edges_xml = doc.CreateElement("Edges");

            deg_txt = doc.CreateTextNode(this.node.Degree.ToString());               //创建各属性的文本元素
            x_txt = doc.CreateTextNode(this.node.Location.X.ToString());
            y_txt = doc.CreateTextNode(this.node.Location.Y.ToString());


            degree_xml.AppendChild(deg_txt);                                    //将标题元素赋予文本内容
            x_xml.AppendChild(x_txt);
            y_xml.AppendChild(y_txt);

            curNode.AppendChild(degree_xml);                                   //向当前节点中加入各属性节点
            curNode.AppendChild(x_xml);
            curNode.AppendChild(y_xml);

            foreach (Edge edge in this.node)                    //遍历，加入连边节点
            {
                edges_xml.AppendChild(edge.XMLItem(ref doc));
            }
            curNode.AppendChild(edges_xml);
            return curNode;
        }
    }
}

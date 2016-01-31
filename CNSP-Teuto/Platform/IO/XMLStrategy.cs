using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Drawing;
using CNSP.Core.Graph;
using CNSP.Core.Node;
using CNSP.Core.Edge;
using CNSP.Core.User;

namespace CNSP.Platform.IO
{
    //XML文件格式示例
    /*
     * <Graph>
     *      <Nodes NodeNumber="9">
     *          <Node num="0">
     *              <NodeType>国家</NodeType>
     *              <Xpos>0</Xpos>
     *              <Ypos>0</Ypos>
     *              <Name>秦</Name>
     *          </Node>
     *          <Node num="1">
     *              <NodeType>地区</NodeType>
     *              <Xpos>0</Xpos>
     *              <Ypos>0</Ypos>
     *              <Name>关中</Name>
     *              <Population>0</Population>
     *          </Node>
     *      </Nodes>
     *      <Edgs EdgeNumber="6">
     *          <Edge>
     *              <EdgeType>统治</EdgeType>
     *              <Start>0</Start>
     *              <End>1</End>
     *          </Edge>
     *      </Edgs> 
     * </Graph>
     * */

    public class XMLStrategy:IfIOStrategy//XML文件读写算法
    {
       //XMLStrategy算法读取函数
        Graph IfIOStrategy.ReadFile(string sPath)
        {
            FileStream stream = null;
            XmlDocument doc = new XmlDocument();
            Graph NewGraph;

            try
            {
                stream = new FileStream(sPath, FileMode.Open);
                doc.Load(stream);               //从流文件读入xml文档
                stream.Close();
            }
            catch (Exception ex)
            {
                if (stream != null)
                {
                    ex.ToString();
                    stream.Dispose();
                }
                return null;
            }
            stream.Dispose();
            //创建网络
            NewGraph = new Graph();
            if (XMLtoNet(ref NewGraph, doc) == false)
            {
                return null;
            }
            return NewGraph;
        }

        //将xml文件转化为网络
        public bool XMLtoNet(ref Graph NewGraph, XmlDocument doc)
        {
            XmlNode xmlroot, xmlNodes, xmlEdges;
            IfCoreNode newNode;
            NodeType newNodeType;
            //取出根节点
            xmlroot = doc.GetElementsByTagName("Graph").Item(0);
            if (xmlroot == null)
            {
                return false;
            }
            xmlNodes = xmlEdges = null;
            foreach (XmlElement xNode in xmlroot.ChildNodes)
            {
                if (xNode.Name == "Nodes")
                {//获取Nodes节点
                    xmlNodes = xNode;
                }
                if (xNode.Name == "Edges")
                {//获取Edges节点
                    xmlEdges = xNode;
                }
            }
            if (xmlNodes == null)
            {
                return false;
            }
            foreach (XmlElement xNode in xmlNodes.ChildNodes)                                      //遍历节点列表
            {
                //生成新节点类型
                newNodeType = new NodeType(GetText(xNode, "NodeType"));
                //生成新节点
                newNode = NodeCreateFactory.CreateNode(newNodeType, xNode);
                //加入图
                NewGraph.AddNode(newNode);
            }
            //如果没有边也可以返回OK
            if (xmlEdges == null)
            {
                return true;
            }
            IfCoreEdge newEdge;
            EdgeType newEdgeType;
            string strStart, strEnd;
            IfCoreNode nodeStart, nodeEnd;
            foreach (XmlElement xNode in xmlEdges.ChildNodes)                                      //遍历连边列表
            {
                //生成新连边类型
                newEdgeType = new EdgeType(GetText(xNode, "EdgeType"));
                //生成新连边
                newEdge = EdgeCreateFactory.CreateNode(newEdgeType, xNode);
                //获取连边的起始和终止节点编号
                strStart = GetText(xNode, "Start");
                strEnd = GetText(xNode, "End");
                nodeStart = NewGraph.GetNodeAtIndex(Convert.ToInt32(strStart));
                nodeEnd = NewGraph.GetNodeAtIndex(Convert.ToInt32(strEnd));
                //加入图
                NewGraph.AddEdge(nodeStart, nodeEnd, newEdge);
            }
            return true;
        }

        //工具函数，从xml节点中读取某个标签的InnerText
        string GetText(XmlElement curNode, string sLabel)
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

        //XMLStrategy算法保存函数
        void IfIOStrategy.SaveFile(XmlDocument doc, string sPath)
        {
            FileStream stream = null;

            try
            {
                stream = new FileStream(sPath, FileMode.Create);
                doc.Save(stream);               //保存xml文档到流
                stream.Close();
            }
            catch (Exception ex)
            {
                if (stream != null)
                {
                    ex.ToString();
                    stream.Dispose();
                }
            }
            stream.Dispose();
        }
    }
}

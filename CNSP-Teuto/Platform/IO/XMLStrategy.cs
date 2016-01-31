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
    //XML�ļ���ʽʾ��
    /*
     * <Graph>
     *      <Nodes NodeNumber="9">
     *          <Node num="0">
     *              <NodeType>����</NodeType>
     *              <Xpos>0</Xpos>
     *              <Ypos>0</Ypos>
     *              <Name>��</Name>
     *          </Node>
     *          <Node num="1">
     *              <NodeType>����</NodeType>
     *              <Xpos>0</Xpos>
     *              <Ypos>0</Ypos>
     *              <Name>����</Name>
     *              <Population>0</Population>
     *          </Node>
     *      </Nodes>
     *      <Edgs EdgeNumber="6">
     *          <Edge>
     *              <EdgeType>ͳ��</EdgeType>
     *              <Start>0</Start>
     *              <End>1</End>
     *          </Edge>
     *      </Edgs> 
     * </Graph>
     * */

    public class XMLStrategy:IfIOStrategy//XML�ļ���д�㷨
    {
       //XMLStrategy�㷨��ȡ����
        Graph IfIOStrategy.ReadFile(string sPath)
        {
            FileStream stream = null;
            XmlDocument doc = new XmlDocument();
            Graph NewGraph;

            try
            {
                stream = new FileStream(sPath, FileMode.Open);
                doc.Load(stream);               //�����ļ�����xml�ĵ�
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
            //��������
            NewGraph = new Graph();
            if (XMLtoNet(ref NewGraph, doc) == false)
            {
                return null;
            }
            return NewGraph;
        }

        //��xml�ļ�ת��Ϊ����
        public bool XMLtoNet(ref Graph NewGraph, XmlDocument doc)
        {
            XmlNode xmlroot, xmlNodes, xmlEdges;
            IfCoreNode newNode;
            NodeType newNodeType;
            //ȡ�����ڵ�
            xmlroot = doc.GetElementsByTagName("Graph").Item(0);
            if (xmlroot == null)
            {
                return false;
            }
            xmlNodes = xmlEdges = null;
            foreach (XmlElement xNode in xmlroot.ChildNodes)
            {
                if (xNode.Name == "Nodes")
                {//��ȡNodes�ڵ�
                    xmlNodes = xNode;
                }
                if (xNode.Name == "Edges")
                {//��ȡEdges�ڵ�
                    xmlEdges = xNode;
                }
            }
            if (xmlNodes == null)
            {
                return false;
            }
            foreach (XmlElement xNode in xmlNodes.ChildNodes)                                      //�����ڵ��б�
            {
                //�����½ڵ�����
                newNodeType = new NodeType(GetText(xNode, "NodeType"));
                //�����½ڵ�
                newNode = NodeCreateFactory.CreateNode(newNodeType, xNode);
                //����ͼ
                NewGraph.AddNode(newNode);
            }
            //���û�б�Ҳ���Է���OK
            if (xmlEdges == null)
            {
                return true;
            }
            IfCoreEdge newEdge;
            EdgeType newEdgeType;
            string strStart, strEnd;
            IfCoreNode nodeStart, nodeEnd;
            foreach (XmlElement xNode in xmlEdges.ChildNodes)                                      //���������б�
            {
                //��������������
                newEdgeType = new EdgeType(GetText(xNode, "EdgeType"));
                //����������
                newEdge = EdgeCreateFactory.CreateNode(newEdgeType, xNode);
                //��ȡ���ߵ���ʼ����ֹ�ڵ���
                strStart = GetText(xNode, "Start");
                strEnd = GetText(xNode, "End");
                nodeStart = NewGraph.GetNodeAtIndex(Convert.ToInt32(strStart));
                nodeEnd = NewGraph.GetNodeAtIndex(Convert.ToInt32(strEnd));
                //����ͼ
                NewGraph.AddEdge(nodeStart, nodeEnd, newEdge);
            }
            return true;
        }

        //���ߺ�������xml�ڵ��ж�ȡĳ����ǩ��InnerText
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

        //XMLStrategy�㷨���溯��
        void IfIOStrategy.SaveFile(XmlDocument doc, string sPath)
        {
            FileStream stream = null;

            try
            {
                stream = new FileStream(sPath, FileMode.Create);
                doc.Save(stream);               //����xml�ĵ�����
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

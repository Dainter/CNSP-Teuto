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
    public class Node:IfCoreNode//ͼ���ݿ�ڵ��ࣺ����洢��һ����ڵ����Ϣ�������ϲ����ṩ���ܽӿں���
    {
        //�������
        static int intMaxNodeNum = 0;
        //��Ա����
        int intNodeNum;                           //�ڵ���
        NodeType nodeType;
        List<IfCoreEdge> OutLink;       //���� ʹ���ֵ�ṹ��ţ�Ŀ��ڵ�ţ����߶���
        List<IfCoreEdge> InLink;
        Point potLoc;                        //�ڵ�λ��
        int intSaveIndex;
        //����///////////////////////////////
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
        //����///////////////////////////////
        //�ڵ���Node���캯��
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

        //xml���캯��
        public Node(NodeType newType, XmlElement xNode)
        {
            string xPos, yPos;
            int intX, intY;
            this.intNodeNum = intMaxNodeNum;
            //ȡ���ƶ���ǩ��Inner Text
            xPos = GetText(xNode, "Xpos");
            yPos = GetText(xNode, "Ypos");
            //ת��Ϊint
            intX = Convert.ToInt32(xPos);
            intY = Convert.ToInt32(yPos);
            //��ֵ���ʼ��
            this.potLoc = new Point(intX, intY);
            this.nodeType = newType;
            this.intSaveIndex = this.intNodeNum;
            OutLink = new List<IfCoreEdge>();
            InLink = new List<IfCoreEdge>();
            intMaxNodeNum++;
        }
        
        //���ߺ�������xml�ڵ��ж�ȡĳ����ǩ��InnerText
        protected string GetText(XmlElement curNode, string sLabel)
        {
            if (curNode == null)
            {
                return "";
            }
            //�����ӽڵ��б�
            foreach (XmlElement xNode in curNode.ChildNodes)
            {
                if (xNode.Name == sLabel)
                {//���Һ�ָ��������ͬ�ı�ǩ��������Innner Text
                    return xNode.InnerText;
                }
            }
            return "";
        }

        //��������
        public bool AddEdge(IfCoreEdge newEdge)
        {
            if (newEdge == null)
            {
                return false;
            }
            //�����������ǰ�ߵ���ʼ�ڵ��Ǳ��ڵ㣬����ֹ�ڵ㲻�Ǳ��ڵ�
            if (newEdge.Start.Number != intNodeNum || newEdge.End.Number == intNodeNum)
            {
                return false;
            }
            //���OutbOund�Ѿ������ñ�
            if (OutBoundContainsEdge(newEdge) == true)
            {
                return false;
            }
            //��Links�м�������Ŀ  
            OutLink.Add(newEdge);   
            return true;
        }

        //Inbound��ע��
        public bool RegisterInbound(IfCoreEdge newEdge)
        {
            if (newEdge == null)
            {
                return false;
            }
            //�����������ǰ�ߵ���ʼ�ڵ㲻�Ǳ��ڵ㣬����ֹ�ڵ��Ǳ��ڵ�
            if (newEdge.End.Number != intNodeNum || newEdge.Start.Number == intNodeNum)
            {
                return false;
            }
            //���Inbound�����ñ���ע��
            if (InBoundContainsEdge(newEdge) == true)
            {
                return false;
            }
            //�����±�
            InLink.Add(newEdge);
            return true;
        }

        //ȥ������
        public bool RemoveEdge(IfCoreEdge curEdge)
        {
            if (curEdge == null)
            {
                return false;
            }
            //�����������ǰ�ߵ���ʼ�ڵ��Ǳ��ڵ㣬����ֹ�ڵ㲻�Ǳ��ڵ�
            if (curEdge.Start.Number != intNodeNum || curEdge.End.Number == intNodeNum)
            {
                return false;
            }
            //���OutbOund�������ñ����˳�
            if (OutBoundContainsEdge(curEdge) == false)
            {
                return false;
            }
            OutLink.Remove(curEdge);
            return true;
        }

        //�����������,���ر�����ı��б�
        public List<IfCoreEdge> ClearEdge()
        {
            List<IfCoreEdge> EdgeList = new List<IfCoreEdge>();
            //���Ƚ�OutBound���������ߵ���ֹ�ڵ���ע���ñ�
            foreach (IfCoreEdge edge in this.OutBound)
            {
                edge.End.UnRegisterInbound(edge);
                edge.Start = null;
                edge.End = null;
                //��ǰ�߼��뷵�ؽ���б�
                EdgeList.Add(edge);
            }
            //��OutBound��������б�
            this.OutBound.Clear();
            //���Ƚ�InBound���������ߵ���ʼ�ڵ���ȥ���ñ�
            foreach (IfCoreEdge edge in this.InBound)
            {
                edge.Start.RemoveEdge(edge);
                edge.Start = null;
                edge.End = null;
                //��ǰ�߼��뷵�ؽ���б�
                EdgeList.Add(edge);
            }
            //��InBound��������б�
            this.InBound.Clear();
            //���ر��ڵ��漰�������б�
            return EdgeList;
        }

        //Inboundע��
        public bool UnRegisterInbound(IfCoreEdge curEdge)
        {
            if (curEdge == null)
            {
                return false;
            }
            //�����������ǰ�ߵ���ʼ�ڵ㲻�Ǳ��ڵ㣬����ֹ�ڵ��Ǳ��ڵ�
            if (curEdge.End.Number != intNodeNum || curEdge.Start.Number == intNodeNum)//�����������ǰ�ڵ���Ŀ��ڵ㲻��������Ŀ��ڵ㲻�ǵ�ǰ�ڵ�
            {
                return false;
            }
            //���Inbound��������ǰ����ע��
            if (InBoundContainsEdge(curEdge) == false)
            {
                return false;
            }
            InLink.Remove(curEdge);
            return true;

        }

        //����OutBound�Ƿ������Ŀ��ڵ�������
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

        //����InBound�Ƿ������Ŀ��ڵ�������
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

        //���ڵ����ݱ���Ϊxml��ʽ
        public virtual XmlElement XMLoutput(ref XmlDocument doc)
        {
            XmlElement curNode = doc.CreateElement("Node");
            XmlElement type_xml, x_xml, y_xml;
            XmlText type_txt, x_txt, y_txt;

            curNode.SetAttribute("num", this.SaveIndex.ToString());                   //���������Ե�TagԪ��
            //�ڵ�����
            type_xml = doc.CreateElement("NodeType");
            //�ڵ�λ��
            x_xml = doc.CreateElement("Xpos");
            y_xml = doc.CreateElement("Ypos");

            type_txt = doc.CreateTextNode(this.Type.ToString());               //���������Ե��ı�Ԫ��
            x_txt = doc.CreateTextNode(this.Location.X.ToString());
            y_txt = doc.CreateTextNode(this.Location.Y.ToString());


            type_xml.AppendChild(type_txt);                                    //������Ԫ�ظ����ı�����
            x_xml.AppendChild(x_txt);
            y_xml.AppendChild(y_txt);

            curNode.AppendChild(type_xml);                                   //��ǰ�ڵ��м�������Խڵ�
            curNode.AppendChild(x_xml);
            curNode.AppendChild(y_xml);

            return curNode;
        }
    }
}

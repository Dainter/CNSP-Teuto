using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using CNSP.Core.Node;
using CNSP.Core.User;

namespace CNSP.Core.Edge
{
    public class Edge : IfCoreEdge//ͼ���ݿ������ࣺ����洢����������Ϣ
    {
        //�������
        static int intMaxEdgeNum = 0;
        //��Ա����
        int intEdgeNum;
        IfCoreNode nodeStart;//�������
        IfCoreNode nodeEnd;//�����յ�
        EdgeType edgeType;//��������

        //����//////////////////////////
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
        //����/////////////////////////
        //������Edge���캯��
        public Edge(EdgeType newType)//���캯�� �������������и�ֵ
        {
            this.intEdgeNum = intMaxEdgeNum;
            this.edgeType = newType;
            intMaxEdgeNum++;
        }
        //������Edge���캯��
        public Edge(EdgeType newType, XmlElement xNode)//���캯�� �������������и�ֵ
        {
            this.intEdgeNum = intMaxEdgeNum;
            this.edgeType = newType;
            intMaxEdgeNum++;
        }

        //���ߺ�������xml�ڵ��ж�ȡĳ����ǩ��InnerText
        protected string GetText(XmlElement curNode, string sLabel)
        {
            if (curNode == null)
            {
                return "";
            }
            //������ǰXML�������ӱ�ǩ
            foreach (XmlElement xNode in curNode.ChildNodes)
            {
                if (xNode.Name == sLabel)
                {//���ر�ǩ����һ�µ��ڲ�����
                    return xNode.InnerText;
                }
            }
            return "";
        }

        //���������ݱ���Ϊxml��ʽ
        public virtual XmlElement XMLoutput(ref XmlDocument doc)
        {
            XmlElement curEdge = doc.CreateElement("Edge");         //��������Ԫ��
            XmlElement type_xml, Start_xml, End_xml;
            XmlText type_txt, Start_txt, End_txt;

            //�ڵ��
            type_xml = doc.CreateElement("EdgeType");
            //�ڵ�λ��
            Start_xml = doc.CreateElement("Start");
            End_xml = doc.CreateElement("End");

            type_txt = doc.CreateTextNode(this.Type.ToString());               //���������Ե��ı�Ԫ��
            Start_txt = doc.CreateTextNode(this.Start.SaveIndex.ToString());
            End_txt = doc.CreateTextNode(this.End.SaveIndex.ToString());


            type_xml.AppendChild(type_txt);                                    //������Ԫ�ظ����ı�����
            Start_xml.AppendChild(Start_txt);
            End_xml.AppendChild(End_txt);

            curEdge.AppendChild(type_xml);                                   //��ǰ�ڵ��м�������Խڵ�
            curEdge.AppendChild(Start_xml);
            curEdge.AppendChild(End_xml);

            return curEdge;
        }
    }
}

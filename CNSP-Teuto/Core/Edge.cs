using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CNSP.Core
{
    public class Edge : IfCoreEdge//�������������ࣺ����洢����������Ϣ
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
        //��������������Edge���캯��
        public Edge(EdgeType newType)//���캯�� �������������и�ֵ
        {
            this.intEdgeNum = intMaxEdgeNum;
            this.edgeType = newType;
            intMaxEdgeNum++;
        }

    }
}

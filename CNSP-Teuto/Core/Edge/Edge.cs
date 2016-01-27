using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using CNSP.Core.Node;

namespace CNSP.Core.Edge
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
        bool bolIsInUse;
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
        public bool IsInUse
        {
            get
            {
                return bolIsInUse;
            }
            set
            {
                bolIsInUse = value;
            }
        }
        //����/////////////////////////
        //��������������Edge���캯��
        public Edge(EdgeType newType)//���캯�� �������������и�ֵ
        {
            this.intEdgeNum = intMaxEdgeNum;
            this.edgeType = newType;
            bolIsInUse = true;
            intMaxEdgeNum++;
        }

    }
}

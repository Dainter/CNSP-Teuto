using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CNSP.Core
{
    public class Edge//�������������ࣺ����洢����������Ϣ
    {
        //�������
        static int intMaxEdgeNum = 0;
        //��Ա����
        int intEdgeNum;
        IfCoreNode nodeStart;//�������
        IfCoreNode nodeEnd;//�����յ�
        //����//////////////////////////
        public int EdgeNum
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

        //����/////////////////////////
        //��������������Edge���캯��
        public Edge()//���캯�� �������������и�ֵ
        {
            this.intEdgeNum = intMaxEdgeNum;
            intMaxEdgeNum++;
        }

    }
}

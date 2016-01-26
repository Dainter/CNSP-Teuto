using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml;

namespace CNSP.Core
{
    public class Node//��������ڵ��ࣺ����洢��һ����ڵ����Ϣ�������ϲ����ṩ���ܽӿں���
    {
        //�������
        static int intMaxNodeNum = 0;
        //��Ա����
        int intNodeNum;                           //�ڵ���
        List<IfCoreEdge> OutLink;       //���� ʹ���ֵ�ṹ��ţ�Ŀ��ڵ�ţ����߶���
        List<IfCoreEdge> InLink;
        Point potLoc;                        //�ڵ�λ��
        //����///////////////////////////////
        public int Number
        {
            get
            {
                return intNodeNum;
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
        //����///////////////////////////////
        //��������ڵ���Node���캯��
        public Node ()    //���캯��
        {
            this.intNodeNum = intMaxNodeNum;
            this.potLoc = new Point(0,0);
            OutLink = new List<IfCoreEdge>();
            InLink = new List<IfCoreEdge>();
            intMaxNodeNum++;
        }

        //��������
        public bool AddEdge(IfCoreEdge newEdge)
        {
            if (newEdge == null)
            {
                return false;
            }
            if (newEdge.Start.Number != intNodeNum || newEdge.End.Number == intNodeNum)//�����������ǰ�ڵ���Ŀ��ڵ㲻��������Ŀ��ڵ㲻�ǵ�ǰ�ڵ�
            {
                return false;
            }
            if (OutBoundContainsEdge(newEdge) == false)
            {
                OutLink.Add(newEdge);   //��Links�м�������Ŀ  
            }
            return true;
        }

        //Inbound��ע��
        public bool RegisterInbound(IfCoreEdge newEdge)
        {
            if (newEdge == null)
            {
                return false;
            }
            if (newEdge.End.Number != intNodeNum || newEdge.Start.Number == intNodeNum)//�����������ǰ�ڵ���Ŀ��ڵ㲻��������Ŀ��ڵ㲻�ǵ�ǰ�ڵ�
            {
                return false;
            }
            if (InBoundContainsEdge(newEdge) == false)
            {
                InLink.Add(newEdge);
            }
            return true;
        }

        //ȥ������
        public bool DecEdge(int iTarget)//ȥ������
        {

            return false;
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
                if (edge.End.Number == newEdge.End.Number)
                {
                    return true;
                }
            }
            return false;
        }

    }
}

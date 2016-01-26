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
    public class Node//复杂网络节点类：负责存储单一网络节点的信息，并向上层类提供功能接口函数
    {
        //共享变量
        static int intMaxNodeNum = 0;
        //成员变量
        int intNodeNum;                           //节点编号
        List<IfCoreEdge> OutLink;       //连边 使用字典结构存放（目标节点号，连边对象）
        List<IfCoreEdge> InLink;
        Point potLoc;                        //节点位置
        //属性///////////////////////////////
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
        //方法///////////////////////////////
        //复杂网络节点类Node构造函数
        public Node ()    //构造函数
        {
            this.intNodeNum = intMaxNodeNum;
            this.potLoc = new Point(0,0);
            OutLink = new List<IfCoreEdge>();
            InLink = new List<IfCoreEdge>();
            intMaxNodeNum++;
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
            if (OutBoundContainsEdge(newEdge) == false)
            {
                OutLink.Add(newEdge);   //向Links中加入新项目  
            }
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
            if (InBoundContainsEdge(newEdge) == false)
            {
                InLink.Add(newEdge);
            }
            return true;
        }

        //去除连边
        public bool DecEdge(int iTarget)//去除连边
        {

            return false;
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
                if (edge.End.Number == newEdge.End.Number)
                {
                    return true;
                }
            }
            return false;
        }

    }
}

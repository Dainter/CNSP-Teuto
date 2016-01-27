using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CNSP.Core
{
    public class Edge : IfCoreEdge//复杂网络连边类：负责存储网络连边信息
    {
        //共享变量
        static int intMaxEdgeNum = 0;
        //成员变量
        int intEdgeNum;
        IfCoreNode nodeStart;//连边起点
        IfCoreNode nodeEnd;//连边终点
        EdgeType edgeType;//连边类型
        //属性//////////////////////////
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
        //方法/////////////////////////
        //复杂网络连边类Edge构造函数
        public Edge(EdgeType newType)//构造函数 对三个变量进行赋值
        {
            this.intEdgeNum = intMaxEdgeNum;
            this.edgeType = newType;
            intMaxEdgeNum++;
        }

    }
}

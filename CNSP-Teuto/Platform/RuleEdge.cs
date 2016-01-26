using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNSP.Core;

namespace CNSP.Platform
{
    public class RuleEdge:IfCoreEdge
    {
        Edge edge;
        double dubWeight;//连边权重
        EdgeType edgeType;//连边类型
        //属性///////////////////////////////
        public IfCoreNode Start
        {
            get
            {
                return edge.Start;
            }
            set
            {
                if (value.Type.Type == NodeTypeEnum.Nation)
                {
                    edge.Start = value;
                }
                else
                {
                    string strMsg;
                    strMsg = "连边类型: " + this.Type.ToString() + " 和节点类型: " + value.Type.ToString() + " 不匹配.";
                    throw new Exception(strMsg);
                }
            }
        }
        public IfCoreNode End
        {
            get
            {
                return edge.End;
            }
            set
            {
                if (value.Type.Type == NodeTypeEnum.District)
                {
                    edge.End = value;
                }
                else
                {
                    string strMsg;
                    strMsg = "连边类型: " + this.Type.ToString() + " 和节点类型: " + value.Type.ToString() + " 不匹配.";
                    throw new Exception(strMsg);
                }
            }
        }
        public EdgeType Type
        {
            get
            {
                return edgeType;
            }
        }
        public double Weigth
        {
            get
            {
                return dubWeight;
            }
            set
            {
                dubWeight = value;
            }
        }
        //方法///////////////////////////////
        public RuleEdge()
        {
            this.edge = new Edge();
            this.edgeType = new EdgeType("统治");
        }
    }
}

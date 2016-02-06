using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using CNSP.Core.Edge;
using CNSP.Core.User;
using CNSP.Platform;

namespace CNSP.Core.User
{
    public class EdgeCreateFactory//连边创建工厂类
    {
        //输入不同连边类型和XML数据，调度生成不同类型连边
        public static IfCoreEdge CreateNode(EdgeType type, XmlElement xNode)
        {
            switch (type.Type)
            {
                case EdgeTypeEnum.Rule:
                    return new RuleEdge(xNode);
                case EdgeTypeEnum.Connect:
                    return new ConnectEdge(xNode);
                case EdgeTypeEnum.Diplomacy:
                    return new DiplomacyEdge(xNode);
                default:
                    return new Edge.Edge(type);
            }
        }
    }
}

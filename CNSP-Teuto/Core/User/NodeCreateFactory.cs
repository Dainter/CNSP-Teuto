using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using CNSP.Core.Node;
using CNSP.Platform;


namespace CNSP.Core.User
{
    public class NodeCreateFactory//节点创建工厂类
    {
        //输入不同节点类型和XML数据，调度生成不同类型节点
        public static IfCoreNode CreateNode(NodeType type, XmlElement xNode)
        {
            switch (type.Type)
            {
                case NodeTypeEnum.Nation:
                    return new NationNode(xNode);
                case NodeTypeEnum.District:
                    return new DistrictNode(xNode);
                case NodeTypeEnum.Troop:
                case NodeTypeEnum.CharGeneral:
                default:
                    return new Node.Node(type);
            }
        }
    }

}

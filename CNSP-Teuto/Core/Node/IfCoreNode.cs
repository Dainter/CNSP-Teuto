using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;
using CNSP.Core.Edge;
using CNSP.Core.User;

namespace CNSP.Core.Node
{
    public interface IfCoreNode//内核节点接口
    {
        int Number { get; }
        int Degree { get; }
        Point Location { get; set; }
        NodeType Type { get; }
        int SaveIndex { get; set; }
        List<IfCoreEdge> OutBound { get; }
        List<IfCoreEdge> InBound { get; }

        bool AddEdge(IfCoreEdge newEdge);
        bool RemoveEdge(IfCoreEdge curEdge);
        List<IfCoreEdge> ClearEdge();
        bool RegisterInbound(IfCoreEdge newEdge);
        bool UnRegisterInbound(IfCoreEdge curEdge);
        XmlElement XMLoutput(ref XmlDocument doc);
    }
}

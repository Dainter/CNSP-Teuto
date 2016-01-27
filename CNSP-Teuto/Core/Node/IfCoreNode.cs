using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNSP.Core.Edge;

namespace CNSP.Core.Node
{
    public interface IfCoreNode
    {
        int Number { get; }
        int Degree { get; }
        NodeType Type { get; }
        List<IfCoreEdge> OutBound { get; }
        List<IfCoreEdge> InBound { get; }

        bool AddEdge(IfCoreEdge newEdge);
        bool RemoveEdge(IfCoreEdge curEdge);
        bool ClearEdge();
        bool RegisterInbound(IfCoreEdge newEdge);
        bool UnRegisterInbound(IfCoreEdge curEdge);
    }
}

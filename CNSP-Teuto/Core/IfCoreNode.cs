using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNSP.Core
{
    public interface IfCoreNode
    {
        int Number { get; }
        int Degree { get; }
        NodeType Type { get; }
        List<IfCoreEdge> OutBound { get; }
        List<IfCoreEdge> InBound { get; }

        bool RegisterInbound(IfCoreEdge newEdge);
        bool UnRegisterInbound(IfCoreEdge curEdge);
    }
}

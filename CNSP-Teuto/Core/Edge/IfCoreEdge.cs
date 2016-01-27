using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNSP.Core.Node;

namespace CNSP.Core.Edge
{
    public interface IfCoreEdge
    {
        int Number { get; }
        IfCoreNode Start { get; set; }
        IfCoreNode End { get; set; }
        EdgeType Type { get; }
        bool IsInUse { get; set; }
    }
}

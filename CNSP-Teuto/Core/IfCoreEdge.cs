using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNSP.Core
{
    public interface IfCoreEdge
    {
        IfCoreNode Start { get; set; }
        IfCoreNode End { get; set; }
        EdgeType Type { get; }
    }
}

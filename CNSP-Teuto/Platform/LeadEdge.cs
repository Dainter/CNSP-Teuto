using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNSP.Core.Node;
using CNSP.Core.Edge;

namespace CNSP.Platform
{
    public class LeadEdge : Edge
    {
        public LeadEdge()
            : base(new EdgeType(EdgeTypeEnum.Lead))
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNSP.Core.Node;
using CNSP.Core.Edge;

namespace CNSP.Platform
{
    public class RuleEdge:Edge
    {

        
        //属性///////////////////////////////


        //方法///////////////////////////////
        public RuleEdge():base(new EdgeType(EdgeTypeEnum.Rule))
        {

        }
    }
}

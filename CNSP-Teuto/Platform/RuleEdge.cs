using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNSP.Core;

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

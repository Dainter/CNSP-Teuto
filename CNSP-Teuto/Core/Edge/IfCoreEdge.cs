using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using CNSP.Core.Node;
using CNSP.Core.User;

namespace CNSP.Core.Edge
{
    public interface IfCoreEdge//内核连边接口
    {
        int Number { get; }
        IfCoreNode Start { get; set; }
        IfCoreNode End { get; set; }
        EdgeType Type { get; }
        XmlElement XMLoutput(ref XmlDocument doc);
    }
}

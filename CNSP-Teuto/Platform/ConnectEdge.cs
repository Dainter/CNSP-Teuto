using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNSP.Core.Node;
using CNSP.Core.Edge;
using CNSP.Core.User;

namespace CNSP.Platform
{
    public class ConnectEdge: Edge//连通关系连边
    {
        //构造函数
        public ConnectEdge()
            : base(new EdgeType(EdgeTypeEnum.Connect))
        {

        }
    }
}

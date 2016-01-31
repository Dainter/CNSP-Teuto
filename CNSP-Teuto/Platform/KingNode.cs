using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNSP.Core.Node;
using CNSP.Core.Edge;
using CNSP.Core.User;

namespace CNSP.Platform
{
    public class KingNode:Node
    {
        string strName;
        int intAge;
        
        //属性/////////////////////
        public string Name
        {
            get
            {
                return strName;
            }
        }
        public int Age
        {
            get
            {
                return intAge;
            }
        }
        //方法////////////////////
        public KingNode(string sName, string sType, int iAge)
            : base(new NodeType(sType))
        {
            strName = sName;
            intAge = iAge;
        }

        public void MakePolicy()
        {

        }
    }
}

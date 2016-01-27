using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using CNSP.Core.Node;
using CNSP.Core.Edge;

namespace CNSP.Platform
{
    public class TroopNode : Node
    {
        string strName;
        int intCreate;

        //属性/////////////////////
        public string Name
        {
            get
            {
                return strName;
            }
        }
        public int CreateYear
        {
            get
            {
                return intCreate;
            }
        }
        //方法////////////////////
        public TroopNode(string sName, int iCreate):base(new NodeType(NodeTypeEnum.Troop))
        {
            strName = sName;
            intCreate = iCreate;
        }


    }
}

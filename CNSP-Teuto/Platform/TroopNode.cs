﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using CNSP.Core.Node;
using CNSP.Core.Edge;
using CNSP.Core.User;

namespace CNSP.Platform
{
    public class TroopNode : Node//军队节点类
    {
        //军队番号
        string strName;
        //建立年份
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

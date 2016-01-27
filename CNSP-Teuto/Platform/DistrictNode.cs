using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using CNSP.Core;


namespace CNSP.Platform
{
    public class DistrictNode : Node
    {
        string strName;
        int intHarvest;
        int intPolulation;
        //属性///////////////////////////////
        public string Name
        {
            get
            {
                return strName;
            }
        }
        public int Harvest
        {
            get
            {
                return intHarvest;
            }
        }
        public int Population
        {
            get
            {
                return intPolulation;
            }
        }
        //方法///////////////////////////////
        public DistrictNode(string sName):base(new NodeType(NodeTypeEnum.District))
        {
            if (sName == null)
            {
                sName = "叛军城镇";
            }
            strName = sName;
            intHarvest = 0;
            intPolulation = 0;
        }

    }
}

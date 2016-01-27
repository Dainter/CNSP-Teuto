using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using CNSP.Core;

namespace CNSP.Platform
{
    public class NationNode:Node
    {
        string strName;
        //属性///////////////////////////////
        public string Name
        {
            get
            {
                return strName;
            }
        }
        //方法///////////////////////////////
        public NationNode(string sName):base(new NodeType(NodeTypeEnum.Nation))
        {
            if (sName == null)
            {
                sName = "叛军";
            }
            strName = sName;
        }

        //兼并地区
        public bool Merger(DistrictNode newRegion)
        {
            if (newRegion == null)
            {
                return false;
            }
            RuleEdge newEdge = new RuleEdge();
            return this.BuildRelationship(newRegion, newEdge);
        }

        //割让地区
        public bool Cession(DistrictNode curRegion)
        {
            if (curRegion == null)
            {
                return false;
            }
            return this.RemoveRelationship(curRegion);
        }

        //返回所统治的地区列表
        public string ShowTerritory()
        {
            string strResult = "";

            foreach (IfCoreEdge edge in this.OutBound)
            {
                if (edge.Type.Type == EdgeTypeEnum.Rule)
                {
                    strResult += ((DistrictNode)edge.End).Name+ ", ";
                }
            }

            return strResult;
        }
    }
}

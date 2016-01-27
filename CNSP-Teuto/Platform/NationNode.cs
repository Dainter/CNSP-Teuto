using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using CNSP.Core;

namespace CNSP.Platform
{
    public class NationNode:IfCoreNode
    {
        Node node;
        string strName;
        NodeType type;
        //属性///////////////////////////////
        public int Number
        {
            get
            {
                return node.Number;
            }
        }
        public string Name
        {
            get
            {
                return strName;
            }
        }
        public int Degree
        {
            get
            {
                return node.OutBound.Count;
            }
        }
        public Point Location
        {
            get
            {
                return node.Location;
            }
            set
            {
                node.Location = value;
            }
        }
        public NodeType Type
        {
            get
            {
                return type;
            }
        }
        public List<IfCoreEdge> OutBound
        {
            get
            {
                return node.OutBound;
            }
        }
        public List<IfCoreEdge> InBound
        {
            get
            {
                return node.InBound;
            }
        }
        //方法///////////////////////////////
        public NationNode(string sName)
        {
            this.node = new Node();
            if (sName == null)
            {
                sName = "叛军";
            }
            strName = sName;
            type = new NodeType("国家");
        }

        //增加连边
        bool AddEdge(IfCoreEdge newEdge)
        {
            return node.AddEdge(newEdge);
        }

        //Inbound边注册
        public bool RegisterInbound(IfCoreEdge newEdge)
        {
            return node.RegisterInbound(newEdge);
        }

        //去除连边
        bool DecEdge(IfCoreEdge curEdge)//去除连边
        {
            return node.DecEdge(curEdge);
        }

        //Inbound注销
        public bool UnRegisterInbound(IfCoreEdge curEdge)
        {
            return node.UnRegisterInbound(curEdge);
        }

        //兼并地区
        public bool Merger(DistrictNode newRegion)
        {
            RuleEdge newRule = new RuleEdge();
            try
            {
                newRule.Start = this;
                newRule.End = newRegion;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "警告", MessageBoxButtons.OK);
                return false;
            }
            if (this.AddEdge(newRule) == false)
            {
                return false;
            }
            if(newRegion.RegisterInbound(newRule) == false)
            {
                return false;
            }
            return true;
        }

        //割让地区
        public bool Cession(DistrictNode curRegion)
        {
            IfCoreEdge curEdge = null;
            foreach (IfCoreEdge edge in this.node.OutBound)
            {
                if (edge.Type.Type != EdgeTypeEnum.Rule)
                {
                    continue;
                }
                if (edge.End.Number == curRegion.Number)
                {
                    curEdge = edge;
                    break;
                }
            }
            if (curEdge == null)
            {
                return false;
            }
            if(this.DecEdge(curEdge) == false)
            {
                return false;
            }
            if (curRegion.UnRegisterInbound(curEdge) == false)
            {
                return false;
            }
            return true;
        }

        //返回所统治的地区列表
        public string ShowTerritory()
        {
            string strResult = "";

            foreach (IfCoreEdge edge in this.node.OutBound)
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

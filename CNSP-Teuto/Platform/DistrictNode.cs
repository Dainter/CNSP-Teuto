using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using CNSP.Core;


namespace CNSP.Platform
{
    public class DistrictNode : IfCoreNode
    {
        Node node;
        string strName;
        NodeType type;
        int intHarvest;
        int intPolulation;
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
        public DistrictNode(string sName)
        {
            this.node = new Node();
            if (sName == null)
            {
                sName = "叛军城镇";
            }
            strName = sName;
            type = new NodeType("地区");
            intHarvest = 0;
            intPolulation = 0;
        }
        //增加连边
        public bool AddEdge(IfCoreEdge newEdge)
        {
            return node.AddEdge(newEdge);
        }

        //Inbound边注册
        public bool RegisterInbound(IfCoreEdge newEdge)
        {
            return node.RegisterInbound(newEdge);
        }

    }
}

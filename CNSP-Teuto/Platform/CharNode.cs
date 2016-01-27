using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using CNSP.Core;

namespace CNSP.Platform
{
    public class CharNode:Node
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
        public CharNode(string sName, string sType, int iAge):base(new NodeType(sType))
        {
            strName = sName;
            intAge = iAge;
        }

        //任命率领军队
        public bool Appoint(TroopNode newTroop)
        {
            if (newTroop == null)
            {
                return false;
            }
            LeadEdge newEdge = new LeadEdge();
            return this.BuildRelationship(newTroop, newEdge); ;
        }
        //从军队解职
        public bool Discharge(TroopNode curTroop)
        {
            if (curTroop == null)
            {
                return false;
            }
            return this.RemoveRelationship(curTroop); ;
        }

    }
}

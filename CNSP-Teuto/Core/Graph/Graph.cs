using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNSP.Core.Node;
using CNSP.Core.Edge;

namespace CNSP.Core.Graph
{
    public class Graph
    {
        List<IfCoreNode> NodeList;
        List<IfCoreEdge> EdgeList;

        public Graph()
        {
            NodeList = new List<IfCoreNode>();
            EdgeList = new List<IfCoreEdge>();
        }

        //加入节点
        public bool AddNode(IfCoreNode newNode)
        {
            NodeList.Add(newNode);
            return true;
        }

        //删除节点
        public bool RemoveNode(IfCoreNode curNode)
        {
            curNode.ClearEdge();
            NodeList.Remove(curNode);
            return true;
        }

        //加入连边
        public bool AddEdge(IfCoreNode curNode, IfCoreNode tarNode, IfCoreEdge newEdge)
        {
            try
            {
                newEdge.Start = curNode;
                newEdge.End = tarNode;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "警告", MessageBoxButtons.OK);
                return false;
            }
            if (curNode.AddEdge(newEdge) == false)
            {
                return false;
            }
            if (tarNode.RegisterInbound(newEdge) == false)
            {
                return false;
            }
            return true;
        }

        //删除连边
        public bool RemoveEdge(IfCoreNode curNode, IfCoreNode tarNode)
        {
            IfCoreEdge curEdge = null;
            foreach (IfCoreEdge edge in curNode.OutBound)
            {
                if (edge.End.Number == tarNode.Number)
                {
                    curEdge = edge;
                    break;
                }
            }
            if (curEdge == null)
            {
                return false;
            }
            if (curNode.RemoveEdge(curEdge) == false)
            {
                return false;
            }
            if (tarNode.UnRegisterInbound(curEdge) == false)
            {
                return false;
            }
            return true;
        }


    }
}

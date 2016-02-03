using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using CNSP.Core.Node;
using CNSP.Core.Edge;
using CNSP.Core.User;

namespace CNSP.Core.Graph
{
    public class Graph//图数据库类，存放节点列表和连边列表
    {
        List<IfCoreNode> NodeList;
        List<IfCoreEdge> EdgeList;
        //属性///////////////////////
        public int NodeNum
        {
            get
            {
                return NodeList.Count;
            }
        }
        public int EdgeNum
        {
            get
            {
                return EdgeList.Count;
            }
        }
        public List<IfCoreNode> Nodes
        {
            get
            {
                return NodeList;
            }
        }
        public List<IfCoreEdge> Edges
        {
            get
            {
                return EdgeList;
            }
        }
        //方法///////////////////////
        //构造函数
        public Graph()
        {
            NodeList = new List<IfCoreNode>();
            EdgeList = new List<IfCoreEdge>();
        }
        //加入节点
        public bool AddNode(IfCoreNode newNode)
        {
            //节点加入节点列表
            NodeList.Add(newNode);
            return true;
        }
        //删除节点
        public bool RemoveNode(IfCoreNode curNode)
        {
            //清除节点所有连边
            ClearUnusedEdge(curNode.ClearEdge());
            //从节点列表中移除节点
            NodeList.Remove(curNode);
            return true;
        }
        //加入连边
        public bool AddEdge(IfCoreNode curNode, IfCoreNode tarNode, IfCoreEdge newEdge)
        {
            try
            {
                //连边的头指针指向起节点
                newEdge.Start = curNode;
                //连边的尾指针指向目标节点
                newEdge.End = tarNode;
            }
            catch (Exception e)
            {//如果连边和起始/目标节点类型不匹配则会报错
                MessageBox.Show(e.Message, "警告", MessageBoxButtons.OK);
                return false;
            }
            //将新连边加入起始节点的outbound
            if (curNode.AddEdge(newEdge) == false)
            {
                return false;
            }
            //将新连边加入目标节点的Inbound
            if (tarNode.RegisterInbound(newEdge) == false)
            {
                return false;
            }
            //全部完成后将连边加入网络连边列表
            EdgeList.Add(newEdge);
            return true;
        }
        //移除连边
        public bool RemoveEdge(IfCoreNode curNode, IfCoreNode tarNode)
        {
            IfCoreEdge curEdge = null;
            //从起始节点的出边中遍历
            foreach (IfCoreEdge edge in curNode.OutBound)
            {//查找终止节点编号和目标节点编号一致的连边
                if (edge.End.Number == tarNode.Number)
                {//找到则返回，本图数据库不支持两点间多连边
                    curEdge = edge;
                    break;
                }
            }
            if (curEdge == null)
            {//没找到直接返回
                return false;
            }
            //起始节点Outbound中移除连边
            curNode.RemoveEdge(curEdge);
            //从终止节点InBound中注销连边
            tarNode.UnRegisterInbound(curEdge);
            //全部完成后，从总连边列表中移除该边
            EdgeList.Remove(curEdge);
            return true;
        }
        //删除所有被解除绑定的连边
        public bool ClearUnusedEdge(List<IfCoreEdge> UnusedList)
        {
            //将入参列表中所有连边从总连边列表中删除
            foreach (IfCoreEdge edge in UnusedList)
            {
                EdgeList.Remove(edge);
            }
            //清空入参列表本身内容
            UnusedList.Clear();
            return true;
        }
        //将数据保存为XML文件
        public XmlDocument ToXML()
        {
            XmlDocument doc = new XmlDocument();
            //所有网络数据都保存为xml格式
            XmlElement root = doc.CreateElement("Graph");
            XmlElement Nodes, Edges;

            AdjustNodeIndex();
            Nodes = doc.CreateElement("Nodes");
            Nodes.SetAttribute("NodeNumber", this.NodeNum.ToString());
            foreach (IfCoreNode curNode in NodeList)
            {
                Nodes.AppendChild(curNode.XMLoutput(ref doc));     //循环调用底层节点的输出函数
            }
            root.AppendChild(Nodes);
            Edges = doc.CreateElement("Edges");
            Edges.SetAttribute("EdgeNumber", this.EdgeNum.ToString());
            foreach (IfCoreEdge curEdge in EdgeList)
            {
                Edges.AppendChild(curEdge.XMLoutput(ref doc)); //循环调用底层节点的输出函数
            }
            root.AppendChild(Edges);
            doc.AppendChild(root);
            return doc;
        }
        //调整节点实际索引(用于保存，和编号不完全相同)
        void AdjustNodeIndex()
        {
            int index = 0;
            foreach (IfCoreNode curNode in NodeList)
            {
                curNode.SaveIndex = index;
                index++;
            }
        }
        //查询函数，返回指定索引处的节点
        public IfCoreNode GetNodeAtIndex(int index)
        {
            return NodeList.ElementAt(index);
        }
        //查询函数，返回节点列表中指定类型的所有节点
        public List<IfCoreNode> GetNodesOfType(NodeTypeEnum type)
        {
            List<IfCoreNode> ResultList = new List<IfCoreNode>();
            //遍历节点列表
            foreach (IfCoreNode curNode in NodeList)
            {
                if (curNode.Type.Type == type)
                {//将符合type要求的节点加入返回结果列表
                    ResultList.Add(curNode);
                }
            }
            return ResultList;
        }

    }
}

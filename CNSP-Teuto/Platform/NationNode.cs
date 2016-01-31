using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;
using CNSP.Core.Node;
using CNSP.Core.Edge;
using CNSP.Core.User;

namespace CNSP.Platform
{
    public class NationNode:Node//国家节点类
    {
        //国家名称
        string strName;
        Color colFore;
        Color colBack;
        Color colFrame;
        double dubArgiRate; //农业生产率
        double dubCommRate;//商业生产率
        double dubTaxRate;//税率
        double dubDraftRate;  //征兵率
        //属性///////////////////////////////
        public string Name
        {
            get
            {
                return strName;
            }
        }
        public Color ForeColor
        {
            get
            {
                return colFore;
            }
        }
        public Color BackColor
        {
            get
            {
                return colBack;
            }
        }
        public Color FrameColor
        {
            get
            {
                return colFrame;
            }
        }
        //方法///////////////////////////////
        //构造函数
        public NationNode(string sName)
            :base(new NodeType(NodeTypeEnum.Nation))
        {
            if (sName == null)
            {
                sName = "叛军";
            }
            strName = sName;
            dubArgiRate = dubCommRate = dubTaxRate = dubDraftRate = 1.0;
            colFore = Color.Blue;
            colBack = Color.Green;
            colFrame = Color.Navy;
        }
        
        //构造函数-xml
        public NationNode(XmlElement xNode)
            : base(new NodeType(NodeTypeEnum.Nation), xNode)
        {
            this.strName = GetText(xNode, "Name");
            this.colFore = Color.FromArgb(Convert.ToInt32(GetText(xNode, "colFore"), 16));
            this.colBack = Color.FromArgb(Convert.ToInt32(GetText(xNode, "colBack"), 16));
            this.colFrame = Color.FromArgb(Convert.ToInt32(GetText(xNode, "colFrame"), 16));
            dubArgiRate = dubCommRate = dubTaxRate = dubDraftRate = 1.0;
        }

         //将节点数据保存为xml格式
        public override XmlElement XMLoutput(ref XmlDocument doc)
        {
            XmlElement curNode;
            XmlElement name_xml, fore_xml, back_xml, frame_xml;
            XmlText name_txt, fore_txt, back_txt, frame_txt;

            curNode = base.XMLoutput(ref doc);

            //节点度
            name_xml = doc.CreateElement("Name");
            fore_xml = doc.CreateElement("colFore");
            back_xml = doc.CreateElement("colBack");
            frame_xml = doc.CreateElement("colFrame");

            name_txt = doc.CreateTextNode(this.Name.ToString());               //创建各属性的文本元素
            fore_txt = doc.CreateTextNode(Convert.ToString(this.colFore.ToArgb(), 16));
            back_txt = doc.CreateTextNode(Convert.ToString(this.colBack.ToArgb(), 16));
            frame_txt = doc.CreateTextNode(Convert.ToString(this.colFrame.ToArgb(), 16));

            name_xml.AppendChild(name_txt);                                    //将标题元素赋予文本内容
            fore_xml.AppendChild(fore_txt);
            back_xml.AppendChild(back_txt);
            frame_xml.AppendChild(frame_txt);

            curNode.AppendChild(name_xml);                                   //向当前节点中加入各属性节点
            curNode.AppendChild(fore_xml);
            curNode.AppendChild(back_xml);
            curNode.AppendChild(frame_xml);
            return curNode;
        }

        public void Initialize()
        {
            

        }

    }
}

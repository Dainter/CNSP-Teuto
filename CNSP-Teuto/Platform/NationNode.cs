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
        int intTotalPopulation;
        int intTotalArmy;
        int intTotalMoney;
        double dubBreed;//出生率
        double dubArgiRate; //农业生产率
        double dubCommRate;//商业生产率
        double dubTaxRate;//税率
        double dubPayRate;//维护费
        double dubEquiptRate;//装备费
        double dubDraftRate;  //征兵率
        List<NationNode> EnemyList;
        List<DistrictNode> DistrictsList;
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
        public int Population
        {
            get
            {
                return intTotalPopulation;
            }
        }
        public int Army
        {
            get
            {
                return intTotalArmy;
            }
        }
        public int Money
        {
            get
            {
                return intTotalMoney;
            }
        }
        public List<DistrictNode> Districts
        {
            get
            {
                return DistrictsList;
            }
        }
        public List<NationNode> Enemies
        {
            get
            {
                return EnemyList;
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
            intTotalPopulation = 0;
            intTotalArmy = 0;
            intTotalMoney = 20000;
            dubBreed = 0.01;
            dubArgiRate = 0.002;
            dubCommRate = 0.006;
            dubTaxRate = 0.1;
            dubDraftRate = 0.005;
            dubPayRate = 0.02;
            dubEquiptRate = 0.1;
            DistrictsList = new List<DistrictNode>();
            EnemyList = new List<NationNode>();
            foreach (IfCoreEdge edge in OutBound)
            {
                if (edge.Type.Type == EdgeTypeEnum.Rule)
                {
                    DistrictsList.Add((DistrictNode)(edge.End));
                    ((DistrictNode)edge.End).Initialize(dubArgiRate, dubCommRate);
                    intTotalPopulation += ((DistrictNode)edge.End).Population;
                }
                else if (edge.Type.Type == EdgeTypeEnum.Diplomacy)
                {
                    if (((DiplomacyEdge)edge).State == "敌对")
                    {
                        EnemyList.Add((NationNode)(edge.End));
                    }
                }
            }
        }

        //比较两个国家编号
        public static int CompareNationsByNumber(NationNode x, NationNode y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    // ...and y is not null, compare the 
                    // lengths of the two strings.
                    //
                    int retval = x.Number.CompareTo(y.Number);
                    return retval;
                }
            }
        }
        //比较两个国家人口
        public static int CompareNationsByPopulation(NationNode x, NationNode y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return 1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return -1;
                }
                else
                {
                    // ...and y is not null, compare the 
                    // lengths of the two strings.
                    //
                    int retval = x.Population.CompareTo(y.Population);
                    return -retval;
                }
            }
        }
        //比较两个国家国库
        public static int CompareNationsByMoney(NationNode x, NationNode y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return 1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return -1;
                }
                else
                {
                    // ...and y is not null, compare the 
                    // lengths of the two strings.
                    //
                    int retval = x.Money.CompareTo(y.Money);
                    return -retval;
                }
            }
        }
        //比较两个国家军队
        public static int CompareNationsByArmy(NationNode x, NationNode y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return 1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return -1;
                }
                else
                {
                    // ...and y is not null, compare the 
                    // lengths of the two strings.
                    //
                    int retval = x.Army.CompareTo(y.Army);
                    return -retval;
                }
            }
        }
        //比较两个国家土地
        public static int CompareNationsByDistrict(NationNode x, NationNode y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return 1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return -1;
                }
                else
                {
                    // ...and y is not null, compare the 
                    // lengths of the two strings.
                    //
                    int retval = x.Districts.Count.CompareTo(y.Districts.Count);
                    return -retval;
                }
            }
        }
        //每回合操作
        public void Round(int iRound)
        {
            if (iRound > 1)
            {
                CalThreaten(GetFrontierDistricts());
            }
            //自然事件：人口增长，商业运作
            PreRound();
            //征兵
            Draft();
            //决策阶段，(发展，防御，扩张)
            //发展：保持和平为主，外交积极讲和，国内积极建设
            //防御：保持现有土地为主，外交不主动宣战，也不讲和，国内均衡建设，加强征兵。
            //扩张（无脑）：拓展现有土地，外交主动宣战，国内不建设，加强征兵，攻击获得最大利益城池。
            //扩张（巧妙）：拓展现有土地，外交被动宣战，国内均衡建设，均衡征兵，防御为主，攻击最容易得手城池。


            //外交事件（敌对，中立 未来加上联盟）
            //第一阶段全是敌对状态


            //国内建设：财政支出选择（全力发展，均衡发展，不发展），发展地选择（平均，重点）

            //交战：战力分配，部队调度，战斗发起，土地兼并

        }

        //每年回合开始前操作
        void PreRound()
        {
            double dTax;
            int iPopu;
            //
            iPopu = 0;
            dTax = 0.0;
            foreach (DistrictNode node in DistrictsList)
            {
                iPopu += node.PopulationBreed(dubBreed);
                dTax += node.Economy(dubArgiRate, dubCommRate, dubTaxRate);
            }
            intTotalPopulation = iPopu;
            intTotalMoney += (int)dTax;
            PayMaintenance();
        }
        //支付薪饷
        void PayMaintenance()
        {
            intTotalMoney -= (int)(intTotalArmy * dubPayRate); 
        }
        //征召部队
        void Draft()
        {
            double dubActuralDraftRate;
            int intNewDraft = 0;
            //征兵率制定
            dubActuralDraftRate = DraftPolicy();
            //征召部队
            foreach (IfCoreEdge edge in OutBound)
            {
                if (edge.Type.Type == EdgeTypeEnum.Rule)
                {
                    intNewDraft += ((DistrictNode)edge.End).Draft(dubActuralDraftRate);
                }
            }
            intTotalArmy += intNewDraft;
            intTotalPopulation -= intNewDraft;
        }
        //制订征兵率，1.国库盈余 2.征兵上限修正
        double DraftPolicy()
        {
            return 0.005;
        }

        //返回所有相邻他国地区列表
        List<DistrictNode> GetNeighborDistricts()
        {
            List<DistrictNode> ResultList = new List<DistrictNode>();
            //遍历本国所有地区
            foreach (DistrictNode node in Districts)
            {
                //遍历该地区的周边地区
                foreach (IfCoreEdge edge in node.OutBound)
                {
                    if (edge.Type.Type == EdgeTypeEnum.Connect)
                    {
                        //如果该地区为本国领地则跳到下一地区
                        if (DistrictsList.Contains((DistrictNode)(edge.End)) == true)
                        {
                            continue;
                        }
                        //如果是外国地区，且不存在于列表中则加入列表
                        if (ResultList.Contains((DistrictNode)(edge.End)) == false)
                        {
                            ResultList.Add((DistrictNode)(edge.End));
                        }
                    }
                }
            }
            return ResultList;
        }
        //返回所有相邻敌国地区列表
        List<DistrictNode> GetNeighborDistrictsAtWar()
        {
            List<DistrictNode> ResultList = new List<DistrictNode>();
            //遍历本国所有地区
            foreach (DistrictNode node in Districts)
            {
                //遍历该地区的周边地区
                foreach (IfCoreEdge edge in node.OutBound)
                {
                    if (edge.Type.Type == EdgeTypeEnum.Connect)
                    {
                        //如果该地区为本国领地则跳到下一地区
                        if (DistrictsList.Contains((DistrictNode)(edge.End)) == true)
                        {
                            continue;
                        }
                        //如果该地区属于敌国
                        if (Enemies.Contains(((DistrictNode)(edge.End)).Nation) == true)
                        {
                            continue;
                        }
                        //如果是外国地区，且不存在于列表中则加入列表
                        if (ResultList.Contains((DistrictNode)(edge.End)) == false)
                        {
                            ResultList.Add((DistrictNode)(edge.End));
                        }
                    }
                }
            }
            return ResultList;
        }
        //返回所有相邻他国列表
        List<NationNode> GetNeighborNations()
        {
            List<NationNode> ResultList = new List<NationNode>();
            //遍历本国所有地区
            foreach (DistrictNode node in Districts)
            {
                //遍历该地区的周边地区
                foreach (IfCoreEdge edge in node.OutBound)
                {
                    if (edge.Type.Type == EdgeTypeEnum.Connect)
                    {
                        //如果该地区为本国领地则跳到下一地区
                        if (DistrictsList.Contains((DistrictNode)(edge.End)) == true)
                        {
                            continue;
                        }
                        //如果是外国地区，且不存在于列表中则加入列表
                        if (ResultList.Contains(((DistrictNode)(edge.End)).Nation) == false)
                        {
                            ResultList.Add(((DistrictNode)(edge.End)).Nation);
                        }
                    }
                }
            }
            return ResultList;
        }
        //返回所有相邻敌国列表
        List<NationNode> GetNeighborNationsAtWar()
        {
            List<NationNode> ResultList = new List<NationNode>();
            //遍历本国所有地区
            foreach (DistrictNode node in Districts)
            {
                //遍历该地区的周边地区
                foreach (IfCoreEdge edge in node.OutBound)
                {
                    if (edge.Type.Type == EdgeTypeEnum.Connect)
                    {
                        //如果该地区为本国领地则跳到下一地区
                        if (DistrictsList.Contains((DistrictNode)(edge.End)) == true)
                        {
                            continue;
                        }
                        //如果该地区从属国家不是敌国则跳到下一地区
                        if (Enemies.Contains(((DistrictNode)(edge.End)).Nation) == false)
                        {
                            continue;
                        }
                        //如果是外国地区，且不存在于列表中则加入列表
                        if (ResultList.Contains(((DistrictNode)(edge.End)).Nation) == false)
                        {
                            ResultList.Add(((DistrictNode)(edge.End)).Nation);
                        }
                    }
                }
            }
            return ResultList;
        }
        //返回所有和外国相邻地区列表
        List<DistrictNode> GetFrontierDistricts()
        {
            List<DistrictNode> ResultList = new List<DistrictNode>();
            //遍历本国所有地区
            foreach (DistrictNode node in Districts)
            {
                //遍历该地区的周边地区
                foreach (IfCoreEdge edge in node.OutBound)
                {
                    if (edge.Type.Type == EdgeTypeEnum.Connect)
                    {
                        //如果该地区为本国领地则跳到下一地区
                        if (DistrictsList.Contains((DistrictNode)(edge.End)) == true)
                        {
                            continue;
                        }
                        //如果是外国地区，且不存在于列表中则加入列表
                        if (ResultList.Contains(node) == false)
                        {
                            ResultList.Add(node);
                            break;
                        }
                    }
                }
            }
            return ResultList;
        }
        //返回所有和敌国相邻地区列表
        List<DistrictNode> GetFrontierDistrictsAtWar()
        {
            List<DistrictNode> ResultList = new List<DistrictNode>();
            //遍历本国所有地区
            foreach (DistrictNode node in Districts)
            {
                //遍历该地区的周边地区
                foreach (IfCoreEdge edge in node.OutBound)
                {
                    if (edge.Type.Type == EdgeTypeEnum.Connect)
                    {
                        //如果该地区为本国领地则跳到下一地区
                        if (DistrictsList.Contains((DistrictNode)(edge.End)) == true)
                        {
                            continue;
                        }
                        //如果该地区所述国家不是敌国则跳到下一地区
                        if (Enemies.Contains(((DistrictNode)(edge.End)).Nation) == false)
                        {
                            continue;
                        }
                        //如果是外国地区，且不存在于列表中则加入列表
                        if (ResultList.Contains(node) == false)
                        {
                            ResultList.Add(node);
                            break;
                        }
                    }
                }
            }
            return ResultList;
        }
        //计算列表中地区的价值，并选出价值最大的地区。
        List<double> CalValueOfDistricts(List<DistrictNode> target)
        {
            List<double> ResultList = new List<double>();
            double dubEconomy = 0.0;
            int intInner, intOuter;
            //遍历邻近地区
            foreach (DistrictNode node in target)
            {
                //计算经济总量
                dubEconomy = node.Harvest + node.Commerce;
                intInner = intOuter = 0;
                //统计连边
                foreach (IfCoreEdge edge in node.OutBound)
                {
                    if (edge.Type.Type != EdgeTypeEnum.Connect)
                    {
                        continue;
                    }
                    if (DistrictsList.Contains((DistrictNode)edge.End) == true)
                    {
                        intInner++;
                    }
                    else
                    {
                        intOuter++;
                    }
                }
                if (intOuter == 0)
                {
                    dubEconomy = 0.0;
                }
                else
                {
                    //计算地区价值
                    dubEconomy *= intInner / (intOuter * 1.0);
                }
                ResultList.Add(dubEconomy);
            }
            return ResultList;
        }
        //计算列表中地区威胁度，并返回
        List<double> CalThreaten(List<DistrictNode> target)
        {
            List<double> ResultList = new List<double>();
            double dubEconomy = 0.0;
            int intInner, intOuter;
            //遍历本国边境
            foreach (DistrictNode node in target)
            {
                dubEconomy = node.Harvest + node.Commerce;
                intInner = intOuter = 0;
                //统计连边
                foreach (IfCoreEdge edge in node.OutBound)
                {
                    if (edge.Type.Type != EdgeTypeEnum.Connect)
                    {
                        continue;
                    }
                    if (DistrictsList.Contains((DistrictNode)edge.End) == true)
                    {
                        intInner++;
                    }
                    else
                    {
                        intOuter++;
                    }
                }
                //计算本国地区威胁度
                dubEconomy *= intOuter / ((intInner + 1) * 1.0);
                ResultList.Add(dubEconomy);
            }
            return ResultList;
        }
    }
}

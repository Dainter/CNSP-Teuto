using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNSP.Core.Edge
{
    public enum EdgeTypeEnum
    {
        Rule = 0x01,
        Lead = 0x02,
        Neutral = 0x10,
        Allies = 0x12,
        Hostile = 0x14,
    }
    public class EdgeType
    {
        EdgeTypeEnum intType;

        public EdgeTypeEnum Type
        {
            get
            {
                return intType;
            }
        }
        //连边类型构造函数
        public EdgeType(EdgeTypeEnum iType)
        {
            intType = iType;
        }

        //连边类型构造函数
        public EdgeType(string sTypeName)
        {
            intType = NameToType(sTypeName);
        }

        EdgeTypeEnum NameToType(string sTypeName)
        {
            switch (sTypeName)
            {
                case "统治":
                    return EdgeTypeEnum.Rule;
                case "率领":
                    return EdgeTypeEnum.Lead;
                case "中立":
                    return EdgeTypeEnum.Neutral;
                case "联盟":
                    return EdgeTypeEnum.Allies;
                case "敌对":
                    return EdgeTypeEnum.Hostile;
                default:
                    return 0;
            }
        }

        public override string ToString()
        {
            switch (intType)
            {
                case EdgeTypeEnum.Rule:
                    return "统治";
                case EdgeTypeEnum.Lead:
                    return "率领";
                case EdgeTypeEnum.Neutral:
                    return "中立";
                case EdgeTypeEnum.Allies:
                    return "联盟";
                case EdgeTypeEnum.Hostile:
                    return "敌对";
                default:
                    return "??";
            }
        }

    }
}

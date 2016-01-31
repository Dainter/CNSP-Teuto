using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNSP.Core.User
{
    public enum NodeTypeEnum//节点类型枚举
    {
        CharKing = 0x0001,
        CharPrince = 0x0002,
        CharGeneral = 0x0004,
        Nation = 0x0010,
        Troop = 0x0100,
        District = 0x1000,
    }

    public class NodeType//节点类型类
    {
        NodeTypeEnum intType;
        //属性
        public NodeTypeEnum Type
        {
            get
            {
                return intType;
            }
        }
        //连边类型构造函数
        public NodeType(NodeTypeEnum iType)
        {
            intType = iType;
        }

        //连边类型构造函数
        public NodeType(string sTypeName)
        {
            intType = NameToType(sTypeName);
        }

        NodeTypeEnum NameToType(string sTypeName)
        {
            switch (sTypeName)
            {
                case "国王":
                    return NodeTypeEnum.CharKing;
                case "王储":
                    return NodeTypeEnum.CharPrince;
                case "将军":
                    return NodeTypeEnum.CharGeneral;
                case "国家":
                    return NodeTypeEnum.Nation;
                case "部队":
                    return NodeTypeEnum.Troop;
                case "地区":
                    return NodeTypeEnum.District;
                default:
                    return 0;
            }
        }

        public override string ToString()
        {
            switch (intType)
            {
                case NodeTypeEnum.CharKing:
                    return "国王";
                case NodeTypeEnum.CharPrince:
                    return "王储";
                case NodeTypeEnum.CharGeneral:
                    return "将军";
                case NodeTypeEnum.Nation:
                    return "国家";
                case NodeTypeEnum.Troop:
                    return "部队";
                case NodeTypeEnum.District:
                    return "地区";
                default:
                    return "??";
            }
        }
    }
}

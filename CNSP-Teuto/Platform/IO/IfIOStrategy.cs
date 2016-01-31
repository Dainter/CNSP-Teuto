using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNSP.Core.Graph;
using System.Xml;

namespace CNSP.Platform.IO
{
    public interface IfIOStrategy//�ļ���д�㷨�ӿ�
    {
        Graph ReadFile(string sPath);
        void SaveFile(XmlDocument doc, string sPath);
    }
}

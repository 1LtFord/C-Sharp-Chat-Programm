using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient
{
    public struct ServerInfo
    {
        public string IP;
        public string Port;
        public string ServerName;
        public string Username;
        public string Pwd;
        public string SrvPwd;
        public UInt16 MaxUserAmount;
        public UInt16 CurrUserAmount;
        public bool isOnline;

        public override string ToString()
        {
            return IP + ";" + Port + ";" + ServerName + ";" + Username + ";" + Pwd + ";" + SrvPwd + ";" + MaxUserAmount + ";" + CurrUserAmount;
        }

        public void parseSrvInfo(List<string> _info)
        {
            ServerName = _info[0];
            MaxUserAmount = Convert.ToUInt16(_info[1]);
            CurrUserAmount = Convert.ToUInt16(_info[2]);

        }


    }
}

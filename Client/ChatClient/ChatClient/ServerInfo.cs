namespace ChatClient
{
    using System;
    using System.Collections.Generic;
    using System.Text;

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
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(this.IP);
            stringBuilder.Append(";");
            stringBuilder.Append(this.Port);
            stringBuilder.Append(";");
            stringBuilder.Append(this.ServerName);
            stringBuilder.Append(";");
            stringBuilder.Append(this.Username);
            stringBuilder.Append(";");
            stringBuilder.Append(this.Pwd);
            stringBuilder.Append(";");
            stringBuilder.Append(this.SrvPwd);
            stringBuilder.Append(";");
            stringBuilder.Append(this.MaxUserAmount);
            stringBuilder.Append(";");
            stringBuilder.Append(this.CurrUserAmount);

            return stringBuilder.ToString();
        }

        public void parseSrvInfo(List<string> _info)
        {
            ServerName = _info[0];
            MaxUserAmount = Convert.ToUInt16(_info[1]);
            CurrUserAmount = Convert.ToUInt16(_info[2]);

        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient
{
    public class Client
    {
        public Server connectedServer;
        public string LoginName;
        public string LoginPwd;
        public string SrvPwd;
        public List<ServerInfo> SrvInfoList;
        

        public Client()
        {
            SrvInfoList = new List<ServerInfo>();
            LoadSrvInfoList();
            connectedServer = new Server();
            connectedServer.Disconnected += new Server.ServerDisconnectedHandler(server_Disconnected);
        }

        private void LoadSrvInfoList()
        {

        }

        public void setLoginData(string _LoginName, string _LoginPwd, string _SrvPwd="")
        {
            LoginName = _LoginName;
            LoginPwd = _LoginPwd;
            SrvPwd = _SrvPwd;
        }

        

        public void server_Disconnected(object handle)
        {
            
        }

        
    }
}

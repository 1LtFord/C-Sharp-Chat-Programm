namespace ChatClient
{
    using System.Collections.Generic;

    public class Client
    {
        public Server connectedServer;
        public string LoginName;
        public string LoginPwd;
        public string SrvPwd;
        public List<ServerInfo> SrvInfoList;
        

        public Client()
        {
            this.SrvInfoList = new List<ServerInfo>();
            this.LoadSrvInfoList();
            this.connectedServer = new Server();
            this.connectedServer.Disconnected += new Server.ServerDisconnectedHandler(server_Disconnected);
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

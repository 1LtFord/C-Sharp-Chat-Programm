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
            this.LoadServerInfoList();
            this.connectedServer = new Server();
            this.connectedServer.Disconnected += new Server.ServerDisconnectedHandler(this.ServerDisconnected);
        }
        
        public void SetLoginData(string loginName, string loginPassword, string serverPassword = "")
        {
            this.LoginName = loginName;
            this.LoginPwd = loginPassword;
            this.SrvPwd = serverPassword;
        }

        public void ServerDisconnected(object handle)
        {
        }
        
        private void LoadServerInfoList()
        {
        }
    }
}

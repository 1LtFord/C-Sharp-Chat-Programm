namespace ChatClient
{
    using System.Collections.Generic;

    public class Client
    {
        private Server connectedServer;
        private string loginName;
        private string loginPassword;
        private string serverPassword;
        public List<ServerInfo> ServerInfoList;
        
        public Client()
        {
            this.ServerInfoList = new List<ServerInfo>();
            this.LoadServerInfoList();
            this.connectedServer = new Server();
            this.connectedServer.Disconnected += new Server.ServerDisconnectedHandler(this.ServerDisconnected);
        }
        
        public void SetLoginData(string loginName, string loginPassword, string serverPassword = "")
        {
            this.loginName = loginName;
            this.loginPassword = loginPassword;
            this.serverPassword = serverPassword;
        }

        public void ServerDisconnected(object handle)
        {
        }
        
        private void LoadServerInfoList()
        {
            // TODO no implement
        }
    }
}

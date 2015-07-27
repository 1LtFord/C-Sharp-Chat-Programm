namespace ChatClient
{
    using System.Collections.Generic;

    public class Client
    {
        public List<ServerInfo> ServerInfoList;

        public Server connectedServer;
        private string loginName;
        private string loginPassword;
        private string serverPassword;
        
        public Client()
        {
            this.ServerInfoList = new List<ServerInfo>();
            this.LoadServerInfoList();
            this.connectedServer = new Server();
            this.connectedServer.Disconnected += new Server.ServerDisconnectedHandler(this.ServerDisconnected);
        }
        
        public void SetLoginData(string name, string password, string serverPassword = "")
        {
            this.loginName = name;
            this.loginPassword = password;
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

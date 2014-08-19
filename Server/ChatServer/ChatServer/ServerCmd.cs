using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    public enum ServerCommand
    {
        //Responses of cmd Login(4;Benutzername;BenutzerPW[;ServerPW])
        isLogged,//(0)
        WrongPwd,//(1)
        NewUserRegistered,//(2)
        ServerIsFull,//(3)
        ServerIsPrivate,//(4)
        UserIsBanned,//(5)

        //Response of Cmd getLoggedUserList(6)
        LoggedUserList, // (6;User;User;User...)

        //Response of Cmd getLatestMsgLog(5)
        sendLatestMsgLog,//(7; Nachricht(User,Time,Msg);....;..;...)
        MsgLogRestricted, //(8)

        //Response of Cmd sendMsg(1;msg)
        MsgAccepted, // (9) 

        //Response of Cmd Disconnect(2)
        DisconnectReceived, //(10)

        //Response of Cmd getServerInfo(16)
        SendServerInfo,//(11,serverName,serverMaxUserCount,currentUserCount,needPwd(bool))

        spreadMsg, //(12,User,Time,Msg)

        ServerIsClosing, //(13[,ServerMsg])

        WrongArgs,//(14)
        AlreadyLogged, //(15)
        NotLoggedIn,//(16)
        ChangeOfLoggedUserList,//(17,nameOfLoggedUser[,anotherNameOfLoggedUser],...)
        ChangeOfServerInfo,//(18,serverName,serverMaxUserCount,currentUserCount,needPwd(bool))

    }

    public enum ClientCommand
    {
        connect,
        sendMsg,//(1,Nachricht)
        disconnect,//(2)
        changeName,
        login, // (4;Benutzername;BenutzerPW[;ServerPW])
        getLatestMsgLog,//(5)
        getLoggedUserList, //(6)
        getAllUserList,
        setMyStatus,
        getMyStatus,
        kickUser,
        banUser,
        setUserRole,
        UnbanUser,
        sendPrivateMsg,
        changePwd,
        getServerInfo,//(16)
        getServerReadme

    }


    public class ServerCmd
    {

        public Client CurrClient;

        public ServerDB CurrServerDB;

        public ServerCommand CurrServerCommand = new ServerCommand();

        
        public ClientCommand CurrClientCommand = new ClientCommand();

        public ServerCmd(ServerDB _currServerDB)
        {
            this.CurrServerDB = _currServerDB;
        }

        public void ExecuteCmd(Client _currClient, byte[] _data)
        {
            string[] args=this.DecodeCmdStringArray(_data);
            this.CurrClient = _currClient;

            switch (CurrClientCommand)
            {
                case ClientCommand.connect:
                    break;
                case ClientCommand.sendMsg:
                    getMsg(args);
                    break;
                case ClientCommand.disconnect:
                    disconnectUser();
                    break;
                case ClientCommand.changeName:
                    break;
                case ClientCommand.login:
                    Login(args);
                    break;
                case ClientCommand.getLatestMsgLog:
                    this.sendLatestMsgLog();
                    break;
                case ClientCommand.getLoggedUserList:
                    this.getLoggedUserList();
                    break;
                case ClientCommand.getAllUserList:
                    break;
                case ClientCommand.setMyStatus:
                    break;
                case ClientCommand.getMyStatus:
                    break;
                case ClientCommand.kickUser:
                    break;
                case ClientCommand.banUser:
                    break;
                case ClientCommand.setUserRole:
                    break;
                case ClientCommand.UnbanUser:
                    break;
                case ClientCommand.sendPrivateMsg:
                    break;
                case ClientCommand.changePwd:
                    break;
                case ClientCommand.getServerInfo:
                    
                    SendServerInfo();
                    break;
                case ClientCommand.getServerReadme:
                    break;
                default:
                    break;
            }


        }

        private void disconnectUser()
        {
            //if (CurrClient.UserID != "") CurrServerDB.LogOff(CurrClient.UserID);
            //CurrClient.Close();
            //Program.clients.RemoveAt(CurrClient.indexOffset);
        }

        private void getMsg(string[] args)
        {
            if (CurrClient.UserID != "")
            {
                string msg=args[0];
                bool NewMsg=CurrServerDB.AddMsg(CurrClient.UserID, msg);
                if (NewMsg) 
                {
                    CurrClient.Send((int)ServerCommand.MsgAccepted);
                    SpreadMsg(CurrServerDB.getLatestMsgFromUser(CurrClient.UserID));
                }
            }
            else
            {
                CurrClient.Send((int)ServerCommand.NotLoggedIn);
            }
        }

        private void SpreadMsg(string[] p)
        {
            string args=this.ConvertToString(p);
            for (int i = 0; i < Program.clients.Count; i++)
            {
                Program.clients[i].Send((int)ServerCommand.spreadMsg, args);
            }
            //CurrClient.Send((int)ServerCommand.spreadMsg, args);

        }

        

        private void sendLatestMsgLog()
        {
            if ((bool)ServerConfigManager.MyConfigs["PullMsgLogAllowed"])
            {
                if (CurrClient.UserID != "")
                {
                    string[] msgLog = CurrServerDB.getLatestMsgLog();

                    CurrClient.Send((int)ServerCommand.sendLatestMsgLog, this.ConvertToString(msgLog));
                }
                else
                {
                    CurrClient.Send((int)ServerCommand.NotLoggedIn);
                }
            }
            else
            {
                CurrClient.Send((int)ServerCommand.MsgLogRestricted);
            }
        }

        private void getLoggedUserList()
        {
            if (CurrClient.UserID != "")
            {

                string[] userlistAr = CurrServerDB.getLoggedUserList();
                string userlist = this.ConvertToString(userlistAr);
                CurrClient.Send((int)ServerCommand.LoggedUserList, userlist);
            }
            else {
                CurrClient.Send((int)ServerCommand.NotLoggedIn);
            }
        }


        

        private void Login(string[] args)
        {
            if ((int)ServerConfigManager.MyConfigs["maxUserCount"] == CurrServerDB.getLoggedUserCount()) CurrClient.Send((int)ServerCommand.ServerIsFull);
            if (CurrClient.UserID != ""){ CurrClient.Send((int)ServerCommand.AlreadyLogged); return;}
            //if ((bool)ServerConfigManager.MyConfigs["isServerPrivate"]) { CurrClient.Send((int)ServerCommand.ServerIsPrivate); return; }
            if(args.Length==2)
            {
                string username=args[0];string password=args[1];
                ServerCommand cmd = CurrServerDB.Login(username, password);
                if (cmd == ServerCommand.isLogged) CurrClient.UserID = CurrServerDB.getIdByUsername(username).ToString();
                if (cmd == ServerCommand.NewUserRegistered) CurrClient.UserID = CurrServerDB.getIdByUsername(username).ToString();
                CurrClient.Send((int)cmd);
            }else
	        {
                Console.WriteLine("Zu viele Parameter beim Login: "+CurrClient.EndPoint.ToString());
                CurrClient.Send((int)ServerCommand.WrongArgs);
	        }

        }

        public void LogOff()
        {

            if(CurrClient.UserID!="")CurrServerDB.LogOff(CurrClient.UserID);
        }


        public string ConvertToString(string[] _args)
        {
            string cmdString="";
            for (int i = 0; i < _args.Length; i++)
            {
                cmdString +=";"+_args[i];
            }
            return cmdString;
        }

        public void SendServerInfo()
        {
            
            //(11,serverName,serverMaxUserCount,currentUserCount,)
            CurrClient.Send((int)ServerCommand.SendServerInfo, ";" + ServerConfigManager.MyConfigs["ServerName"] + ";" + ServerConfigManager.MyConfigs["maxUserCount"] + ";" + CurrServerDB.getLoggedUserCount().ToString());
            
        }

        public void DecodeArgs(string[] _args)
        {
            for (int i = 0; i < _args.Length; i++)
            {
                _args[i] = Uri.UnescapeDataString(_args[i]);
            }
        }

        public void EncodeArgs(string[] _args)
        {
            for (int i = 0; i < _args.Length; i++)
            {
                _args[i] = Uri.EscapeDataString(_args[i]);
            }
        }

        public string[] DecodeCmdStringArray(byte[] _data)
        {
            string argsString = System.Text.Encoding.UTF8.GetString(_data);
            string[] args = argsString.Split(new char[] { ';' });
            try
            {
                this.CurrClientCommand = (ClientCommand)Enum.Parse(typeof(ClientCommand), args[0]);
            }
            catch
            {
                Console.WriteLine("Wrong Command Nr: "+args[0]);
            }
            args = args.Where(w => w != args[0]).ToArray();
            return args;
        }


    }
}

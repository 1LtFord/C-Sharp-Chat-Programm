using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    public class ServerCmd
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
            SendServerInfo,//(11,serverName,serverMaxUserCount,currentUserCount,)

            spreadMsg, //(12,User,Time,Msg)

            ServerIsClosing //(13[,ServerMsg])

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

        public ServerCommand CurrServerCommand = new ServerCommand();

        public ClientCommand CurrClientCommand = new ClientCommand();

        public void ExecuteCmd(Client currClient, string[] args)
        {
            Console.WriteLine("Bin im ExecuteCmd");
            CurrClientCommand = (ClientCommand)Enum.Parse(typeof(ClientCommand), args[0]);
            args = args.Where(w => w != args[0]).ToArray();


            switch (CurrClientCommand)
            {
                case ClientCommand.connect:
                    break;
                case ClientCommand.sendMsg:
                    break;
                case ClientCommand.disconnect:
                    break;
                case ClientCommand.changeName:
                    break;
                case ClientCommand.login:
                    break;
                case ClientCommand.getLatestMsgLog:
                    break;
                case ClientCommand.getLoggedUserList:
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
                    CurrServerCommand = ServerCommand.SendServerInfo;
                    
                    SendServerInfo(currClient);
                    break;
                case ClientCommand.getServerReadme:
                    break;
                default:
                    break;
            }


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

        public string[] ConvertToStringArray(string _argsInString)
        {
            return new string[]{"2"};
        }

        public void SendServerInfo(Client currClient)
        {
            
            //(11,serverName,serverMaxUserCount,currentUserCount,)
            currClient.Send((int)CurrServerCommand,";SkullteriaServer;18;0");
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatClient
{
   

    public enum ServerCmd
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

    public enum ClientCmd
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


    public class ClientCommand
    {
        public ClientCmd cmd;
        public List<string> Args;
        public ClientCommand(string _CmdString)
        {
            fetchCmd(_CmdString);
            Init();
        }
        public ClientCommand()
        {
            Init();
        }
        public ClientCommand(int _cmd)
        {
            cmd = (ClientCmd)Enum.Parse(typeof(ClientCmd), _cmd.ToString());
            Init();
        }

        private void Init()
        {
            Args = new List<string>();
        }
        
        public void fetchCmd(string _CmdString)
        {
            string[] buff=_CmdString.Split(';');
            ClientCmd cmd = (ClientCmd)Enum.Parse(typeof(ClientCmd), buff[0]);
            Args=buff.Where(w => w != buff[0]).ToList<string>();
        }

        public override string ToString()
        {
            string myCmdString = ((int)cmd).ToString() ;
            foreach (string item in Args)
            {
                myCmdString = myCmdString + ";" + item;
            }
            return myCmdString;
        }


    }

    public class ServerCommand
    {
        public ServerCmd cmd;
        public List<string> Args;
        public ServerCommand(string _CmdString)
        {
            fetchCmd(_CmdString);
        }
        public ServerCommand()
        {

        }
        public ServerCommand(int _cmd)
        {
            ClientCmd cmd = (ClientCmd)Enum.Parse(typeof(ClientCmd), _cmd.ToString());
        }

        public void fetchCmd(string _CmdString)
        {
            string[] buff = _CmdString.Split(';');
            ClientCmd cmd = (ClientCmd)Enum.Parse(typeof(ClientCmd), buff[0]);
            Args = buff.Where(w => w != buff[0]).ToList<string>();
        }

        public override string ToString()
        {
            string myCmdString = ((int)cmd).ToString();
            foreach (string item in Args)
            {
                myCmdString = myCmdString + ";" + item;
            }
            return myCmdString;
        }


    }

}

namespace ChatClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public enum ServerCmd
    {
        //Responses of CommandList Login(4;Benutzername;BenutzerPW[;ServerPW])
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
            ClientCommandList CommandList = (ClientCommandList)Enum.Parse(typeof(ClientCommandList), _cmd.ToString());
        }

        public void fetchCmd(string _CmdString)
        {
            string[] buff = _CmdString.Split(';');
            ServerCmd cmd = (ServerCmd)Enum.Parse(typeof(ServerCmd), buff[0]);
            Args = buff.Where(w => w != buff[0]).ToList<string>();
        }

        public override string ToString()
        {
            string myCmdString = ((int)cmd).ToString();

            return this.Args.Aggregate(myCmdString, (current, item) => current + ";" + item);
        }


    }

}

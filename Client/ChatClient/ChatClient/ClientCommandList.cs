namespace ChatClient
{
    public enum ClientCommandList
    {
        Connect,
        SendMsg, // (1,Nachricht)
        Disconnect, // (2)
        ChangeName,
        Login, // (4;Benutzername;BenutzerPW[;ServerPW])
        GetLatestMsgLog, // (5)
        GetLoggedUserList, // (6)
        GetAllUserList,
        SetMyStatus,
        GetMyStatus,
        KickUser,
        BanUser,
        SetUserRole,
        UnbanUser,
        SendPrivateMsg,
        ChangePwd,
        GetServerInfo, // (16)
        GetServerReadme
    }
}

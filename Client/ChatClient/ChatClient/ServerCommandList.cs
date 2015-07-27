namespace ChatClient
{
    public enum ServerCommandList
    {
        IsLogged,
        WrongPwd,
        NewUserRegistered,
        ServerIsFull,
        ServerIsPrivate,
        UserIsBanned,
        LoggedUserList,
        SendLatestMsgLog,
        MsgLogRestricted,
        MsgAccepted,
        DisconnectReceived,
        SendServerInfo,
        SpreadMessage,
        ServerIsClosing,
        WrongArgs,
        AlreadyLogged,
        NotLoggedIn,
        ChangeOfLoggedUserList,
        ChangeOfServerInfo
    }
}

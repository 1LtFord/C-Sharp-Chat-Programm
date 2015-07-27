namespace ChatClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class ServerCommand
    {
        public ServerCommandList CommandList;
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
            ServerCommandList CommandList = (ServerCommandList)Enum.Parse(typeof(ServerCommandList), buff[0]);
            Args = buff.Where(w => w != buff[0]).ToList<string>();
        }

        public override string ToString()
        {
            string myCmdString = ((int)this.CommandList).ToString();

            return this.Args.Aggregate(myCmdString, (current, item) => current + ";" + item);
        }


    }

}

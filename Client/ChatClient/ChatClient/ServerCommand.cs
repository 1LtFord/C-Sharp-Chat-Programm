namespace ChatClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class ServerCommand
    {
        public ServerCommandList CommandList;
        public List<string> Args;

        public ServerCommand(string command)
        {
            this.FetchCommand(command);
        }

        public ServerCommand()
        {
        }

        public ServerCommand(int command)
        {
            ClientCommandList CommandList = (ClientCommandList)Enum.Parse(typeof(ClientCommandList), command.ToString());
        }

        public void FetchCommand(string command)
        {
            string[] buff = command.Split(';');
            ServerCommandList CommandList = (ServerCommandList)Enum.Parse(typeof(ServerCommandList), buff[0]);
            this.Args = buff.Where(w => w != buff[0]).ToList<string>();
        }

        public override string ToString()
        {
            var myCmdString = ((int)this.CommandList).ToString();
            return this.Args.Aggregate(myCmdString, (current, item) => current + ";" + item);
        }
    }
}
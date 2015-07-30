namespace ChatClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ClientCommand
    {
        private ClientCommandList commandList;
        public List<string> Args;

        public ClientCommand(string commandString)
        {
            this.FetchCommand(commandString);
            this.Init();
        }

        public ClientCommand()
        {
            this.Init();
        }

        public ClientCommand(int command)
        {
            this.commandList = (ClientCommandList)Enum.Parse(typeof(ClientCommandList), command.ToString());
            this.Init();
        }

        private void Init()
        {
            this.Args = new List<string>();
        }

        public void FetchCommand(string commandString)
        {
            string[] buff = commandString.Split(';');
            ClientCommandList CommandList = (ClientCommandList)Enum.Parse(typeof(ClientCommandList), buff[0]);
            this.Args = buff.Where(w => w != buff[0]).ToList<string>();
        }

        public override string ToString()
        {
            var myCmdString = ((int)this.commandList).ToString();

            return this.Args.Aggregate(myCmdString, (current, item) => current + ";" + item);
        }
    }
}

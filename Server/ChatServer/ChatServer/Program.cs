using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace ChatServer
{
    class Program
    {
        //Ich erzeuge mein Lauscher Klasse in welcher sich der Socket befindet, 
        //der mir die eigtl. Verbindungssockets erzeugt 
        static Listener listener;
        static ServerCmd serverCmd;
        static List<Client> clients;
        static int port = 8;
        static void Main(string[] args)
        {
            listener = new Listener(port);
            listener.SocketAccepted += new EventHandler<SocketAcceptedEventHandler>(listener_SocketAccepted);
            listener.Start();
            clients = new List<Client>();


            //Schließe das Programm nicht
            System.Diagnostics.Process.GetCurrentProcess().WaitForExit();
        }

        static void listener_SocketAccepted(object sender, SocketAcceptedEventHandler e)
        {
            Console.WriteLine("New Connection: {0}\n{1}\n===========", e.Accepted.RemoteEndPoint, DateTime.Now);
            clients.Add(new Client(e.Accepted));
            int currIndex = clients.Count - 1;
            clients[currIndex].Received += new Client.ClientReceivedHandler(client_Received);
            clients[currIndex].Disconnected += new Client.ClientDisconnectedHandler(client_Disconnected);
        }

        static void client_Received(object sender, byte[] data)
        {
            string argsString=System.Text.Encoding.UTF8.GetString(data);
            string[] args = argsString.Split(new char[]{';'});
            Client currClient = (Client)sender;
            serverCmd.ExecuteCmd(currClient, args);
        }

        static void client_Disconnected(Client sender)
        {

        }
    }
}

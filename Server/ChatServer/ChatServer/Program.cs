using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Diagnostics;

namespace ChatServer
{
    class Program
    {
        //Ich erzeuge mein Lauscher Klasse in welcher sich der Socket befindet, 
        //der mir die eigtl. Verbindungssockets erzeugt 
        static public Listener listener;
        static public ServerCmd serverCmd;
        static public ServerDB serverDB;
        static public List<Client> clients;
        static public int port = 8;

        static void Main(string[] args)
        {
            //This must be the first line!!
            ServerConfigManager.LoadMyConfigs();

            Process.GetCurrentProcess().Exited += Program_Exited;

            Console.WriteLine((string)ServerConfigManager.MyConfigs["ServerName"]);


            serverDB = new ServerDB();
            serverCmd = new ServerCmd(serverDB);
            

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
            clients[currIndex].indexOffset = currIndex;
            clients[currIndex].Received += new Client.ClientReceivedHandler(client_Received);
            clients[currIndex].Disconnected += new Client.ClientDisconnectedHandler(client_Disconnected);
        }

        static void client_Received(object sender, byte[] data)
        {
            Console.WriteLine("Etwas kommt: "+Encoding.UTF8.GetString(data));
            Client currClient = (Client)sender;
            serverCmd.ExecuteCmd(currClient, data);
        }

        static void client_Disconnected(Client sender)
        {
            Console.WriteLine("User hat sich ausgeloggt: " + sender.EndPoint.ToString());
            serverCmd.CurrClient = sender;
            serverCmd.LogOff();
            sender.Close();
            
        }

        private static void Program_Exited(object sender, EventArgs e)
        {
            ServerConfigManager.SaveMyConfigs();
            
        }
        
    }
}

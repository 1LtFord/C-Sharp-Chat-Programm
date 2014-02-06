using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
namespace ChatServer
{
    public class ServerDB
    {
        public string cs = "Data Source=ChatServerDB.s3db";
        public SQLiteConnection con;
        public SQLiteCommand cmd;
        public SQLiteDataReader reader;

        public ServerDB() 
        {
            initServerDB();
            

        }

        public ServerCommand Login(string _username,string _password)
        {
            cmd.CommandText = "select count(id) as myCount,id from client where username='"+_username+"';";

            SQLiteDataReader reader = cmd.ExecuteReader();

            reader.Read();
            //User existiert nicht
            if (reader.GetInt16(0) == 0)
            {
                reader.Close();
                cmd.CommandText = "insert into client values(null,'" + _username + "','" + _password + "',null,null,1,'abwesend')";
                cmd.ExecuteNonQuery();
                Console.WriteLine("add new User: " +_username );
                return ServerCommand.NewUserRegistered;

            }
            //User existiert
            else
            {
                reader.Close();
                
                Console.WriteLine("Username vorhanden");
                cmd.CommandText = "select count(id) as myCount,id from client where password='" + _password + "';";
                reader = cmd.ExecuteReader();
                reader.Read();
                //Passwort ist richtig
                if (reader.GetInt16(0) != 0)
                {
                    return ServerCommand.isLogged;
                    Console.WriteLine("Richtiges PW");
                }
                else {
                    return ServerCommand.WrongPwd;
                    Console.WriteLine("Falsches PW");
                }
            }
            return 0;
        }

        public void LogOff(string _UserID)
        {
            cmd.CommandText = "Update client set isLogged=0";
            cmd.ExecuteNonQuery();
        }

        

        public string[] getLoggedUserList()
        {
            this.clearCmd();
            cmd.CommandText = "Select username from client where isLogged=1;";
            reader = cmd.ExecuteReader();
            List<string> userlist=new List<string>();
            while (reader.Read())
            {
                userlist.Add(reader.GetString(0));
            }
            return userlist.ToArray();
            
        }

        public string getIdByUsername(string _username)
        {
            this.clearCmd();
            cmd.CommandText = "Select id from client where username=" + _username + ";";
            reader = cmd.ExecuteReader();
            reader.Read();
            return reader.GetString(0);


        }

        private void clearCmd()
        {
            cmd.Dispose();
            reader.Close();
            cmd = new SQLiteCommand(con);
        }

        public string getUsernameById(int _clientId)
        {
            SQLiteCommand cmd2=new SQLiteCommand(con);
            cmd2.CommandText = "Select username from client where id=" + _clientId + ";";
            SQLiteDataReader reader2 = cmd.ExecuteReader();
            reader2.Read();
            string username=reader2["username"].ToString();
            reader2.Close();
            reader2.Dispose();
            cmd.Dispose();
            return username;
        }


        ~ServerDB()
        {
            cmd.Dispose();
            con.Close();
            con.Close();
        }

        public void initServerDB()
        {
            con = new SQLiteConnection(cs);
            con.Open();
            cmd = new SQLiteCommand(con);
            
        }






        public string[] getLatestMsgLog()
        {
            this.clearCmd();
            List<string> msgLogList=new List<string>();
            int AllowedMsgAmount = (int)ServerConfigManager.MyConfigs["MaxPullMsgLogAmount"];
            cmd.CommandText = "Select * from msgLog ORDER BY sendTimestamp DESC LIMIT "+AllowedMsgAmount.ToString()+";";
            reader = cmd.ExecuteReader();
            while (reader.Read())
	        {
	            msgLogList.Add( System.Uri.EscapeDataString(this.getUsernameById(reader.GetInt16(1)))+","+System.Uri.EscapeDataString(Convert.ToString(reader.GetDateTime(3)))+","+System.Uri.EscapeDataString(reader.GetString(2)));
	        }

            
            return msgLogList.ToArray();
        }
        private bool insertMsg(string _msg,string _userId)
        {
            this.clearCmd();

            cmd.CommandText = "insert into msgLog values(null," + _userId + "," + _msg + ",null);";
            return Convert.ToBoolean(cmd.ExecuteNonQuery());
        }
    }
}

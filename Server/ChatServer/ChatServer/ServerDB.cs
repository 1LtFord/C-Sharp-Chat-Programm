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
            this.clearCmd();
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
                    Console.WriteLine("Richtiges PW");
                    this.setUserLogged(_username);
                    return ServerCommand.isLogged;
                }
                else {
                    return ServerCommand.WrongPwd;
                    Console.WriteLine("Falsches PW");
                }
            }
            return 0;
        }

        private void setUserLogged(string _username)
        {
            clearCmd();
            cmd.CommandText="UPDATE client set isLogged=1 where username='"+_username+"';";
            cmd.ExecuteNonQuery();
        }



        public void LogOff(string _UserID)
        {
            this.clearCmd();
            cmd.CommandText = "Update client set isLogged=0 where id="+_UserID+";";
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

        public int getIdByUsername(string _username)
        {
            this.clearCmd();
            cmd.CommandText = "Select id from client where username='" + _username + "';";
            reader = cmd.ExecuteReader();
            reader.Read();
            return reader.GetInt16(0);


        }

        private void clearCmd()
        {
            cmd.Dispose();
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


        public int getLoggedUserCount()
        {
            this.clearCmd();
            cmd.CommandText = "select count(id) from client where isLogged=1;";
            reader = cmd.ExecuteReader();
            reader.Read();
            return reader.GetInt16(0);
        }

        public bool AddMsg(string p, string msg)
        {
            this.clearCmd();
            cmd.CommandText = "insert into msgLog values("+p+","+msg+",null);";
            bool isInserted = Convert.ToBoolean(cmd.ExecuteNonQuery());
            if (isInserted)
            {
                Console.WriteLine("Neue Nachricht wurde hinzugefügt von "+this.getUsernameById(Convert.ToInt16(p)));
                return true;
            }
            return false;
        }
        public string[] getLatestMsgFromUser(string uid)
        {
            
            this.clearCmd();
            string username = this.getUsernameById(Convert.ToInt16(uid));
            string[] msgAr = new string[3];
            msgAr[0] = Uri.EscapeDataString(username);

            cmd.CommandText="Select msg,sendTimestamp from msgLog where userid="+uid+" ORDER BY sendTimestamp DESC LIMIT 0,1";

            reader=cmd.ExecuteReader();
            reader.Read();
            msgAr[1] = Uri.EscapeDataString(reader.GetString(0));
            msgAr[2] = Uri.EscapeDataString(Convert.ToString(reader.GetDateTime(1)));
            return msgAr;
        }
    }
}

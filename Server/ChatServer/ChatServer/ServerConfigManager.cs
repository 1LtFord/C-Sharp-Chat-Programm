using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    static public class ServerConfigManager
    {
        static public readonly string ConfigPath = "./MyConfigs.cfg";
        static public Hashtable MyConfigs = new Hashtable();

        static public void LoadMyConfigs()
        {
            if (File.Exists(ConfigPath))
            {
                MyConfigs.Clear();
                string[] configLines = File.ReadAllLines(ConfigPath);
                foreach(string item in configLines)
                {
                    string[] configArray = item.Split(new char[] {';'});
                    string value = configArray[1];
                    //configArray[2] ist der String welcher in einen Type umgewandelt werden soll, weil ich durch den cast
                    //Operator den String configArray[1] in den geparsten type von configArray[2] umwandeln will.
                    switch (configArray[2])
	                {
                            case "System.Boolean":
                        MyConfigs.Add(configArray[0],Convert.ToBoolean(configArray[1]));
                            break;
                            case "System.Int32":
                    MyConfigs.Add(configArray[0],Convert.ToInt32(configArray[1]));
                        break;
                            case "System.String":
                    MyConfigs.Add(configArray[0],configArray[1]);
                        break;
		                default:
                        break;
	                }
                }

            }
            else {
                MyConfigs.Add("maxUserCount", 20);
                MyConfigs.Add("maxMsgCount", 200);
                MyConfigs.Add("PullMsgLogAllowed", true);
                MyConfigs.Add("MaxPullMsgLogAmount", 50);
                MyConfigs.Add("isServerPrivate", false);
                MyConfigs.Add("isWhiteListActivated", false);
                MyConfigs.Add("isBlackListActivated", false);
                MyConfigs.Add("ServerName", "C#-ChatServer");
                MyConfigs.Add("Description", "Copyright by Ferhat Catak");
                MyConfigs.Add("port",8);

                SaveMyConfigs();
            }
        }

       
        public static void SaveMyConfigs()
        {


            if (!File.Exists(ConfigPath))
            {
                File.Create(ConfigPath).Close(); 
            }
                using (StreamWriter sw = File.AppendText(ConfigPath))
                {
                    foreach (DictionaryEntry entry in MyConfigs)
                    {
                        sw.WriteLine(entry.Key + ";" + Convert.ToString(entry.Value) + ";" + entry.Value.GetType().ToString());
                    }
                    sw.Close();
                    sw.Dispose();
                }
            
            
        }
    }
}

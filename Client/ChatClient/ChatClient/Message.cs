using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient
{
    public class Message
    {
        public string Author;
        public string Text;
        public string Date;

        public Message() { }

        public Message(string _author, string _text, string _date)
        {
            fetchMessage(_author, _text, _date);
        }

        public Message(string MsgString)
        { 
            string[] buff=MsgString.Split(';');
            fetchMessage(decText(buff[0]), decText(buff[1]), decText(buff[2]));
        }


        public void fetchMessage(string _author, string _text, string _date)
        {
            Author = _author;
            Text = _text;
            Date = _date;
        }

        public override string ToString()
        {
            return encText(Author) + ";" + encText(Text) + ";" + encText(Date);
        }

        public string decText(string text)
        {
            return Uri.UnescapeDataString(text);
        }

        public string encText(string text)
        {
            return Uri.EscapeDataString(text);
        }
    }
}

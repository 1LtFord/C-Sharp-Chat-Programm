namespace ChatClient
{
    using System;
    using System.Text;

    public class Message
    {
        private string author;
        private string text;
        private string date;

        public Message(string author, string textString, string date)
        {
            this.FetchMessage(author, textString, date);
        }

        public Message(string message)
        { 
            string[] buff = message.Split(';');
            this.FetchMessage(this.UnscapeText(buff[0]), this.UnscapeText(buff[1]), this.UnscapeText(buff[2]));
        }


        public void FetchMessage(string author, string textString, string date)
        {
            this.author = author;
            this.text = textString;
            this.date = date;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(this.EscapeText(this.author));
            stringBuilder.Append(";");
            stringBuilder.Append(this.EscapeText(this.text));
            stringBuilder.Append(";");
            stringBuilder.Append(this.EscapeText(this.date));
            stringBuilder.Append(";");

            return stringBuilder.ToString();
        }

        public string UnscapeText(string textString)
        {
            return Uri.UnescapeDataString(textString);
        }

        public string EscapeText(string textString)
        {
            return Uri.EscapeDataString(textString);
        }
    }
}

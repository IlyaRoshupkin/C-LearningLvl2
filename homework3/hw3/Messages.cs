using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Messages
    {
        public static List<string> messagesJournal = new List<string>();

        public delegate void AddMessage(string message);
        public static void ConsoleMessage(string message)
        {
            Console.WriteLine(message);
            //Game.messagesJournal.Add(message);
        }
        public static void JournalMessage(string message)
        {
            messagesJournal.Add(message);
        }
    }
}

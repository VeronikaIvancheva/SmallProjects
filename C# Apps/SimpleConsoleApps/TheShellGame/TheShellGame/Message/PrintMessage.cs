using System;

namespace TheShellGame.Message
{
    /// <summary>
    /// A class that print all given messages to the console.
    /// </summary>
    public static class PrintMessage
    {
        public static void Message(string message)
        {
            Console.WriteLine(message);
        }

        public static void Message(string message, int number)
        {
            Console.WriteLine(message, number);
        }
    }
}

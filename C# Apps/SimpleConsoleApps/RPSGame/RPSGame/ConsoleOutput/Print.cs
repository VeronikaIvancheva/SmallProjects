using System;

namespace RPSGame.ConsoleOutput
{
    public static class Print
    {
        public static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void PrintMessage(string message, string choose)
        {
            Console.WriteLine(message, choose);
        }

        public static void PrintMessage(string message, int number)
        {
            Console.WriteLine(message, number);
        }
    }
}

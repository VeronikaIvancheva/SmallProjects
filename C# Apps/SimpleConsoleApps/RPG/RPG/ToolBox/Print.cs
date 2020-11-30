using System;

namespace RPG.ToolBox
{
    /// <summary>
    /// This class will print the messages on the console.
    /// </summary>
    public static class Print
    {
        public static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void PrintMessage(string message, Exception exception)
        {
            Console.WriteLine(message, exception);
        }

        public static void PrintMessage(string message, int number)
        {
            Console.WriteLine(message, number);
        }

        public static void PrintMessage(string message, string name)
        {
            Console.WriteLine(message, name);
        }

        public static void PrintMessage(string message, string name, string enemy)
        {
            Console.WriteLine(message, name, enemy);
        }

        public static void PrintMessage(string message, string name, int dmg, int health)
        {
            Console.WriteLine(message, name, dmg, health);
        }
    }
}

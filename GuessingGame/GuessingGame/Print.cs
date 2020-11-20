using System;

namespace GuessingGame
{
    public static class Print
    {
        public static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void WelcomeMessage()
        {
            PrintMessage(Messages.GeneratedNumber);
            PrintMessage(Messages.GameRules);
            PrintMessage(Messages.EndGameRule);
            PrintMessage(Messages.StartMessage);
        }
    }
}

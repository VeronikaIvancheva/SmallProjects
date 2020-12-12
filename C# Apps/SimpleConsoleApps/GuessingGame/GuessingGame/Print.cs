using System;

namespace GuessingGame
{
    /// <summary>
    /// A class that prints the messages to the console
    /// </summary>
    public static class Print
    {
        public static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// A bundle of Game rules messages: rules to won the game, to end it and a start prompt
        /// </summary>
        public static void GameRulesMessages()
        {
            PrintMessage(Messages.GameRules);
            PrintMessage(Messages.EndGameRule);
            PrintMessage(Messages.StartMessage);
        }
    }
}

using RPSGame.ConsoleOutput;
using System;

namespace RPSGame
{
    public static class Validations
    {
        /// <summary>
        /// Checking if the player is entered a valid letter and if not - loop till it is valid
        /// </summary>
        public static string CheckIfPlayerInputIsValid(string playerGuess)
        {
            while (playerGuess != "r" && playerGuess != "p" && playerGuess != "s")
            {
                Print.PrintMessage(Messages.NeedLetter);
                playerGuess = Console.ReadLine().ToLower();
            }

            return playerGuess;
        }

        /// <summary>
        /// Checking if the player is entered a valid number for the rounds that will be played and if not - loop till it is valid
        /// </summary>
        public static int CheckIfRoundsNumberIsValid(string num)
        {
            int number;

            while (!int.TryParse(num, out number))
            {
                Print.PrintMessage(Messages.EnterANumber);
                num = Console.ReadLine();
            }

            number = Convert.ToInt32(num);

            return number;
        }
    }
}

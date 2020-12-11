using System;
using TheShellGame.Message;

namespace TheShellGame.Validations
{
    public static class CheckInput
    {
        /// <summary>
        /// Checking if the player is entered a valid letter (to choose either the game to start again or no) 
        /// and if not - loop till it is valid
        /// </summary>
        public static string CheckIfPlayerInputIsValid(string playerInput)
        {
            while (playerInput != "y" && playerInput != "n")
            {
                PrintMessage.Message(Messages.NeedLetter);
                playerInput = Console.ReadLine().ToLower();
            }

            return playerInput;
        }

        /// <summary>
        /// Checking if the player is entered a valid number for the container and if not - loop till it is valid
        /// </summary>
        public static int CheckIfContainerNumberIsValid()
        {
            string num = Console.ReadLine();
            int number;

            while (!int.TryParse(num, out number) || (number != 1 && number != 2 && number != 3))
            {
                PrintMessage.Message(Messages.EnterANumber);
                num = Console.ReadLine();
            }

            number = Convert.ToInt32(num);

            return number;
        }
    }
}

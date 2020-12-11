using System;
using TheShellGame.Message;

namespace TheShellGame.Validations
{
    public static class CheckToStartAgainOrNot
    {
        /// <summary>
        /// Check if the player want to play again or no.
        /// </summary>
        public static bool StartAgainOrNot()
        {
            PrintMessage.Message(Messages.PlayAgain);

            string input = Console.ReadLine();
            string playerAnswer = CheckInput.CheckIfPlayerInputIsValid(input);

            if (playerAnswer.ToLower() == "y")
            {
                return true;
            }

            return false;
        }
    }
}

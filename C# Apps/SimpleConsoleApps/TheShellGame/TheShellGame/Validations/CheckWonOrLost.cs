using TheShellGame.Message;

namespace TheShellGame.Validations
{
    public static class CheckWonOrLost
    {
        /// <summary>
        /// Check if the game is won by the player or lost and print corresponding messages.
        /// </summary>
        public static void WonOrLost(int playerGuess, int containerNumber)
        {
            if (playerGuess == containerNumber)
            {
                PrintMessage.Message(Messages.ChoosedContainerFull, playerGuess);
                PrintMessage.Message(Messages.GameWon);
            }
            else
            {
                PrintMessage.Message(Messages.ChoosedContainerEmpty, playerGuess);
                PrintMessage.Message(Messages.GameLost);
            }
        }
    }
}

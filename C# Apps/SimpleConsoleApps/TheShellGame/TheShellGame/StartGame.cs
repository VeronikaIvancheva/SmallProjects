using System;
using TheShellGame.Message;
using TheShellGame.Validations;

namespace TheShellGame
{
    public static class StartGame
    {
        public static void Game()
        {
            try
            {
                PrintMessage.Message(Messages.Welcome);
                PrintMessage.Message(Messages.Intro);

            PlayAgain: PrintMessage.Message(Messages.GameRules);

                int containerNumber = GenerateRandomNumber.RandomNumber();

                PrintMessage.Message(Messages.Containers);
                PrintMessage.Message(Messages.EnterGuess);

                int playerGuess = CheckInput.CheckIfContainerNumberIsValid();

                CheckWonOrLost.WonOrLost(playerGuess, containerNumber);
                bool playAgain = CheckToStartAgainOrNot.StartAgainOrNot();

                if (playAgain)
                {
                    goto PlayAgain;
                }
            }
            catch (Exception e)
            {
                PrintMessage.Message(e);
            }
        }
    }
}

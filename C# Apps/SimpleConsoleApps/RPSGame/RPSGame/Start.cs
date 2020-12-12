using RPSGame.ConsoleOutput;
using System;

namespace RPSGame
{
    public static class Start
    {
        public static void StartGame()
        {
            try
            {
                int computerScore = 0;
                int playerScore = 0;

                Random random = new Random();

                MessagesGroups.StartMessages();

            startAgain:
                MessagesGroups.RoundsMessages();

                string num = Console.ReadLine();
                int number = Validations.CheckIfRoundsNumberIsValid(num);

                MessagesGroups.GameRules(number);
                GameLoop.Loop(playerScore, computerScore, number, random);

                string response = PlayAgain();

                if (response == "y")
                {
                    playerScore = 0;
                    computerScore = 0;

                    goto startAgain;
                }

                Print.PrintMessage(Messages.GoodByeMessage);
            }
            catch (Exception e)
            {
                Print.PrintMessage(e);
            }
            
        }

        /// <summary>
        /// Check if the player will continue to play or not.
        /// </summary>
        private static string PlayAgain()
        {
            Print.PrintMessage(Messages.AnotherGame);
            string response = Console.ReadLine().ToLower();

            while (response != "y" && response != "n")
            {
                Print.PrintMessage(Messages.PlayAgainWrongInput);
                response = Console.ReadLine().ToLower();
            }

            return response;
        }
    }
}

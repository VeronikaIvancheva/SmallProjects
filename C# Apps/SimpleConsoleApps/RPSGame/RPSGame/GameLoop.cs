using RPSGame.ConsoleOutput;
using System;

namespace RPSGame
{
    public static class GameLoop
    {
        public static void Loop(int playerScore, int computerScore, int number, Random random)
        {
            while (playerScore < number && computerScore < number)
            {
                string playerGuess = Console.ReadLine().ToLower();

                Validations.CheckIfPlayerInputIsValid(playerGuess);

                string computerGuess = ComputerChoise(random.Next(1, 3));

                Print.PrintMessage(Messages.ComputerChoise, computerGuess);

                if ((playerGuess == "r" && computerGuess == "s") || (playerGuess == "s" && computerGuess == "r"))
                {
                    if (playerGuess == "r")
                    {
                        playerScore += 1;
                    }
                    else if (computerGuess == "r")
                    {
                        computerScore += 1;
                    }
                }
                else if ((playerGuess == "s" && computerGuess == "p") || (playerGuess == "p" && computerGuess == "s"))
                {
                    if (playerGuess == "s")
                    {
                        playerScore += 1;
                    }
                    else if (computerGuess == "s")
                    {
                        computerScore += 1;
                    }
                }
                else if ((playerGuess == "p" && computerGuess == "r") || (playerGuess == "r" && computerGuess == "p"))
                {
                    if (playerGuess == "p")
                    {
                        playerScore += 1;
                    }
                    else if (computerGuess == "p")
                    {
                        computerScore += 1;
                    }
                }
                else
                {
                    Print.PrintMessage(Messages.Draw);
                }

                Print.PrintMessage(Messages.PlayerScore, playerScore);
                Print.PrintMessage(Messages.ComputerScore, computerScore);
            }

            if (playerScore > computerScore)
            {
                Print.PrintMessage(Messages.Won);
            }
            else
            {
                Print.PrintMessage(Messages.Lost);
            }
        }

        /// <summary>
        /// Convert random number into letter (R, P, S) representing the Rock, Paper or Scissors choise of the computer.
        /// </summary>
        private static string ComputerChoise(int number)
        {
            switch (number)
            {
                case 1:
                    return "r";
                case 2:
                    return "p";
                default:
                    return "s";
            }
        }
    }
}

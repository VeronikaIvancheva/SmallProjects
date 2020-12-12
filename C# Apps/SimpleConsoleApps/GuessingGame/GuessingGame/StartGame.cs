using System;

namespace GuessingGame
{
    public static class StartGame
    {
        public static void MainLogic()
        {
            Print.PrintMessage(Messages.Welcome);

            startAgain: int generatedRandomNumber = RandomNumber.GetRandomNumber();

            Print.PrintMessage(Messages.GeneratedNumber);
            Print.GameRulesMessages();

            int userGuess = 0;

            userGuess = GameLoop(generatedRandomNumber, userGuess);

            if (userGuess == generatedRandomNumber)
            {
                Print.PrintMessage(Messages.Won);
                goto startAgain;
            }
        }

        private static int GameLoop(int generatedRandomNumber, int userGuess)
        {
            string input;

            while (generatedRandomNumber != userGuess)
            {
                input = Console.ReadLine();

                if (input == "exit")
                {
                    Print.PrintMessage(Messages.NextTime);
                    break;
                }

                try
                {
                    userGuess = Convert.ToInt32(input);

                    if (userGuess > generatedRandomNumber)
                    {
                        Print.PrintMessage(Messages.High);
                    }
                    else if (userGuess < generatedRandomNumber)
                    {
                        Print.PrintMessage(Messages.Low);
                    }
                }
                catch (Exception)
                {
                    Print.PrintMessage(Messages.NeedNumber);
                }
            }

            return userGuess;
        }
    }
}

using System;

namespace GuessingGame
{
    public static class StartGame
    {
        public static void MainLogic()
        {
            startAgain: int generatedRandomNumber = RandomNumber.GetRandomNumber();

            Print.WelcomeMessage();

            int userGuess = 0;
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

            if (userGuess == generatedRandomNumber)
            {
                Print.PrintMessage(Messages.Won);
                goto startAgain;
            }
        }
    }
}

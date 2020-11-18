using System;

namespace GuessingGame
{
    public static class StartGame
    {
        public static void MainLogic()
        {
            Console.WriteLine(Messages.GameRules);
            Console.WriteLine(Messages.StartMessage);

            int generatedRandomNumber = RandomNumber.GetRandomNumber();
            int userGuess = 0;
            string input;

            while (generatedRandomNumber != userGuess)
            {
                input = Console.ReadLine();

                if (input == "exit")
                {
                    Console.WriteLine(Messages.NextTime);
                    break;
                }

                userGuess = Convert.ToInt32(input);

                if (userGuess > generatedRandomNumber)
                {
                    Console.WriteLine(Messages.High);
                }
                else if (userGuess < generatedRandomNumber)
                {
                    Console.WriteLine(Messages.Low);
                }
            }

            if (userGuess == generatedRandomNumber)
            {
                Console.WriteLine(Messages.Won);
            }
        }
    }
}

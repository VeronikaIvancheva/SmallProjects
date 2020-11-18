using System;

namespace GuessingGame
{
    public static class RandomNumber
    {
        public static int GetRandomNumber()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 1000);

            return randomNumber;
        }
    }
}

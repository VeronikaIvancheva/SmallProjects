using System;

namespace GuessingGame
{
    /// <summary>
    /// A class that is responsible to generate random number
    /// </summary>
    public static class RandomNumber
    {
        /// <summary>
        /// Generate random number between 1 to 1000
        /// </summary>
        public static int GetRandomNumber()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 1000);

            return randomNumber;
        }
    }
}

using System;

namespace TheShellGame
{
    public class GenerateRandomNumber
    {
        /// <summary>
        /// Generate and return a random number between 1 to 3.
        /// </summary>
        public static int RandomNumber()
        {
            Random random = new Random();

            int containerNumber = random.Next(1, 3);

            return containerNumber;
        }
    }
}

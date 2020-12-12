
namespace RPSGame.ConsoleOutput
{
    /// <summary>
    /// This class represent combined messages for console print (like StartGame messages and est.)
    /// </summary>
    public static class MessagesGroups
    {
        public static void StartMessages()
        {
            Print.PrintMessage(Messages.Welcome);
            Print.PrintMessage(Messages.GameIntro);
        }

        /// <summary>
        /// This class prints messages which are connected with the number of the score that determine the max score
        /// </summary>
        public static void RoundsMessages()
        {
            Print.PrintMessage(Messages.ChooseTheMaxGameScore);
            Print.PrintMessage(Messages.EnterANumber);
        }

        /// <summary>
        /// This class prints the game rules messages to the console
        /// </summary>
        public static void GameRules(int number)
        {
            Print.PrintMessage(Messages.GameRules, number);
            Print.PrintMessage(Messages.InputRules);
        }
    }
}

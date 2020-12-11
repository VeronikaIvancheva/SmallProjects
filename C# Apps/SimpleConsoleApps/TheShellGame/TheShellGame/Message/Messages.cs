
namespace TheShellGame.Message
{
    /// <summary>
    /// A class that contains all game messages.
    /// </summary>
    public static class Messages
    {
        public const string Welcome = "Welcome!";
        public const string Intro = "This is a Shell game.";
        public const string GameRules = "The rules are simple: you need to guess under which container is the ball - 1, 2 or 3.";

        public const string EnterGuess = "Please, enter your guess...";

        public const string GameWon = "You WON!";
        public const string GameLost = "Better luck next time...";

        public const string PlayAgain = "Play again? Y/N";

        public const string NeedLetter = "You must enter Y for yes or N for no.";
        public const string EnterANumber = "Enter a number from 1 to 3...";

        #region Game containers for visualization (console printed)
        public const string Containers = @"
   ___________        ___________        ___________
   |         |        |         |        |         |
   |         |        |         |        |         |
   |    1    |        |    2    |        |    3    |
   |         |        |         |        |         |
___|         |___  ___|         |___  ___|         |___
=================  =================  =================
";

        //Container is printed correctly - need 2 more spaces because of the {} part
        public const string ChoosedContainerEmpty = @"

          ||
          ||===========|
          ||           |
          ||           |
          ||    {0}      |
          ||           |
          ||===========|
          ||
------------------------------------
";

        //Container is printed correctly - need 2 more spaces because of the {} part
        public const string ChoosedContainerFull = @"

          ||
          ||===========|
          ||           |
          ||           |
          ||    {0}      |
   __     ||           |
  /  \    ||===========|
  \__/    ||
------------------------------------
";
        #endregion
    }
}

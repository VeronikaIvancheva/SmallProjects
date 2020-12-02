
namespace RPSGame.ConsoleOutput
{
    public static class Messages
    {
        public const string Won = "You WON!";
        public const string Lost = "You lost.";
        public const string Draw = "Draw";

        public const string AnotherGame = "Another game? Y/N";
        public const string ComputerChoise = "Computer choise: {0}";

        public const string NeedLetter = "You must enter R for Rock, P for Paper or S for Scissors.";
        public const string PlayAgainWrongInput = "Please, enter valide answer. Choose Y for yes or N for no.";

        public const string GoodByeMessage = "Have a nice day!";

        public const string PlayerScore = "Your score: {0}";
        public const string ComputerScore = "Your opponent score: {0}";
        
        #region Start Messages
        public const string Welcome = "Welcome!";
        public const string GameIntro = "This is a Rock, Paper, Scissors game.";
        #endregion

        #region Number of rounds messages
        public const string ChooseTheMaxGameScore = "Please, choose till how much score you want to play.";
        public const string EnterANumber = "Enter a number...";
        #endregion

        #region Game rules
        public const string GameRules = "The game continue till someone make {0} points.";
        public const string InputRiles = " For Rock, please enter - R \n For Paper, please enter - P \n For Scissors, please enter - S";
        #endregion
    }
}

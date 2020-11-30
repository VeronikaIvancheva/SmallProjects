
namespace RPG.ToolBox
{
    /// <summary>
    /// This class holds all the messages that the player reserves in one form or another.
    /// </summary>
    public static class Messages
    {
        public const string NamePrompt = "Hello! Please, enter your name.";
        public const string Welcome = "Welcome, {0}!";
        public const string GameOver = "Game Over!";
        public const string YouWon = "CONGRATULATIONS! YOU WON!!!";
        public const string EnemyEncounter = "{0}, you have encounter {1}...";

        public const string WhatToDo = "What whould you like to do?";


        #region Action Options
        public const string ActionOptions1 = "1. Single Attack";
        public const string ActionOptions2 = "2. Three Strike Attack";
        public const string ActionOptions3 = "3. Defend";
        public const string ActionOptions4 = "4. Heal";
        #endregion

        #region Player Action Message
        public const string Action1 = "1. You choose to use a single attack!";
        public const string Action2 = "2. You choose to use a three strike attack!";
        public const string Action3 = "3. You choose to defend!";
        public const string Action4 = "4. You choose to heal!";
        public const string ActionOther = "That is not a valid action. Please, choose again.";
        #endregion

        #region When three strike attack
        public const string CannotUseThreeStrikeAttackNow = "You cannot use three strike attack again in the next {0} rounds.";
        public const string ThreeStrikeAttackAvailable = "Three strike attack is available.";
        #endregion

        #region When dead messages
        public const string NameDied = "{0} is dead!";
        #endregion

        #region When hit messages
        public const string GetHitByDamage = "{0} was hit for {1} damage. He now has {2} health left.";
        #endregion

        #region When healing
        public const string WasHealed = "{0} was healed with {1} health. He now has {2} health remaining.";
        public const string CannotHealNow = "You cannot heal again in the next {0} rounds.";
        public const string HealAvailable = "Heal is available.";
        #endregion

        #region When defending
        public const string DefendedSuccessfully = "{0} stopped the blow and was unharmed.";
        public const string CannotDefendNow = "You cannot defend again in the next {0} rounds.";
        public const string DefendAvailable = "Defend is available.";
        public const string IsDefending = "{0} is defending.";
        #endregion

        #region Error messages
        public const string GlobalException = "The setup didn't go as planned. I need to go and check where Mike went... " +
            "I think he needs to know that there is problem with: {0}";

        public const string GameLoopError = "Something went wrong with this fight, pal. " +
            "Sorry about that. But heyy - you are going to fight the next enemy in just a second. I will just go and check the: {0}";

        public const string PlayerMovesError = "Something went wrong in the player moves section. " +
            "May be the armor is still in the blacksmith area again? I will go to see if there is anything in the records " +
            "about that: {0} part.";

        public const string EnemyMovesError = "Something went wrong in the enemy moves section. " +
            "I really hope that he is not chewing another hero right now... Or maybe there is problem with that: {0} - again...";
        #endregion
    }
}

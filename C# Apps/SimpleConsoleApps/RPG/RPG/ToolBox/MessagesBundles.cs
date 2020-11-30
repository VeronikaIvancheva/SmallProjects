
namespace RPG.ToolBox
{
    /// <summary>
    /// This class contains the combined messages.
    /// </summary>
    public static class MessagesBundles
    {
        /// <summary>
        /// Used to ask the player what he is going to do after he encounter the enemy. (i.e. What to do... option 1, 2, 3...)
        /// </summary>
        public static void ActionPrompt()
        {
            Print.PrintMessage(Messages.WhatToDo);

            Print.PrintMessage(Messages.ActionOptions1);
            Print.PrintMessage(Messages.ActionOptions2);
            Print.PrintMessage(Messages.ActionOptions3);
            Print.PrintMessage(Messages.ActionOptions4);
        }
    }
}

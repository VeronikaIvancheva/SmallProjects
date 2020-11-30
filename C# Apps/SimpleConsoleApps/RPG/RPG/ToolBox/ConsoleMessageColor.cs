using System;

namespace RPG.ToolBox
{
    /// <summary>
    /// This class if for managing console messages text color
    /// </summary>
    public static class ConsoleMessageColor
    {
        public static void SetMessageColorEnemy()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        public static void SetMessageColorPlayer()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        /// <summary>
        /// Return the default color.
        /// </summary>
        public static void ResetMessageColor()
        {
            Console.ResetColor();
        }
    }
}

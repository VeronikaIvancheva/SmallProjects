using RPG.Entities;
using RPG.Moves;
using RPG.ToolBox;
using System;

namespace RPG
{
    public static class StartGame
    {
        /// <summary>
        /// The place where the game will start.
        /// </summary>
        public static void Run()
        {
            try
            {
                Random random = new Random();
                Player player = new Player();
                Enemy enemy = new Enemy("Bob");
                Tools tools = new Tools();

                Print.PrintMessage(Messages.NamePrompt);
                player.Name = Console.ReadLine();

                Print.PrintMessage(Messages.Welcome, player.Name);

                GameLoop(random, enemy, player, tools);

                if (!player.IsDead)
                {
                    Enemy boss = new Boss();
                    GameLoop(random, boss, player, tools);
                }

                if (!player.IsDead)
                {
                    Print.PrintMessage(Messages.YouWon);
                }
                else
                {
                    Print.PrintMessage(Messages.GameOver);
                }
            }
            catch (Exception e)
            {
                Print.PrintMessage(Messages.GlobalException, e);
            }
        }


        /// <summary>
        /// The main game loop thats allow the player to attack the enemy.
        /// </summary>
        /// <param name="random">Random number value that we are using for the player and enemy actions.</param>
        /// <param name="enemy">The current enemy.</param>
        /// <param name="player">The player that we are playing as.</param>
        /// <param name="tools">Player restriction area - counters for the hheal and three strike attack usages.</param>
        private static void GameLoop(Random random, Enemy enemy, Player player, Tools tools)
        {
            Print.PrintMessage(Messages.EnemyEncounter, player.Name, enemy.Name);

            try
            {
                while (!enemy.IsDead && !player.IsDead)
                {
                    PlayerMoves.PlayerAction(random, enemy, player, tools);
                    EnemyMoves.EnemyAction(random, enemy, player);

                    ConsoleMessageColor.ResetMessageColor();
                }
            }
            catch (Exception e)
            {
                Print.PrintMessage(Messages.GameLoopError, e);
            }
        }
    }
}

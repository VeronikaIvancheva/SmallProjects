using RPG.Entities;
using RPG.ToolBox;
using System;

namespace RPG.Moves
{
    public static class PlayerMoves
    {
        public static void PlayerAction(Random random, Enemy enemy, Player player, Tools tools)
        {
            try
            {
                //Set here so the "Cannot Use Now Message to be actual - if set down the message has 1 point difference
                DecreaseTheCounters(tools);

                #region Inform the player that heal, three strike attack or defence is ready
                CheckIfHealAvailable(tools, player);
                CheckIfThreeStrikeAttackAvailable(tools);
                CheckIfDefenceAvailable(tools);
                #endregion

                MessagesBundles.ActionPrompt();

                string playerAction = Console.ReadLine();

                ConsoleMessageColor.SetMessageColorPlayer();

                switch (playerAction)
                {
                    //Single attack
                    case "1":
                        Print.PrintMessage(Messages.Action1);
                        enemy.GetHit(random.Next(player.MinAttackPower, player.MaxAttackPower));

                        break;

                    //Three strike attack
                    case "2":
                        Print.PrintMessage(Messages.Action2);

                        if (tools.NextThreeStrikeAttackIn == 0)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                enemy.GetHit(random.Next(player.MinAttackPower, player.MaxAttackPower));

                                if (enemy.IsDead)
                                {
                                    break;
                                }
                            }

                            tools.NextThreeStrikeAttackIn = 6;
                            tools.ChangedNow = true;
                        }
                        else
                        {
                            Print.PrintMessage(Messages.CannotUseThreeStrikeAttackNow, tools.NextThreeStrikeAttackIn);
                        }

                        break;

                    //Defend
                    case "3":
                        Print.PrintMessage(Messages.Action3);


                        if (tools.NextDefenceIn == 0)
                        {
                            player.IsDefending = true;
                            tools.ChangedNow = true;

                            Print.PrintMessage(Messages.IsDefending, player.Name);

                            tools.NextDefenceIn = 2;
                        }
                        else
                        {
                            Print.PrintMessage(Messages.CannotDefendNow, tools.NextDefenceIn);
                        }

                        break;

                    //Heal
                    case "4":
                        Print.PrintMessage(Messages.Action4);

                        if (tools.NextHealIn == 0)
                        {
                            player.Heal(random.Next(player.MinHealAmount, player.MaxHealAmount));
                            tools.NextHealIn = 4;
                            tools.ChangedNow = true;
                        }
                        else
                        {
                            Print.PrintMessage(Messages.CannotHealNow, tools.NextHealIn);
                        }

                        break;

                    default:
                        Print.PrintMessage(Messages.ActionOther);
                        break;
                }

                //To set changeNow to false in - this round, after the three strike attack or heal was used.
                if (tools.ChangedNow == true)
                {
                    tools.ChangedNow = false;
                }
            }
            catch (Exception e)
            {
                Print.PrintMessage(Messages.PlayerMovesError, e);
            }
        }

        /// <summary>
        /// To check if heal is available
        /// </summary>
        /// <param name="tools">The place where the counters are</param>
        /// <param name="player">The place where the player max health is located</param>
        private static void CheckIfHealAvailable(Tools tools, Player player)
        {
            if (tools.NextHealIn == 0 && player.Health != player.StartingHealth)
            {
                Print.PrintMessage(Messages.HealAvailable);
            }
        }

        /// <summary>
        /// To check if three strike attack is available
        /// </summary>
        /// <param name="tools">The place where the counters are</param>
        private static void CheckIfThreeStrikeAttackAvailable(Tools tools)
        {
            if (tools.NextThreeStrikeAttackIn == 0)
            {
                Print.PrintMessage(Messages.ThreeStrikeAttackAvailable);
            }
        }

        /// <summary>
        /// To check if defence is available
        /// </summary>
        /// <param name="tools">The place where the counters are</param>
        private static void CheckIfDefenceAvailable(Tools tools)
        {
            if (tools.NextDefenceIn == 0)
            {
                Print.PrintMessage(Messages.DefendAvailable);
            }
        }

        /// <summary>
        /// Decreasing the counters of next heal, next three strike attack and next defend option
        /// </summary>
        /// <param name="tools">The place where the counters are</param>
        private static void DecreaseTheCounters(Tools tools)
        {
            if (tools.NextHealIn != 0 && tools.ChangedNow != true)
            {
                tools.NextHealIn--;
            }

            if (tools.NextThreeStrikeAttackIn != 0 && tools.ChangedNow != true)
            {
                tools.NextThreeStrikeAttackIn--;
            }

            if (tools.NextDefenceIn != 0 && tools.ChangedNow != true)
            {
                tools.NextDefenceIn--;
            }
        }
    }
}

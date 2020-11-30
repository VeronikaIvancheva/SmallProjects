using RPG.Entities;
using RPG.ToolBox;
using System;

namespace RPG.Moves
{
    public static class EnemyMoves
    {
        public static void EnemyAction(Random random, Enemy enemy, Player player)
        {
            try
            {
                if (!enemy.IsDead && !player.IsDead)
                {
                    int enemyAction = random.Next(1, 5);

                    ConsoleMessageColor.SetMessageColorEnemy();
                    switch (enemyAction)
                    {
                        //Defend
                        case 1:
                            enemy.IsDefending = true;
                            Print.PrintMessage(Messages.IsDefending, enemy.Name);

                            break;

                        //Heal
                        case 2:
                            enemy.Heal(random.Next(enemy.MinHealAmount, enemy.MaxHealAmount));
                            break;

                        default:
                            player.GetHit(random.Next(enemy.MinAttackPower, enemy.MaxAttackPower));
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Print.PrintMessage(Messages.EnemyMovesError, e);
            }
        }
    }
}

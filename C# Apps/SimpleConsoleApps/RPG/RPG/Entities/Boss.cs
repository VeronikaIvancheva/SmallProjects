
namespace RPG.Entities
{
    /// <summary>
    /// This class represents the boss enemy.
    /// </summary>
    public class Boss : Enemy
    {
        public Boss() : base ("The BOSS!")
        {
            StartingHealth = 150;
            Health = StartingHealth;

            MinAttackPower = 5;
            MaxAttackPower = 25;

            MinHealAmount = 3;
            MaxHealAmount = 13;
        }
    }
}

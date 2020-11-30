
namespace RPG.Entities
{
    /// <summary>
    /// This class represents the enemy.
    /// </summary>
    public class Enemy : Units
    {
        public Enemy(string name)
        {
            StartingHealth = 100;
            Health = StartingHealth;
            Name = name;

            MinAttackPower = 1;
            MaxAttackPower = 5;

            MinHealAmount = 3;
            MaxHealAmount = 9;
        }
    }
}

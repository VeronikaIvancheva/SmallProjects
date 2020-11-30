
namespace RPG.Entities
{
    /// <summary>
    /// This class represents the playable character.
    /// </summary>
    public class Player : Units
    {
        public Player()
        {
            StartingHealth = 100;
            Health = StartingHealth;

            MinAttackPower = 1;
            MaxAttackPower = 15;

            MinHealAmount = 3;
            MaxHealAmount = 15;
        }
    }
}

using RPG.ToolBox;

namespace RPG.Entities
{
    public class Units
    {
        public int StartingHealth { get; set; }
        public int Health { get; set; }

        public string Name { get; set; }
        public bool IsDead { get; set; }
        public bool IsDefending { get; set; }

        public int MaxAttackPower { get; set; }
        public int MinAttackPower { get; set; }

        public int MaxHealAmount { get; set; }
        public int MinHealAmount { get; set; }


        /// <summary>
        /// Used when the player or the enemy take damage.
        /// </summary>
        /// <param name="damage">The amount of damage that the player or the enemy takes.</param>
        public void GetHit(int damage)
        {
            if (IsDefending)
            {
                Print.PrintMessage(Messages.DefendedSuccessfully, Name);

                IsDefending = false;
            }
            else
            {
                Health -= damage;
                Print.PrintMessage(Messages.GetHitByDamage, Name, damage, Health);

                CheckIfDead(Health);
            }            
        }

        /// <summary>
        /// Check if the enemy/player is dead.
        /// </summary>
        private void CheckIfDead(int health)
        {
            if (health <= 0)
            {
                Dead();
            }
        }

        /// <summary>
        /// Tells the player who is dead - the player or the enemy.
        /// </summary>
        private void Dead()
        {
            Print.PrintMessage(Messages.NameDied, Name);

            IsDead = true;
        }

        /// <summary>
        /// Heals the player or the enemy.
        /// </summary>
        /// <param name="amountToHeal">How much the player or the enemy will heal</param>
        public void Heal(int amountToHeal)
        {
            Health += amountToHeal;

            if (Health > StartingHealth)
            {
                Health = StartingHealth;
            }

            Print.PrintMessage(Messages.WasHealed, Name, amountToHeal, Health);
        }
    }
}


namespace RPG.Entities
{
    public class Tools
    {
        public int NextHealIn { get; set; }
        public int NextThreeStrikeAttackIn { get; set; }
        public int NextDefenceIn { get; set; }
        public bool ChangedNow { get; set; }

        public Tools()
        {
            NextHealIn = 0;
            NextThreeStrikeAttackIn = 0;
            NextDefenceIn = 0;
            ChangedNow = false;
        }
    }
}

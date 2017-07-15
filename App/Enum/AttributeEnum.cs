namespace MognetPlugin.Enum
{
    public class AttributeEnum
    {
        public static readonly AttributeEnum StartTime = new AttributeEnum("Start Time");
        public static readonly AttributeEnum Duration = new AttributeEnum("Duration");
        public static readonly AttributeEnum MaxHitParty = new AttributeEnum("Max Hit (Party)");
        public static readonly AttributeEnum TotalHealing = new AttributeEnum("Total Healing");
        public static readonly AttributeEnum MapName = new AttributeEnum("Map Name");
        public static readonly AttributeEnum TargetName = new AttributeEnum("Target Name");
        public static readonly AttributeEnum PlayerJob = new AttributeEnum("Player Job");
        public static readonly AttributeEnum PlayerName = new AttributeEnum("Player Name");
        public static readonly AttributeEnum DPS = new AttributeEnum("DPS");
        public static readonly AttributeEnum DamagePerc = new AttributeEnum("Damage%");
        public static readonly AttributeEnum MaxHitIndividual = new AttributeEnum("Max Hit (Individual)");
        public static readonly AttributeEnum HPS = new AttributeEnum("HPS");
        public static readonly AttributeEnum HealingPerc = new AttributeEnum("Healing%");
        public static readonly AttributeEnum MaxHeal = new AttributeEnum("Max Heal");
        public static readonly AttributeEnum OverHealPerc = new AttributeEnum("Overheal%");
        public static readonly AttributeEnum Deaths = new AttributeEnum("Deaths");
        public static readonly AttributeEnum Crit = new AttributeEnum("Crit%");
        public static readonly AttributeEnum DirectHit = new AttributeEnum("Direct Hit%");
        public static readonly AttributeEnum DirectHitCrit = new AttributeEnum("Direct Hit Crit%");
        public static readonly AttributeEnum CritHealPerc = new AttributeEnum("Crit Heal%");

        public string Name { get; }

        public AttributeEnum(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
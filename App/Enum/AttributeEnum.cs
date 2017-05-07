using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVPostParse.Enum
{
    public class AttributeEnum
    {
        public static readonly AttributeEnum START_TIME = new AttributeEnum(0, "Start Time");
        public static readonly AttributeEnum DURATION = new AttributeEnum(1, "Duration");
        public static readonly AttributeEnum MAX_HIT_PARTY = new AttributeEnum(2, "Max Hit (Party)");
        public static readonly AttributeEnum TOTAL_HEALING = new AttributeEnum(3, "Total Healing");
        public static readonly AttributeEnum MAP_NAME = new AttributeEnum(4, "Map Name");
        public static readonly AttributeEnum BOSS_NAME = new AttributeEnum(5, "Boss Name");
        public static readonly AttributeEnum PLAYER_JOB = new AttributeEnum(6, "Player Job");
        public static readonly AttributeEnum PLAYER_NAME = new AttributeEnum(7, "Player Name");
        public static readonly AttributeEnum DPS = new AttributeEnum(8, "DPS");
        public static readonly AttributeEnum DAMAGE_PERCENTAGE = new AttributeEnum(9, "Damage Percentage");
        public static readonly AttributeEnum MAX_HIT_INDIVIDUAL = new AttributeEnum(10, "Max Hit (Individual Player)");
        public static readonly AttributeEnum HPS = new AttributeEnum(11, "HPS");
        public static readonly AttributeEnum HEALING_PERCENTAGE = new AttributeEnum(12, "Healing Percentage");
        public static readonly AttributeEnum MAX_HEAL = new AttributeEnum(13, "Max Heal");
        public static readonly AttributeEnum OVERHEAL_PERCENTAGE = new AttributeEnum(14, "Overheal Percentage");
        public static readonly AttributeEnum DEATHS = new AttributeEnum(15, "Deaths");
        public static readonly AttributeEnum CRITS = new AttributeEnum(16, "Crits");
        public static readonly AttributeEnum MISSES = new AttributeEnum(17, "Misses");

        public static IEnumerable<AttributeEnum> Values
        {
            get
            {
                yield return START_TIME;
                yield return DURATION;
                yield return MAX_HIT_PARTY;
                yield return TOTAL_HEALING;
                yield return MAP_NAME;
                yield return BOSS_NAME;
                yield return PLAYER_JOB;
                yield return PLAYER_NAME;
                yield return DPS;
                yield return DAMAGE_PERCENTAGE;
                yield return MAX_HIT_INDIVIDUAL;
                yield return HPS;
                yield return HEALING_PERCENTAGE;
                yield return MAX_HEAL;
                yield return OVERHEAL_PERCENTAGE;
                yield return DEATHS;
                yield return CRITS;
                yield return MISSES;
            }
        }

        private readonly int index;
        private readonly String name;

        AttributeEnum(int index, String name)
        {
            this.index = index;
            this.name = name;
        }

        public int Index { get { return this.index; } }

        public String Name { get { return this.name; } }

        public static AttributeEnum GetAttributeByIndex(int index)
        {
            foreach (AttributeEnum a in AttributeEnum.Values)
            {
                if (a.Index == index)
                {
                    return a;
                }
            }

            return null;
        }

        public override string ToString()
        {
            return this.name;
        }

        public override bool Equals(object obj)
        {
            var item = obj as AttributeEnum;

            if (item == null)
            {
                return false;
            }

            return this.index.Equals(item.index);
        }

        public override int GetHashCode() { 
            return this.index.GetHashCode();
        }
    }

}
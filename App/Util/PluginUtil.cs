using Advanced_Combat_Tracker;
using FFXIVPostParse.Enum;
using FFXIVPostParse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVPostParse.Util
{
    class PluginUtil
    {
        public static Log ACTEncounterToModel(EncounterData encounter, List<AttributeEnum> attributes, String playerName)
        {
            Log Log = new Log();
            Log.startTime = ValidateAndFill(attributes, AttributeEnum.START_TIME, encounter.StartTime.TimeOfDay.ToString());
            Log.duration = ValidateAndFill(attributes, AttributeEnum.DURATION, encounter.Duration.ToString());
            Log.maxHit = ValidateAndFill(attributes, AttributeEnum.MAX_HIT_PARTY, GetMaxHit(encounter, playerName));
            Log.totalHealing = ValidateAndFill(attributes, AttributeEnum.TOTAL_HEALING, encounter.Healed.ToString());
            Log.bossName = ValidateAndFill(attributes, AttributeEnum.TOTAL_HEALING, encounter.GetStrongestEnemy(null));
            Log.mapName = ValidateAndFill(attributes, AttributeEnum.MAP_NAME, encounter.ZoneName);
            encounter.GetAllies().ForEach(combatant =>
            {
                Player Player = new Player();
                Player.playerJob = ValidateAndFill(attributes, AttributeEnum.PLAYER_JOB, GetCustomColumnData(combatant, "Job"));
                Player.playerName = ValidateAndFill(attributes, AttributeEnum.PLAYER_NAME, GetCharName(combatant, playerName));
                Player.damagePercentage = ValidateAndFill(attributes, AttributeEnum.DAMAGE_PERCENTAGE, combatant.DamagePercent);
                Player.dps = ValidateAndFill(attributes, AttributeEnum.DPS, Math.Round(combatant.EncDPS).ToString());
                Player.maxHit = ValidateAndFill(attributes, AttributeEnum.MAX_HIT_INDIVIDUAL, combatant.GetMaxHit(true));
                Player.healingPercentage = ValidateAndFill(attributes, AttributeEnum.HEALING_PERCENTAGE, combatant.HealedPercent);
                Player.hps = ValidateAndFill(attributes, AttributeEnum.HPS, Math.Round(combatant.EncHPS).ToString());
                Player.maxHeal = ValidateAndFill(attributes, AttributeEnum.MAX_HEAL, combatant.GetMaxHeal(true, false));
                Player.overhealPercentage = ValidateAndFill(attributes, AttributeEnum.OVERHEAL_PERCENTAGE, GetCustomColumnData(combatant, "OverHealPct"));
                Player.deaths = ValidateAndFill(attributes, AttributeEnum.DEATHS, combatant.Deaths.ToString());
                Player.crits = ValidateAndFill(attributes, AttributeEnum.CRITS, combatant.CritHits.ToString());
                Player.misses = ValidateAndFill(attributes, AttributeEnum.MISSES, combatant.Misses.ToString());

                Log.players.Add(Player);
            });

            return Log;
        }

        private static String ValidateAndFill(List<AttributeEnum> attributes, AttributeEnum currentAttribute, String data)
        {
            if (attributes.Contains(currentAttribute)) {
                return data;
            }

            return "";
        }

        private static String GetCustomColumnData(CombatantData combatant, String column)
        {
            String data = combatant.GetColumnByName(column);
            if (data != null)
            {
                return data;
            }

            return "";
        }

        private static String GetCharName(CombatantData combatant, String playerName)
        {
            String charName = combatant.Name;
            if (charName.StartsWith("YOU"))
            {
                return charName.Replace("YOU", playerName);
            }
            return charName;
        }

        private static String GetMaxHit(EncounterData encounter, String playerName)
        {
            String maxHit = encounter.GetMaxHit(true);
            if (maxHit.StartsWith("YOU"))
            {
                return maxHit.Replace("YOU", playerName);
            }
            return maxHit;
        }
    }
}

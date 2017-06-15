using Advanced_Combat_Tracker;
using MognetPlugin.Enum;
using MognetPlugin.Model;
using MognetPlugin.Properties;
using System;
using System.Web.Script.Serialization;

namespace MognetPlugin.Util
{
    class PluginUtil
    {
        private static JavaScriptSerializer Serializer = new JavaScriptSerializer();


        public static string ToJson(object obj)
        {
            return Serializer.Serialize(obj);

        }

        public static T FromJson<T>(string json)
        {
            return Serializer.Deserialize<T>(json);
        }

        public static bool IsPluginEnabled()
        {
            bool enabled = PluginSettings.GetSetting<bool>("Enabled");
            string token = PluginSettings.GetSetting<string>("Token");
            return enabled && token != null;
        }

        public static Log ACTEncounterToModel(EncounterData encounter)
        {
            Log Log = new Log();
            Log.successLevel = SuccessLevelEnum.GetByCode(encounter.GetEncounterSuccessLevel()).Name;
            Log.startTime = encounter.StartTime.TimeOfDay.ToString();
            Log.duration = encounter.Duration.ToString();
            Log.maxHit = ValidateAndFill("MaxHitParty", encounter.GetMaxHit(false));
            Log.totalHealing = ValidateAndFill("TotalHealing", encounter.Healed.ToString());
            Log.targetName = encounter.GetStrongestEnemy(null);
            Log.mapName = ValidateAndFill("MapName", encounter.ZoneName);
            Log.sortBy = PluginSettings.GetSetting<string>("SortBy");
            encounter.GetAllies().ForEach(combatant =>
            {
                Player Player = new Player();
                if (!IsLimitBreak(combatant.Name))
                {
                    Player.playerJob = GetCustomColumnData(combatant, "Job");
                    Player.playerName = combatant.Name;
                    Player.damagePercentage = ValidateAndFill("DamagePerc", combatant.DamagePercent);
                    Player.dps = Math.Round(combatant.EncDPS).ToString();
                    Player.maxHit = ValidateAndFill("MaxHitIndividual", combatant.GetMaxHit(true));
                    Player.healingPercentage = ValidateAndFill("HealingPerc", combatant.HealedPercent);
                    Player.hps = ValidateAndFill("HPS", Math.Round(combatant.EncHPS).ToString());
                    Player.maxHeal = ValidateAndFill("MaxHeal", combatant.GetMaxHeal(true, false));
                    Player.overhealPercentage = ValidateAndFill("OverHealPerc", GetCustomColumnData(combatant, "OverHealPct"));
                    Player.deaths = ValidateAndFill("Deaths", combatant.Deaths.ToString());
                    Player.crits = ValidateAndFill("Crits", combatant.CritHits.ToString());
                    Player.critDmgPercentage = ValidateAndFill("CritDmgPerc", Math.Round(combatant.CritDamPerc).ToString());
                    Player.critHealPercentage = ValidateAndFill("CritHealPerc", Math.Round(combatant.CritHealPerc).ToString());
                    Player.misses = ValidateAndFill("Misses", combatant.Misses.ToString());
                }
                else
                {
                    Player.playerName = combatant.Name;
                    Player.maxHit = combatant.GetMaxHit(true);
                }
                

                Log.players.Add(Player);
            });

            return Log;
        }

        private static String ValidateAndFill(string setting, string data)
        {
            if (PluginSettings.GetSetting<bool>(setting)) {
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

        private static bool IsLimitBreak(string charName)
        {
            return "Limit Break".Equals(charName);
        }
    }
}

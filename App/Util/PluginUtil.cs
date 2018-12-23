using Advanced_Combat_Tracker;
using MognetPlugin.Enum;
using MognetPlugin.Model;
using MognetPlugin.Properties;
using System;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;

namespace MognetPlugin.Util
{
    internal class PluginUtil
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

                if (IsLimitBreak(combatant.Name))
                {
                    Player.playerName = combatant.Name;
                    Player.maxHit = combatant.GetMaxHit(true);

                    Log.players.Add(Player);
                }
                else if (!IsLimitBreak(combatant.Name) && GetCustomColumnData(combatant, "Job") != "")
                {
                    Player.playerJob = GetCustomColumnData(combatant, "Job").ToUpper();
                    Player.playerName = FormatName(combatant.Name);
                    Player.damagePercentage = ValidateAndFill("DamagePerc", combatant.DamagePercent);
                    Player.dps = Math.Round(combatant.EncDPS).ToString();
                    Player.maxHit = FormatSkill(ValidateAndFill("MaxHitIndividual", combatant.GetMaxHit(true)));
                    Player.healingPercentage = ValidateAndFill("HealingPerc", combatant.HealedPercent);
                    Player.hps = ValidateAndFill("HPS", Math.Round(combatant.EncHPS).ToString());
                    Player.maxHeal = FormatSkill(ValidateAndFill("MaxHeal", combatant.GetMaxHeal(true, false)));
                    Player.overhealPercentage = ValidateAndFill("OverHealPerc", GetCustomColumnData(combatant, "OverHealPct"));
                    Player.deaths = ValidateAndFill("Deaths", combatant.Deaths.ToString());
                    Player.crit = ValidateAndFill("Crit", Math.Round(combatant.CritDamPerc).ToString());
                    Player.dh = ValidateAndFill("DirectHit", GetCustomColumnData(combatant, "DirectHitPct"));
                    Player.dhCrit = ValidateAndFill("DirectHitCrit", GetCustomColumnData(combatant, "CritDirectHitPct"));
                    Player.critHealPercentage = ValidateAndFill("CritHealPerc", Math.Round(combatant.CritHealPerc).ToString());

                    Log.players.Add(Player);
                }
            });

            if (Log.players.Count == 0 || Log.duration == "00:00:00")
            {
                return null;
            }

            return Log;
        }

        private static String ValidateAndFill(string setting, string data)
        {
            if (PluginSettings.GetSetting<bool>(setting))
            {
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

        private static string FormatSkill(string skillHit)
        {
            if (skillHit != "")
            {
                string skill = MatchOne(skillHit, @".*(?=-.)").Replace(" ", "");
                string damage = MatchOne(skillHit, @"[^-]+$");

                if (skill.Length > 10)
                {
                    skill = skill.Substring(0, 10);
                }

                return skill + "-" + damage;
            }

            return "";
        }

        private static string FormatName(string name)
        {
            if (name.Length > 20)
            {
                return name.Substring(0, 20);
            }

            return name;
        }

        private static string MatchOne(string text, string regex)
        {
            Regex r = new Regex(regex, RegexOptions.IgnoreCase);
            Match m = r.Match(text);
            return m.Groups[0].ToString().Trim();
        }
    }
}
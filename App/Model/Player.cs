using System;

namespace MognetPlugin.Model
{
    class Player
    {
        public String playerJob { get; set; }
        public String playerName { get; set; }
        public String damagePercentage { get; set; }
        public String dps { get; set; }
        public String maxHit { get; set; }
        public String healingPercentage { get; set; }
        public String hps { get; set; }
        public String maxHeal { get; set; }
        public String overhealPercentage { get; set; }
        public String deaths { get; set; }
        public String crit { get; set; }
        public String dh { get; set; }
        public String dhCrit { get; set; }
        public String critHealPercentage { get; set; }

        public Player()
        {
            this.playerName = "";
            this.damagePercentage = "";
            this.dps = "";
            this.maxHit = "";
            this.healingPercentage = "";
            this.hps = "";
            this.maxHeal = "";
            this.overhealPercentage = "";
            this.deaths = "";
            this.crit = "";
            this.dh = "";
            this.dhCrit = "";
            this.critHealPercentage = "";
        }
    }
}

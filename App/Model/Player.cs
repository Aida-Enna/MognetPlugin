using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVPostParse.Model
{
    class Player
    {
        public String PlayerJob { get; set; }
        public String PlayerName { get; set; }
        public String DamagePercentage { get; set; }
        public String Dps { get; set; }
        public String HealingPercentage { get; set; }
        public String Hps { get; set; }
        public String Deaths { get; set; }
        public String Crits { get; set; }
        public String Misses { get; set; }
        public Boolean JobIconEnabled { get; set; }

        public Player()
        {
            this.PlayerJob = "";
            this.PlayerName = "";
            this.DamagePercentage = "";
            this.Dps = "";
            this.HealingPercentage = "";
            this.Hps = "";
            this.Deaths = "";
            this.Crits = "";
            this.Misses = "";
            this.JobIconEnabled = true;
        }
    }
}

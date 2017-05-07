using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVPostParse.Model
{
    class Log
    {
        public String startTime { get; set; }
        public String duration { get; set; }
        public String maxHit { get; set; }
        public String totalHealing { get; set; }
        public String bossName { get; set; }
        public String mapName { get; set; }
        public List<Player> players { get; set; }

        public Log()
        {
            this.startTime = "";
            this.duration = "";
            this.maxHit = "";
            this.totalHealing = "";
            this.bossName = "";
            this.mapName = "";
            this.players = new List<Player>();
        }
    }
}

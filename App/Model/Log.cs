using System;
using System.Collections.Generic;

namespace MognetPlugin.Model
{
    class Log
    {
        public String successLevel { get; set; }
        public String startTime { get; set; }
        public String duration { get; set; }
        public String maxHit { get; set; }
        public String totalHealing { get; set; }
        public String targetName { get; set; }
        public String mapName { get; set; }
        public String sortBy { get; set; }
        public List<Player> players { get; set; }

        public Log()
        {
            this.successLevel = "";
            this.startTime = "";
            this.duration = "";
            this.maxHit = "";
            this.totalHealing = "";
            this.targetName = "";
            this.mapName = "";
            this.sortBy = "";
            this.players = new List<Player>();
        }
    }
}

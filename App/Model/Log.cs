using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVPostParse.Model
{
    class Log
    {
        public String StartTime { get; set; }
        public String Duration { get; set; }
        public String TotalHps { get; set; }
        public String BossName { get; set; }
        public String MapName { get; set; }
        public Boolean IncludeHps { get; set; }
        public List<Player> Players { get; set; }

        public Log()
        {
            this.StartTime = "";
            this.Duration = "";
            this.TotalHps = "";
            this.BossName = "";
            this.MapName = "";
            this.IncludeHps = true;
            this.Players = new List<Player>();
        }
    }
}

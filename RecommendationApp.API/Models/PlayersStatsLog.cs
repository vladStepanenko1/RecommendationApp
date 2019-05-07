using System;
using System.Collections.Generic;

namespace RecommendationApp.API.Models
{
    public partial class PlayersStatsLog
    {
        public long UserId { get; set; }
        public int TotalKills { get; set; }
        public int TotalDeaths { get; set; }
        public int TotalKillsHeadshot { get; set; }
        public DateTime AtDay { get; set; }
    }
}

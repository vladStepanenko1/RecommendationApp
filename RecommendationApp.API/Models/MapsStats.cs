using System;
using System.Collections.Generic;

namespace RecommendationApp.API
{
    public partial class MapsStats
    {
        public long UserId { get; set; }
        public int? TotalRounds { get; set; }
        public int? TotalWins { get; set; }
        public string MapName { get; set; }
    }
}

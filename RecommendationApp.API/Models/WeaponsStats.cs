using System;
using System.Collections.Generic;

namespace RecommendationApp.API.Models
{
    public partial class WeaponsStats
    {
        public long UserId { get; set; }
        public string WeaponName { get; set; }
        public int? TotalKills { get; set; }
        public int? TotalHits { get; set; }
        public int? TotalShots { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace RecommendationApp.API.Models
{
    public partial class Profiles1
    {
        public long UserId { get; set; }
        public int? TotalKills { get; set; }
        public int? TotalDeaths { get; set; }
        public int? TotalTimePlayed { get; set; }
        public int? TotalKillsHeadshot { get; set; }
        public int? TotalShotsHit { get; set; }
        public int? TotalMvps { get; set; }
        public int? TotalWins { get; set; }
        public int? TotalRoundsPlayed { get; set; }
        public int? TotalShotsFired { get; set; }
        public short? RankId { get; set; }
        public short? GoalId { get; set; }
        public string About { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

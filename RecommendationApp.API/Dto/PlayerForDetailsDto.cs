using System.Collections.Generic;

namespace RecommendationApp.API.Dto
{
    public class PlayerForDetailsDto
    {
        public long Id { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }
        public float AverageRating { get; set; }
        public int TotalTimePlayed { get; set; }
        public int TotalWins { get; set; }
        public int TotalRoundsPlayed { get; set; }
        public int TotalKills { get; set; }
        public int TotalDeaths { get; set; }
        public ICollection<MapStatsForListDto> MapsStats { get; set; }
        public ICollection<WeaponStatsForListDto> WeaponsStats { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace RecommendationApp.API.Dto
{
    public class TeamForDetailsDto
    {
        public long ProfileId { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string Country { get; set; }
        public float Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<TeamBestMapsDto> BestMaps { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace RecommendationApp.API.Models
{
    public partial class TeamsData
    {
        public long ProfileId { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string Country { get; set; }
        public string SteamLink { get; set; }
        public string TwitchLink { get; set; }
        public string YoutubeLink { get; set; }
        public string FacebookLink { get; set; }
        public string VkLink { get; set; }
        public string TwitterLink { get; set; }
        public string WebsiteLink { get; set; }
        public short? GoalId { get; set; }
        public short? RegionId { get; set; }
        public long? OwnerId { get; set; }
        public float Rating { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

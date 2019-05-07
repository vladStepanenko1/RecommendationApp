using System;
using System.Collections.Generic;

namespace RecommendationApp.API.Models
{
    public partial class Reviews
    {
        public long Id { get; set; }
        public string Message { get; set; }
        public long ReviewerProfileId { get; set; }
        public int? Rate { get; set; }
        public int? Likes { get; set; }
        public long? ParentId { get; set; }
        public long ProfileId { get; set; }
        public DateTime AtTime { get; set; }
        public float? RateWeight { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace RecommendationApp.API.Models
{
    public partial class ProfilesRatings
    {
        public long ProfileId { get; set; }
        public float Rating { get; set; }
        public int NumRates { get; set; }
    }
}

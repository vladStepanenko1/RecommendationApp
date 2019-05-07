using System;
using System.Collections.Generic;

namespace RecommendationApp.API
{
    public partial class TeamsUsers
    {
        public long TeamProfileId { get; set; }
        public long UserProfileId { get; set; }
        public DateTime? AtTime { get; set; }
    }
}

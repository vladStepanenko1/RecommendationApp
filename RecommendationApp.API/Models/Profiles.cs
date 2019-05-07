using System;
using System.Collections.Generic;

namespace RecommendationApp.API.Models
{
    public partial class Profiles
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public long? TeamId { get; set; }
        public short? GameId { get; set; }
        public short? TypeId { get; set; }
        public DateTime? AtTime { get; set; }
    }
}

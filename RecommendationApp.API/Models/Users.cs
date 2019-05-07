using System;
using System.Collections.Generic;

namespace RecommendationApp.API.Models
{
    public partial class Users
    {
        public long Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Verified { get; set; }
        public DateTime? Birthday { get; set; }
        public bool? ReceiveEmails { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public int? CityId { get; set; }
        public string Status { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace RecommendationApp.API
{
    public partial class TeamBestMaps
    {
        public long ProfileId { get; set; }
        public short? Place { get; set; }
        public string MapName { get; set; }
    }
}

namespace RecommendationApp.API.Helpers
{
    public class TeamParams
    {
        private const int MaxPageSize = 25;
        private int pageSize = 10;
        public int PageNumber { get; set; } = 1;
        public int PageSize
        { 
            get
            {
                return pageSize;
            }
            set
            {
                pageSize = (value > MaxPageSize) ? MaxPageSize : value;
            }
        }
        public string Name { get; set; }
        public string Country { get; set; }
        public double MinRating { get; set; } = 1.0;
        public double MaxRating { get; set; } = 10.0;
    }
}
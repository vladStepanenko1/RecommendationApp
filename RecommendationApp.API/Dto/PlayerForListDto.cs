namespace RecommendationApp.API.Dto
{
    public class PlayerForListDto
    {
        public long Id { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public float AverageRating { get; set; }
    }
}
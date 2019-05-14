namespace RecommendationApp.API.RecommendationEngine
{
    public class Player
    {
        public long Id { get; set; }
        public double CalculatedRating { get; set; }
        public float AverageRating { get; set; }
    }
}
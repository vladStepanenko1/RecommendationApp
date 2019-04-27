namespace RecommendationApp.API.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string About { get; set; }
        public double Rating { get; set; }

        public Team(int id, string name, string country, string about, double rating)
        {
            Id = id;
            Name = name;
            Country = country;
            About = about;
            Rating = rating;
        }
    }
}
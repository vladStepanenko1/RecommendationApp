using System.Runtime.Serialization;

namespace RecommendationApp.API.RecommendationEngine
{
    public class RecommenderModel
    {
        [DataMember]
        public double AverageRating { get; set; }
        [DataMember]
        public double[] ReviewerBiases { get; set; }
        [DataMember]
        public double[] PlayerBiases { get; set; }
        [DataMember]
        public double[][] ReviewersFeatures { get; set; }
        [DataMember]
        public double[][] PlayersFeatures { get; set; }
    }
}
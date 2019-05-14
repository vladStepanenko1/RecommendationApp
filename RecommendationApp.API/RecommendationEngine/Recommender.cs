using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;

namespace RecommendationApp.API.RecommendationEngine
{
    public class Recommender
    {
        private double averageRating;
        private double[] reviewerBiases;
        private double[] playersBiases;
        private double[][] reviewersFeatures;
        private double[][] playersFeatures;

        public Recommender(string pathToModelFile)
        {
            if(string.IsNullOrEmpty(pathToModelFile))
            {
                throw new ArgumentNullException("Path to model file should not be emply or null");
            }

            LoadModel(pathToModelFile);
        }

        public double GetRating(int reviewerIndex, int playerIndex)
        {
            double ratingToPredict = averageRating + reviewerBiases[reviewerIndex] 
                + playersBiases[playerIndex] + GetDotProduct(playersFeatures[playerIndex], 
                reviewersFeatures[reviewerIndex]);

            return ratingToPredict;
        }

        private double GetDotProduct(double[] v1, double[] v2)
        {
            return v1.Zip(v2, (a, b) => a * b).Sum();
        }

        private void LoadModel(string filePath)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(RecommenderModel));
            RecommenderModel model;
            using(FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                model = (RecommenderModel)serializer.ReadObject(fs);
            }

            if (model != null)
            {
                averageRating = model.AverageRating;
                playersBiases = model.PlayerBiases;
                playersFeatures = model.PlayersFeatures;
                reviewerBiases = model.ReviewerBiases;
                reviewersFeatures = model.ReviewersFeatures;
            }
        }
    }
}
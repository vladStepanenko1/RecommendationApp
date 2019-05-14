using System.Collections.Generic;
using RecommendationApp.API.Helpers;
using RecommendationApp.API.Models;
using RecommendationApp.API.RecommendationEngine;

namespace RecommendationApp.API.Data
{
    public interface IPlayerRepository
    {
        PagedList<Users> GetPlayers(long teamId);
        Users GetPlayer(long id);
        float GetRating(long id);
        IEnumerable<Player> GetRecommendedPlayers(long teamId);
        Profiles1 GetPlayersStatistics(long id);
        IEnumerable<MapsStats> GetMapsStatistics(long id);
        IEnumerable<WeaponsStats> GetWeaponsStatistics(long id);
    }
}
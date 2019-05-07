using RecommendationApp.API.Helpers;
using RecommendationApp.API.Models;

namespace RecommendationApp.API.Data
{
    public interface IPlayerRepository
    {
        PagedList<Users> GetPlayers(long teamId);
        Users GetPlayer(long id);
        float GetRating(long id);
    }
}
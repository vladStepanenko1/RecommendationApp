using System.Collections.Generic;
using RecommendationApp.API.Helpers;
using RecommendationApp.API.Models;

namespace RecommendationApp.API.Data
{
    public interface ITeamRepository
    {
        PagedList<TeamsData> GetTeams(TeamParams teamParams);
        TeamsData GetTeam(int id);
        IEnumerable<string> GetCountries();
    }
}
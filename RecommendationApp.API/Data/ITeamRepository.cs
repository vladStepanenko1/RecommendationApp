using System.Collections.Generic;
using RecommendationApp.API.Helpers;
using RecommendationApp.API.Models;

namespace RecommendationApp.API.Data
{
    public interface ITeamRepository
    {
        PagedList<Team> GetTeams(TeamParams teamParams);
        Team GetTeam(int id);
    }
}
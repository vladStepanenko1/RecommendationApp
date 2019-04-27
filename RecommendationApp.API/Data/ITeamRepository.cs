using System.Collections.Generic;
using RecommendationApp.API.Models;

namespace RecommendationApp.API.Data
{
    public interface ITeamRepository
    {
        IEnumerable<Team> GetTeams();
        Team GetTeam(int id);
    }
}
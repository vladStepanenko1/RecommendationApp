using System.Collections.Generic;

namespace RecommendationApp.API.Data
{
    public interface ITeamRepository
    {
        IEnumerable<Team> GetTeams();
        Team GetTeam(int id);
    }
}
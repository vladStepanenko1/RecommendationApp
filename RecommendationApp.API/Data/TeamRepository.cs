using System.Collections.Generic;
using System.Linq;
using RecommendationApp.API.Helpers;
using RecommendationApp.API.Models;

namespace RecommendationApp.API.Data
{
    public class TeamRepository : ITeamRepository
    {
        private DreamTeamContext _context;

        public TeamRepository(DreamTeamContext context)
        {
            _context = context;
        }

        public TeamsData GetTeam(int id)
        {
            var team = _context.TeamsData.Find((long)id);
            return team;
        }

        public PagedList<TeamsData> GetTeams(TeamParams teamParams)
        {
            var teamOwners = _context.TeamsData.Where(t => t.OwnerId.HasValue)
                .Select(t => t.OwnerId.GetValueOrDefault());
            var reviewers = _context.Reviews.Where(r => r.Rate.HasValue && r.ReviewerProfileId != r.ProfileId)
                .Select(r => r.ReviewerProfileId);
            var reviewersTeamOwners = reviewers.Intersect(teamOwners);

            var teams = _context.TeamsData.Where(t => reviewers.Contains(t.OwnerId.GetValueOrDefault()))
                .AsQueryable();

            if(!string.IsNullOrEmpty(teamParams.Name))
            {
                teams = teams.Where(t => t.Name.ToLower().Contains(teamParams.Name.ToLower()));
            }

            if(!string.IsNullOrEmpty(teamParams.Country))
            {
                teams = teams.Where(t => t.Country == teamParams.Country);
            }

            teams = teams.Where(t => t.Rating >= teamParams.MinRating && t.Rating <= teamParams.MaxRating);

            return PagedList<TeamsData>.Create(teams, teamParams.PageNumber, teamParams.PageSize);
        }

        public IEnumerable<string> GetCountries()
        {
            var countries = _context.TeamsData
                .Select(t => t.Country)
                .Where(c => !string.IsNullOrEmpty(c))
                .Distinct();

            return countries;
        }

        public IEnumerable<TeamBestMaps> GetBestMaps(long id)
        {
            var bestMaps = _context.TeamBestMaps.Where(bm => bm.ProfileId == id);
            return bestMaps;
        }
    }
}
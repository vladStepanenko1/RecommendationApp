using System;
using System.Collections.Generic;
using System.Linq;
using RecommendationApp.API.Helpers;
using RecommendationApp.API.Models;

namespace RecommendationApp.API.Data
{
    public class PlayerRepository : IPlayerRepository
    {
        private DreamTeamContext _context;

        public PlayerRepository(DreamTeamContext context)
        {
            _context = context;
        }

        public Users GetPlayer(long id)
        {
            return _context.Users.Find(id);
        }

        public PagedList<Users> GetPlayers(long teamId)
        {
            var temp = _context.TeamsUsers
                .Where(tu => tu.TeamProfileId == teamId)
                .Select(tu => tu.UserProfileId);

            var players = _context.Users.Where(u => temp.Contains(u.Id));

            return PagedList<Users>.Create(players, 1, 7);
        }

        public float GetRating(long id)
        {
            var rating = _context.ProfilesRatings
                .Where(pr => pr.ProfileId == id)
                .Select(pr => pr.Rating)
                .Average();
            
            return rating;
        }

        public IEnumerable<Users> GetRecommendedPlayers(long teamId)
        {
            throw new NotImplementedException();
        }
    }
}
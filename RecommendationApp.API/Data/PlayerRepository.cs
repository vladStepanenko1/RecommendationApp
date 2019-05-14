using System;
using System.Collections.Generic;
using System.Linq;
using RecommendationApp.API.Helpers;
using RecommendationApp.API.Models;
using RecommendationApp.API.RecommendationEngine;

namespace RecommendationApp.API.Data
{
    public class PlayerRepository : IPlayerRepository
    {
        private DreamTeamContext _context;

        public PlayerRepository(DreamTeamContext context)
        {
            _context = context;
        }

        public IEnumerable<MapsStats> GetMapsStatistics(long id)
        {
            return _context.MapsStats.Where(ms => ms.UserId == id)
                .Where(ms => ms.TotalWins.HasValue && ms.TotalRounds.HasValue);
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

        public Profiles1 GetPlayersStatistics(long id)
        {
            return _context.Profiles1.SingleOrDefault(p => p.UserId == id);
        }

        public float GetRating(long id)
        {
            var rating = _context.ProfilesRatings
                .Where(pr => pr.ProfileId == id)
                .Select(pr => pr.Rating)
                .Average();
            
            return rating;
        }

        public IEnumerable<Player> GetRecommendedPlayers(long teamId)
        {
            var teamOwnerId = _context.TeamsData.Where(t => t.ProfileId == teamId).Select(t => t.OwnerId)
                .Single();

            if(!teamOwnerId.HasValue)
            {
                throw new Exception($"There is no team owner for team with teamId = {teamId}");
            }
            
            var teamOwners = _context.TeamsData.Where(t => t.OwnerId.HasValue)
                .Select(t => t.OwnerId.GetValueOrDefault());
             var reviewers = _context.Reviews.Where(r => r.Rate.HasValue && r.ReviewerProfileId != r.ProfileId)
                    .Select(r => r.ReviewerProfileId);
            var reviewersTeamOwners = reviewers.Intersect(teamOwners);
            var teamPlayers = _context.TeamsUsers.Select(tu => tu.UserProfileId);
            var players = _context.Reviews.Where(r => teamOwners.Contains(r.ProfileId) == false)
                .Select(r => r.ProfileId);
            players = players.Where(p => teamPlayers.Contains(p) == false);

            var reviewerIndexToId = reviewersTeamOwners.OrderBy(r => r).Distinct().ToList();
            var playerIndexToId = players.OrderBy(p => p).Distinct().ToList();

            var modelFilePath = "model.json";
            Recommender recommender = new Recommender(modelFilePath);
            
            long playerId;
            double calculatedRating;
            int teamOwnerIndex = reviewerIndexToId.IndexOf(teamOwnerId.Value);
            var playerWithCalculatedRatings = new List<Player>();
            for(int i = 0; i < playerIndexToId.Count; i++)
            {
                playerId = playerIndexToId[i];
                calculatedRating = recommender.GetRating(teamOwnerIndex, i);
                playerWithCalculatedRatings.Add(new Player{Id=playerId, CalculatedRating=calculatedRating});
            }

            playerWithCalculatedRatings.OrderByDescending(p => p.CalculatedRating);
            
            foreach(var player in playerWithCalculatedRatings)
            {
                var profiles = _context.ProfilesRatings.Where(p => p.ProfileId == player.Id);
                if(profiles.Count() > 0)
                {
                    var ratings = profiles.Select(p => p.Rating);
                    player.AverageRating = ratings.Average();
                }
            }

            playerWithCalculatedRatings = playerWithCalculatedRatings.Where(p => p.AverageRating > 0).ToList();

            return playerWithCalculatedRatings;
        }

        public IEnumerable<WeaponsStats> GetWeaponsStatistics(long id)
        {
            return _context.WeaponsStats.Where(ws => ws.UserId == id)
                .Where(ws => ws.TotalShots.HasValue && ws.TotalHits.HasValue);
        }
    }
}
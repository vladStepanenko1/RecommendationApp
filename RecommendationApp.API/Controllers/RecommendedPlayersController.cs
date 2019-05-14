using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecommendationApp.API.Data;
using RecommendationApp.API.Dto;
using RecommendationApp.API.Helpers;

namespace RecommendationApp.API.Controllers
{
    [ApiController]
    [Route("api/teams/{teamId}/[controller]")]
    public class RecommendedPlayersController : ControllerBase
    {
        private IPlayerRepository _playerRepository;
        private ITeamRepository _teamRepository;
        private IMapper _mapper;

        public RecommendedPlayersController(IPlayerRepository playerRepository, ITeamRepository teamRepository,
         IMapper mapper)
        {
            _playerRepository = playerRepository;
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(int teamId)
        {
            var team = _teamRepository.GetTeam(teamId);

            if(team == null)
            {
                return BadRequest("Team not found");
            }

            var players = _playerRepository.GetRecommendedPlayers(teamId);
            var playersToReturn = _mapper.Map<IEnumerable<PlayerForListDto>>(players);

            foreach(var playerDto in playersToReturn)
            {
                var profile = _playerRepository.GetPlayer(playerDto.Id);
                if(profile != null)
                {
                    playerDto.Gender = profile.Gender;
                    playerDto.Country = profile.Country;
                }
            }

            float sumRatingOverTeam = 0;
            var playersOfTeam = _playerRepository.GetPlayers(teamId);
            foreach(var player in playersOfTeam)
            {
                var rating = _playerRepository.GetRating(player.Id);
                sumRatingOverTeam += rating;
            }
            var averageRatingOverTeam = sumRatingOverTeam / playersOfTeam.Count;

            //playersToReturn = playersToReturn.Where(p => p.Country == team.Country);
            playersToReturn = playersToReturn.Where(p => p.AverageRating > averageRatingOverTeam - 1);
            playersToReturn = playersToReturn.Where(p => p.AverageRating < averageRatingOverTeam + 1);
            playersToReturn = playersToReturn.Take(7);

            return Ok(playersToReturn);
        }
    }
}
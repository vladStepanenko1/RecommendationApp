using System.Collections.Generic;
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
        private IMapper _mapper;

        public RecommendedPlayersController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        [HttpGet]
        public IActionResult Get(int teamId)
        {
            var players = _playerRepository.GetRecommendedPlayers(teamId);
            var playersToReturn = _mapper.Map<IEnumerable<PlayerForListDto>>(players);

            return Ok(playersToReturn);
        }
    }
}
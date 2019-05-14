using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecommendationApp.API.Data;
using RecommendationApp.API.Dto;

namespace RecommendationApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController : ControllerBase
    {
        private IPlayerRepository _playerRepository;
        private IMapper _mapper;

        public PlayersController(IPlayerRepository playerRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var player = _playerRepository.GetPlayer(id);
            if (player == null)
            {
                return BadRequest("Player not found");
            }

            var playerToReturn = _mapper.Map<PlayerForDetailsDto>(player);
            var stats = _playerRepository.GetPlayersStatistics(player.Id);
            var mapsStats = _playerRepository.GetMapsStatistics(player.Id);
            var weaponsStats = _playerRepository.GetWeaponsStatistics(player.Id);

            playerToReturn.AverageRating = _playerRepository.GetRating(player.Id);

            int yearsOld = 0;
            if (player.Birthday.HasValue)
            {
                yearsOld = DateTime.Now.AddYears(-player.Birthday.Value.Year).Year;
                playerToReturn.Age = yearsOld;
            }

            if (stats != null)
            {
                playerToReturn.TotalTimePlayed = stats.TotalTimePlayed.GetValueOrDefault();
                playerToReturn.TotalWins = stats.TotalWins.GetValueOrDefault();
                playerToReturn.TotalRoundsPlayed = stats.TotalRoundsPlayed.GetValueOrDefault();
                playerToReturn.TotalKills = stats.TotalKills.GetValueOrDefault();
                playerToReturn.TotalDeaths = stats.TotalDeaths.GetValueOrDefault();
            }

            if (mapsStats.Count() > 0)
            {
                var mapsStatsToReturn = _mapper.Map<IEnumerable<MapStatsForListDto>>(mapsStats);
                playerToReturn.MapsStats = mapsStatsToReturn.ToList();
            }

            if (weaponsStats.Count() > 0)
            {
                var weaponsStatsToReturn = _mapper.Map<IEnumerable<WeaponStatsForListDto>>(weaponsStats);
                playerToReturn.WeaponsStats = weaponsStatsToReturn.ToList();
            }

            return Ok(playerToReturn);
        }
    }
}
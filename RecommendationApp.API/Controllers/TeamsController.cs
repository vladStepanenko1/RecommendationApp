using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecommendationApp.API.Data;
using RecommendationApp.API.Dto;
using RecommendationApp.API.Helpers;
using RecommendationApp.API.Models;

namespace RecommendationApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController:ControllerBase
    {
        private ITeamRepository _teamRepository;
        private IMapper _mapper;

        public TeamsController(ITeamRepository teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get([FromQuery]TeamParams teamParams)
        {
            var teams = _teamRepository.GetTeams(teamParams);
            var teamsToReturn = _mapper.Map<IEnumerable<TeamForListDto>>(teams);
            Response.AddPagination(teams.CurrentPage, teams.PageSize, teams.TotalCount, teams.TotalPages);
            return Ok(teamsToReturn);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var team = _teamRepository.GetTeam(id);

            if(team == null)
            {
                return BadRequest("Team not found");
            }

            var teamToReturn = _mapper.Map<TeamForDetailsDto>(team);
            var bestMaps = _teamRepository.GetBestMaps(team.ProfileId);
            var bestMapsToReturn = _mapper.Map<IEnumerable<TeamBestMapsDto>>(bestMaps);
            teamToReturn.BestMaps = bestMapsToReturn.ToList();
            return Ok(teamToReturn);
        }
    }
}
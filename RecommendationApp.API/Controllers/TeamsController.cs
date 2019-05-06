using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RecommendationApp.API.Data;
using RecommendationApp.API.Helpers;
using RecommendationApp.API.Models;

namespace RecommendationApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController:ControllerBase
    {
        private ITeamRepository _teamRepository;

        public TeamsController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        [HttpGet]
        public IActionResult Get([FromQuery]TeamParams teamParams)
        {
            var teams = _teamRepository.GetTeams(teamParams);
            Response.AddPagination(teams.CurrentPage, teams.PageSize, teams.TotalCount, teams.TotalPages);
            return Ok(teams);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var team = _teamRepository.GetTeam(id);

            if(team == null)
            {
                return BadRequest("Team not found");
            }

            return Ok(team);
        }
    }
}
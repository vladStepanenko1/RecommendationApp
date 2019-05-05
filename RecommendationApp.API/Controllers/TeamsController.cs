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
        public IActionResult Get([FromQuery]UserParams userParams)
        {
            var teams = _teamRepository.GetTeams(userParams);
            Response.AddPagination(teams.CurrentPage, teams.PageSize, teams.TotalCount, 
                teams.TotalPages);
            return Ok(teams);
        }
    }
}
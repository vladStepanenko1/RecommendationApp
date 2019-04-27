using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RecommendationApp.API.Data;
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
        public ActionResult<IEnumerable<Team>> Get()
        {
            return _teamRepository.GetTeams().ToList();
        }
    }
}
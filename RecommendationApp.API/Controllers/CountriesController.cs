using System;
using Microsoft.AspNetCore.Mvc;
using RecommendationApp.API.Data;

namespace RecommendationApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController:ControllerBase
    {
        private ITeamRepository _teamRepository;

        public CountriesController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var countries = _teamRepository.GetCountries();
            return Ok(countries);
        }
    }
}
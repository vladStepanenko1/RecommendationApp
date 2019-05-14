using AutoMapper;
using RecommendationApp.API.Dto;
using RecommendationApp.API.Models;
using RecommendationApp.API.RecommendationEngine;

namespace RecommendationApp.API.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<TeamsData, TeamForListDto>();
            CreateMap<TeamsData, TeamForDetailsDto>();
            CreateMap<TeamBestMaps, TeamBestMapsDto>();
            CreateMap<Users, PlayerForListDto>();
            CreateMap<Users, PlayerForDetailsDto>();
            CreateMap<Player, PlayerForListDto>();
        }
    }
}
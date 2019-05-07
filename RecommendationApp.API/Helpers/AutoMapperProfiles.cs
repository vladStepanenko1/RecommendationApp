using AutoMapper;
using RecommendationApp.API.Dto;
using RecommendationApp.API.Models;

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
        }
    }
}
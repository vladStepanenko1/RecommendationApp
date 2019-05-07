using AutoMapper;
using RecommendationApp.API.Dto;

namespace RecommendationApp.API.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<TeamsData, TeamForListDto>();
            CreateMap<TeamsData, TeamForDetailsDto>();
            CreateMap<TeamBestMaps, TeamBestMapsDto>();
        }
    }
}
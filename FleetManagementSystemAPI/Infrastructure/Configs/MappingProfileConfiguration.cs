using AutoMapper;
using FleetManagementAPI.Data.Entity;
using FleetManagementAPI.DTO;
using FleetManagementAPI.DTO.Response;
using FleetManagementAPI.DTO.Request;

namespace FleetManagementAPI.Infrastructure.Configs
{
    public class MappingProfileConfiguration : Profile
    {
        public MappingProfileConfiguration()
        {
            CreateMap<Fleet, CreateFleetRequest>().ReverseMap();
            CreateMap<Fleet, UpdateFleetRequest>().ReverseMap();
            CreateMap<Fleet, FleetQueryResponse>().ReverseMap();

        }
    }
}

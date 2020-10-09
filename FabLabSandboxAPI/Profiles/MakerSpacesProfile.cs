using AutoMapper;
using FabLabSandboxAPI.Models;
using FabLabSandboxAPI.Dtos;

namespace FabLabSandboxAPI.Profiles
{
    public class MakerSpacesProfile : Profile{
        public MakerSpacesProfile()
        {
            CreateMap<MakerSpace, MakerSpaceReadDto>();
        }
    }
}
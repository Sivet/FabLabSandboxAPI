using AutoMapper;
using FabLabSandboxAPI.Models;
using FabLabSandboxAPI.Dtos;

namespace FabLabSandboxAPI.Profiles
{
    public class MakerSpacesProfile : Profile{
        public MakerSpacesProfile()
        {
            //Source -> Target
            CreateMap<MakerSpace, MakerSpaceReadDto>();

            //Target -> Source
            CreateMap<MakerSpaceCreateDto, MakerSpace>();
        }
    }
}
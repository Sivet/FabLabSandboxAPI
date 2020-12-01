using AutoMapper;
using FabLabSandboxAPI.Models;
using FabLabSandboxAPI.Dtos;
using FabLabSandboxAPI.Dtos.MachineDto;

namespace FabLabSandboxAPI.Profiles
{
    public class MakerSpacesProfile : Profile{
        public MakerSpacesProfile()
        {
            //Source -> Target
            CreateMap<MakerSpace, MakerSpaceReadDto>();
            CreateMap<Machine, MachineReadDto>();
            CreateMap<MakerSpace, MakerSpaceUpdateDto>();
            CreateMap<MakerSpace, MakerSpaceIdReadDto>();

            //Target -> Source
            CreateMap<MakerSpaceCreateDto, MakerSpace>();
            CreateMap<MakerSpaceUpdateDto, MakerSpace>();
            CreateMap<MachineCreateDto, Machine>();

        }
    }
}
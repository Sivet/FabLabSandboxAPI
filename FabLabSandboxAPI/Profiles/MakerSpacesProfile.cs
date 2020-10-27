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

            //Target -> Source
            CreateMap<MakerSpaceCreateDto, MakerSpace>();

            CreateMap<MakerSpaceUpdateDto, MakerSpace>();
            CreateMap<MakerSpace, MakerSpaceUpdateDto>();
<<<<<<< HEAD
            CreateMap<MakerSpace, MakerSpaceIdReadDto>();

            CreateMap<Machine,MachineReadDto>();
            CreateMap<MachineCreateDto,Machine>();


=======
>>>>>>> MachineController
        }
    }
}
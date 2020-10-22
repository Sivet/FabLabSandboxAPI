using AutoMapper;
using FabLabSandboxAPI.Models;
using FabLabSandboxAPI.Dtos.MachineDto;

namespace FabLabSandboxAPI.Profiles
{
    public class MachineProfile : Profile
    {
        public MachineProfile()
        {
            //Source -> Target
            CreateMap<Machine, MachineReadDto>();
            //Target -> Source
            CreateMap<MachineCreateDto, Machine>();
        }
    }
}
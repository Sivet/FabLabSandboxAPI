using FabLabSandboxAPI.Data;
using FabLabSandboxAPI.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabLabSandboxAPI.Services
{
    public interface IMakerSpaceService
    {
        IEnumerable<MakerSpaceReadDto> GetAllMakerSpaces();

        MakerSpaceReadDto GetMakerSpaceById(Guid id);

        MakerSpaceReadDto GetMakerSpaceByName(string name);

        MakerSpaceReadDto GetMakerSpaceByPostCode(string postCode);

        MakerSpaceReadDto CreateMakerSpace(MakerSpaceCreateDto createDto);

        bool UpdateMakerSpace(Guid id, MakerSpaceCreateDto MakerSpaceCreateDto);

        bool DeleteMakerSpace(Guid id);
    }
}

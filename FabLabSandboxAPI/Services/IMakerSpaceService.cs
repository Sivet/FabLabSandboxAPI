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

        MakerSpaceReadDto GetMakerSpaceById(int id);

        MakerSpaceReadDto GetMakerSpaceByName(string name);

        MakerSpaceReadDto GetMakerSpaceByPostCode(string postCode);

        MakerSpaceReadDto CreateMakerSpace(MakerSpaceCreateDto createDto);

        bool UpdateMakerSpace(int id, MakerSpaceCreateDto MakerSpaceCreateDto);

        bool PartialMakerSpaceUpdate(int id, JsonPatchDocument<MakerSpaceUpdateDto> patchDoc);

        bool DeleteMakerSpace(int id);
    }
}

using System.Collections.Generic;
using FabLabSandboxAPI.Models;
using System;

namespace FabLabSandboxAPI.Data
{
    public interface IMakerSpaceRepo
    {
        bool SaveChanges();
        IEnumerable<MakerSpace> GetAllMakerSpaces();
        MakerSpace GetMakerSpaceById(Guid id);
        MakerSpace GetMakerSpaceByName(string name);
        MakerSpace GetMakerSpaceByPostCode(string postCode);
        void CreateMakerSpace(MakerSpace space);
        void UpdateMakerSpace(MakerSpace space);
        void DeleteMakerSpace(MakerSpace space);
    }
}
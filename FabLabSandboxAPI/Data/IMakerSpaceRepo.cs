using System.Collections.Generic;
using FabLabSandboxAPI.Models;

namespace FabLabSandboxAPI.Data
{
    public interface IMakerSpaceRepo
    {
        bool SaveChanges();
        IEnumerable<MakerSpace> GetAllMakerSpaces();
        MakerSpace GetMakerSpaceById(int id);
        MakerSpace GetMakerSpaceByName(string name);
        void CreateMakerSpace(MakerSpace space);
        void UpdateMakerSpace(MakerSpace space);
        void DeleteMakerSpace(MakerSpace space);
    }
}
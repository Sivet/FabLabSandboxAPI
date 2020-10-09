using System.Collections.Generic;
using FabLabSandboxAPI.Models;

namespace FabLabSandboxAPI.Data
{
    public interface IMakerSpaceRepo    
    {
        IEnumerable<MakerSpace> GetAllMakerSpaces();

        MakerSpace GetMakerSpaceById(int id);
        MakerSpace GetMakerSpaceByName(string name);
    }
}
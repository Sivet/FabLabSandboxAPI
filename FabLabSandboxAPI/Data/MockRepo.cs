using System.Collections.Generic;
using FabLabSandboxAPI.Models;

namespace FabLabSandboxAPI.Data
{
    public class MockRepo : IMakerSpaceRepo
    {
        public void CreateMakerSpace(MakerSpace space)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<MakerSpace> GetAllMakerSpaces()
        {
             var makerSpaces = new List<MakerSpace>
            {
                 new MakerSpace{Id=0, name="FabLab UCL"},
                 new MakerSpace{Id=2, name="BackYardMakerSpace"},
                 new MakerSpace { Id = 3, name = "A Third one"}
        };
            return makerSpaces;
        }

        public MakerSpace GetMakerSpaceById(int id)
        {
            return new MakerSpace{Id=0, name="FabLab UCL"};
        }

        public MakerSpace GetMakerSpaceByName(string name)
        {
            return new MakerSpace{Id=0, name="FabLab UCL"};
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}
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

        public void DeleteMakerSpace(MakerSpace space)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<MakerSpace> GetAllMakerSpaces()
        {
             var makerSpaces = new List<MakerSpace>
            {
                 new MakerSpace{Id=0, MakerSpaceName="FabLab UCL"},
                 new MakerSpace{Id=2, MakerSpaceName="BackYardMakerSpace"},
                 new MakerSpace {Id = 3, MakerSpaceName = "A Third one"}
        };
            return makerSpaces;
        }

        public MakerSpace GetMakerSpaceById(int id)
        {
            return new MakerSpace{Id=0, MakerSpaceName="FabLab UCL"};
        }

        public MakerSpace GetMakerSpaceByName(string name)
        {
            return new MakerSpace{Id=0, MakerSpaceName="FabLab UCL"};
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateMakerSpace(MakerSpace space)
        {
            throw new System.NotImplementedException();
        }
    }
}
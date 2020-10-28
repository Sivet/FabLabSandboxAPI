using System.Collections.Generic;
using FabLabSandboxAPI.Models;

namespace FabLabSandboxAPI.Data
{
    public class MockRepo : IMakerSpaceRepo
    {
        private readonly IEnumerable<MakerSpace> makerSpaces;
        public MockRepo(){
            makerSpaces = new List<MakerSpace>
            {
                 new MakerSpace{
                    Id=1, 
                    MakerSpaceName="FabLab UCL",
                    MakerSpacePostCode="2700",
                    MakerSpaceCity="CityVille",
                    MakerSpaceStreet="StreetStreet"
                    },
                 new MakerSpace{
                    Id=2, 
                    MakerSpaceName="BackYardMakerSpace",
                    MakerSpacePostCode="5000",
                    MakerSpaceCity="SmallCity",
                    MakerSpaceStreet="TheStreetAle"
                    },
                 new MakerSpace {
                    Id = 3,
                    MakerSpaceName = "A Third one",
                    MakerSpacePostCode="2500",
                    MakerSpaceCity="BigCity",
                    MakerSpaceStreet="CarStreet"}
        };
        }
        public void CreateMakerSpace(MakerSpace space)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<MakerSpace> GetAllMakerSpaces()
        {
            return makerSpaces;
        }

        public MakerSpace GetMakerSpaceById(int id)
        {
            foreach (var item in makerSpaces)
            {
                if(id == item.Id){
                    return item;
                }
            }
            return null;
        }

        public MakerSpace GetMakerSpaceByName(string name)
        {
            foreach (var item in makerSpaces)
            {
                if(name == item.MakerSpaceName){
                    return item;
                }
            }
            return null;
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateMakerSpace(MakerSpace space)
        {
            throw new System.NotImplementedException();
        }
        public void DeleteMakerSpace(MakerSpace space)
        {
            throw new System.NotImplementedException();
        }
    }
}
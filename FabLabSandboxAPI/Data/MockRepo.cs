using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using FabLabSandboxAPI.Models;

namespace FabLabSandboxAPI.Data
{
    public class MockRepo : IMakerSpaceRepo
    {
        private readonly IEnumerable<MakerSpace> makerSpaces;
        public MockRepo()
        {
            makerSpaces = new List<MakerSpace>
            {
                 new MakerSpace{
                    MakerSpaceId=new Guid(), 
                    MakerSpaceName="FabLab UCL",
                    /*MakerSpacePostCode="2700",
                    MakerSpaceCity="CityVille",
                    MakerSpaceStreet="StreetStreet"*/
                    },
                 new MakerSpace{
                    MakerSpaceId=new Guid(), 
                    MakerSpaceName="BackYardMakerSpace",
                    /*MakerSpacePostCode="5000",
                    MakerSpaceCity="SmallCity",
                    MakerSpaceStreet="TheStreetAle"*/
                    },
                 new MakerSpace {
                    MakerSpaceId = new Guid(),
                    MakerSpaceName = "A Third one",
                   /* MakerSpacePostCode="2500",
                    MakerSpaceCity="BigCity",
                    MakerSpaceStreet="CarStreet"*/
                    }
        };
        }
        public void CreateMakerSpace(MakerSpace space)
        {
            if (space == null)
            {
                throw new ArgumentNullException(nameof(space));
            }
            IEnumerable<MakerSpace> makerSpaceToCreate = new List<MakerSpace>
            {
                new MakerSpace
                {
                    MakerSpaceId = space.MakerSpaceId,
                    MakerSpaceName = space.MakerSpaceName,
                    ZipCode = space.ZipCode,
                    City= space.City,
                    StreetName = space.StreetName,
                    StreetNumber = space.StreetNumber
                }
            };
        }

        public IEnumerable<MakerSpace> GetAllMakerSpaces()
        {
            return makerSpaces;
        }

        public MakerSpace GetMakerSpaceById(Guid id)
        {
            foreach (var item in makerSpaces)
            {
                if(id == item.MakerSpaceId){
                    return item;
                }
            }
            return null;
        }

        public MakerSpace GetMakerSpaceByName(string name)
        {
            foreach (var item in makerSpaces)
            {
                if (name == item.MakerSpaceName)
                {
                    return item;
                }
            }
            return null;
        }

        public MakerSpace GetMakerSpaceByPostCode(string postCode)
        {
            foreach (var item in makerSpaces)
            {
                if (postCode == item.ZipCode)
                {
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
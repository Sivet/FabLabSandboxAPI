using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using FabLabSandboxAPI;
using FabLabSandboxAPI.Services;
using FabLabSandboxAPI.Models;
using FabLabSandboxAPI.Profiles;
using Xunit;
using FabLabSandboxAPI.Data;
using AutoMapper;
using FabLabSandboxAPI.Dtos;

namespace FabLabSandboxAPITest
{
    public class MakerSpaceMoqTests
    {
        Mapper mapper;
        Mock _repo = new Mock<IMakerSpaceRepo>();
        MakerSpacesProfile profile = new MakerSpacesProfile();
        MapperConfiguration configuration;
        
        public MakerSpaceMoqTests()
        {
            configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            mapper = new Mapper(configuration);
        }

        [Theory]
        [InlineData("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200")]
        public void GetMakerSpaceById_ShouldReturnMakerSpace_WhenIdExists(Guid id)
        {
            //ARRANGE
            var _service = new Mock<IMakerSpaceService>();
            MakerSpaceCreateDto dto = new MakerSpaceCreateDto()
            {
                MakerSpaceCity = "OdenseMoq",
                MakerSpaceName = "MoqSpace",
                MakerSpacePostCode = "5000",
                MakerSpaceStreet = "Seebladsgade"
            };

            //ACT
            _service.Setup(x => x.CreateMakerSpace(dto));
            var mkrSpace = _service.Object.GetMakerSpaceById(id);

            //ASSERT
            _service.Verify(e => e.GetMakerSpaceById(id), Times.Once);
            Assert.Equal(mkrSpace.Id, id);
        }
    }
}


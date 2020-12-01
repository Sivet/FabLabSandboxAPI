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
    /*public class MakerSpaceMoqTests
    {
        Mapper mapper;
        Mock _repo = new Mock<IMakerSpaceRepo>();
        MakerSpacesProfile profile = new MakerSpacesProfile();
        MapperConfiguration configuration;
        Mock _service;

        public MakerSpaceMoqTests()
        {
            configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            mapper = new Mapper(configuration);
            _service = new Mock<IMakerSpaceService>();
        }

        [Theory]
        [InlineData("MoqSpace")]
        public void GetMakerSpaceById_ShouldReturnMakerSpace_WhenNameExists(string name)
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

            MakerSpaceReadDto dtoRead = new MakerSpaceReadDto()
            {
                Id = new Guid(),
                MakerSpaceCity = "OdenseMoq",
                MakerSpaceName = "MoqSpace",
                MakerSpacePostCode = "5000",
                MakerSpaceStreet = "Seebladsgade"
            };

            //ACT
            _service.Setup(x => x.CreateMakerSpace(dto)).Returns(dtoRead);

            //ASSERT
            //_service.Verify(e => e.GetMakerSpaceByName(name), Times.Once);
            Assert.Equal(_service.Object.GetMakerSpaceByName(name).MakerSpaceName, name);
        }

        [Fact]
        void GetMakerSpaceByGuid_Valid()
        {
            //arr
            Guid id = Guid.NewGuid();
            var _repo = new Mock<IMakerSpaceRepo>();
            _repo.Setup(x => x.GetMakerSpaceById(id)).Returns(new MakerSpace()
            {
                MakerSpaceId = id
            });

            //act
            //var result = 

            //ass
        }
    }*/
}


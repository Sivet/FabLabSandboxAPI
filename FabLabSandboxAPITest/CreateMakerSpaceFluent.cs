using AutoMapper;
using FabLabSandboxAPI.Controllers;
using FabLabSandboxAPI.Data;
using FabLabSandboxAPI.Dtos;
using FabLabSandboxAPI.Profiles;
using FabLabSandboxAPI.Models;
using FabLabSandboxAPI.Services;
using Microsoft.AspNetCore.Mvc;
using NuGet.Frameworks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using Moq;

namespace FabLabSandboxAPITest
{
    public class CreateMakerSpaceFluent
    {
        Mock<IMakerSpaceRepo> _repo;
        MakerSpaceService _service;
        Mapper _mapper;

        public CreateMakerSpaceFluent()
        {
            var profile = new MakerSpacesProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            _mapper = new Mapper(configuration);

            _repo = new Mock<IMakerSpaceRepo>();//MockRepo();

            _service = new MakerSpaceService(_repo.Object, _mapper);

        }
        [Fact]
        public void GetAllMakerSpaces_CalledOnceValid()
        {
            _repo.Setup(repo => repo.GetAllMakerSpaces()).Returns(
                new List<MakerSpace>()
            );

            var result = _service.GetAllMakerSpaces();

            result.Should().NotBeNull()
            .And.OnlyHaveUniqueItems();
            _repo.Verify(x => x.GetAllMakerSpaces(), Times.Once);
        }

        [Theory]
        [InlineData("FabLab UCL")]
        [InlineData("BackYardMakerSpace")]
        [InlineData("A Third one")]
        public void GetMakerSpaceByName_Valid(string name)
        {
            _repo.Setup(repo => repo.GetMakerSpaceByName(name)).Returns(
                new MakerSpace()
                {
                    MakerSpaceName = name
                }
            );
            var result = _service.GetMakerSpaceByName(name);

            _repo.Verify(repo => repo.GetMakerSpaceByName(name), Times.Once);
            result.MakerSpaceName.Should().Be(name);
        }

        [Theory]
        [MemberData(nameof(MakerSpaceIds))]
        public void GetMakerSpaceById_Exists(Guid id)
        {
            //Arrange
            //Guid id = Guid.NewGuid();
            _repo.Setup(repo => repo.GetMakerSpaceById(id)).Returns(
                new MakerSpace()
                {
                    MakerSpaceId = id
                }
            );

            //Act
            var result = _service.GetMakerSpaceById(id);

            //Assert
            _repo.Verify(repo => repo.GetMakerSpaceById(id), Times.Once);
            result.MakerSpaceId.Should().Be(id);
        }

        [Theory]
        [ClassData(typeof(MakerSpaceTestData))]
        public void GetMakerSpaceById_NotExists(Guid id)
        {
            //Arrange

            //Act
            MakerSpaceReadDto result = null;
            Action act = () => _service.GetMakerSpaceById(id);

            //Assert
            act.Should().Throw<NullReferenceException>();
            _repo.Verify(repo => repo.GetMakerSpaceById(id), Times.Once);
            result.Should().BeNull();
        }

        [Fact]
        public void CreateMakerSpace_Valid()
        {
            //Arrange
            MakerSpaceCreateDto mySpace = new MakerSpaceCreateDto
            {
                MakerSpaceName = "BestName",
                ZipCode = "2700",
                StreetName = "Group5Street",
                StreetNumber = "5",
                City = "FiveCity"
            };

            //Act
            var result = _service.CreateMakerSpace(mySpace);

            //Assert
            result.Should().BeEquivalentTo(mySpace);
        }

        public static IEnumerable<object[]> MakerSpaceIds =>
            new List<object[]>
            {
            new object[] { Guid.NewGuid() },
            new object[] { Guid.NewGuid() },
            new object[] { Guid.NewGuid() },
            };
    }
}

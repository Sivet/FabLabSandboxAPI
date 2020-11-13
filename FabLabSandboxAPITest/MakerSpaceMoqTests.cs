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
        Mock _service;
        Mock _repo = new Mock<IMakerSpaceRepo>();
        MakerSpacesProfile profile = new MakerSpacesProfile();
        MapperConfiguration configuration;
        
        public MakerSpaceMoqTests()
        {
            configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            mapper = new Mapper(configuration);
        }

        [Theory]
        [InlineData(1)]
        public void GetMakerSpaceById_ShouldReturnMakerSpace_WhenIdExists(int id)
        {
            //ARRANGE
            //_service = new Mock<IMakerSpaceService>()
            //    .Setup(x => x.GetMakerSpaceById(It.IsAny<int>()))
            //    .Returns(/*TODO*/);
            

            //ACT


            //ASSERT


        }
    }
}


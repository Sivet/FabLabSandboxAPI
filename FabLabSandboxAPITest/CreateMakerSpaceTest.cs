using AutoMapper;
using FabLabSandboxAPI.Controllers;
using FabLabSandboxAPI.Data;
using FabLabSandboxAPI.Dtos;
using FabLabSandboxAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NuGet.Frameworks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace FabLabSandboxAPITest
{
    public class CreateMakerSpaceTest
    {
        //Problem: can't access mapper or repo, wrong approach?
        [Fact]
        public void GetAllMakerSpacesTest()
        {
            //_mapper = Mapper of the controller
            //Arrange
            var _mockRepo = new Mock<IMakerSpaceRepo>();
            _mockRepo.Setup(x => x.GetAllMakerSpaces());

            var _mockMapper = new Mock<IMapper>();
            _mockMapper.Setup(_ => _.Map<IEnumerable<MakerSpaceReadDto>>(_mockRepo.Setup(x => x.GetAllMakerSpaces())));

            var controller = new MakerSpacesController(_mockRepo.Object, _mockMapper.Object);
            // Act

            var result = controller.GetAllMakerSpaces();

            // Assert
            Assert.NotNull(result);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using AutoMapper;
using FabLabSandboxAPI.Controllers;
using FabLabSandboxAPI.Data;
using FabLabSandboxAPI.Dtos;
using FabLabSandboxAPI.Profiles;
using FabLabSandboxAPI.Models;
using FabLabSandboxAPI.Services;
using Microsoft.AspNetCore.Mvc;
using NuGet.Frameworks;
using System.Threading.Tasks;
using Xunit;
using Moq;
using ExcelDataReader;
using System.IO;
using Microsoft.EntityFrameworkCore.Update;
using System.Data;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace FabLabSandboxAPITest
{
    public class AddUserToMakerSpaceTest
    {
        MakerSpacesController _controller;
        IMakerSpaceRepo _repo;
        MakerSpacesService service;

        public AddUserToMakerSpaceTest()
        {
            var profile = new MakerSpacesProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new Mapper(configuration);
            _repo = new MockRepo();
            service = new MakerSpacesService(_repo, mapper);
            _controller = new MakerSpacesController(service);
            var mockController = new Mock<MakerSpacesController>();
        }

        [Fact]
        public void AddUserToMakerSpaceTest_ShouldFail()
        {
            //ARRANGE

            //ACT

            //ASSERT
            //Assert.True(USERINVALID)
        }

        [Fact]
        public void AddUserToMakerSpaceTest_ShouldSucceed()
        {
            //ARRANGE

            //ACT

            //ASSERT
            //Assert.True(USERVALID)
        }
    }
}

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
        //MakerSpacesController _controller;
        IMakerSpaceRepo _repo;
        MakerSpacesService _service;

        public CreateMakerSpaceFluent(){
            var profile = new MakerSpacesProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new Mapper(configuration);

            _repo = new MockRepo();
            _service = new MakerSpacesService(_repo, mapper);
            
        }
        [Fact]
        public void GetAllMakerSpaces_Valid(){
            var result = _service.GetAllMakerSpaces();

            result.Should().NotBeEmpty()
            .And.OnlyHaveUniqueItems();
        }
        [Theory]
        [InlineData("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200")]
        public void GetMakerSpaceById_Valid(String id){
           /*var result = _service.GetMakerSpaceById(new Guid(id));

            result.Should().BeOfType<MakerSpace>().And.NotBeNull();
            result.Id.Should().Be(id);*/
        }
        [Theory]
        [InlineData("FabLab UCL")]
        [InlineData("BackYardMakerSpace")]
        [InlineData("A Third one")]
        public void GetMakerSpaceByName_Valid(string name){
            var result = _service.GetMakerSpaceByName(name);

            Assert.Equal(result.MakerSpaceName, name);
        }
    }
}

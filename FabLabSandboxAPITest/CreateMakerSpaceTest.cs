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
using Xunit;
using Moq;

namespace FabLabSandboxAPITest
{
    public class CreateMakerSpaceTest
    {
        //MakerSpacesController _controller;
        IMakerSpaceRepo _repo;
        MakerSpacesService _service;

        public CreateMakerSpaceTest(){
            var profile = new MakerSpacesProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new Mapper(configuration);

            _repo = new MockRepo();
            _service = new MakerSpacesService(_repo, mapper);
            //_controller = new MakerSpacesController(_service);
            
        }
        [Fact]
        public void GetAllMakerSpaces_Valid(){
            var result = _service.GetAllMakerSpaces();

            Assert.Equal(1, 1);
        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetMakerSpaceById_Valid(int id){
            var result = _service.GetMakerSpaceById(id);

            Assert.Equal(result.Id, id);
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

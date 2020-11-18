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
using System.IO;
using System.Linq;

namespace FabLabSandboxAPITest
{
    public class CreateMakerSpaceTest
    {
        //MakerSpacesController _controller;
        Mock<IMakerSpaceRepo> _repo;
        MakerSpacesService _service;
        Mapper mapper;
        
        public CreateMakerSpaceTest(){
            var profile = new MakerSpacesProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
             mapper = new Mapper(configuration);

            _repo = new Mock<IMakerSpaceRepo>();//MockRepo();'
            
            _service = new MakerSpacesService(_repo.Object, mapper);
            
        }
        [Fact]
        public void GetAllMakerSpaces_Valid(){
            var result = _service.GetAllMakerSpaces();

            _repo.Verify(x => x.GetAllMakerSpaces(), Times.Once);
        }
        [Theory]
        [InlineData("FabLab UCL")]
        [InlineData("BackYardMakerSpace")]
        [InlineData("A Third one")]
        public void GetMakerSpaceById_Exists(string name){
            Guid id = Guid.NewGuid();
            _repo.Setup(repo => repo.GetMakerSpaceById(id)).Returns(
                new MakerSpace(){
                    MakerSpaceId = id,
                    MakerSpaceName = name
                }
            );

            var result = _service.GetMakerSpaceById(id);

            Assert.Equal(result.MakerSpaceName, name);
        }
        [Theory]
        [InlineData("FabLab UCL")]
        [InlineData("BackYardMakerSpace")]
        [InlineData("A Third one")]
        public void GetMakerSpaceById_NotExists(string name){
            Guid id = Guid.NewGuid();
            _repo.Setup(repo => repo.GetMakerSpaceById(id)).Returns(
                new MakerSpace(){
                    MakerSpaceId = id,
                    MakerSpaceName = name
                }
            );
            MakerSpaceReadDto result = null;
            try{
                result = _service.GetMakerSpaceById(new Guid("451dd7c8-b533-4c43-ac0b-582b1d1a37eb"));
            }
            catch(Exception e){
                Assert.IsType(typeof(NullReferenceException), e);
            }
            Assert.Equal(result, null);
        }

        [Theory]
        [InlineData("FabLab UCL")]
        [InlineData("BackYardMakerSpace")]
        [InlineData("A Third one")]
        public void GetMakerSpaceByName_Exists(string name){
            _repo.Setup(repo => repo.GetMakerSpaceByName(name)).Returns(
                new MakerSpace(){
                    MakerSpaceName = name
                }
            );

            var result = _service.GetMakerSpaceByName(name);

            _repo.Verify(repo => repo.GetMakerSpaceByName(name), Times.Once);
            Assert.Equal(result.MakerSpaceName, name);
        }

        [Theory]
        [InlineData("2700")]
        public void GetMakerSpaceByPostCode_Verify(string postCode)
        {
            //Arrange
            var result = _service.GetMakerSpaceByPostCode(postCode);

            //ACT
            //Postal Code list from spreadsheet.
            List<string> postalCodes = new List<string>();

            //Read from spreadsheet and store in list.
            var path = System.IO.Directory.GetCurrentDirectory(); //Finds build folder with compiled files
            var reader = new StreamReader(File.OpenRead(path + "/danske-postnumre-byer-1.csv"));
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                postalCodes.Add(line.Split(';')[0]);
            }
            postalCodes.RemoveAt(0);

            string match = postalCodes
                    .FirstOrDefault(stringToCheck => stringToCheck.Contains(postCode));

            //Assert
            Assert.Equal(result.MakerSpacePostCode, match);

        }
    }
}

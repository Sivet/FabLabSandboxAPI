using AutoMapper;
using FabLabSandboxAPI.Controllers;
using FabLabSandboxAPI.Data;
using FabLabSandboxAPI.Dtos;
using FabLabSandboxAPI.Models;
using FabLabSandboxAPI.Profiles;
using Microsoft.AspNetCore.Mvc;
using NuGet.Frameworks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Moq;
using ExcelDataReader;
using System.IO;
using Microsoft.EntityFrameworkCore.Update;
using System.Data;

namespace FabLabSandboxAPITest
{
    public class CreateMakerSpaceTest
    {
        MakerSpacesController _controller;
        IMakerSpaceRepo _repo;

        public CreateMakerSpaceTest(){
            var profile = new MakerSpacesProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new Mapper(configuration);

            _repo = new MockRepo();
            _controller = new MakerSpacesController(_repo, mapper);
            
        }
        [Fact]
        public void GetAllMakerSpaces_Valid(){
            var result = _controller.GetAllMakerSpaces();

            Assert.IsType<OkObjectResult>(result.Result);
        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetMakerSpaceById_Valid(int id){
            var result = _controller.GetMakerSpaceById(id);

            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(result.Value.Id, id);
        }
        [Theory]
        [InlineData("FabLab UCL")]
        [InlineData("BackYardMakerSpace")]
        [InlineData("A Third one")]
        public void GetMakerSpaceByName_Valid(string name){
            var result = _controller.GetMakerSpaceByName(name);

            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(result.Value.Name, name);
        }
        //Problem: can't access mapper or repo, wrong approach?
        /*[Fact]
        public void GetAllMakerSpacesTest()
        {
            //ARRANGE

            //MakerSpace dummy
            var makerSpace = new MakerSpace();
            makerSpace.MakerSpaceName = "Lab1";
            makerSpace.MakerSpacePostCode = "5000";
            makerSpace.MakerSpaceCity = "Vejle";
            makerSpace.MakerSpaceStreet = "Fynsvej 12";
            //ExampleDto
            MakerSpaceCreateDto dto = new MakerSpaceCreateDto();
            dto.Name = makerSpace.MakerSpaceName;
            dto.PostCode = makerSpace.MakerSpacePostCode;
            dto.City = makerSpace.MakerSpaceCity;
            dto.Street = makerSpace.MakerSpaceStreet;

            //Postal Code list from spreadsheet.
            List<string> postalCodes = new List<string>();

            //Read from spreadsheet and store in list.
            var reader = new StreamReader(File.OpenRead(@"C:\Users\AsbjoernLaptop\Documents\GitHub\FabLabSandboxAPI\FabLabSandboxAPITest\danske-postnumre-byer-1.csv"));
            while(!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                postalCodes.Add(line.Split(';')[0]);
            }
            postalCodes.RemoveAt(0);
            //Mock setup

            //Mock Repo
            var _mockRepo = new Mock<IMakerSpaceRepo>();
            _mockRepo.Setup(x => x.CreateMakerSpace(makerSpace));

            //Mock Mapper
            var _mockMapper = new Mock<IMapper>();
            _mockMapper.Setup(_ => _
            .Map<IEnumerable<MakerSpaceReadDto>>(_mockRepo
            .Setup(x => x
            .CreateMakerSpace(makerSpace)))); //create example makerspace.

            //Mock Controller
            var controller = new MakerSpacesController(_mockRepo.Object, _mockMapper.Object);

            //ACT
            var result = controller.CreateMakerSpace(dto);

            //ASSERT
            Assert.Equal(result.Value.PostCode, postalCodes[1]);
        }*/
    }
}

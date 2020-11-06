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
using ExcelDataReader;
using System.IO;
using Microsoft.EntityFrameworkCore.Update;
using System.Data;
using System.Linq;

namespace FabLabSandboxAPITest
{
    public class CreateMakerSpaceTest
    {
        MakerSpacesController _controller;
        IMakerSpaceRepo _repo;
        MakerSpacesService service;

        public CreateMakerSpaceTest(){
            var profile = new MakerSpacesProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new Mapper(configuration);
            _repo = new MockRepo();
            service = new MakerSpacesService(_repo, mapper);
            _controller = new MakerSpacesController(service);
            
        }
        [Fact]
        public void GetAllMakerSpaces_Valid(){
            var result = _controller.GetAllMakerSpaces();

            Assert.IsType<OkObjectResult>(result.Result);
        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
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
            Assert.Equal(result.Value.MakerSpaceName, name);
        }

        //Makes no sense: TODO, test authentication.
        [Theory]
        [InlineData("2700")]
        public void GetMakerSpaceByPostCode_Verify(string postCode)
        {
            //Arrange
            var result = _controller.GetMakerSpaceByPostCode(postCode);

            //ACT
            //Postal Code list from spreadsheet.
            List<string> postalCodes = new List<string>();

            //Read from spreadsheet and store in list.
            var reader = new StreamReader(File.OpenRead(@"C:\Users\AsbjoernLaptop\Documents\GitHub\FabLabSandboxAPI\FabLabSandboxAPITest\danske-postnumre-byer-1.csv"));
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                postalCodes.Add(line.Split(';')[0]);
            }
            postalCodes.RemoveAt(0);

            string match = postalCodes
                    .FirstOrDefault(stringToCheck => stringToCheck.Contains(postCode));

            //Fault! result.Value returns null. ActionResult value is through result.Result.Value internally... Shucks.
            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(result.Value.MakerSpacePostCode, match);

        }

    }
}

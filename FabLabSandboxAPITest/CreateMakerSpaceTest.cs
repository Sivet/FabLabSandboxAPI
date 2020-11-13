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
        [InlineData("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200")]
        public void GetMakerSpaceById_Valid(string id){
            var result = _service.GetMakerSpaceById(new Guid(id));

            Assert.Equal(result.Id.ToString(), id);
        }
        [Theory]
        [InlineData("FabLab UCL")]
        [InlineData("BackYardMakerSpace")]
        [InlineData("A Third one")]
        public void GetMakerSpaceByName_Valid(string name){
            var result = _service.GetMakerSpaceByName(name);

            Assert.Equal(result.MakerSpaceName, name);
        }

        [Theory]
        [InlineData("Generic1")]
        public void CreateMakerSpace_ValidName(string name)
        {
            MakerSpaceCreateDto genericSpace = new MakerSpaceCreateDto()
            {
                MakerSpaceName = name,
                MakerSpacePostCode = "3000",
                MakerSpaceStreet = "Danmarksgade 12",
                MakerSpaceCity = "Odense"
            };

            var result = _service.GetMakerSpaceByName(name);
            Assert.Equal(result.MakerSpaceName, genericSpace.MakerSpaceName);
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
            var reader = new StreamReader(File.OpenRead(@"C:\Users\AsbjoernLaptop\Documents\GitHub\FabLabSandboxAPI\FabLabSandboxAPITest\danske-postnumre-byer-1.csv"));
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

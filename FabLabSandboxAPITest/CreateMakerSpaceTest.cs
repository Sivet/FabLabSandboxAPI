using AutoMapper;
using FabLabSandboxAPI.Controllers;
using FabLabSandboxAPI.Data;
using FabLabSandboxAPI.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Frameworks;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace FabLabSandboxAPITest
{
    public class CreateMakerSpaceTest
    {
        //Problem: can't access mapper or repo, wrong approach?

        Mapper _mapper;
        public ViewResult viewResult;
        [Fact]
        public void GetAllMakerSpacesTest()
        {
           //_mapper = Mapper of the controller
            //Arrange

            // Act

            // Assert
          //  Assert.Equal(viewResult = OkObjectResult()) 
        }
    }
}

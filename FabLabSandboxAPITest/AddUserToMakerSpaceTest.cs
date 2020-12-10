using AutoMapper;
using FabLabSandboxAPI.Data;
using FabLabSandboxAPI.Profiles;
using FabLabSandboxAPI.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace FabLabSandboxAPITest
{
    public class AddUserToMakerSpaceTest
    {
        IMakerSpaceRepo _repo;
        MakerSpaceService _service;

        public AddUserToMakerSpaceTest()
        {
            var profile = new MakerSpacesProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new Mapper(configuration);

            _repo = new MockRepo();
            _service = new MakerSpaceService(_repo, mapper);
        }

        public void AddUserToMakerSpace_ShouldFail()
        {
            //ARRANGE

            //ACT

            //ASSERT
        }

        public void AddUserToMakerSpace_ShouldSucceed()
        {
            //ARRANGE

            //ACT

            //ASSERT
        }
    }
}

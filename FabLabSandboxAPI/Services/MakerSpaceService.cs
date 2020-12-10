using System.Collections.Generic;
using FabLabSandboxAPI.Models;
using FabLabSandboxAPI.Data;
using AutoMapper;
using FabLabSandboxAPI.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using System;

namespace FabLabSandboxAPI.Services
{

    public class MakerSpaceService : IMakerSpaceService
    {
        private readonly IMakerSpaceRepo _repo;
        private readonly IMapper _mapper;

        public MakerSpaceService(IMakerSpaceRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public IEnumerable<MakerSpaceReadDto> GetAllMakerSpaces()
        {
            var makerSpaces = _repo.GetAllMakerSpaces();
            return _mapper.Map<IEnumerable<MakerSpaceReadDto>>(makerSpaces);
        }

        public MakerSpaceReadDto GetMakerSpaceById(Guid id)
        {
            var makerSpace = _repo.GetMakerSpaceById(id);

            if (makerSpace == null){
                throw new NullReferenceException();
            }
            return _mapper.Map<MakerSpaceReadDto>(makerSpace);
        }

        public MakerSpaceReadDto GetMakerSpaceByName(string name)
        {
            var makerSpace = _repo.GetMakerSpaceByName(name);
            return _mapper.Map<MakerSpaceReadDto>(makerSpace);
        }

        public MakerSpaceReadDto GetMakerSpaceByPostCode(string postCode)
        {
            var makerSpace = _repo.GetMakerSpaceByPostCode(postCode);
            return _mapper.Map<MakerSpaceReadDto>(makerSpace);
        }


        public MakerSpaceReadDto CreateMakerSpace(MakerSpaceCreateDto createDto)
        {
            var makerSpaceModel = _mapper.Map<MakerSpace>(createDto);
            _repo.CreateMakerSpace(makerSpaceModel);
            _repo.SaveChanges();

            return _mapper.Map<MakerSpaceReadDto>(makerSpaceModel);
        }


        public bool UpdateMakerSpace(Guid id, MakerSpaceCreateDto MakerSpaceCreateDto)
        {
            var MakerSpaceModelFromRepo = _repo.GetMakerSpaceById(id);
            if (MakerSpaceModelFromRepo == null)
            {
                return false;
            }

            _mapper.Map(MakerSpaceCreateDto, MakerSpaceModelFromRepo);
            _repo.UpdateMakerSpace(MakerSpaceModelFromRepo);
            _repo.SaveChanges();

            return true;
        }

        public bool DeleteMakerSpace(Guid id)
        {
            var makerSpaceModel = _repo.GetMakerSpaceById(id);
            if (makerSpaceModel == null)
            {
                return false;
            }
            _repo.DeleteMakerSpace(makerSpaceModel);
            _repo.SaveChanges();
            return true;
        }

    }
}
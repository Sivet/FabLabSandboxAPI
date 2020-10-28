using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FabLabSandboxAPI.Models;
using FabLabSandboxAPI.Data;
using AutoMapper;
using FabLabSandboxAPI.Dtos;
using Microsoft.AspNetCore.JsonPatch;

namespace FabLabSandboxAPI.Services
{

    public class MakerSpacesService
    {
        private readonly IMakerSpaceRepo _repo;
        private readonly IMapper _mapper;

        public MakerSpacesService(IMakerSpaceRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public IEnumerable<MakerSpaceReadDto> GetAllMakerSpaces()
        {
            var makerSpaces = _repo.GetAllMakerSpaces();
            return _mapper.Map<IEnumerable<MakerSpaceReadDto>>(makerSpaces);
        }
        
        public MakerSpaceReadDto GetMakerSpaceById(int id)
        {
            var makerSpace = _repo.GetMakerSpaceById(id);
            return _mapper.Map<MakerSpaceReadDto>(makerSpace);
        }

        
        public MakerSpaceReadDto GetMakerSpaceByName(string name)
        {
            var makerSpace = _repo.GetMakerSpaceByName(name);
            return _mapper.Map<MakerSpaceReadDto>(makerSpace);
        }

        
        public MakerSpaceReadDto CreateMakerSpace(MakerSpaceCreateDto createDto)
        {
            var makerSpaceModel = _mapper.Map<MakerSpace>(createDto);
            _repo.CreateMakerSpace(makerSpaceModel);
            _repo.SaveChanges();

            return _mapper.Map<MakerSpaceReadDto>(makerSpaceModel);
        }

        
        public bool UpdateMakerSpace(int id, MakerSpaceCreateDto MakerSpaceCreateDto)
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

        public bool PartialMakerSpaceUpdate(int id, JsonPatchDocument<MakerSpaceUpdateDto> patchDoc)
        {
            /*var MakerSpaceModelFromRepo = _repo.GetMakerSpaceById(id);
            if (MakerSpaceModelFromRepo == null)
            {
                return false;
            }
            var MakerSpaceToPatch = _mapper.Map<MakerSpaceUpdateDto>(MakerSpaceModelFromRepo);
            patchDoc.ApplyTo(MakerSpaceToPatch, ModelState);
            if (!TryValidateModel(MakerSpaceToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(MakerSpaceToPatch, MakerSpaceModelFromRepo);
            _repo.UpdateMakerSpace(MakerSpaceModelFromRepo);
            _repo.SaveChanges();*/

            return false;
        }

        public bool DeleteMakerSpace(int id)
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
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FabLabSandboxAPI.Models;
using FabLabSandboxAPI.Data;
using AutoMapper;
using FabLabSandboxAPI.Dtos;
using Microsoft.AspNetCore.JsonPatch;

namespace FabLabSandboxAPI.Controllers
{

    /// <summary>Controller responsible for GET/POST/DELETE for managing MakerSpace </summary>
    [ApiController]
    [Route("api/MakerSpaces")]
    public class MakerSpacesController : ControllerBase
    {
        private readonly IMakerSpaceRepo _repo;
        private readonly IMapper _mapper;

        public MakerSpacesController(IMakerSpaceRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        /// <summary>This GET method returns all MakerSpaces from DB</summary>
        /// <returns>An arrey of MakerSpases</returns>
        [HttpGet]
        public ActionResult<IEnumerable<MakerSpaceReadDto>> GetAllMakerSpaces()
        {
            var makerSpaces = _repo.GetAllMakerSpaces();
            return Ok(_mapper.Map<IEnumerable<MakerSpaceReadDto>>(makerSpaces));
        }
        /// <summary> This GET method returns search in DB and returns MakerSpace from DB by its ID </summary>
        /// <returns>An MakerSpase</returns>
        [HttpGet("{id}", Name = "GetMakerSpaceById")] //Named so the Post can use it
        public ActionResult<MakerSpaceReadDto> GetMakerSpaceById(int id)
        {
            var makerSpace = _repo.GetMakerSpaceById(id);
            return Ok(_mapper.Map<MakerSpaceReadDto>(makerSpace));
        }

        /// <summary> This GET method returns search in DB and returns MakerSpace from DB by its name </summary>
        /// <returns>An MakerSpase</returns>
        [HttpGet("name/{name}")]
        public ActionResult<MakerSpaceReadDto> GetMakerSpaceByName(string name)
        {
            var makerSpace = _repo.GetMakerSpaceByName(name);
            return Ok(_mapper.Map<MakerSpaceReadDto>(makerSpace));
        }

        /// <summary> This POST method create MakerSpace in DB </summary>
        /// <returns>returns createt MacerSpase url -/api/MakerSpaces/{created} </returns>
        [HttpPost]
        public ActionResult<MakerSpaceReadDto> CreateMakerSpace(MakerSpaceCreateDto createDto)
        {
            var makerSpaceModel = _mapper.Map<MakerSpace>(createDto);
            _repo.CreateMakerSpace(makerSpaceModel);
            _repo.SaveChanges();

            var makerSpaceReadDto = _mapper.Map<MakerSpaceReadDto>(makerSpaceModel);

            return CreatedAtRoute(nameof(GetMakerSpaceById), new { Id = makerSpaceReadDto.Id }, makerSpaceReadDto);
        }

        ///<summary> This PUT method update MakerSpace in DB </summary>
        [HttpPut("{id}")]
        public ActionResult UpdateMakerSpace(int id, MakerSpaceCreateDto MakerSpaceCreateDto)
        {
            var MakerSpaceModelFromRepo = _repo.GetMakerSpaceById(id);
            if (MakerSpaceModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(MakerSpaceCreateDto, MakerSpaceModelFromRepo);
            _repo.UpdateMakerSpace(MakerSpaceModelFromRepo);
            _repo.SaveChanges();

            return NoContent();
        }

        /// <summary> This PUT method partial update MakerSpace (not all but some columns in tabel in DB </summary>
        //Purtial update
        //PATCH api/MakerSpace/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialMakerSpaceUpdate(int id, JsonPatchDocument<MakerSpaceUpdateDto> patchDoc)
        {
            var MakerSpaceModelFromRepo = _repo.GetMakerSpaceById(id);
            if (MakerSpaceModelFromRepo == null)
            {
                return NotFound();
            }
            var MakerSpaceToPatch = _mapper.Map<MakerSpaceUpdateDto>(MakerSpaceModelFromRepo);
            patchDoc.ApplyTo(MakerSpaceToPatch, ModelState);
            if (!TryValidateModel(MakerSpaceToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(MakerSpaceToPatch, MakerSpaceModelFromRepo);
            _repo.UpdateMakerSpace(MakerSpaceModelFromRepo);
            _repo.SaveChanges();

            return NoContent();
        }

        /// <summary> This DELETE method delete MakerSpace from DB </summary>
        [HttpDelete("{id}")]
        public ActionResult DeleteMakerSpace(int id)
        {
            var makerSpaceModel = _repo.GetMakerSpaceById(id);
            if (makerSpaceModel == null)
            {
                return NotFound();
            }
            _repo.DeleteMakerSpace(makerSpaceModel);
            _repo.SaveChanges();
            return NoContent();
        }

    }
}
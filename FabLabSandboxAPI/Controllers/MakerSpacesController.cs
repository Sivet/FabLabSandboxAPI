using System.Collections.Generic;
using FabLabSandboxAPI.Authorization.AuthServises;
using Microsoft.AspNetCore.Mvc;
using FabLabSandboxAPI.Services;
using FabLabSandboxAPI.Models;
using FabLabSandboxAPI.Data;
//using AutoMapper;
using FabLabSandboxAPI.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;

namespace FabLabSandboxAPI.Controllers
{ 
    /// <summary>Controller responsible for GET/POST/DELETE for managing MakerSpace </summary>
 
  //[Authorize]
    [ApiController]
    [Route("api/MakerSpaces")]
    public class MakerSpacesController : ControllerBase
    {
        /*private readonly IMakerSpaceRepo _repo;
        private readonly IMapper _mapper;*/
        MakerSpacesService _service; //Should be interface

        public MakerSpacesController(MakerSpacesService service)
        {
            _service = service;
        }
        /// <summary>This GET method returns all MakerSpaces from DB</summary>
        /// <returns>An arrey of MakerSpases</returns>
        [HttpGet]
        public ActionResult<IEnumerable<MakerSpaceReadDto>> GetAllMakerSpaces()
        {
            return Ok(_service.GetAllMakerSpaces());
        }
        /// <summary> This GET method returns search in DB and returns MakerSpace from DB by its ID </summary>
        /// <returns>An MakerSpase</returns>
         [Authorize(Roles = UserRoles.Admin)]
         [HttpGet("{id}", Name = "GetMakerSpaceById")] //Named so the Post can use it
        public ActionResult<MakerSpaceReadDto> GetMakerSpaceById(int id)
        {
            return Ok(_service.GetMakerSpaceById(id));
        }

        /// <summary> This GET method returns search in DB and returns MakerSpace from DB by its name </summary>
        /// <returns>An MakerSpase</returns>
       
        [HttpGet("name/{name}")]
        public ActionResult<MakerSpaceReadDto> GetMakerSpaceByName(string name)
        {
            return Ok(_service.GetMakerSpaceByName(name));
        }

        /// <summary> This GET method returns search in DB and returns MakerSpace from DB by its name </summary>
        /// <returns>An MakerSpase</returns>

        [HttpGet("{postCode}")]
        public ActionResult<MakerSpaceReadDto> GetMakerSpaceByPostCode(string postCode)
        {
            return Ok(_service.GetMakerSpaceByPostCode(postCode));
        }

        /// <summary> This POST method create MakerSpace in DB </summary>
        /// <returns>returns createt MacerSpase url -/api/MakerSpaces/{created} </returns>
        [HttpPost]
        public ActionResult<MakerSpaceReadDto> CreateMakerSpace(MakerSpaceCreateDto createDto)
        {
            _service.CreateMakerSpace(createDto);
            //Check if valid
            return Created($"api/MakerSpaces", null);//CreatedAtRoute(nameof(GetMakerSpaceById), new { Id = makerSpaceReadDto.Id }, makerSpaceReadDto);
        }

        ///<summary> This PUT method update MakerSpace in DB </summary>
        [HttpPut("{id}")]
        public ActionResult UpdateMakerSpace(int id, MakerSpaceCreateDto MakerSpaceCreateDto)
        {
            if (_service.UpdateMakerSpace(id, MakerSpaceCreateDto) == false)
            {
                return NotFound();
            }
            return NoContent();
        }

        /// <summary> This PUT method partial update MakerSpace (not all but some columns in tabel in DB </summary>
        //Purtial update
        //PATCH api/MakerSpace/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialMakerSpaceUpdate(int id, JsonPatchDocument<MakerSpaceUpdateDto> patchDoc)
        {
            if (_service.PartialMakerSpaceUpdate(id, patchDoc) == false)
            {
                return NotFound();
            }
            return NoContent();
        }

        /// <summary> This DELETE method delete MakerSpace from DB </summary>
        [HttpDelete("{id}")]
        public ActionResult DeleteMakerSpace(int id)
        {
            if (_service.DeleteMakerSpace(id) == false)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
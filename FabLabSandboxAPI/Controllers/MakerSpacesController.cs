using System.Collections.Generic;
using FabLabSandboxAPI.Authorization.AuthServises;
using Microsoft.AspNetCore.Mvc;
using FabLabSandboxAPI.Services;
//using FabLabSandboxAPI.Models;
//using FabLabSandboxAPI.Data;
//using AutoMapper;
using FabLabSandboxAPI.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using System;

namespace FabLabSandboxAPI.Controllers
{ 
    /// <summary>Controller responsible for GET/POST/DELETE for managing MakerSpace </summary>
 
  //[Authorize]
    [ApiController]
    [Route("api/MakerSpaces")]
    public class MakerSpacesController : ControllerBase
    {
        IMakerSpaceService _service;

        public MakerSpacesController(IMakerSpaceService service)
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
        public ActionResult<MakerSpaceReadDto> GetMakerSpaceById(Guid id)
        {
            try{
                return Ok(_service.GetMakerSpaceById(id));
            }
            catch(Exception e){
                
            }
            return NotFound();
        }

        /// <summary> This GET method returns search in DB and returns MakerSpace from DB by its name </summary>
        /// <returns>An MakerSpase</returns>
       
        [HttpGet("name/{name}")]
        public ActionResult<MakerSpaceReadDto> GetMakerSpaceByName(string name)
        {
            return Ok(_service.GetMakerSpaceByName(name));
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
        public ActionResult UpdateMakerSpace(Guid id, MakerSpaceCreateDto MakerSpaceCreateDto)
        {
            if (_service.UpdateMakerSpace(id, MakerSpaceCreateDto) == false)
            {
                return NotFound();
            }
            return NoContent();
        }

        /// <summary> This DELETE method delete MakerSpace from DB </summary>
        [HttpDelete("{id}")]
        public ActionResult DeleteMakerSpace(Guid id)
        {
            if (_service.DeleteMakerSpace(id) == false)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
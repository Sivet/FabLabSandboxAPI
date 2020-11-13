using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FabLabSandboxAPI.Models;
using FabLabSandboxAPI.Data.MachineData;
using AutoMapper;
using FabLabSandboxAPI.Dtos.MachineDto;
using FabLabSandboxAPI.Services;
using Microsoft.AspNetCore.JsonPatch;
using System;

namespace FabLabSandboxAPI.Controllers
{

    /// <summary>Controller responsible for GET/POST/DELETE for managing Machine </summary>
    [ApiController]
    [Route("api/Machine")]
    public class MachineController : ControllerBase
    {
        //private readonly IMachineRepo _repo;
        //private readonly IMapper _mapper;
        private MachineService _service;
        public MachineController(MachineService service)
        {
            _service = service;
            
        }
        /// <summary>This GET method returns all Machine from DB</summary>
        /// <returns>An arrey of MakerSpases</returns>
        [HttpGet]
        public ActionResult<IEnumerable<MachineReadDto>> GetAllMachine()
        {
            var Machine = _service.GetAllMachine();
            return Ok(Machine);
        }
        /// <summary> This GET method returns search in DB and returns Machine from DB by its ID </summary>
        /// <returns>An MakerSpase</returns>
        [HttpGet("{id}", Name = "GetMachineById")] //Named so the Post can use it
        public ActionResult<MachineReadDto> GetMachineById(Guid id)
        {
            var Machine = _service.GetMachineById(id);
            return Ok(Machine);
        }

        /// <summary> This GET method returns search in DB and returns Machine from DB by its name </summary>
        /// <returns>An MakerSpase</returns>
        [HttpGet("name/{name}")]
        public ActionResult<MachineReadDto> GetMachineByName(string name)
        {
            var Machine = _service.GetMachineByName(name);
            return Ok(Machine);
        }

        /// <summary> This POST method create Machine in DB </summary>
        /// <returns>returns createt MacerSpase url -/api/Machine/{created} </returns>
        [HttpPost]
        public ActionResult<MachineReadDto> CreateMachine(MachineCreateDto createDto)
        {
            _service.CreateMachine(createDto);


            return Created($"api/Machine", null);
        }

        ///<summary> This PUT method update Machine in DB </summary>
        [HttpPut("{id}")]
        public ActionResult UpdateMachine(Guid id, MachineCreateDto MachineCreateDto)
        {
            if (_service.UpdateMachine(id, MachineCreateDto) == false)
            {
                return NotFound();
            }
            
            return NoContent();
        }

        /// <summary> This PUT method purtial update Machine (not all but some colons in tabel in DB </summary>
        //Purtial update
        //PATCH api/Machine/{id}
       /* [HttpPatch("{id}")]
        public ActionResult PartialMachineUpdate(int id, JsonPatchDocument<MachineCreateDto> patchDoc)
        {
            var MachineModelFromRepo = _repo.GetMachineById(id);
            if (MachineModelFromRepo == null)
            {
                return NotFound();
            }
            var MachineToPatch = _mapper.Map<MachineCreateDto>(MachineModelFromRepo);
            patchDoc.ApplyTo(MachineToPatch, ModelState);
            if (!TryValidateModel(MachineToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(MachineToPatch, MachineModelFromRepo);
            _repo.UpdateMachine(MachineModelFromRepo);
            _repo.SaveChanges();

            return NoContent();
        }
       */
        /// <summary> This DELETE method delete Machine from DB </summary>
        [HttpDelete("{id}")]
        public ActionResult DeleteMachine(Guid id)
        {
           if (_service.DeleteMachine(id) == false)
           {
               return NotFound();
           }
           
           return NoContent();
        }

    }
}

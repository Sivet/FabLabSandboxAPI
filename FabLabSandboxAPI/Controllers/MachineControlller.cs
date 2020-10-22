using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FabLabSandboxAPI.Models;
using FabLabSandboxAPI.Data.MachineData;
using AutoMapper;
using FabLabSandboxAPI.Dtos.MachineDto;
using Microsoft.AspNetCore.JsonPatch;

namespace FabLabSandboxAPI.Controllers
{

    /// <summary>Controller responsible for GET/POST/DELETE for managing Machine </summary>
    [ApiController]
    [Route("api/Machine")]
    public class MachineController : ControllerBase
    {
        private readonly IMachineRepo _repo;
        private readonly IMapper _mapper;

        public MachineController(IMachineRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        /// <summary>This GET method returns all Machine from DB</summary>
        /// <returns>An arrey of MakerSpases</returns>
        [HttpGet]
        public ActionResult<IEnumerable<MachineReadDto>> GetAllMachine()
        {
            var Machine = _repo.GetAllMachines();
            return Ok(_mapper.Map<IEnumerable<MachineReadDto>>(Machine));
        }
        /// <summary> This GET method returns search in DB and returns Machine from DB by its ID </summary>
        /// <returns>An MakerSpase</returns>
        [HttpGet("{id}", Name = "GetMachineById")] //Named so the Post can use it
        public ActionResult<MachineReadDto> GetMachineById(int id)
        {
            var Machine = _repo.GetMachineById(id);
            return Ok(_mapper.Map<MachineReadDto>(Machine));
        }

        /// <summary> This GET method returns search in DB and returns Machine from DB by its name </summary>
        /// <returns>An MakerSpase</returns>
        [HttpGet("name/{name}")]
        public ActionResult<MachineReadDto> GetMachineByName(string name)
        {
            var Machine = _repo.GetMachineByName(name);
            return Ok(_mapper.Map<MachineReadDto>(Machine));
        }

        /// <summary> This POST method create Machine in DB </summary>
        /// <returns>returns createt MacerSpase url -/api/Machine/{created} </returns>
        [HttpPost]
        public ActionResult<MachineReadDto> CreateMachine(MachineCreateDto createDto)
        {
            var MachineModel = _mapper.Map<Machine>(createDto);
            _repo.CreateMachine(MachineModel);
            _repo.SaveChanges();

            var MachineReadDto = _mapper.Map<MachineReadDto>(MachineModel);

            return CreatedAtRoute(nameof(GetMachineById), new { Id = MachineReadDto.MachineId }, MachineReadDto);
        }

        ///<summary> This PUT method update Machine in DB </summary>
        [HttpPut("{id}")]
        public ActionResult UpdateMachine(int id, MachineCreateDto MachineCreateDto)
        {
            var MachineModelFromRepo = _repo.GetMachineById(id);
            if (MachineModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(MachineCreateDto, MachineModelFromRepo);
            _repo.UpdateMachine(MachineModelFromRepo);
            _repo.SaveChanges();

            return NoContent();
        }

        /// <summary> This PUT method purtial update Machine (not all but some colons in tabel in DB </summary>
        //Purtial update
        //PATCH api/Machine/{id}
        [HttpPatch("{id}")]
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

        /// <summary> This DELETE method delete Machine from DB </summary>
        [HttpDelete("{id}")]
        public ActionResult DeleteMachine(int id)
        {
            var MachineModel = _repo.GetMachineById(id);
            if (MachineModel == null)
            {
                return NotFound();
            }
            _repo.DeleteMachine(MachineModel);
            _repo.SaveChanges();
            return NoContent();
        }

    }
}

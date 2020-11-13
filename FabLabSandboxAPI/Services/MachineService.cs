using System;
using System.Collections.Generic;
using AutoMapper;
using FabLabSandboxAPI.Data.MachineData;
using FabLabSandboxAPI.Dtos.MachineDto;
using FabLabSandboxAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FabLabSandboxAPI.Services
{
    public class MachineService
    {

        /// <summary>Controller responsible for GET/POST/DELETE for managing Machine </summary>

        
        
            private readonly IMachineRepo _repo;
            private readonly IMapper _mapper;

            public MachineService(IMachineRepo repo, IMapper mapper)
            {
                _repo = repo;
                _mapper = mapper;
            }
           
            /// <summary>This GET method returns all Machine from DB</summary>
            /// <returns>An arrey of MakerSpases</returns>

            public IEnumerable<MachineReadDto> GetAllMachine()
            {
                var Machine = _repo.GetAllMachines();
                return _mapper.Map<IEnumerable<MachineReadDto>>(Machine);
            }
            /// <summary> This GET method returns search in DB and returns Machine from DB by its ID </summary>
            /// <returns>An MakerSpase</returns>

            public MachineReadDto GetMachineById(Guid id)
            {
                var Machine = _repo.GetMachineById(id);
                return _mapper.Map<MachineReadDto>(Machine);
            }

            /// <summary> This GET method returns search in DB and returns Machine from DB by its name </summary>
            /// <returns>An MakerSpase</returns>
            public MachineReadDto GetMachineByName(string name)
            {
                var Machine = _repo.GetMachineByName(name);
                return _mapper.Map<MachineReadDto>(Machine);
            }

            /// <summary> This POST method create Machine in DB </summary>
            /// <returns>returns createt MacerSpase url -/api/Machine/{created} </returns>
           
            public MachineReadDto CreateMachine(MachineCreateDto createDto)
            {
                var MachineModel = _mapper.Map<Machine>(createDto);
                _repo.CreateMachine(MachineModel);
                _repo.SaveChanges();

                return _mapper.Map<MachineReadDto>(MachineModel);

            }

            ///<summary> This PUT method update Machine in DB </summary>
            public bool UpdateMachine(Guid id, MachineCreateDto MachineCreateDto)
            {
                var MachineModelFromRepo = _repo.GetMachineById(id);
                if (MachineModelFromRepo == null)
                {
                    return false;
                }

                _mapper.Map(MachineCreateDto, MachineModelFromRepo);
                _repo.UpdateMachine(MachineModelFromRepo);
                _repo.SaveChanges();

                return true;
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
            }*/

            /// <summary> This DELETE method delete Machine from DB </summary>
            public bool  DeleteMachine(Guid id)
            {
                var MachineModel = _repo.GetMachineById(id);
                if (MachineModel == null)
                {
                    return false;
                }
                _repo.DeleteMachine(MachineModel);
                _repo.SaveChanges();
                return true;
            }

        
    }
}

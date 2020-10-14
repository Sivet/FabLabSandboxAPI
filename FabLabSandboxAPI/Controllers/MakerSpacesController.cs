using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FabLabSandboxAPI.Models;
using FabLabSandboxAPI.Data;
using AutoMapper;
using FabLabSandboxAPI.Dtos;

namespace FabLabSandboxAPI.Controllers
{
    [Route("api/MakerSpaces")]
    [ApiController]
    public class MakerSpacesController : ControllerBase
    {
        private readonly IMakerSpaceRepo _repo;
        private readonly IMapper _mapper;

        public MakerSpacesController(IMakerSpaceRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<MakerSpaceReadDto>> GetAllMakerSpaces()
        {
            var makerSpaces = _repo.GetAllMakerSpaces();
            return Ok(_mapper.Map<IEnumerable<MakerSpaceReadDto>>(makerSpaces));
        }
        [HttpGet("{id}", Name="GetMakerSpaceById")] //Named so the Post can use it
        public ActionResult<MakerSpaceReadDto> GetMakerSpaceById(int id)
        {
            var makerSpace = _repo.GetMakerSpaceById(id);
            return Ok(_mapper.Map<MakerSpaceReadDto>(makerSpace));
        }
        [HttpGet("name/{name}")]
        public ActionResult<MakerSpaceReadDto> GetMakerSpaceByName(string name)
        {
            var makerSpace = _repo.GetMakerSpaceByName(name);
            return Ok(_mapper.Map<MakerSpaceReadDto>(makerSpace));
        }
        [HttpPost]
        public ActionResult<MakerSpaceReadDto> CreateMakerSpace(MakerSpaceCreateDto createDto){
            var makerSpaceModel = _mapper.Map<MakerSpace>(createDto);
            _repo.CreateMakerSpace(makerSpaceModel);
            _repo.SaveChanges();

            var makerSpaceReadDto = _mapper.Map<MakerSpaceReadDto>(makerSpaceModel);

            return CreatedAtRoute(nameof(GetMakerSpaceById),new {Id = makerSpaceReadDto.Id}, makerSpaceReadDto);
        }
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
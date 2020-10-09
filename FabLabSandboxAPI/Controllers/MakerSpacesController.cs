using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FabLabSandboxAPI.Models;
using FabLabSandboxAPI.Data;

namespace FabLabSandboxAPI.Controllers
{
    [Route("api/MakerSpaces")]
    [ApiController]
    public class MakerSpacesController : ControllerBase
    {
        private readonly IMakerSpaceRepo _repo;
        public MakerSpacesController(IMakerSpaceRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public ActionResult<IEnumerable<MakerSpace>> GetAllMakerSpaces()
        {
            var makerSpaces = _repo.GetAllMakerSpaces();
            return Ok(makerSpaces);
        }
        [HttpGet("{id}")]
        public ActionResult<MakerSpace> GetMakerSpaceById(int id)
        {
            var makerSpace = _repo.GetMakerSpaceById(id);
            return Ok(makerSpace);
        }
        [HttpGet("name/{name}")]
        public ActionResult<MakerSpace> GetMakerSpaceByName(string name)
        {
            var makerSpace = _repo.GetMakerSpaceByName(name);
            return Ok(makerSpace);
        }
    }
}
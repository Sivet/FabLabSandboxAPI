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
        private readonly MockRepo _mockRepo = new MockRepo();
        [HttpGet]
        public ActionResult<IEnumerable<MakerSpace>> GetAllMakerSpaces()
        {
            var makerSpaces = _mockRepo.GetAllMakerSpaces();
            return Ok(makerSpaces);
        }
        [HttpGet("{id}")]
        public ActionResult<MakerSpace> GetMakerSpaceById(int id)
        {
            var makerSpace = _mockRepo.GetMakerSpaceById(id);
            return Ok(makerSpace);
        }
        [HttpGet("name/{name}")]
        public ActionResult<MakerSpace> GetMakerSpaceByName(string name)
        {
            var makerSpace = _mockRepo.GetMakerSpaceByName(name);
            return Ok(makerSpace);
        }
    }
}
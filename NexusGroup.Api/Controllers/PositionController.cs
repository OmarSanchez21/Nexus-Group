using Microsoft.AspNetCore.Mvc;
using NexusGroup.Service.Services.Positions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NexusGroup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly iPositionsService _positionsService;
        public PositionController(iPositionsService service)
        {
            this._positionsService = service;
        }
        // GET: api/<PositionController>
        [HttpGet]
        public async Task<IActionResult>Getll()
        {
            var result = await _positionsService.GetAll();
            if (!result.Success)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // GET api/<PositionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PositionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PositionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PositionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

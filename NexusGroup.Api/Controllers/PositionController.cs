using Microsoft.AspNetCore.Mvc;
using NexusGroup.Service.DTOs.Position;
using NexusGroup.Service.Services.Positions;
using Swashbuckle.AspNetCore.Annotations;
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
        [SwaggerOperation(Summary = "Get All Position", Description = "Adds a new position to the database")]
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
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0) 
            {
                return NotFound("The position not can be 0");
            }
            var result = await _positionsService.GetValue(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // POST api/<PositionController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddPosition position)
        {
            if (position == null)
            {
                return NotFound("Position data is null");
            }
            var result = await _positionsService.Save(position);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // PUT api/<PositionController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdatePosition update)
        {
            if(update == null)
            {
                return NotFound("Position data is null");
            }
            var result = await _positionsService.Update(update);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // DELETE api/<PositionController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(id == 0)
            {
                return NotFound("The Id is not can be zero");
            }
            var result = await _positionsService.Delete(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using NexusGroup.Service.DTOs.AccessLevels;
using NexusGroup.Service.DTOs.JobOffers;
using NexusGroup.Service.DTOs.Position;
using NexusGroup.Service.Services.JobOffers;
using NexusGroup.Service.Services.Positions;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NexusGroup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobOffersControllers : ControllerBase
    {
        private readonly iJobOffersService _serivce;
        public JobOffersControllers(iJobOffersService service)
        {
            this._serivce = service;
        }
        // GET: api/<PositionController>
        [HttpGet]
        [SwaggerOperation(Summary = "Get All Position", Description = "Adds a new position to the database")]
        public async Task<IActionResult> Getll()
        {
            var result = await this._serivce.GetAll();
            if (!result.Success)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("deleted")]
        public async Task<IActionResult> GetDeleted()
        {
            var result = await this._serivce.GetAllDeleted();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        // GET api/<PositionController>/5
        [HttpGet("value/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
            {
                return NotFound("The job offer ID not can be 0");
            }
            var result = await _serivce.GetValue(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // POST api/<PositionController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddJobOffers position)
        {
            if (position == null)
            {
                return NotFound("The Job Offer data is null");
            }
            var result = await _serivce.Save(position);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // PUT api/<PositionController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateJobOffers update)
        {
            if (update == null)
            {
                return NotFound("The job Offer data is null");
            }
            var result = await _serivce.Update(update);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // DELETE api/<PositionController>/5
        [HttpPut("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound("The Id is not can be zero");
            }
            var result = await _serivce.Delete(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut("recover/{id}")]
        public async Task<IActionResult> Recover(int id)
        {
            if (id == 0)
            {
                return NotFound("The Id can't be zero");
            }
            var result = await this._serivce.Recover(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            if (id == 0)
            {
                return NotFound("The Id can't be zero");
            }
            var result = await this._serivce.Remove(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}

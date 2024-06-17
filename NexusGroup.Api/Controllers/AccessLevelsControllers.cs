using Microsoft.AspNetCore.Mvc;
using NexusGroup.Service.DTOs.AccessLevels;
using NexusGroup.Service.Services.AccessLevels;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NexusGroup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessLevelsControllers : ControllerBase
    {
        private readonly iAccessLevelsService service;
        public AccessLevelsControllers(iAccessLevelsService accessLevelsService)
        {
            this.service = accessLevelsService;
        }
        // GET: api/<AccessLevelsControllers>
        [HttpGet("")]
        [SwaggerOperation(Summary = "Get All Access Level")]
        public async Task<IActionResult> Get()
        {
            var result = await service.GetAll();
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
        //GET api/<AccessLevelsControllers>/deleted
        [HttpGet("deleted")]
        public async Task<IActionResult> GetDeleted()
        {
            var result = await this.service.GetAllDeleted();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        // GET api/<AccessLevelsControllers>/value/5
        [HttpGet("value/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
            {
                return NotFound("The access level not can be 0");
            }
            var result = await this.service.GetValue(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // POST api/<AccessLevelsControllers>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddAccessLevels add)
        {
            if (add.Name == Empty.ToString())
            {
                return NotFound("The access level data is null");
            }
            var result = await this.service.SaveAccessLevels(add);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // PUT api/<AccessLevelsControllers>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateAccessLevels update)
        {
            if (update == null)
            {
                return NotFound("Access Level data is null");
            }
            var result = await this.service.EditAccessLevels(update);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // DELETE api/<AccessLevelsControllers>/5
        [HttpPut("recover/{id}")]
        public async Task<IActionResult> Recover(int id)
        {
            if (id == 0)
            {
                return NotFound("The Id can't be zero");
            }
            var result = await this.service.Recover(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound("The Id can't be zero");
            }
            var result = await this.service.Delete(id);
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
            var result = await this.service.Remove(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}

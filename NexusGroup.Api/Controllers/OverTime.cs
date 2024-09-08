using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexusGroup.Service.DTOs;
using NexusGroup.Service.Services.OverTime;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NexusGroup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OverTime : ControllerBase
    {
        private readonly IOverTimeService _service;
        public OverTime(IOverTimeService overTimeService)
        {
            _service = overTimeService;
        }
        // GET: api/<OverTime>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAll();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("deleted")]
        public async Task<IActionResult> GetDeleted()
        {
            var result = await _service.GetAllDeletd();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        // GET api/<Position>/5
        [HttpGet("value/{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.Get(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // POST api/<Position>
        [HttpPost("add")]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] AddOverTimeDTO dto)
        {
            var result = await _service.Add(dto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // PUT api/<Position>/5
        [HttpPut("edit")]
        [Authorize]
        public async Task<IActionResult> Put([FromBody] EditOverTimeDTO dto)
        {
            var result = await _service.Edit(dto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut("remove/{id}")]
        [Authorize]
        public async Task<IActionResult> Remove(int id)
        {
            var result = await _service.Delete(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut("recover/{id}")]
        [Authorize]
        public async Task<IActionResult> Recover(int id)
        {
            var result = await _service.Recover(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        // DELETE api/<Position>/5
        [HttpDelete("delete/{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeletePermantly(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}

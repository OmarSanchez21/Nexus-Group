using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexusGroup.Service.Services.AccessLevels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NexusGroup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessLevels : ControllerBase
    {
        private readonly IAccessLevelsServices _service;
        public AccessLevels(IAccessLevelsServices accessLevelsServices)
        {
            _service = accessLevelsServices;
        }
        // GET: api/<AccessLevels>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAll();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("value/{id}")]
        [Authorize]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _service.GetValue(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}

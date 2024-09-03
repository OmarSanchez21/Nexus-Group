using Microsoft.AspNetCore.Mvc;
using NexusGroup.Service.DTOs;
using NexusGroup.Service.Services.Auth;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NexusGroup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Auth : ControllerBase
    {
        private readonly IAuthService _service;
        public Auth(IAuthService authService)
        {
            _service = authService;
        }
        // GET: api/<Auth>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Auth>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Auth>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AuthDTO dto)
        {
            var result = await _service.Login(dto.Username, dto.Password);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        // PUT api/<Auth>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Auth>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

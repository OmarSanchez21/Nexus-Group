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

    }
}

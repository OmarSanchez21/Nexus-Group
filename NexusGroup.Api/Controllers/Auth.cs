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
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthDTO dto)
        {
            var result = await _service.Login(dto.Username, dto.Password);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO dto)
        {
            var result = await _service.ChangePassword(dto.Id, dto.newPassword);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}

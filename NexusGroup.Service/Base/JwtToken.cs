using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NexusGroup.Data.Repositories.Auth;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Base
{
    public interface IJwtTokenHelper
    {
        Task<string> GenerateToken(LoginResult login);
    }
    public class JwtTokenHelper : IJwtTokenHelper
    {
        private readonly IConfiguration _configuration;
        public JwtTokenHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Task<string> GenerateToken(LoginResult login)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, login.UserName),
                new Claim("FullName", login.FullName),
                new Claim(ClaimTypes.Email, login.Email),
                new Claim("AccessLevel", login.AccessLevels),
                new Claim("PositionID", login.PositionId.ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["JWT:ExpiresInMinutes"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Task.FromResult(tokenHandler.WriteToken(token));
        }
    }
}

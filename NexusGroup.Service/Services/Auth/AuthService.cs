using NexusGroup.Data.Repositories.Auth;
using NexusGroup.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepositories _repositories;   
        public async Task<ServiceResult> Login(string username, string password)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var loing = await _repositories.Login(username);
                if (loing == null)
                {
                    result.Success = false;
                    result.Message = "User not found";
                    return result;
                }
                if(!BCrypt.Net.BCrypt.Verify(password, loing.PasswordHash))
                {
                    result.Success = false;
                    result.Message = "Password incorrect";
                    return result;
                }
                result.Message = "Login Success";
            }
            catch (Exception)
            {

                throw;
            }
            return result;

        }
    }
}

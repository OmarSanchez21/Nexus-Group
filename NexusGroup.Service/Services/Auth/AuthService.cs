using NexusGroup.Data.Repositories.Auth;
using NexusGroup.Service.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepositories _repositories;
        private readonly IJwtTokenHelper _token;
        public AuthService(IAuthRepositories authRepositories, IJwtTokenHelper token)
        {
            _repositories = authRepositories;
            _token = token;
        }
        public async Task<ServiceResult> Login(string username, string password)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var login = await _repositories.Login(username);
                if (login == null)
                {
                    result.Success = false;
                    result.Message = ServiceMessages.LoginFail;
                    return result;
                }
                if (!BCrypt.Net.BCrypt.Verify(password, login.PasswordHash))
                {
                    result.Success = false;
                    result.Message = ServiceMessages.LoginFail;
                    return result;
                }
                var token = await _token.GenerateToken(login);
                result.Message = ServiceMessages.LoginSuccess;
                result.Data = token;
            }
            catch (SqlException sqlexception)
            {
                string accion = ServiceMessages.LogHelper("_", "Login");
                new LogConfiguration.ExceptionServer(accion, sqlexception);
                result.Success = false;
                result.Message = ServiceMessages.DatabaseError;
                result.Data = sqlexception.Message;
                return result;

            }
            catch (Exception ex)
            {
                string accion = ServiceMessages.LogHelper("_", "Login");
                new LogConfiguration.ExceptionServer(accion, ex);
                result.Success = false;
                result.Message = ServiceMessages.InternalError;
                result.Data = ex.Message;
                return result;
            }
            return result;
        }
        public async Task<ServiceResult> ChangePassword(int id, string password)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                string passwordHash = FuncCore.HashPassword(password);
                var rowsAffected = await _repositories.ChangePassword(id, passwordHash);
                if (rowsAffected <= 0)
                {
                    result.Success = false;
                    result.Message = ServiceMessages.PasswordFail;
                    return result;
                }
                result.Message = ServiceMessages.PasswordSuccess;
            }
            catch (SqlException sqlexception)
            {
                string accion = ServiceMessages.LogHelper("_", "Change Password");
                new LogConfiguration.ExceptionServer(accion, sqlexception);
                result.Success = false;
                result.Message = ServiceMessages.DatabaseError;
                result.Data = sqlexception.Message;
                return result;

            }
            catch (Exception ex)
            {
                string accion = ServiceMessages.LogHelper("_", "Change Password");
                new LogConfiguration.ExceptionServer(accion, ex);
                result.Success = false;
                result.Message = ServiceMessages.InternalError;
                result.Data = ex.Message;
                return result;
            }
            return result;
        }
    }
}

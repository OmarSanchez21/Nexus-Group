using Dapper;
using NexusGroup.Data.BaseData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Data.Repositories.Auth
{
    public class LoginResult
    {
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string AccessLevels { get; set; }
    }
    public class AuthRepositories : IAuthRepositories
    {
        private readonly IDapperContext _dapperContext;
        public AuthRepositories(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public Task<int> ChangePassword(int id, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<LoginResult> Login(string username)
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Username", username);
                parameters.Add("@Password", dbType: DbType.String, size:355 ,direction: ParameterDirection.Output);
                parameters.Add("@FullName", dbType: DbType.String,size:150, direction: ParameterDirection.Output);
                parameters.Add("@AccessLevels", dbType: DbType.String,size:5, direction: ParameterDirection.Output);
                parameters.Add("@MessageCode", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await connection.ExecuteAsync("sp_Login", parameters, commandType: CommandType.StoredProcedure);
                var password = parameters.Get<string>("@Password");
                var fullname = parameters.Get<string>("@FullName");
                var access = parameters.Get<string>("@AccessLevels");
                return new LoginResult
                {
                    FullName = fullname,
                    PasswordHash = password,
                    AccessLevels = access
                };
            }
        }
    }
}

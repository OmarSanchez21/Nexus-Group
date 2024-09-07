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
        public string Email { get; set; }
        public string AccessLevels { get; set; }
        public int PositionId { get; set; }
        public string UserName { get; set; }
    }
    public class AuthRepositories : IAuthRepositories
    {
        private readonly IDapperContext _dapperContext;
        public AuthRepositories(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<int> ChangePassword(int id, string password)
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                var paramaters = new DynamicParameters();
                paramaters.Add("@Id", id);
                paramaters.Add("@Password", password);
                paramaters.Add("@RowsAffected", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await connection.ExecuteAsync("sp_ChangePassword", paramaters, commandType: CommandType.StoredProcedure);
                int rows = paramaters.Get<int>("@RowsAffected");
                return rows;
            }
        }

        public async Task<LoginResult> Login(string username)
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Username", username);
                parameters.Add("@Password", dbType: DbType.String, size:355 ,direction: ParameterDirection.Output);
                parameters.Add("@FullName", dbType: DbType.String,size:150, direction: ParameterDirection.Output);
                parameters.Add("@Email", dbType: DbType.String, size: 100, direction: ParameterDirection.Output);
                parameters.Add("@AccessLevels", dbType: DbType.String,size:5, direction: ParameterDirection.Output);
                parameters.Add("@UserOut", dbType: DbType.String, size: 75, direction: ParameterDirection.Output);
                parameters.Add("@PositionId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@MessageCode", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await connection.ExecuteAsync("sp_Login", parameters, commandType: CommandType.StoredProcedure);
                var password = parameters.Get<string>("@Password");
                var fullname = parameters.Get<string>("@FullName");
                var email = parameters.Get<string>("@Email");
                var access = parameters.Get<string>("@AccessLevels");
                var userout = parameters.Get<string>("@UserOut");
                var position = parameters.Get<int>("@PositionId");
                return new LoginResult
                {
                    FullName = fullname,
                    PasswordHash = password,
                    AccessLevels = access,
                    Email = email,
                    UserName = userout,
                    PositionId = position
                };
            }
        }
    }
}

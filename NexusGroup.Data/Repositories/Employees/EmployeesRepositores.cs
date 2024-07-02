using Dapper;
using NexusGroup.Data.Base;
using NexusGroup.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using static Dapper.SqlMapper;

namespace NexusGroup.Data.Repositories.Employees
{
    public class EmployeesRepositores : IEmployeesRepositories
    {
        private readonly IDapperDBConnection _dbConnection;
        public EmployeesRepositores(IDapperDBConnection connection)
        {
            this._dbConnection = connection;
        }
        public async Task<IEnumerable<EmployeesModels>> GetAll()
        {
            using(IDbConnection db = _dbConnection.CreateConnection())
            {
                return await db.QueryAsync<EmployeesModels>("getAllEmployees", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<EmployeesModels>> GetAllDeleted()
        {
            using (IDbConnection db = _dbConnection.CreateConnection())
            {
                return await db.QueryAsync<EmployeesModels>("getAllEmployeesDeleted", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<EmployeesModels> GetByID(int id)
        {
            using (IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new { Id = id };
                return await db.QueryFirstOrDefaultAsync<EmployeesModels>("getIdEmployees", parameters ,commandType: CommandType.StoredProcedure);
            }
        }
        public async Task Add(EmployeesModels entity)
        {
            using (IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new {
                    Name = entity.name,
                    LastName = entity.lastName,
                    Photo = entity.photo,
                    Email = entity.email,
                    Username = entity.username,
                    PasswordHash = entity.passwordHash,
                    JoinDate = entity.joinDate,
                    PositionID = entity.positionID,
                    AccessLevelID = entity.accessLevelID
                };
               await db.ExecuteAsync("addEmployees", parameters ,commandType: CommandType.StoredProcedure);
            }
        }

        public async Task Delete(int id)
        {
            using (IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new
                {
                   Id = id
                };
                await db.ExecuteAsync("editEmployees", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task Recover(int id)
        {
            using (IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new { Id = id };
                await db.ExecuteAsync("recoverEmployees", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task RemovePermantly(int id)
        {
            using (IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new { Id = id };
                await db.ExecuteAsync("removePermEmployees", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task Update(EmployeesModels entity)
        {
            using (IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new
                {
                    Name = entity.name,
                    LastName = entity.lastName,
                    Photo = entity.photo,
                    Email = entity.email,
                    Username = entity.username,
                    JoinDate = entity.joinDate,
                    PositionID = entity.positionID,
                    AccessLevelID = entity.accessLevelID,
                    UpdatedRegistration = entity.updatedRegistration
                };
                await db.ExecuteAsync("editEmployees", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task ChangePassword(int id, string password)
        {
            using(IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new
                {
                    Id = id,
                    Password = password
                };
                await db.ExecuteAsync("ChangePassword", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

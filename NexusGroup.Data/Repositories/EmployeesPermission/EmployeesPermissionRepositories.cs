using Dapper;
using NexusGroup.Data.Base;
using NexusGroup.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Data.Repositories.EmployeesPermission
{
    public class EmployeesPermissionRepositories : iEmployeesPermissionRepositories
    {
        private readonly IDapperDBConnection _dbConnection;
        public EmployeesPermissionRepositories(IDapperDBConnection dBConnection)
        {
            this._dbConnection = dBConnection;
        }
        public async Task Add(EmployeesPermissionModels entity)
        {
            using(IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new
                {
                    EmployeeID = entity.employeeID,
                    PermissionType = entity.permissionType,
                    StartDate = entity.startDate,
                    EndDate = entity.endDate,
                    RequestDate = entity.requestDate,
                    isAproved = entity.isAproved,
                };
                await db.QueryAsync<EmployeesPermissionModels>("addEmployeesPermissions", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task Delete(int id)
        {
            using(IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new { Id = id };
                await db.ExecuteAsync("deleteEmployeesPermissions", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<EmployeesPermissionModels>> GetAll()
        {
            using(IDbConnection db = _dbConnection.CreateConnection())
            {
                return await db.QueryAsync<EmployeesPermissionModels>("getAllEmployeesPermission", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<EmployeesPermissionModels>> GetAllDeleted()
        {
            using(IDbConnection db = _dbConnection.CreateConnection())
            {
                return await db.QueryAsync<EmployeesPermissionModels>("getAllEmployeesPermissionDeleted", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<EmployeesPermissionModels> GetByID(int id)
        {
            using(IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new { Id = id };
                return await db.QueryFirstOrDefaultAsync<EmployeesPermissionModels>("getIdEmployeesPermissions", parameters, commandType: CommandType.StoredProcedure); 
            }
        }

        public async Task Recover(int id)
        {
            using(IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new { Id = id };
                await db.ExecuteAsync("recoverEmployeesPermissions", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task RemovePermantly(int id)
        {
            using(IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new { Id = id };
                await db.ExecuteAsync("removePermEmployeesPermission", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task Update(EmployeesPermissionModels entity)
        {
            using(IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new
                {
                    Id = entity.permissionID,
                    EmployeeID = entity.employeeID,
                    PermissionType = entity.permissionType,
                    StartDate = entity.startDate,
                    EndDate = entity.endDate,
                    isAproved = entity.isAproved,
                    UpdateRegistration = entity.updatedRegistration
                };
                await db.QueryAsync<EmployeesPermissionModels>("editEmployeesPermissions", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

using NexusGroup.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NexusGroup.Data.BaseData;
using Dapper;
using System.Data;
namespace NexusGroup.Data.Repositories.EmployeesPermission
{
    public class EmployeesPermissionRepositories : IEmployeesPermissionRepositories
    {
        private readonly IDapperContext _dapperContext;
        public EmployeesPermissionRepositories(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<int> Add(M_EmployeesPermission entity)
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                var paramaters = new DynamicParameters();
                paramaters.Add("@EmployeeID", entity.EmployeeID);
                paramaters.Add("@PermissionType", entity.PermissionType);
                paramaters.Add("@StartDate", entity.StartDate);
                paramaters.Add("@EndDate", entity.EndDate);
                paramaters.Add("IsRequest", entity.IsRequest);
                paramaters.Add("ApprovedDate", entity.ApprovedDate);
                paramaters.Add("@RowsAffected", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await connection.ExecuteAsync("spAddEmployeesPermission", paramaters, commandType: CommandType.StoredProcedure);
                int rowsAffected = paramaters.Get<int>("@RowsAffected");
                return rowsAffected;
            }
        }

        public async Task<int> Delete(int id)
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                var paramaters = new DynamicParameters();
                paramaters.Add("@Id", id);
                paramaters.Add("@RowsAffected", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await connection.ExecuteAsync("spDeleteEmployeesPermission", paramaters, commandType: CommandType.StoredProcedure);
                int rowsAffected = paramaters.Get<int>("@RowsAffected");
                return rowsAffected;
            }
        }

        public async Task<int> DeletePermantly(int id)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var paramaters = new DynamicParameters();
                paramaters.Add("@Id", id);
                paramaters.Add("@RowsAffected", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await connection.ExecuteAsync("spDeletePermantlyzEmployeesPermission", paramaters, commandType: CommandType.StoredProcedure);
                int rowsAffected = paramaters.Get<int>("@RowsAffected");
                return rowsAffected;
            }
        }

        public async Task<int> Edit(M_EmployeesPermission entity)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var paramaters = new DynamicParameters();
                paramaters.Add("@Id", entity.EmployeesPermissionID);
                paramaters.Add("@EmployeeID", entity.EmployeeID);
                paramaters.Add("@PermissionType", entity.PermissionType);
                paramaters.Add("@StartDate", entity.StartDate);
                paramaters.Add("@EndDate", entity.EndDate);
                paramaters.Add("IsRequest", entity.IsRequest);
                paramaters.Add("ApprovedDate", entity.ApprovedDate);
                paramaters.Add("@RowsAffected", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await connection.ExecuteAsync("spEditEmployeesPermission", paramaters, commandType: CommandType.StoredProcedure);
                int rowsAffected = paramaters.Get<int>("@RowsAffected");
                return rowsAffected;
            }
        }

        public async Task<IEnumerable<M_EmployeesPermission>> GetAll()
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                return await connection.QueryAsync<M_EmployeesPermission>("spGetAllEmployeesPermission", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<M_EmployeesPermission>> GetAllDeleted()
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                return await connection.QueryAsync<M_EmployeesPermission>("spGetAllEmployeesPermissionDeleted", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<M_EmployeesPermission> GetValue(int id)
        {
            using (var connection = _dapperContext.CreateConnection()) 
            {
                var paramaters = new DynamicParameters();
                paramaters.Add("@Id", id);
                return await connection.QueryFirstOrDefaultAsync<M_EmployeesPermission>("spGetEmployeesPermission", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> Recover(int id)
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                parameters.Add("@RowsAffected", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await connection.ExecuteAsync("spRecoverEmployeesPermission", commandType: CommandType.StoredProcedure);
                int rowsAffected = parameters.Get<int>("@RowsAffected");
                return rowsAffected;
            }
        }
    }
}

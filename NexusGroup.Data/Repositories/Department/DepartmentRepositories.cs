using Dapper;
using NexusGroup.Data.BaseData;
using NexusGroup.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Data.Repositories.Department
{
    public class DepartmentRepositories : IDepartmentRepositories
    {
        private readonly IDapperContext _dapperContext;
        public DepartmentRepositories(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;   
        }
        public async Task<int> Add(M_Department entity)
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Name", entity.Name);
                parameters.Add("@ManagerID", entity.ManagerID);
                parameters.Add("@RowsAffected", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await connection.ExecuteAsync("spAddDepartment", parameters, commandType: CommandType.StoredProcedure);
                int rowsAffected = parameters.Get<int>("@RowsAffected");
                return rowsAffected;
            }
        }

        public async Task<int> Delete(int id)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                parameters.Add("@RowsAffected", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await connection.ExecuteAsync("spDeleteDepartment", parameters, commandType: CommandType.StoredProcedure);
                int rowsAffected = parameters.Get<int>("@RowsAffected");
                return rowsAffected;
            }
        }

        public async Task<int> DeletePermantly(int id)
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                parameters.Add("@RowsAffected", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await connection.ExecuteAsync("spDeletePermantlyDepartment", parameters, commandType: CommandType.StoredProcedure);
                int rowsAffected = parameters.Get<int>("@RowsAffected");
                return rowsAffected;
            }
        }

        public async Task<int> Edit(M_Department entity)
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", entity.DepartmentID);
                parameters.Add("@Name", entity.Name);
                parameters.Add("@ManagerID", entity.ManagerID);
                parameters.Add("@RowsAffected", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await connection.ExecuteAsync("spEditDepartment", parameters, commandType: CommandType.StoredProcedure);
                int rowsAffected = parameters.Get<int>("@RowsAffected");
                return rowsAffected;
            }
        }

        public async Task<IEnumerable<M_Department>> GetAll()
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                return await connection.QueryAsync<M_Department>("spGetAllDepartment", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<M_Department>> GetAllDeleted()
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                return await connection.QueryAsync<M_Department>("spGetAllDepartmentDeleted", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<M_Department> GetValue(int id)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                return await connection.QueryFirstOrDefaultAsync<M_Department>("spGetDepartment", parameters, commandType: CommandType.StoredProcedure); ;
            }
        }
        public async Task<int> Recover(int id)
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                parameters.Add("@RowsAffected", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await connection.ExecuteAsync("spRecoverDepartment", parameters, commandType: CommandType.StoredProcedure);
                int rowsAffected = parameters.Get<int>("@RowsAffected");
                return rowsAffected;
            }
        }
    }
}

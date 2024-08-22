using Dapper;
using NexusGroup.Data.BaseData;
using NexusGroup.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Data.Repositories.Employees
{
    public class EmployeesRepositories : IEmployeesRepositories
    {
        private readonly IDapperContext _dapperContext;
        public EmployeesRepositories(IDapperContext context)
        {
            _dapperContext = context;
        }
        public async Task<int> Add(M_Employees entity)
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Cedula", entity.Cedula);
                parameters.Add("@FirstName", entity.FirstName);
                parameters.Add("@LastName", entity.LastName);
                parameters.Add("@Email", entity.Email);
                parameters.Add("@Username", entity.Username);
                parameters.Add("@Password", entity.Password);
                parameters.Add("@PhotoURL", entity.photoURL);
                parameters.Add("@Salary", entity.Salary);
                parameters.Add("@PositionID", entity.PositionID);
                parameters.Add("@AccessLevelsID", entity.AccessLevelsID);
                return await connection.ExecuteAsync("spAddEmployees", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> Delete(int id)
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                return await connection.ExecuteAsync("spDeleteEmployees", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> DeletePermantly(int id)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                return await connection.ExecuteAsync("spDeletePermantlyEmployees", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> Edit(M_Employees entity)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", entity.EmployeeID);
                parameters.Add("@Cedula", entity.Cedula);
                parameters.Add("@FirstName", entity.FirstName);
                parameters.Add("@LastName", entity.LastName);
                parameters.Add("@Email", entity.Email);
                parameters.Add("@Username", entity.Username);
                parameters.Add("@Password", entity.Password);
                parameters.Add("@PhotoURL", entity.photoURL);
                parameters.Add("@Salary", entity.Salary);
                parameters.Add("@PositionID", entity.PositionID);
                parameters.Add("@AccessLevelsID", entity.AccessLevelsID);
                return await connection.ExecuteAsync("spEditEmployees", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<M_Employees>> GetAll()
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                return await connection.QueryAsync<M_Employees>("spGetAllEmployees", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<M_Employees>> GetAllDeleted()
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                return await connection.QueryAsync<M_Employees>("spGetAllEmployeesDeleted", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<M_Employees> GetValue(int id)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                return await connection.QueryFirstOrDefaultAsync<M_Employees>("spGetEmployees", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public async  Task<int> Recover(int id)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                return await connection.ExecuteAsync("spRecoverEmployees", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

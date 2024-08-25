using Dapper;
using NexusGroup.Data.BaseData;
using NexusGroup.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Data.Repositories.OverTime
{
    public class OverTimeRepositories : IOverTimeRepositories
    {
        private readonly IDapperContext _dapperContext;
        public OverTimeRepositories(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<int> Add(M_Overtime entity)
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeID", entity.EmployeeID);
                parameters.Add("@WorkDate", entity.WorkDate);
                parameters.Add("@ExtrasHours", entity.ExtraHours);
                parameters.Add("@HourlyRate", entity.HourlyRate);
                return await connection.ExecuteAsync("spAddOverTime", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> Delete(int id)
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                return await connection.ExecuteAsync("spDeleteOverTime", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> DeletePermantly(int id)
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                return await connection.ExecuteAsync("spDeletePermantlyOverTime", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> Edit(M_Overtime entity)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", entity.OverTimeID);
                parameters.Add("@EmployeeID", entity.EmployeeID);
                parameters.Add("@WorkDate", entity.WorkDate);
                parameters.Add("@ExtrasHours", entity.ExtraHours);
                parameters.Add("@HourlyRate", entity.HourlyRate);
                return await connection.ExecuteAsync("spEditOverTime", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<M_Overtime>> GetAll()
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                return await connection.QueryAsync<M_Overtime>("spGetAllOverTime", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<M_Overtime>> GetAllDeleted()
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                return await connection.QueryAsync<M_Overtime>("spGetAllOverTimeDeleted", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<M_Overtime> GetValue(int id)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                return await connection.QueryFirstOrDefaultAsync<M_Overtime>("spGetOverTime", parameters, commandType: CommandType.StoredProcedure);
            }
        } 
        public async Task<int> Recover(int id)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                return await connection.ExecuteAsync("spRecoverOverTime", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

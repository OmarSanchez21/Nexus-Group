using Dapper;
using NexusGroup.Data.BaseData;
using NexusGroup.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Data.Repositories.Training
{
    public class TrainingRepositories : ITrainingRepositories
    {
        private readonly IDapperContext _dapperContext;
        public TrainingRepositories(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<int> Add(M_Training entity)
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeID", entity.EmployeeID);
                parameters.Add("@TrainingDate", entity.TrainingDate);
                parameters.Add("@TrainingDescription", entity.TrainingDescription);
                parameters.Add("@RowsAffected", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await connection.ExecuteAsync("spAddTraining", parameters, commandType: CommandType.StoredProcedure);
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
                await connection.ExecuteAsync("spPermantlyTraining", parameters, commandType: CommandType.StoredProcedure);
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
                await connection.ExecuteAsync("spDeletePermantlyTraining", parameters, commandType: CommandType.StoredProcedure);
                int rowsAffected = parameters.Get<int>("@RowsAffected");
                return rowsAffected;
            }
        }

        public async Task<int> Edit(M_Training entity)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", entity.TrainingID);
                parameters.Add("@EmployeeID", entity.EmployeeID);
                parameters.Add("@TrainingDate", entity.TrainingDate);
                parameters.Add("@TrainingDescription", entity.TrainingDescription);
                parameters.Add("@RowsAffected", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await connection.ExecuteAsync("spEditTraining", parameters, commandType: CommandType.StoredProcedure);
                int rowsAffected = parameters.Get<int>("@RowsAffected");
                return rowsAffected;
            }
        }

        public async Task<IEnumerable<M_Training>> GetAll()
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                return await connection.QueryAsync<M_Training>("spGetAllTraining", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<M_Training>> GetAllDeleted()
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                return await connection.QueryAsync<M_Training>("spGetAllTrainingDeleted", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<M_Training> GetValue(int id)
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                return await connection.QueryFirstOrDefaultAsync<M_Training>("spGetTraining", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> Recover(int id)
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                parameters.Add("@RowsAffected", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await connection.ExecuteAsync("spRecoverTraining", parameters, commandType: CommandType.StoredProcedure);
                int rowsAffected = parameters.Get<int>("@RowsAffected");
                return rowsAffected;
            }
        }
    }
}

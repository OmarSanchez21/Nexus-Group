using Dapper;
using NexusGroup.Data.BaseData;
using NexusGroup.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Data.Repositories.PerformanceReview
{
    public class PerformanceReviewRepositories : IPerformanceReviewRepositories
    {
        private readonly IDapperContext _dapperContext;
        public PerformanceReviewRepositories(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<int> Add(M_PerformanceReview entity)
        {
            using (var connection = _dapperContext.CreateConnection()) 
            {
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeID", entity.EmployeeID);
                parameters.Add("@ReviewDate", entity.ReviewDate);
                parameters.Add("@Reviewer", entity.Reviewer);
                parameters.Add("@ReviewDescription", entity.ReviewDescription);
                parameters.Add("@Observation", entity.Observation);
                parameters.Add("@Score", entity.Score);
                parameters.Add("@RowsAffected", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await connection.ExecuteAsync("spAddPerformanceReview", parameters, commandType: CommandType.StoredProcedure);
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
                await connection.ExecuteAsync("spDeletePerformanceReview", parameters, commandType: CommandType.StoredProcedure);
                int rowsAffected = parameters.Get<int>("@RowsAffected");
                return rowsAffected;
            }
        }

        public async Task<int> DeletePermantly(int id)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                parameters.Add("@RowsAffected", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await connection.ExecuteAsync("spDeletePermantlyPerformanceReview", parameters, commandType: CommandType.StoredProcedure);
                int rowsAffected = parameters.Get<int>("@RowsAffected");
                return rowsAffected;
            }
        }

        public async Task<int> Edit(M_PerformanceReview entity)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", entity.ReviewID);
                parameters.Add("@EmployeeID", entity.EmployeeID);
                parameters.Add("@ReviewDate", entity.ReviewDate);
                parameters.Add("@Reviewer", entity.Reviewer);
                parameters.Add("@ReviewDescription", entity.ReviewDescription);
                parameters.Add("@Observation", entity.Observation);
                parameters.Add("@Score", entity.Score);
                parameters.Add("@RowsAffected", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await connection.ExecuteAsync("spEditPerformanceReview", parameters, commandType: CommandType.StoredProcedure);
                int rowsAffected = parameters.Get<int>("@RowsAffected");
                return rowsAffected;
            }
        }

        public async Task<IEnumerable<M_PerformanceReview>> GetAll()
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                return await connection.QueryAsync<M_PerformanceReview>("spGetAllPerformanceReview", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<M_PerformanceReview>> GetAllDeleted()
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                return await connection.QueryAsync<M_PerformanceReview>("spGetAllPerformanceReviewDeleted", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<M_PerformanceReview> GetValue(int id)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                return await connection.QueryFirstOrDefaultAsync<M_PerformanceReview>("spGetPerformanceReview", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<int> Recover(int id)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                parameters.Add("@RowsAffected", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await connection.ExecuteAsync("spRecoverPermantlyPerformanceReview", parameters, commandType: CommandType.StoredProcedure);
                int rowsAffected = parameters.Get<int>("@RowsAffected");
                return rowsAffected;
            }
        }
    }
}

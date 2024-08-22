using Dapper;
using NexusGroup.Data.BaseData;
using NexusGroup.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Data.Repositories.JobOffers
{
    public class JobOffersRepositories : IJobOffersRepositories
    {
        private readonly IDapperContext _dapperContext;
        public JobOffersRepositories(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<int> Add(M_JobOffers entity)
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Title", entity.Title);
                parameters.Add("@Description", entity.Description);
                parameters.Add("@StartPublication", entity.StartPublication);
                parameters.Add("@EndPublication", entity.EndPublication);
                return await connection.ExecuteAsync("spAddJobOffer", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> Delete(int id)
        {
            using (var connection = _dapperContext.CreateConnection()) 
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                return await connection.ExecuteAsync("spDeleteJobOffer", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> DeletePermantly(int id)
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                return await connection.ExecuteAsync("spDeletePermantlyJobOffer", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> Edit(M_JobOffers entity)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", entity.JobOfferID);
                parameters.Add("@Title", entity.Title);
                parameters.Add("@Description", entity.Description);
                parameters.Add("@StartPublication", entity.StartPublication);
                parameters.Add("@EndPublication", entity.EndPublication);
                return await connection.ExecuteAsync("spEditJobOffer", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<M_JobOffers>> GetAll()
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                return await connection.QueryAsync<M_JobOffers>("spGetAllJobOffers", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<M_JobOffers>> GetAllDeleted()
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                return await connection.QueryAsync<M_JobOffers>("spGetAllJobOffersDeleted", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<M_JobOffers> GetValue(int id)
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                return await connection.QueryFirstOrDefaultAsync<M_JobOffers>("spGetJobOffer", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> Recover(int id)
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                return await connection.ExecuteAsync("spRecoverJobOffer", commandType: CommandType.StoredProcedure);
            }
        }
    }
}

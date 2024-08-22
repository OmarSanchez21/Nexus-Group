using Dapper;
using NexusGroup.Data.BaseData;
using NexusGroup.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Data.Repositories.Candidates
{
    public class CandidatesRepositories : ICandidatesRepositories
    {
        private readonly IDapperContext _dapperContext;
        public CandidatesRepositories(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<int> Add(M_Candidates entity)
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@FirstName", entity.FirstName);
                parameters.Add("@LastName", entity.LastName);
                parameters.Add("@Email", entity.Email);
                parameters.Add("@CVURL", entity.cvURL);
                parameters.Add("@ApplicationDate", entity.ApplicationDate);
                parameters.Add("@IdJobOffer", entity.IdJobOffer);
                return await connection.ExecuteAsync("spAddCandidates", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> Delete(int id)
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                return await connection.ExecuteAsync("spDeleteCandidates", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> DeletePermantly(int id)
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                return await connection.ExecuteAsync("spDeletePermantlyCnadidates", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> Edit(M_Candidates entity)
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", entity.CandidateID);
                parameters.Add("@FirstName", entity.FirstName);
                parameters.Add("@LastName", entity.LastName);
                parameters.Add("@Email", entity.Email);
                parameters.Add("@CVURL", entity.cvURL);
                parameters.Add("@ApplicationDate", entity.ApplicationDate);
                parameters.Add("@IdJobOffer", entity.IdJobOffer);
                return await connection.ExecuteAsync("spEditCandidates", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<M_Candidates>> GetAll()
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                return await connection.QueryAsync<M_Candidates>("spGetAllCandidates", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<M_Candidates>> GetAllDeleted()
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                return await connection.QueryAsync<M_Candidates>("spGetAllCandidatesDeleted", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<M_Candidates> GetValue(int id)
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                return await connection.QueryFirstOrDefaultAsync<M_Candidates>("spGetCandidates", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> Recover(int id)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                return await connection.ExecuteAsync("spRecoverCandidates", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

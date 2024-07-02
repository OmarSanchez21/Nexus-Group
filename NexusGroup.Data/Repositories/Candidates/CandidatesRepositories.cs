using Dapper;
using NexusGroup.Data.Base;
using NexusGroup.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Data.Repositories.Candidates
{
    public class CandidatesRepositories: ICandidatesRepositories
    {
        private readonly IDapperDBConnection _dbConnection;
        public CandidatesRepositories(IDapperDBConnection db)
        {
            this._dbConnection = db;
        }

        public async Task Add(CandidatesModels entity)
        {
            using(IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new
                {
                    Name = entity.name,
                    LastName = entity.lastname,
                    Email = entity.email,
                    Phone = entity.phone,
                    CVURL = entity.cvURL,
                    Status = entity.status,
                    OfferID = entity.offerID,
                };
                await db.ExecuteAsync("addCandidates", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task Delete(int id)
        {
            using(IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new { Id = id };
                await db.ExecuteAsync("deleteCandidates", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<CandidatesModels>> GetAll()
        {
            using(IDbConnection db = _dbConnection.CreateConnection())
            {
                return await db.QueryAsync<CandidatesModels>("getAllCandidates", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<CandidatesModels>> GetAllDeleted()
        {
            using(IDbConnection db = _dbConnection.CreateConnection())
            {
                return await db.QueryAsync<CandidatesModels>("getAllCandidatesDeleted", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<CandidatesModels> GetByID(int id)
        {
            using(IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new { Id = id };
                return await db.QueryFirstOrDefaultAsync("getIdCandidates", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task Recover(int id)
        {
            using(IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new { Id = id };
                await db.ExecuteAsync("recoverCandidates", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task RemovePermantly(int id)
        {
            using (IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new { Id = id };
                await db.ExecuteAsync("removerPermCandidates", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task Update(CandidatesModels entity)
        {
            using(IDbConnection db = _dbConnection.CreateConnection())
                {
                    var parameters = new
                    {
                        Id = entity.candidateID,
                        Name = entity.name,
                        LastName = entity.lastname,
                        Email = entity.email,
                        Phone = entity.phone,
                        CVURL = entity.cvURL,
                        Status = entity.status,
                        OfferID = entity.offerID,
                        UpdateRegistration = entity.updatedRegistration
                    };
                    await db.QueryAsync("editCandidates", parameters, commandType: CommandType.StoredProcedure);
                }
        }
    }
}

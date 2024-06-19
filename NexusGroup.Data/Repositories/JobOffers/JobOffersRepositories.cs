using Dapper;
using NexusGroup.Data.Base;
using NexusGroup.Data.Models;
using System.Data;


namespace NexusGroup.Data.Repositories.JobOffers
{
    public class JobOffersRepositories : IJobOffersRepositories
    {
        private readonly IDapperDBConnection _dbConnection;
        public JobOffersRepositories(IDapperDBConnection connection)
        {
            this._dbConnection = connection;
        }
        public async Task Add(JobOffersModels entity)
        {
            using (IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new
                {
                    Title = entity.title,
                    Description = entity.description,
                    PublicationDate = entity.publicationDate.Date,
                    ClouserDate = entity.clouserDate.Date
                };
                await db.ExecuteAsync("addJobOffers", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task Delete(int id)
        {
            using (IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new { Id = id };
                await db.ExecuteAsync("deletejobOffers", parameters, commandType: CommandType.StoredProcedure);
            } 
        }

        public async Task<IEnumerable<JobOffersModels>> GetAll()
        {
            using(IDbConnection db = _dbConnection.CreateConnection())
            {
                return await db.QueryAsync<JobOffersModels>("getAlljobOffers", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<JobOffersModels>> GetAllDeleted()
        {
            using(IDbConnection db = _dbConnection.CreateConnection())
            {
                return await db.QueryAsync<JobOffersModels>("getAlljobOffersDeleted", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<JobOffersModels> GetByID(int id)
        {
            using (IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new { Id = id };
                return await db.QueryFirstOrDefaultAsync<JobOffersModels>("getIdjobOffers", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task Recover(int id)
        {
            using (IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new { Id = id };
                await db.ExecuteAsync("RecoverjobOffers", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task RemovePermantly(int id)
        {
            using (IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new { Id = id };
                await db.ExecuteAsync("removePermJobOffers", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task Update(JobOffersModels entity)
        {
            using(IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new
                {
                    Id = entity.offerID,
                    Title = entity.title,
                    Description = entity.description,
                    PublicationDate = entity.publicationDate.Date,
                    ClouserDate = entity.clouserDate.Date,
                    UpdatedRegistration = entity.updatedRegistration
                };
                await db.ExecuteAsync("editJobOffers", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

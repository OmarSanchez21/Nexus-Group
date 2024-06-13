using NexusGroup.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Data.SqlClient;
using NexusGroup.Data.Base;


namespace NexusGroup.Data.Repositories.Positions
{
    public class PositionsRepositories : IPositionsRepositories
    {
        private readonly IDapperDBConnection _dbConnection;
        public PositionsRepositories(IDapperDBConnection dbConnection)
        {
            this._dbConnection = dbConnection;
        }
        public async Task Add(PositionsModels entity)
        {
            using (IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new { Name = entity.name };
                await db.ExecuteAsync("addPositions", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task Delete(int id)
        {
            using (IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new { Id = id };
                await db.ExecuteAsync("deletePosition", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task Remove(int id)
        {
            using (IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new { Id = id };
                await db.ExecuteAsync("deletePosition", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<PositionsModels>> GetAll()
        {
            using (IDbConnection db = _dbConnection.CreateConnection())
            {
                return await db.QueryAsync<PositionsModels>("getAllPositions", commandType: CommandType.StoredProcedure);
            }
        }

        public Task<PositionsModels> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PositionsModels> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task Update(PositionsModels entity)
        {
            using (IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new { Id = entity.positionID, Name = entity.name, UpdateDate = entity.updatedRegistration };
                await db.ExecuteAsync("editPosition", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

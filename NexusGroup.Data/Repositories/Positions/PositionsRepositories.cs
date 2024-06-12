﻿using NexusGroup.Data.Models;
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
            using(IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Name", entity.name, DbType.String, ParameterDirection.Input);

                await db.ExecuteAsync("addPositions", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
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

        public Task Update(PositionsModels entity)
        {
            throw new NotImplementedException();
        }
    }
}

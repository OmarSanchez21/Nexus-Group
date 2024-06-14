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
        /*
          Esta parte es de los Obtener hay 3:
            El obtener todos sin tener el campo del isDeleted falso
            El obtener todos con el campo de isDeleted true
            El obtener mediante el Id este no importa si esta en true o false el isDeleted
         */
        //Obtener todos sin tener el isDeleted en true
        public async Task<IEnumerable<PositionsModels>> GetAll()
        {
            using (IDbConnection db = _dbConnection.CreateConnection())
            {
                return await db.QueryAsync<PositionsModels>("getAllPositions", commandType: CommandType.StoredProcedure);
            }
        }
        //Obtener todos con el isDeleted en true
        public async Task<IEnumerable<PositionsModels>> GetAllDeleted()
        {
            using (IDbConnection db = _dbConnection.CreateConnection())
            {
                return await db.QueryAsync<PositionsModels>("getAllPositionsDeleted", commandType: CommandType.StoredProcedure);
            }
        }
        //Obtener a uno solo
        public async Task<PositionsModels> GetByID(int id)
        {
            using (IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new { Id = id };
                return await db.QueryFirstOrDefaultAsync<PositionsModels>("getIdPosition", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        //Agregar 
        public async Task Add(PositionsModels entity)
        {
            using (IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new { Name = entity.name };
                await db.ExecuteAsync("addPositions", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        //Actualizar
        public async Task Update(PositionsModels entity)
        {
            using (IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new { Id = entity.positionID, Name = entity.name, UpdateDate = entity.updatedRegistration };
                await db.ExecuteAsync("editPosition", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        //En este actualiza el isDeleted a true
        public async Task Delete(int id)
        {
            using (IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new { Id = id };
                await db.ExecuteAsync("deletePosition", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        //Cambia el valor de isDeleted a falso
        public async Task Recover(int id)
        {
            using (IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new { Id = id };
                await db.ExecuteAsync("RecoverPosition", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        //Este elimina completamente
        public async Task RemovePermantly(int id)
        {
            using (IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new { Id = id };
                await db.ExecuteAsync("removePermPosition", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

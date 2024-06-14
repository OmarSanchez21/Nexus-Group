using Dapper;
using NexusGroup.Data.Base;
using NexusGroup.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Data.Repositories.AccessLevels
{
    public class AccessLevelsRepositories : IAccessLevelsRepositories
    {
        private readonly IDapperDBConnection _dBConnection;
        public AccessLevelsRepositories(IDapperDBConnection dBConnection)
        {
            this._dBConnection = dBConnection;
        }
        /*
          Esta parte es de los Obtener hay 3:
            El obtener todos sin tener el campo del isDeleted falso
            El obtener todos con el campo de isDeleted true
            El obtener mediante el Id este no importa si esta en true o false el isDeleted
         */
        public async Task<IEnumerable<AccessLevelsModels>> GetAll()
        {
            using (IDbConnection db = _dBConnection.CreateConnection())
            {
                return await db.QueryAsync<AccessLevelsModels>("getAllAccessLevels", commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<AccessLevelsModels>> GetAllDeleted()
        {
            using (IDbConnection db = _dBConnection.CreateConnection())
            {
                return await db.QueryAsync<AccessLevelsModels>("getAllAccessLevelsDeleted", commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<AccessLevelsModels> GetByID(int id)
        {
            using (IDbConnection db = _dBConnection.CreateConnection())
            {
                var parameters = new { Id = id };
                return await db.QueryFirstOrDefaultAsync<AccessLevelsModels>("getIdAccessLevels", commandType: CommandType.StoredProcedure);
            }
        }
        //Añade
        public async Task Add(AccessLevelsModels entity)
        {
            using(IDbConnection db = _dBConnection.CreateConnection())
            {
                var parameters = new { Name = entity.name };
                await db.ExecuteAsync("addAccessLevels", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        //Editar
        public async Task Update(AccessLevelsModels entity)
        {
            using (IDbConnection db = _dBConnection.CreateConnection())
            {
                var parameters = new { Id = entity.accessLevelsID, Name = entity.name, updateDate = entity.updatedRegistration };
                await db.ExecuteAsync("editAccessLevels", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        //Cambia el valor el isDeleted a true
        public async Task Delete(int id)
        {
            using (IDbConnection db = _dBConnection.CreateConnection())
            {
                var parameters = new { Id = id };
                await db.ExecuteAsync("deleteAccessLevels", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        //Cambia el valor de isDeleted a falso
        public async Task Recover(int id)
        {
            using(IDbConnection db = _dBConnection.CreateConnection())
            {
                var parameters = new { Id = id };
                await db.ExecuteAsync("RecoverAccessLevels", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        //Esto eliminar permanente
        public async Task RemovePermantly(int id)
        {
            using (IDbConnection db = _dBConnection.CreateConnection())
            {
                var parameters = new { Id = id };
                await db.ExecuteAsync("removePermAccessLevels", commandType: CommandType.StoredProcedure);
            }
        }
    }
}

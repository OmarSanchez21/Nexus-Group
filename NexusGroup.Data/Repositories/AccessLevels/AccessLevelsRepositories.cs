using Dapper;
using NexusGroup.Data.BaseData;
using NexusGroup.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Data.Repositories.AccessLevels
{
    public class AccessLevelsRepositories : IAccessLevelsRepositories
    {
        private readonly IDapperContext _dapperContext;
        public AccessLevelsRepositories(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<M_AccessLevels>> GetAll()
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                return await connection.QueryAsync<M_AccessLevels>("spGetAcessLevels", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<M_AccessLevels> GetValue(int id)
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                var parameters = new
                {
                    Id = id
                };
                return await connection.QueryFirstOrDefaultAsync<M_AccessLevels>("spGetAccessLevels", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

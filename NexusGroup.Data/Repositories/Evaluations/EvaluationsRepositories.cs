using Dapper;
using NexusGroup.Data.Base;
using NexusGroup.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Data.Repositories.Evaluations
{
    public class EvaluationsRepositories : IEvaluationsRepositories
    {
        private readonly IDapperDBConnection _dbConnection;
        public EvaluationsRepositories(IDapperDBConnection dapperDBConnection) 
        {
            this._dbConnection = dapperDBConnection;
        }
        public async Task Add(EvaluationsModels entity)
        {
            using(IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new
                {
                    EmployeeID = entity.employeeID,
                    EvalutionDate = entity.evalutionDate,
                    Objectives = entity.objectives,
                    FeedBack = entity.feedback,
                    Result = entity.result
                };
                await db.ExecuteAsync("addEvaluations", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task Delete(int id)
        {
            using(IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new { Id = id };
                await db.ExecuteAsync("deleteEvaluations", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<EvaluationsModels>> GetAll()
        {
            using(IDbConnection db = _dbConnection.CreateConnection())
            {
                return await db.QueryAsync<EvaluationsModels>("getAllEvaluations", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<EvaluationsModels>> GetAllDeleted()
        {
            using(IDbConnection db = _dbConnection.CreateConnection())
            {
                return await db.QueryAsync<EvaluationsModels>("getAllEvaluationsDeleted", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<EvaluationsModels> GetByID(int id)
        {
            using(IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new { Id = id };
                return await db.QueryFirstOrDefaultAsync<EvaluationsModels>("getIdEvaluations", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task Recover(int id)
        {
            using(IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new { Id = id };
                await db.ExecuteAsync("recoverEvaluations", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task RemovePermantly(int id)
        {
            using(IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new { Id = id };
                await db.ExecuteAsync("removerPermEvaluations", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task Update(EvaluationsModels entity)
        {
            using(IDbConnection db = _dbConnection.CreateConnection())
            {
                var parameters = new
                {
                    Id = entity.evaluationID,
                    EmployeeID = entity.employeeID,
                    EvalutionDate = entity.evalutionDate,
                    Objectives = entity.objectives,
                    FeedBack = entity.feedback,
                    Result = entity.result,
                    UpdateRegistration = entity.updatedRegistration
                };
                await db.ExecuteAsync("editEvaluations", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

using Dapper;
using NexusGroup.Data.Base;
using NexusGroup.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Data.Repositories.PayRoll
{
    public class PayRollRepositories : IPayRollRepositories
    {
        private readonly IDapperDBConnection _dBConnection;
        public PayRollRepositories(IDapperDBConnection db)
        {
            this._dBConnection = db;
        }
        public async Task Add(PayRollModels entity)
        {
            using(IDbConnection db = _dBConnection.CreateConnection())
            {
                var parameters = new
                {
                    EmployeeID = entity.employeeID,
                    Salary = entity.salary,
                    Deductions = entity.deductions,
                    Taxes = entity.taxes,
                    PaymentDate = entity.paymentDate,
                };
                await db.ExecuteAsync("addPayRoll", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task Delete(int id)
        {
            using (IDbConnection db = _dBConnection.CreateConnection())
            {
                var parameters = new { Id = id };
                await db.ExecuteAsync("deletePayRoll", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<PayRollModels>> GetAll()
        {
            using(IDbConnection db = _dBConnection.CreateConnection())
            {
                return await db.QueryAsync<PayRollModels>("getAllPayRoll", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<PayRollModels>> GetAllDeleted()
        {
            using(IDbConnection db = _dBConnection.CreateConnection())
            {
                return await db.QueryAsync<PayRollModels>("getAllPayRollDeleted", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<PayRollModels> GetByID(int id)
        {
            using (IDbConnection db = _dBConnection.CreateConnection())
            {
                var parameters = new { Id = id };
                return await db.QueryFirstOrDefaultAsync<PayRollModels>("getIdPayRoll", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task Recover(int id)
        {
            using (IDbConnection db = _dBConnection.CreateConnection())
            {
                var parameters = new { Id = id };
                await db.ExecuteAsync("recoverPayRoll", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task RemovePermantly(int id)
        {
            using (IDbConnection db = _dBConnection.CreateConnection())
            {
                var parameters = new { Id = id };
                await db.ExecuteAsync("removerPermPayRoll", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task Update(PayRollModels entity)
        {
            using(IDbConnection db = _dBConnection.CreateConnection())
            {
                var parameters = new
                {
                    Id = entity.payRollID,
                    EmployeeID = entity.employeeID,
                    Salary = entity.salary,
                    Deductions = entity.deductions,
                    Taxes = entity.taxes,
                    PaymentDate = entity.paymentDate,
                    UpdateRegistration = entity.updatedRegistration
                };
                await db.ExecuteAsync("editPayRoll", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

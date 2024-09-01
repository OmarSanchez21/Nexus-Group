using Dapper;
using NexusGroup.Data.BaseData;
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
        private readonly IDapperContext _dapperContext;
        public PayRollRepositories(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext; 
        }
        public async Task<int> Add(M_PayRoll entity)
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeID", entity.EmployeeID);
                parameters.Add("@PayDate", entity.PayDate);
                parameters.Add("@BaseSalary", entity.BaseSalary);
                parameters.Add("@OvertimePay", entity.OvertimePay);
                parameters.Add("@Deduction", entity.Deduction);
                parameters.Add("@RowsAffected", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await connection.ExecuteAsync("spAddPayRoll", parameters, commandType: CommandType.StoredProcedure);
                int rowsAffected = parameters.Get<int>("@RowsAffected");
                return rowsAffected;
            }
        }

        public async Task<int> Delete(int id)
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                parameters.Add("@RowsAffected", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await connection.ExecuteAsync("spDeletePayRoll", parameters, commandType: CommandType.StoredProcedure);
                int rowsAffected = parameters.Get<int>("@RowsAffected");
                return rowsAffected;
            }
        }

        public async Task<int> DeletePermantly(int id)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                parameters.Add("@RowsAffected", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await connection.ExecuteAsync("spDeletePermantlyPayRoll", parameters, commandType: CommandType.StoredProcedure);
                int rowsAffected = parameters.Get<int>("@RowsAffected");
                return rowsAffected;
            }
        }

        public async Task<int> Edit(M_PayRoll entity)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", entity.PayrollID);
                parameters.Add("@EmployeeID", entity.EmployeeID);
                parameters.Add("@PayDate", entity.PayDate);
                parameters.Add("@BaseSalary", entity.BaseSalary);
                parameters.Add("@OvertimePay", entity.OvertimePay);
                parameters.Add("@Deduction", entity.Deduction);
                parameters.Add("@RowsAffected", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await connection.ExecuteAsync("spEditPayRoll", parameters, commandType: CommandType.StoredProcedure);
                int rowsAffected = parameters.Get<int>("@RowsAffected");
                return rowsAffected;
            }
        }

        public async Task<IEnumerable<M_PayRoll>> GetAll()
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                return await connection.QueryAsync<M_PayRoll>("spGetAllPayRoll", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<M_PayRoll>> GetAllDeleted()
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                return await connection.QueryAsync<M_PayRoll>("spGetAllPayRollDeleted", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<M_PayRoll> GetValue(int id)
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                return await connection.QueryFirstOrDefaultAsync<M_PayRoll>("sGetPayRoll", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<int> Recover(int id)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                parameters.Add("@RowsAffected", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await connection.ExecuteAsync("spRecoverPayRoll", parameters, commandType: CommandType.StoredProcedure);
                int rowsAffected = parameters.Get<int>("@RowsAffected");
                return rowsAffected;
            }
        }
    }
}

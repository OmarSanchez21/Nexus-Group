using NexusGroup.Data.Models;
using NexusGroup.Data.Repositories.Employees;
using NexusGroup.Service.Core;
using NexusGroup.Service.DTOs.Employees;
using NexusGroup.Service.DTOs.JobOffers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Services.Employees
{
    public class EmployeesService : iEmployeesService
    {
        private readonly IEmployeesRepositories repositories;
        public EmployeesService(IEmployeesRepositories employeesService)
        {
            repositories = employeesService;
        }

        public async Task<ServiceResult> Delete(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                await this.repositories.Delete(id);
                result.Message = "The employees is deleted successfully";
            }
            catch (SqlException ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error en la base de datos";
                ExcetionLogs.LogSQLError(ex);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Internal Error";
                ExcetionLogs.LogInternalError(ex);
            }
            return result;
        }

        public async Task<ServiceResult> GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var employees = await repositories.GetAll();
                var employeesDTO = employees.Select(emp => new AllEmployees()
                {
                    employeeID = emp.employeeID,
                    name = emp.name,
                    lastName = emp.lastName,
                    photo = emp.photo,
                    email = emp.email,
                    joinDate = DateOnly.FromDateTime(emp.joinDate),
                    accessLevelID = emp.accessLevelID,
                    positionID = emp.positionID,
                })
                result.Success = true;
                result.Data = employeesDTO;
            }
            catch (SqlException ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error en la base de datos";
                ExcetionLogs.LogSQLError(ex);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Internal Error";
                ExcetionLogs.LogInternalError(ex);
            }
            return result;
        }

        public Task<ServiceResult> GetAllDeleted()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> GetValue(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> Recover(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> Save(AddEmployees obj)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> Update(UpdateEmployees obj)
        {
            throw new NotImplementedException();
        }
    }
}

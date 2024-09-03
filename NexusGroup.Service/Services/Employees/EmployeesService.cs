using NexusGroup.Data.Models;
using NexusGroup.Data.Repositories.Employees;
using NexusGroup.Service.Base;
using NexusGroup.Service.DTOs;
using NexusGroup.Service.Mappers;
using NexusGroup.Service.Validations;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Services.Employees
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IEmployeesRepositories _repositories;
        public EmployeesService(IEmployeesRepositories employeesRepositories)
        {
            _repositories = employeesRepositories;
        }
        public async Task<ServiceResult> Add(AddEmployeeDTO dto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = EmployeeValidation.ValidateAdd(dto);
                if (!result.Success)
                {
                    return result;
                }
                M_Employees employees = EmployeeMappers.toModelAdd(dto);
                var rowsAffected = await _repositories.Add(employees);
                if(rowsAffected <= 0)
                {
                    result.Success = false;
                    result.Message = "Failed to add";
                    return result;
                }
                result.Message = ServiceMessages.AddSuccess;
                result.Data = employees;
            }
            catch (SqlException sqlexception)
            {
                string accion = ServiceMessages.GetErrorLog("add", "Employees");
                new LogConfiguration.ExceptionServer(accion, sqlexception);
                result.Success = false;
                result.Message = "Error on DataBase.";
                result.Data = sqlexception.Message;
                return result;

            }
            catch (Exception ex)
            {
                new LogConfiguration.ExceptionServer("Internal Error", ex);
                result.Success = false;
                result.Message = "Internal Error.";
                result.Data = ex.Message;
                return result;
            }
            return result;
        }

        public async Task<ServiceResult> Delete(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var rowsAffected = await _repositories.Delete(id);
                if (rowsAffected <= 0)
                {
                    result.Success = false;
                    result.Message = ServiceMessages.DeleteFail;
                    return result;
                }
                result.Message = ServiceMessages.DeleteSuccess;
            }
            catch (SqlException sqlexception)
            {
                string accion = ServiceMessages.GetErrorLog("delete", "Employees");
                new LogConfiguration.ExceptionServer(accion, sqlexception);
                result.Success = false;
                result.Message = "Error on DataBase.";
                result.Data = sqlexception.Message;
                return result;

            }
            catch (Exception ex)
            {
                new LogConfiguration.ExceptionServer("Internal Error", ex);
                result.Success = false;
                result.Message = "Internal Error.";
                result.Data = ex.Message;
                return result;
            }
            return result;
        }

        public async Task<ServiceResult> DeletePermantly(int id)
        {
            ServiceResult result = new ServiceResult();
            string accion = ServiceMessages.GetErrorLog("perm", "Employees");
            try
            {
                var rowsAffected = await _repositories.DeletePermantly(id);
                if (rowsAffected <= 0)
                {
                    result.Success = false;
                    result.Message = ServiceMessages.DeleteFail;
                    return result;
                }
                result.Message = ServiceMessages.DeletePermantlySuccess;
            }
            catch (SqlException sqlexception)
            {
                new LogConfiguration.ExceptionServer(accion, sqlexception);
                result.Success = false;
                result.Message = "Error on DataBase.";
                result.Data = sqlexception.Message;
                return result;

            }
            catch (Exception ex)
            {
                new LogConfiguration.ExceptionServer(accion, ex);
                result.Success = false;
                result.Message = "Internal Error.";
                result.Data = ex.Message;
                return result;
            }
            return result;
        }

        public Task<ServiceResult> Edit(EditEmployeeDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> GetAllDeletd()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> Recover(int id)
        {
            throw new NotImplementedException();
        }
    }
}

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
        private const string TableName = "Employees";
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
                    result.Message = ServiceMessages.AddFail;
                    return result;
                }
                result.Message = ServiceMessages.AddSuccess;
                result.Data = employees;
            }
            catch (SqlException sqlexception)
            {
                string accion = ServiceMessages.LogHelper("add", TableName);
                new LogConfiguration.ExceptionServer(accion, sqlexception);
                result.Success = false;
                result.Message = ServiceMessages.DatabaseError;
                result.Data = sqlexception.Message;
                return result;

            }
            catch (Exception ex)
            {
                string accion = ServiceMessages.LogHelper("add", TableName);
                new LogConfiguration.ExceptionServer(accion, ex);
                result.Success = false;
                result.Message = ServiceMessages.InternalError;
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
                string accion = ServiceMessages.LogHelper("delete", TableName);
                new LogConfiguration.ExceptionServer(accion, sqlexception);
                result.Success = false;
                result.Message = ServiceMessages.DatabaseError;
                result.Data = sqlexception.Message;
                return result;

            }
            catch (Exception ex)
            {
                string accion = ServiceMessages.LogHelper("delete", TableName);
                new LogConfiguration.ExceptionServer(accion, ex);
                result.Success = false;
                result.Message = ServiceMessages.InternalError;
                result.Data = ex.Message;
                return result;
            }
            return result;
        }

        public async Task<ServiceResult> DeletePermantly(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var rowsAffected = await _repositories.DeletePermantly(id);
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
                string accion = ServiceMessages.LogHelper("perm", TableName);
                new LogConfiguration.ExceptionServer(accion, sqlexception);
                result.Success = false;
                result.Message = ServiceMessages.DatabaseError;
                result.Data = sqlexception.Message;
                return result;

            }
            catch (Exception ex)
            {
                string accion = ServiceMessages.LogHelper("perm", TableName);
                new LogConfiguration.ExceptionServer(accion, ex);
                result.Success = false;
                result.Message = ServiceMessages.InternalError;
                result.Data = ex.Message;
                return result;
            }
            return result;
        }

        public async Task<ServiceResult> Edit(EditEmployeeDTO dto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = EmployeeValidation.ValidateEdit(dto);
                if (!result.Success)
                {
                    return result;
                }
                M_Employees editData = EmployeeMappers.toModelEdit(dto);
                int rowsAffected = await _repositories.Edit(editData);
                if(rowsAffected >= 0)
                {
                    result.Success = false;
                    result.Message = ServiceMessages.EditFail;
                    return result;
                }
                result.Message = ServiceMessages.EditSuccess;
                result.Data = editData;
            }
            catch (SqlException sqlexception)
            {
                string accion = ServiceMessages.LogHelper("edit", TableName);
                new LogConfiguration.ExceptionServer(accion, sqlexception);
                result.Success = false;
                result.Message = ServiceMessages.DatabaseError;
                result.Data = sqlexception.Message;
                return result;

            }
            catch (Exception ex)
            {
                string accion = ServiceMessages.LogHelper("edit", TableName);
                new LogConfiguration.ExceptionServer(accion, ex);
                result.Success = false;
                result.Message = ServiceMessages.InternalError;
                result.Data = ex.Message;
                return result;
            }
            return result;
        }

        public async Task<ServiceResult> Get(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var value = await _repositories.GetValue(id);
                if(value == null)
                {
                    result.Success = false;
                    result.Message = ServiceMessages.NotFound;
                    return result;
                }
                result.Message = ServiceMessages.GetValue;
                result.Data = value;
            }
            catch (SqlException sqlexception)
            {
                string accion = ServiceMessages.LogHelper("get", TableName);
                new LogConfiguration.ExceptionServer(accion, sqlexception);
                result.Success = false;
                result.Message = ServiceMessages.DatabaseError;
                result.Data = sqlexception.Message;
                return result;

            }
            catch (Exception ex)
            {
                string accion = ServiceMessages.LogHelper("get", TableName);
                new LogConfiguration.ExceptionServer(accion, ex);
                result.Success = false;
                result.Message = ServiceMessages.InternalError;
                result.Data = ex.Message;
                return result;
            }
            return result;
        }

        public async Task<ServiceResult> GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var entities = await _repositories.GetAll();
                if(entities == null)
                {
                    result.Success = false;
                    result.Message = ServiceMessages.NotFoundAll;
                    return result;
                }
                var data = entities.Select(cd => new EmpleadosDTO()
                {
                    Cedula = cd.Cedula,
                    photoURL = cd.photoURL,
                    EmployeeID = cd.EmployeeID,
                    FirstName = cd.FirstName,
                    LastName = cd.LastName,
                    Email = cd.Email,
                    Username = cd.Username,
                    Salary = cd.Salary,
                    PositionID = cd.PositionID,
                    AccessLevelsID = cd.AccessLevelsID,
                    CreateAt = cd.CreateAt
                });
                result.Message = ServiceMessages.GetAllSuccess;
                result.Data = data;
            }
            catch (SqlException sqlexception)
            {
                string accion = ServiceMessages.LogHelper("all", TableName);
                new LogConfiguration.ExceptionServer(accion, sqlexception);
                result.Success = false;
                result.Message = ServiceMessages.DatabaseError;
                result.Data = sqlexception.Message;
                return result;

            }
            catch (Exception ex)
            {
                string accion = ServiceMessages.LogHelper("all", TableName);
                new LogConfiguration.ExceptionServer(accion, ex);
                result.Success = false;
                result.Message = ServiceMessages.InternalError;
                result.Data = ex.Message;
                return result;
            }
            return result;
        }

        public async Task<ServiceResult> GetAllDeletd()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var entities = await _repositories.GetAllDeleted();
                if (entities == null)
                {
                    result.Success = false;
                    result.Message = ServiceMessages.NotFoundAll;
                    return result;
                }
                var data = entities.Select(cd => new M_Employees()
                {
                    EmployeeID = cd.EmployeeID,
                    Cedula = cd.Cedula,
                    FirstName = cd.FirstName,
                    LastName = cd.LastName,
                    Email = cd.Email,
                    Username = cd.Username,
                    Salary = cd.Salary,
                    photoURL = cd.photoURL,
                    PositionID = cd.PositionID,
                    AccessLevelsID = cd.AccessLevelsID,
                    CreateAt = cd.CreateAt,
                    DeleteAt = cd.DeleteAt,
                });
                result.Message = ServiceMessages.GetAllSuccess;
                result.Data = data;
            }
            catch (SqlException sqlexception)
            {
                string accion = ServiceMessages.LogHelper("alld", TableName);
                new LogConfiguration.ExceptionServer(accion, sqlexception);
                result.Success = false;
                result.Message = ServiceMessages.DatabaseError;
                result.Data = sqlexception.Message;
                return result;

            }
            catch (Exception ex)
            {
                string accion = ServiceMessages.LogHelper("alld", TableName);
                new LogConfiguration.ExceptionServer(accion, ex);
                result.Success = false;
                result.Message = ServiceMessages.InternalError;
                result.Data = ex.Message;
                return result;
            }
            return result;
        }

        public async Task<ServiceResult> Recover(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var rowsAffected = await _repositories.Recover(id);
                if(rowsAffected <= 0)
                {
                    result.Success = false;
                    result.Message = ServiceMessages.RecoverFail;
                    return result;
                }
                result.Message = ServiceMessages.RecoverSuccess;
            }
            catch (SqlException sqlexception)
            {
                string accion = ServiceMessages.LogHelper("recover", TableName);
                new LogConfiguration.ExceptionServer(accion, sqlexception);
                result.Success = false;
                result.Message = ServiceMessages.DatabaseError;
                result.Data = sqlexception.Message;
                return result;

            }
            catch (Exception ex)
            {
                string accion = ServiceMessages.LogHelper("recover", TableName);
                new LogConfiguration.ExceptionServer(accion, ex);
                result.Success = false;
                result.Message = ServiceMessages.InternalError;
                result.Data = ex.Message;
                return result;
            }
            return result;
        }
    }
}

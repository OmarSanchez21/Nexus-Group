using NexusGroup.Data.Models;
using NexusGroup.Data.Repositories.EmployeesPermission;
using NexusGroup.Service.Core;
using NexusGroup.Service.DTOs.EmployeesPermission;
using NexusGroup.Service.Extention;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Services.EmployeesPermissions
{
    public class EmployeesPermissionService : iEmployeesPermissionsService
    {
        private readonly iEmployeesPermissionRepositories repositories;
        public EmployeesPermissionService(iEmployeesPermissionRepositories repositories)
        {
            this.repositories = repositories;
        }
        public async Task<ServiceResult> Delete(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                await this.repositories.Delete(id);
                result.Message = "The Employee Permission is deleted succesfully";
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
                var permission = await repositories.GetAll();
                var permissionDTO = permission.Select(perm => new EmployeesPermissionDTO()
                {
                    permissionID = perm.permissionID,
                    employeeID = perm.employeeID,
                    permissionType = perm.permissionType,
                    startDate = DateOnly.FromDateTime(perm.startDate),
                    endDate = DateOnly.FromDateTime(perm.endDate),
                    requestDate = DateOnly.FromDateTime(perm.requestDate),
                    isAproved = perm.isAproved
                }).ToList();

                result.Data = permissionDTO;
                result.Message = "All Permission is here";
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

        public async Task<ServiceResult> GetAllDeleted()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var permission = await repositories.GetAllDeleted();
                var permissionDTO = permission.Select(perm => new EmployeesPermissionDTO()
                {
                    permissionID = perm.permissionID,
                    employeeID = perm.employeeID,
                    permissionType = perm.permissionType,
                    startDate = DateOnly.FromDateTime(perm.startDate),
                    endDate = DateOnly.FromDateTime(perm.endDate),
                    requestDate = DateOnly.FromDateTime(perm.requestDate),
                    isAproved = perm.isAproved
                }).ToList();

                result.Data = permissionDTO;
                result.Message = "All Permission Deleted is here";
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

        public async Task<ServiceResult> GetValue(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var permision = await this.repositories.GetByID(id);
                if (permision == null)
                {
                    result.Success = false;
                    result.Message = "The permission doesnt exits";
                    return result;
                }
                else
                {
                    EmployeesPermissionDTO perm = new EmployeesPermissionDTO()
                    {
                        permissionID = permision.permissionID,
                        employeeID = permision.employeeID,
                        permissionType = permision.permissionType,
                        startDate = DateOnly.FromDateTime(permision.startDate),
                        endDate = DateOnly.FromDateTime(permision.endDate),
                        requestDate = DateOnly.FromDateTime(permision.requestDate),
                        isAproved = permision.isAproved
                    };
                    result.Data = perm;
                    result.Message = "The Permission is here";
                }
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

        public async Task<ServiceResult> Recover(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                await this.repositories.Recover(id);
                result.Message = "The Employee Permission is recovered successfully";
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

        public async Task<ServiceResult> Remove(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                await this.repositories.RemovePermantly(id);
                result.Message = "The Employee Permission is removed permantly";
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

        public async Task<ServiceResult> Save(AddEmployeesPermissionDTO dto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                EmployeesPermissionModels models = dto.GetPermissionEntity();
                await this.repositories.Add(models);
                result.Message = "The Permission saved Successfully";
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

        public async Task<ServiceResult> Update(EditEmployeesPermissionDTO dto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                EmployeesPermissionModels models = await this.repositories.GetByID(dto.permissionID);

                models = dto.GetUpdatedPermissionEntity();

                await this.repositories.Update(models);
                result.Message = "The Permission was updated Successfully";
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
    }
}

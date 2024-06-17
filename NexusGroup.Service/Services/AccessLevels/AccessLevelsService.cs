using NexusGroup.Data.Models;
using NexusGroup.Data.Repositories.AccessLevels;
using NexusGroup.Service.Core;
using NexusGroup.Service.DTOs.AccessLevels;
using NexusGroup.Service.Extention;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Services.AccessLevels
{
    public class AccessLevelsService : iAccessLevelsService
    {
        private readonly IAccessLevelsRepositories repositories;
        public AccessLevelsService(IAccessLevelsRepositories repositories) 
        {
            this.repositories = repositories;
        }
        public async Task<ServiceResult> GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var access = await this.repositories.GetAll();
                result.Message = "Se ha consultado todos";
                result.Data = access;
            }
            catch(SqlException ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error en el procedimiento de la base de datos";
                ExcetionLogs.LogSQLError(ex); 
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error interno del servidor";
                ExcetionLogs.LogInternalError(ex);
            }
            return result;
        }

        public async Task<ServiceResult> GetAllDeleted()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var access = await this.repositories.GetAllDeleted();
                result.Message = "Se ha consultado todos los eliminados";
                result.Data = access;
            }
            catch(SqlException ex)
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
                var access = await this.repositories.GetByID(id);
                if(access == null)
                {
                    result.Success = false;
                    result.Message = "The access level is not found";
                    return result;
                }
                else
                {
                    result.Message = "The access level is found";
                    result.Data = access;
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

        public async Task<ServiceResult> SaveAccessLevels(AddAccessLevels accessLevels)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                AccessLevelsModels models = accessLevels.GetAccessLevelsEntity();
                await this.repositories.Add(models);
                result.Message = "Access Level saved successfully";
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

        public async Task<ServiceResult> EditAccessLevels(UpdateAccessLevels accessLevels)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var access = new AccessLevelsModels()
                {
                    accessLevelsID = accessLevels.Id,
                    name = accessLevels.Name,
                    updatedRegistration = accessLevels.updatedRegistration
                };
                await this.repositories.Update(access);
                result.Message = "The access level updated successfully";
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

        public async Task<ServiceResult> Delete(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                await this.repositories.Delete(id);
                result.Message = "The access level is deleted successfully";
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
                result.Message = "The access level is recovered succesfully";
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
                result.Message = "The access level is removed permantly succesfully";
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

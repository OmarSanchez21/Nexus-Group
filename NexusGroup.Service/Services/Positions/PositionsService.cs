using NexusGroup.Data.Models;
using NexusGroup.Data.Repositories.Positions;
using NexusGroup.Service.Core;
using NexusGroup.Service.DTOs.Position;
using NexusGroup.Service.Extention;
using NexusGroup.Service.Validations;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Services.Positions
{
    public class PositionsService : iPositionsService
    {
        private readonly IPositionsRepositories repositories;
        public PositionsService(IPositionsRepositories positions)
        {
            this.repositories = positions;
        }
        public async Task<ServiceResult> GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var positions = await repositories.GetAll();
                result.Success = true;
                result.Data = positions;
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
                var positions = await this.repositories.GetAllDeleted();
                result.Message = "All position Deleted";
                result.Data = positions;
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
                var position = await repositories.GetByID(id);
                if (position == null)
                {
                    result.Success = false;
                    result.Message = "The position is not found";
                    return result;
                }
                else
                {
                    result.Data = position;
                    result.Message = "The position is found";
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

        public async Task<ServiceResult> Save(AddPosition obj)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = PositionsValidations.ValidationsAdd(obj);
                if (!result.Success)
                {
                    return result;
                }
                PositionsModels models = obj.GetPositionEntity();
                await this.repositories.Add(models);
                result.Message = "Positions saved successfully";
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

        public async Task<ServiceResult> Update(UpdatePosition obj)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = PositionsValidations.ValidationsUpdate(obj);
                if (!result.Success)
                {
                    return result;
                }
                var position = new PositionsModels
                {
                    positionID = obj.Id,
                    name = obj.name,
                    updatedRegistration = obj.updatedRegistration
                };
                await this.repositories.Update(position);
                result.Message = "The position is updated successfully";
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
                await repositories.Delete(id);
                result.Message = "The positions is delete successfully";
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
                result.Message = "The position is removed permantly";
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
                result.Message = "The positions is recovered succesfully";
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

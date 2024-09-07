using NexusGroup.Data.Models;
using NexusGroup.Data.Repositories.OverTime;
using NexusGroup.Service.Base;
using NexusGroup.Service.DTOs;
using NexusGroup.Service.Mappers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Services.OverTime
{
    public class OverTimeService : IOverTimeService
    {
        private readonly IOverTimeRepositories _repositories;
        private const string TableName = "OverTime";
        public OverTimeService(IOverTimeRepositories overTimeRepositories)
        {
            
        }
        public async Task<ServiceResult> Add(AddOverTimeDTO dto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var entity = OverTimeMappers.toModelAdd(dto);
                var rowsAffected = await this._repositories.Add(entity);
                if(rowsAffected <= 0)
                {
                    result.Success = false;
                    result.Message = ServiceMessages.AddFail;
                    return result;
                }
                result.Message = ServiceMessages.AddSuccess;
                result.Data = entity;
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

        public async Task<ServiceResult> Edit(EditOverTimeDTO dto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var entity = OverTimeMappers.toModelEdot(dto);
                var rowsAffected = await _repositories.Edit(entity);
                if (rowsAffected <= 0)
                {
                    result.Success = false;
                    result.Message = ServiceMessages.EditSuccess;
                    return result;
                }
                result.Message = ServiceMessages.EditFail;
                result.Data = entity;
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
                var entities = await _repositories.GetValue(id);
                if (entities == null)
                {
                    result.Success = false;
                    result.Message = ServiceMessages.NotFound;
                    return result;
                }
                result.Message = ServiceMessages.GetValue;
                result.Data = entities;
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
                if (entities == null)
                {
                    result.Success = false;
                    result.Message = ServiceMessages.NotFoundAll;
                    return result;
                }
                var data = OverTimeMappers.ToDTO(entities);
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
                result.Message = ServiceMessages.GetAllSuccess;
                result.Data = entities;
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
                if (rowsAffected <= 0)
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

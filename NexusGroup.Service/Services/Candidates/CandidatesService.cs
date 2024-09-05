﻿using NexusGroup.Data.Models;
using NexusGroup.Data.Repositories.Candidates;
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

namespace NexusGroup.Service.Services.Candidates
{
    public class CandidatesService : ICandidatesService
    {
        private readonly ICandidatesRepositories _repositories;
        private const string TableName = "Candidates";
        public CandidatesService(ICandidatesRepositories candidatesRepositories)
        {
            _repositories = candidatesRepositories;
        }
        public async Task<ServiceResult> Add(AddCandidateDTO dto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = CandidateValidation.ValidationAdd(dto);
                if (!result.Success)
                {
                    return result;
                }
                var entity = CandidateMappers.toModelAdd(dto);
                var rowsAffected = await _repositories.Add(entity);
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

        public async Task<ServiceResult> Edit(EditCandidateDTO dto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = CandidateValidation.ValidationEdit(dto);
                if (!result.Success)
                {
                    return result;
                }
                var entity = CandidateMappers.toModelEdit(dto);
                var rowsAffected = await _repositories.Edit(entity);
                if (rowsAffected <= 0)
                {
                    result.Success = false;
                    result.Message = ServiceMessages.EditFail;
                    return result;
                }
                result.Message = ServiceMessages.EditSuccess;
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
                var entity = await _repositories.GetValue(id);
                if(entity == null)
                {
                    result.Success = false;
                    result.Message = ServiceMessages.NotFound;
                    return result;
                }
                result.Message = ServiceMessages.GetValue;
                result.Data = entity;
            }
            catch (SqlException sqlexception)
            {
                string acccion = ServiceMessages.LogHelper("get", TableName);
                new LogConfiguration.ExceptionServer(acccion, sqlexception);
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
                var entity = await _repositories.GetAll();
                if (entity == null)
                {
                    result.Success = false;
                    result.Message = ServiceMessages.NotFoundAll;
                    return result;
                }
                var entities = CandidateMappers.toDto(entity);
                result.Message = ServiceMessages.GetAllSuccess;
                result.Data = entities;
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
                var entity = await _repositories.GetAllDeleted();
                if (entity == null)
                {
                    result.Success = false;
                    result.Message = ServiceMessages.NotFoundAll;
                    return result;
                }
                var data = entity.Select(cd => new M_Candidates()
                {
                    CandidateID = cd.CandidateID,
                    FirstName = cd.FirstName,
                    LastName = cd.LastName,
                    ApplicationDate = cd.ApplicationDate,
                    cvURL = cd.cvURL,
                    Email = cd.Email,
                    IdJobOffer = cd.IdJobOffer,
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

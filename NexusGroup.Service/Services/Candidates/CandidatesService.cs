using NexusGroup.Data.Repositories.Candidates;
using NexusGroup.Service.Base;
using NexusGroup.Service.DTOs;
using NexusGroup.Service.Mappers;
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
        public CandidatesService(ICandidatesRepositories candidatesRepositories)
        {
            _repositories = candidatesRepositories;
        }
        public async Task<ServiceResult> Add(AddCandidateDTO dto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var entity = CandidateMappers.toModelAdd(dto);
                var rowsAffected = await _repositories.Add(entity);
                if(rowsAffected <= 0)
                {
                    result.Success = false;
                    result.Message = "Failed to add candidate";
                    return result;
                }
                result.Message = "Candidate was added successfully";
                result.Data = entity;
            }
            catch (SqlException sqlexception)
            {
                new LogConfiguration.ExceptionServer("Added a Job Offer.", sqlexception);
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
                    result.Message = "Failed deleted candidate";
                    return result;
                }
                result.Message = "Candidate deleted successfully";
            }
            catch (SqlException sqlexception)
            {
                new LogConfiguration.ExceptionServer("Delete a candidate.", sqlexception);
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
            try
            {
                var rowsAffected = await _repositories.DeletePermantly(id);
                if (rowsAffected <= 0)
                {
                    result.Success = false;
                    result.Message = "Failed deleted candidate";
                    return result;
                }
                result.Message = "Candidate deleted successfully";
            }
            catch (SqlException sqlexception)
            {
                new LogConfiguration.ExceptionServer("Delete permantly candidate.", sqlexception);
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

        public async Task<ServiceResult> Edit(EditCandidateDTO dto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var entity = CandidateMappers.toModelEdit(dto);
                var rowsAffected = await _repositories.Edit(entity);
                if (rowsAffected <= 0)
                {
                    result.Success = false;
                    result.Message = "Failed to edit candidate";
                    return result;
                }
                result.Message = "Candidate was edited successfully";
                result.Data = entity;
            }
            catch (SqlException sqlexception)
            {
                new LogConfiguration.ExceptionServer("edited a Job Offer.", sqlexception);
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

        public async Task<ServiceResult> Get(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var entity = await _repositories.GetValue(id);
                if(entity == null)
                {
                    result.Success = false;
                    result.Message = "The id dont have a value";
                    return result;
                }
                result.Message = "Founded successfully";
                result.Data = entity;
            }
            catch (SqlException sqlexception)
            {
                new LogConfiguration.ExceptionServer("edited a Job Offer.", sqlexception);
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

        public async Task<ServiceResult> GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var entity = await _repositories.GetAll();
                if (entity == null)
                {
                    result.Success = false;
                    result.Message = "They dont have a value";
                    return result;
                }
                var entities = entity.Select(cd => new CandidateDTO()
                {
                    CandidateID = cd.CandidateID,
                    FirstName = cd.FirstName,
                    LastName = cd.LastName,
                    IdJobOffer = cd.IdJobOffer,
                    Email = cd.Email,
                    ApplicationDate = DateOnly.FromDateTime(cd.ApplicationDate),
                    cvURL = cd.cvURL,
                    CreateAt = cd.CreateAt

                }).AsEnumerable();
                result.Message = "All found";
                result.Data = entities;
            }
            catch (SqlException sqlexception)
            {
                new LogConfiguration.ExceptionServer("edited a Job Offer.", sqlexception);
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

        public async Task<ServiceResult> GetAllDeletd()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var entity = await _repositories.GetAllDeleted();
                if (entity == null)
                {
                    result.Success = false;
                    result.Message = "They dont have a value";
                    return result;
                }
                result.Message = "All found";
                result.Data = entity;
            }
            catch (SqlException sqlexception)
            {
                new LogConfiguration.ExceptionServer("edited a Job Offer.", sqlexception);
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

        public async Task<ServiceResult> Recover(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var rowsAffected = await _repositories.Recover(id);
                if (rowsAffected <= 0)
                {
                    result.Success = false;
                    result.Message = "Failed recover candidate";
                    return result;
                }
                result.Message = "Candidate recover successfully";
            }
            catch (SqlException sqlexception)
            {
                new LogConfiguration.ExceptionServer("recover candidate.", sqlexception);
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
    }
}

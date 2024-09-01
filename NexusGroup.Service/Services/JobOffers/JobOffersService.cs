using NexusGroup.Data.Models;
using NexusGroup.Data.Repositories.JobOffers;
using NexusGroup.Service.Base;
using NexusGroup.Service.DTOs;
using NexusGroup.Service.Mappers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Services.JobOffers
{
    public class JobOffersService : IJobOffersService
    {
        private readonly IJobOffersRepositories _repositories;
        public JobOffersService(IJobOffersRepositories jobOffersRepositories)
        {
            _repositories = jobOffersRepositories;
        }
        public async Task<ServiceResult> Add(AddJobOffersDTO dto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var entity = JobOffersMappers.toModelAdd(dto);
                var rowsAffected = await _repositories.Add(entity);
                if (rowsAffected <= 0)
                {
                    result.Success = false;
                    result.Message = "Failed to add job offer";
                    return result;
                }
                result.Message = "Job offer added successfully";
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
                if(rowsAffected <= 0)
                {
                    result.Success = false;
                    result.Message = "Failed deleted job offfer";
                    return result;
                }
                result.Message = "Job offer deleted successfully";
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

        public async Task<ServiceResult> DeletePermantly(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var rowsAffected = await _repositories.DeletePermantly(id);
                if (rowsAffected <= 0)
                {
                    result.Success = false;
                    result.Message = "Failed deleted job offfer";
                    return result;
                }
                result.Message = "Job offer deleted successfully";
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

        public async Task<ServiceResult> Edit(EditJobOffersDTO dto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var entity = JobOffersMappers.toModelEdit(dto);
                var rowsAffected = await _repositories.Edit(entity);
                if (rowsAffected <= 0)
                {
                    result.Success = false;
                    result.Message = "Failed to edit job offer";
                    return result;
                }
                result.Message = "Job offer edited successfully";
                result.Data = entity;
            }
            catch (SqlException sqlexception)
            {
                new LogConfiguration.ExceptionServer("Edit a Job Offer.", sqlexception);
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
                    result.Message = "The id is not found";
                    return result;
                }
                result.Message = "the job offer is founded";
                result.Data = entity;
            }
            catch (SqlException sqlexception)
            {
                new LogConfiguration.ExceptionServer("Edit a Job Offer.", sqlexception);
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
                var entities = await _repositories.GetAll();
                var data = entities.Select(job => new JobOffersDTO() 
                {
                    JobOfferID = job.JobOfferID,
                    Title = job.Title,
                    Description = job.Description,
                    StartPublication = DateOnly.FromDateTime(job.StartPublication),
                    EndPublication = DateOnly.FromDateTime(job.EndPublication),
                    CreateAt = job.CreateAt
                }).AsEnumerable();
                result.Message = "All job offers";
                result.Data = data;
            }
            catch (SqlException sqlexception)
            {
                new LogConfiguration.ExceptionServer("Edit a Job Offer.", sqlexception);
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
                var entities = await _repositories.GetAllDeleted();
                var data = entities.Select(job => new M_JobOffers()
                {
                    JobOfferID = job.JobOfferID,
                    Title = job.Title,
                    StartPublication = job.StartPublication,
                    EndPublication = job.EndPublication,
                    CreateAt = job.CreateAt,
                    DeleteAt = job.DeleteAt
                }).AsEnumerable();
                result.Message = "All Deleted job offers";
                result.Data = data;
            }
            catch (SqlException sqlexception)
            {
                new LogConfiguration.ExceptionServer("Edit a Job Offer.", sqlexception);
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
                    result.Message = "Failed recover job offfer";
                    return result;
                }
                result.Message = "Job offer recover successfully";
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
    }
}

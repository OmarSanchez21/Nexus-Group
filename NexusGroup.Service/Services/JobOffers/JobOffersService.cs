using NexusGroup.Data.Models;
using NexusGroup.Data.Repositories.JobOffers;
using NexusGroup.Service.Core;
using NexusGroup.Service.DTOs.JobOffers;
using NexusGroup.Service.Extention;
using NexusGroup.Service.Validations;
using System.Data.SqlClient;

namespace NexusGroup.Service.Services.JobOffers
{
    public class JobOffersService : iJobOffersService
    {
        private readonly IJobOffersRepositories repositories;
        public JobOffersService(IJobOffersRepositories repositories)
        {
            this.repositories = repositories;
        }
        public async Task<ServiceResult> Delete(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                await this.repositories.Delete(id);
                result.Message = "The job offers is deleted successfully";
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
                var joboffers = await repositories.GetAll();
                var jobofferDTO = joboffers.Select(jo => new AllJobOffers()
                {
                    offerID = jo.offerID,
                    title = jo.title,
                    description = jo.description,
                    publicationDate = DateOnly.FromDateTime(jo.publicationDate),
                    clouserDate = DateOnly.FromDateTime(jo.clouserDate)
                }).ToList();
                result.Success = true;
                result.Data = jobofferDTO;
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
                var joboffer = await this.repositories.GetAllDeleted();
                result.Success = true;
                result.Data = joboffer;
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
                var joboffer = await this.repositories.GetByID(id);
                if(joboffer == null)
                {
                    result.Success = false;
                    result.Message = "The job offer doesnt exist";
                    return result;
                }
                else
                {
                    result.Data = joboffer;
                    result.Message = "The job offer is founded. ";
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
                result.Message = "The Job Offers is recovered succesfully";
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
                result.Message = "The Job Offers is removed permantly";
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

        public async Task<ServiceResult> Save(AddJobOffers obj)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = JobOfferesValidation.ValidationsAdd(obj);
                if (!result.Success)
                {
                    return result;
                }
                JobOffersModels models = obj.GetJobOffersEntity();
                await this.repositories.Add(models);
                result.Message = "Job Offers saved successfully";
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

        public async Task<ServiceResult> Update(UpdateJobOffers obj)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = JobOfferesValidation.ValidationsUpdate(obj);
                if (!result.Success)
                {
                    return result;
                }
                var joboffers = new JobOffersModels
                {
                    offerID = obj.offerID,
                    title = obj.title,
                    description = obj.description,
                    publicationDate = obj.publicationDate.ToDateTime(TimeOnly.MinValue),
                    clouserDate = obj.clouserDate.ToDateTime(TimeOnly.MinValue),
                    updatedRegistration = obj.updatedRegistration
                };
                await this.repositories.Update(joboffers);
                result.Message = "The Job offers is updated successfully";
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

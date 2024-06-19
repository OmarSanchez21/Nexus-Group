using NexusGroup.Data.Models;
using NexusGroup.Service.Core;
using NexusGroup.Service.DTOs.JobOffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Validations
{
    public static class JobOfferesValidation
    {
        public static ServiceResult ValidationsAdd(AddJobOffers models)
        {
            ServiceResult result = new ServiceResult();
            if (string.IsNullOrEmpty(models.title))
            {
                result.Success = false;
                result.Message = "The title is requerid";
                return result;
            }
            if (string.IsNullOrEmpty(models.description))
            {
                result.Success = false;
                result.Message = "The description is requerid";
                return result;
            }
            if(models.title.Length > 100)
            {
                result.Success = false;
                result.Message = "The length of the title cannot be more than 100 characters.";
                return result;
            }
            return result;
        }
        public static ServiceResult ValidationsUpdate(UpdateJobOffers models) 
        {
            ServiceResult result = new ServiceResult();
            if (string.IsNullOrEmpty(models.title))
            {
                result.Success = false;
                result.Message = "The title is requerid";
                return result;
            }
            if (string.IsNullOrEmpty(models.description))
            {
                result.Success = false;
                result.Message = "The description is requerid";
                return result;
            }
            if (models.title.Length > 100)
            {
                result.Success = false;
                result.Message = "The length of the title cannot be more than 100 characters.";
                return result;
            }
            return result;
        }
    }
}

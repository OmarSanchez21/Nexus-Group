using NexusGroup.Service.Base;
using NexusGroup.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Validations
{
    public static class JobOffersValidations
    {
        public static ServiceResult ValidationsAdd(AddJobOffersDTO dto)
        {
            ServiceResult result = new ServiceResult();
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(dto.Title))
            {
                result.Success = false;
                sb.AppendLine("The title cannot be empty.");
            }
            if (string.IsNullOrEmpty(dto.Description))
            {
                result.Success = false;
                sb.AppendLine("The description cannot be empty.");
            }
            if (dto.StartPublication > dto.EndPublication) 
            {
                result.Success = false;
                sb.AppendLine("The start date cannot be later than the end date.");
            }
            if(dto.EndPublication <= DateOnly.FromDateTime(DateTime.Now))
            {
                result.Success = false;
                sb.AppendLine("The end publication date must be a future date.");
            }
            if(sb.Length > 0)
            {
                result.Message = sb.ToString();
            }
            return result;
        }
    }
}

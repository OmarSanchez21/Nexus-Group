using NexusGroup.Service.Base;
using NexusGroup.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Validations
{
    public static class PositionValidations
    {
        public static ServiceResult ValidationsAdd(AddPositionDTO dto)
        {
            ServiceResult result = new ServiceResult();
            if (string.IsNullOrEmpty(dto.Title))
            {
                result.Success = false;
                result.Message = "The title can no be empty";
            }
            if(dto.Title.Length > 100)
            {
                result.Success = false;
                result.Message = "The length for the title can not be higher than 100 caractheres";
            }
            return result;
        }
        public static ServiceResult ValidationsEdit(EditPositionDTO dto)
        {
            ServiceResult result = new ServiceResult();
            if (string.IsNullOrEmpty(dto.Title))
            {
                result.Success = false;
                result.Message = "The title can no be empty";
            }
            if (dto.Title.Length > 100)
            {
                result.Success = false;
                result.Message = "The length for the title can not be higher than 100 caractheres";
            }
            return result;
        }
    }
}

using NexusGroup.Service.Core;
using NexusGroup.Service.DTOs.AccessLevels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Validations
{
    public static class AccessLevelsValidations
    {
        public static ServiceResult ValidationsAdd(AddAccessLevels model)
        {
            ServiceResult result = new ServiceResult();
            if (string.IsNullOrEmpty(model.Name))
            {
                result.Success = false;
                result.Message = "The name is required";
                return result;
            }
            if(model.Name.Length > 100)
            {
                result.Success = false;
                result.Message = "The lenght of the name cannot be more than 100 characteres";
                return result;
            }
            return result;
        }
        public static ServiceResult ValidationsUpdate(UpdateAccessLevels model)
        {
            ServiceResult result = new ServiceResult();
            if (string.IsNullOrEmpty(model.Name))
            {
                result.Success = false;
                result.Message = "The name is required";
                return result;
            }
            if (model.Name.Length > 100)
            {
                result.Success = false;
                result.Message = "The lenght of the name cannot be more than 100 characteres";
                return result;
            }
            return result;
        }
    }
}

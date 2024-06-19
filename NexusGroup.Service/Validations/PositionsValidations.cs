using NexusGroup.Service.Core;
using NexusGroup.Service.DTOs.Position;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Validations
{
    public static class PositionsValidations
    {
        public static ServiceResult ValidationsAdd(AddPosition model)
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
                result.Message = "The lenght of the name cannot be more than 100 characters";
                return result;
            }
            return result;
        }
        public static ServiceResult ValidationsUpdate(UpdatePosition model)
        {
            ServiceResult result = new ServiceResult();
            if (string.IsNullOrEmpty(model.name))
            {
                result.Success = false;
                result.Message = "The name is required";
                return result;
            }
            if (model.name.Length > 100)
            {
                result.Success = false;
                result.Message = "The lenght of the name cannot be more than 100 characters";
                return result;
            }
            return result;
        }
    }
}

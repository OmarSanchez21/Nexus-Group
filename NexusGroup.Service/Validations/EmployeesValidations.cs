using NexusGroup.Service.Core;
using NexusGroup.Service.DTOs.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Validations
{
    public static class EmployeesValidations
    {
        public static ServiceResult ValidationsAdd(AddEmployees model)
        {
            ServiceResult result = new ServiceResult();
            if (string.IsNullOrEmpty(model.name))
            {
                result.Success = false;
                result.Message = "The name is requerid";
                return result;
            }
            if (string.IsNullOrEmpty(model.lastName))
            {
                result.Success = false;
                result.Message = "The LastName is requerid";
                return result;
            }
            if (string.IsNullOrEmpty(model.email))
            {
                result.Success = false;
                result.Message = "The email is requerid";
                return result;
            }
            if (string.IsNullOrEmpty(model.passwordHash))
            {
                result.Success = false;
                result.Message = "The password is requerid";
                return result;
            }
            if (model.email.Length > 100)
            {
                result.Success = false;
                result.Message = "The legth of the email cannot be more than 100 characters";
                return result;
            }
            return result;
        }
        public static ServiceResult ValidationsUpdate(UpdateEmployees model)
        {
            ServiceResult result = new ServiceResult();
            if (string.IsNullOrEmpty(model.name))
            {
                result.Success = false;
                result.Message = "The name is requerid";
                return result;
            }
            if (string.IsNullOrEmpty(model.lastName))
            {
                result.Success = false;
                result.Message = "The LastName is requerid";
                return result;
            }
            if (string.IsNullOrEmpty(model.email))
            {
                result.Success = false;
                result.Message = "The email is requerid";
                return result;
            }
            if (string.IsNullOrEmpty(model.passwordHash))
            {
                result.Success = false;
                result.Message = "The password is requerid";
                return result;
            }
            if (model.email.Length > 100)
            {
                result.Success = false;
                result.Message = "The legth of the email cannot be more than 100 characters";
                return result;
            }
            return result;
        }
    }
}

using NexusGroup.Service.Base;
using NexusGroup.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Validations
{
    public static class EmployeeValidation
    {
        private static ServiceResult Validations(string cedula, string firstname, string lastname, string email, string username, string password, string photo, decimal salary)
        {
            ServiceResult result = new ServiceResult();
            StringBuilder sb = new StringBuilder();

            if (string.IsNullOrEmpty(cedula))
            {
                sb.AppendLine("The cedula cannot be empty");
            }
            if (string.IsNullOrEmpty(firstname))
            {
                sb.AppendLine("The first Name cannot be empty");
            }
            if (string.IsNullOrEmpty(lastname))
            {
                sb.AppendLine("The lastname cannot be empty");
            }
            if (string.IsNullOrEmpty(email))
            {
                sb.AppendLine("The email cannot be empty");
            }
            else if (!FuncCore.isValidEmail(email))
            {
                sb.AppendLine("The email format is not valid");
            }
            if (string.IsNullOrEmpty(username))
            {
                sb.AppendLine("The username cannot be empty");
            }
            if(sb.Length > 0)
            {
                result.Success = false;
                result.Message = sb.ToString();
            }
            return result;
        }
        public static ServiceResult ValidateAdd(AddEmployeeDTO dto)
        {
            return Validations(dto.Cedula, dto.FirstName, dto.LastName, dto.Email, dto.Username, dto.Password, dto.photoURL, dto.Salary);
        }
        public static ServiceResult ValidateEdit(EditEmployeeDTO dto)
        {
            return Validations(dto.Cedula, dto.FirstName, dto.LastName, dto.Email, dto.Username, dto.Password, dto.photoURL, dto.Salary);
        }
    }
}

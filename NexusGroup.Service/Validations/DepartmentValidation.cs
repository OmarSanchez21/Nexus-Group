using NexusGroup.Service.Base;
using NexusGroup.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Validations
{
    public static class DepartmentValidation
    {
        private static string Validation(string title, int managerid)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (string.IsNullOrEmpty(title))
            {
                stringBuilder.AppendLine("Title cannot be empty");
            }
            if (managerid == 0)
            {
                stringBuilder.AppendLine("The Manager is not correct");
            }
            return stringBuilder.ToString();
        }
        public static ServiceResult ValidationAdd(AddDepartmentDTO dto)
        {
            string message = Validation(dto.Name, dto.ManagerID);
            return FuncCore.CreateServiceResultValidations(message);
        }
        public static ServiceResult ValidationEdit(EditDepartmentDTO dto) 
        {
            string message = Validation(dto.Name, dto.ManagerID);
            return FuncCore.CreateServiceResultValidations(message);
        }
    }
}

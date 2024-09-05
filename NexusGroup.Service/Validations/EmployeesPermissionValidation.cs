using NexusGroup.Service.Base;
using NexusGroup.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NexusGroup.Service.Validations
{
    public static class EmployeesPermissionValidation
    {
        private static string Validations(int EmployeeID,string PermissionType, DateOnly StartDate,DateOnly EndDate)
        {
            StringBuilder sb = new StringBuilder();
            if (EmployeeID <= 0) 
            {
                sb.AppendLine("Employee is null");
            }
            if (string.IsNullOrEmpty(PermissionType))
            {
                sb.AppendLine("Permission Type cannot be null");
            }
            if(EndDate <= StartDate)
            {
                sb.AppendLine("The end date cannot be less than start date");
            }
            if(EndDate <= DateOnly.FromDateTime(DateTime.Now))
            {
                sb.AppendLine("The end date cannot be the date rigth now");
            }
            return sb.ToString();
        }
        public static ServiceResult ValidationsAdd(AddEmployeePermissionDTO dto)
        {
            string validations = Validations(dto.EmployeeID, dto.PermissionType, dto.StartDate, dto.EndDate);
            return FuncCore.CreateServiceResultValidations(validations);
        }
        public static ServiceResult ValidationsEdit(EditEmployeePermissionDTO dto)
        {
            string validations = Validations(dto.EmployeeID, dto.PermissionType, dto.StartDate, dto.EndDate);
            return FuncCore.CreateServiceResultValidations(validations);
        }
    }
}

using NexusGroup.Data.Models;
using NexusGroup.Service.DTOs.EmployeesPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Extention
{
    public static class EmployeesPermissionExtention
    {
        public static EmployeesPermissionModels GetPermissionEntity(this AddEmployeesPermissionDTO dto)
        {
            EmployeesPermissionModels models = new EmployeesPermissionModels()
            {
                employeeID = dto.employeeID,
                permissionType = dto.permissionType,
                startDate = dto.startDate.ToDateTime(TimeOnly.MinValue),
                endDate = dto.endDate.ToDateTime(TimeOnly.MinValue),
                requestDate = dto.requestDate.ToDateTime(TimeOnly.MinValue),
                isAproved = dto.isAproved
            };
            return models;
        }
        public static EmployeesPermissionModels GetUpdatedPermissionEntity(this EditEmployeesPermissionDTO dto)
        {
            EmployeesPermissionModels models = new EmployeesPermissionModels()
            {
                permissionID = dto.permissionID,
                employeeID = dto.employeeID,
                permissionType = dto.permissionType,
                startDate = dto.startDate.ToDateTime(TimeOnly.MinValue),
                endDate = dto.endDate.ToDateTime(TimeOnly.MinValue),
                requestDate = dto.requestDate.ToDateTime(TimeOnly.MinValue),
                isAproved = dto.isAproved,
                updatedRegistration = dto.updatedRegistration
            };
            return models;
        }
    }
}

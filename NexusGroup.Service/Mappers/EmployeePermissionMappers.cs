using NexusGroup.Data.Models;
using NexusGroup.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Mappers
{
    public static class EmployeePermissionMappers
    {
        public static IEnumerable<EmployeePermissionDTO> ToDTO(IEnumerable<M_EmployeesPermission> models)
        {
            IEnumerable<EmployeePermissionDTO> dto = models.Select(model => new EmployeePermissionDTO()
            {
                EmployeesPermissionID = model.EmployeesPermissionID,
                EmployeeID = model.EmployeeID,
                PermissionType = model.PermissionType,
                StartDate = DateOnly.FromDateTime(model.StartDate),
                EndDate = DateOnly.FromDateTime(model.EndDate),
                ApprovedDate = DateOnly.FromDateTime(model.ApprovedDate),
                IsRequest = model.IsRequest,
                CreateAt = model.CreateAt
            });
            return dto;
        }
        public static M_EmployeesPermission ToModelAdd(AddEmployeePermissionDTO dto)
        {
            M_EmployeesPermission model = new M_EmployeesPermission()
            {
                EmployeeID = dto.EmployeeID,
                PermissionType = dto.PermissionType,
                StartDate = dto.StartDate.ToDateTime(TimeOnly.MinValue),
                EndDate = dto.EndDate.ToDateTime(TimeOnly.MinValue),
                ApprovedDate = dto.ApprovedDate.ToDateTime(TimeOnly.MinValue),
                IsRequest = dto.IsRequest
            };
            return model;
        }
        public static M_EmployeesPermission ToModelEdit(EditEmployeePermissionDTO dto)
        {
            M_EmployeesPermission model = new M_EmployeesPermission()
            {
                EmployeesPermissionID = dto.EmployeesPermissionID,
                EmployeeID = dto.EmployeeID,
                PermissionType = dto.PermissionType,
                StartDate = dto.StartDate.ToDateTime(TimeOnly.MinValue),
                EndDate = dto.EndDate.ToDateTime(TimeOnly.MinValue),
                ApprovedDate = dto.ApprovedDate.ToDateTime(TimeOnly.MinValue),
                IsRequest = dto.IsRequest
            };
            return model;
        }
    }
}

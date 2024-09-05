using NexusGroup.Service.Base;
using NexusGroup.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Services.EmployeesPermission
{
    public interface IEmployeesPermissionService: ICoreService
    {
        Task<ServiceResult> Add(AddEmployeePermissionDTO dto);
        Task<ServiceResult> Edit(EditEmployeePermissionDTO dto);
    }
}

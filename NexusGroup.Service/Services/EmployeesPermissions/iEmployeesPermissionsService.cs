using NexusGroup.Data.Models;
using NexusGroup.Service.Core;
using NexusGroup.Service.DTOs.EmployeesPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Services.EmployeesPermissions
{
    public interface iEmployeesPermissionsService: iCoreService<EmployeesPermissionModels>
    {
        Task<ServiceResult> Save(AddEmployeesPermissionDTO dto);
        Task<ServiceResult> Update(EditEmployeesPermissionDTO dto);
    }
}

using NexusGroup.Service.Base;
using NexusGroup.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Services.Employees
{
    public interface IEmployeesService: ICoreService
    {
        Task<ServiceResult> Add(AddEmployeeDTO dto);
        Task<ServiceResult> Edit(EditEmployeeDTO dto);
    }
}

using NexusGroup.Service.Base;
using NexusGroup.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Services.Department
{
    public interface IDepartmentService : ICoreService
    {
        Task<ServiceResult> Add(AddDepartmentDTO dto);
        Task<ServiceResult> Edit(EditDepartmentDTO dto);
    }
}

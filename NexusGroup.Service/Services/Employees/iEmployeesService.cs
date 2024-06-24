using NexusGroup.Data.Base;
using NexusGroup.Data.Models;
using NexusGroup.Service.Core;
using NexusGroup.Service.DTOs.Employees;
using NexusGroup.Service.DTOs.JobOffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Services.Employees
{
    public interface iEmployeesService: iCoreService<EmployeesModels>
    {
        Task<ServiceResult> Save(AddEmployees obj);
        Task<ServiceResult> Update(UpdateEmployees obj);
    }
}

using NexusGroup.Service.Base;
using NexusGroup.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Services.PayRoll
{
    public interface IPayRollService: ICoreService
    {
        Task<ServiceResult> Add(AddPayRollDTO dto);
        Task<ServiceResult> Edit(EditPayRollDTO dto);
    }
}

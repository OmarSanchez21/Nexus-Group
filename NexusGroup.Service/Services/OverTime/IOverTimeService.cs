using NexusGroup.Service.Base;
using NexusGroup.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Services.OverTime
{
    public interface IOverTimeService: ICoreService
    {
        Task<ServiceResult> Add(AddOverTimeDTO dto);
        Task<ServiceResult> Edit(EditOverTimeDTO dto);
    }
}

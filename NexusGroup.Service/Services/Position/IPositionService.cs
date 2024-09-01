using NexusGroup.Service.Base;
using NexusGroup.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Services.Position
{
    public interface IPositionService: ICoreService
    {
        Task<ServiceResult> Add(AddPositionDTO dto);
        Task<ServiceResult> Edit(EditPositionDTO dto);
    }
}

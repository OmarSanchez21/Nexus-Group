using NexusGroup.Data.Models;
using NexusGroup.Service.Core;
using NexusGroup.Service.DTOs.AccessLevels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Services.AccessLevels
{
    public interface iAccessLevelsService: iCoreService<AccessLevelsModels>
    {
        Task<ServiceResult> SaveAccessLevels(AddAccessLevels accessLevels);
        Task<ServiceResult> EditAccessLevels(UpdateAccessLevels accessLevels);
    }
}

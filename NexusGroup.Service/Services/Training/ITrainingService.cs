using NexusGroup.Service.Base;
using NexusGroup.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Services.Training
{
    public interface ITrainingService: ICoreService 
    {
        Task<ServiceResult> Add(AddTrainingDTO dto);
        Task<ServiceResult> Edit(EditTrainingDTO dto);
    }
}

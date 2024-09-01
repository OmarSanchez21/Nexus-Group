using NexusGroup.Service.Base;
using NexusGroup.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Services.JobOffers
{
    public interface IJobOffersService: ICoreService
    {
        Task<ServiceResult> Add(AddJobOffersDTO dto);
        Task<ServiceResult> Edit(EditJobOffersDTO dto);
    }
}

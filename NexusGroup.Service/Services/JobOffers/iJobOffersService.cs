using NexusGroup.Data.Models;
using NexusGroup.Service.Core;
using NexusGroup.Service.DTOs.JobOffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Services.JobOffers
{
    public interface iJobOffersService: iCoreService<JobOffersModels>
    {
        Task<ServiceResult> Save(AddJobOffers obj);
        Task<ServiceResult> Update(UpdateJobOffers obj);
    }
}

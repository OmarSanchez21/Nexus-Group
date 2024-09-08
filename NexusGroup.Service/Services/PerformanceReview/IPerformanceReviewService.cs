using NexusGroup.Service.Base;
using NexusGroup.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Services.PerformanceReview
{
    public interface IPerformanceReviewService: ICoreService
    {
        Task<ServiceResult> Add(AddPerformanceReviewDTO dto);
        Task<ServiceResult> Edit(EditPerformanceReviewDTO dto);
    }
}

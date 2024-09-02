using NexusGroup.Service.Base;
using NexusGroup.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Services.Candidates
{
    public interface ICandidatesService: ICoreService
    {
        Task<ServiceResult> Add(AddCandidateDTO dto);
        Task<ServiceResult> Edit(EditCandidateDTO dto);
    }
}

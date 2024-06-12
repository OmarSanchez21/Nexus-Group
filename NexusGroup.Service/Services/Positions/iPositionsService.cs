using NexusGroup.Data.Models;
using NexusGroup.Service.Core;
using NexusGroup.Service.DTOs.Position;


namespace NexusGroup.Service.Services.Positions
{
    public interface iPositionsService: iCoreService<PositionsModels>
    {
        Task<ServiceResult> Save(AddPosition obj);
        Task<ServiceResult> Update(UpdatePosition obj);
        Task<ServiceResult> Delete(int id);
    }
}

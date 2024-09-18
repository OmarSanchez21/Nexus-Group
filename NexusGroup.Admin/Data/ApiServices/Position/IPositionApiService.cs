using NexusGroup.Admin.Data.ApiResponse;
using NexusGroup.Admin.Data.Request;

namespace NexusGroup.Admin.Data.ApiServices.Position
{
    public interface IPositionApiService: _CoreApiService
    {
        Task<APIR_Position.All> GetAll();
        Task<APIR_Position.One> GetOne(int id);
        Task<APIR_Position.One> Add(PositionRequest.AddPosition add);
        Task<APIR_Position.One> Edit(PositionRequest.EditPosition edit);
    }
}

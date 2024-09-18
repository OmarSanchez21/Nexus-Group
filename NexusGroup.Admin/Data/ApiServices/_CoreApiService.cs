using NexusGroup.Admin.Data.ApiResponse;

namespace NexusGroup.Admin.Data.ApiServices
{
    public interface _CoreApiService
    {
        Task<_CoreApiR.BaseResponse> Delete(int id);
        Task<_CoreApiR.BaseResponse> DeletePermantly(int id);
        Task<_CoreApiR.BaseResponse > Recover(int id);
    }
}

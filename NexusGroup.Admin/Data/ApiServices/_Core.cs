using NexusGroup.Admin.Data.ApiResponse;

namespace NexusGroup.Admin.Data.ApiServices
{
    public interface _Core
    {
        Task<BaseResponse> GetAll();
        Task<BaseResponse> GetById(int id);
        Task<BaseResponse> Delete(int id);
        Task<BaseResponse> DeletePermantly(int id);
        Task<BaseResponse> Recover(int id);

    }
}

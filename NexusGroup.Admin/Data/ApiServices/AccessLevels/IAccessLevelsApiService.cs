using NexusGroup.Admin.Data.ApiResponse;

namespace NexusGroup.Admin.Data.ApiServices.AccessLevels
{
    public interface IAccessLevelsApiService
    {
        Task<APIR_AccessLevels.All> GetAll();
        Task<APIR_AccessLevels.One> GetOne(string id);
    }
}

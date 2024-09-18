using NexusGroup.Admin.Data.ApiResponse;
using NexusGroup.Admin.Data.Request;

namespace NexusGroup.Admin.Data.ApiServices.Auth
{
    public interface IAuthApiService
    {
        Task<APIR_Login> Login(AuthRequest.LoginRequest login);
        Task<_CoreApiR.BaseResponse> ChangePassword(AuthRequest.ChangePassword changePassword);
    }
}

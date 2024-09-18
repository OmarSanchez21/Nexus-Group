using NexusGroup.Admin.Data.ApiResponse;
using NexusGroup.Admin.Data.Request;
using System.Net;

namespace NexusGroup.Admin.Data.ApiServices.Auth
{
    public class AuthApiService : IAuthApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string baseUrl;
        private readonly IConfiguration _configuration;
        public AuthApiService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            baseUrl = this._configuration["ApiSettings:BaseUrl"];
        }
        public Task<_CoreApiR.BaseResponse> ChangePassword(AuthRequest.ChangePassword changePassword)
        {
            throw new NotImplementedException();
        }

        public async Task<APIR_Login> Login(AuthRequest.LoginRequest login)
        {
            APIR_Login loginResponse = new APIR_Login();
            try
            {
                var httpClient = _httpClientFactory.CreateClient();
                httpClient.BaseAddress = new Uri(baseUrl);
                var httpResponse = await httpClient.PostAsJsonAsync<AuthRequest.LoginRequest>("Auth/login", login);
                if(httpResponse.StatusCode == HttpStatusCode.InternalServerError)
                {
                    loginResponse.Success = false;
                    loginResponse.Message = "Ha ocurrido un error interno";
                }
                else
                {
                    var content = await httpResponse.Content.ReadFromJsonAsync<APIR_Login>();
                    if(content != null)
                    {
                        loginResponse = content;
                    }
                }
            }
            catch (Exception ex)
            {
                loginResponse.Success = false;
                loginResponse.Message += ex.Message;
                return loginResponse;
            }
            return loginResponse;
        }
    }
}

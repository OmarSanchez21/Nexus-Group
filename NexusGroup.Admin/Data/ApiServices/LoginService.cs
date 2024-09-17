using NexusGroup.Admin.Data.ApiResponse;
using NexusGroup.Admin.Data.Request;
using System.Net;

namespace NexusGroup.Admin.Data.ApiServices
{
    public interface ILoginService
    {
        Task<ApiResponse<string>> Login(LoginRequest request);
    }
    public class LoginService : ILoginService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string baseUrl;
        private readonly IConfiguration _configuration;
        public LoginService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            baseUrl = this._configuration["ApiSettings:BaseUrl"];
        }

        public async Task<ApiResponse<string>> Login(LoginRequest request)
        {
            ApiResponse<string> result = new ApiResponse<string>();
            try
            {
                var httpClient = _httpClientFactory.CreateClient();
                httpClient.BaseAddress = new Uri(baseUrl);
                var httpResponse = await httpClient.PostAsJsonAsync<LoginRequest>("Auth/login", request);
                if (httpResponse.StatusCode == HttpStatusCode.InternalServerError)
                {
                    result.Success = false;
                    result.Message = "Error interno";
                }
                else
                {
                    var content = await httpResponse.Content.ReadFromJsonAsync<ApiResponse<string>>();
                    if (content != null)
                    {
                        result = content;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error en la peticion";
            }
            return result;
        }
    }
}

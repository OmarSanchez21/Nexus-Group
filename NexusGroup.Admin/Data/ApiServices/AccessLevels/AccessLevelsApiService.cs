using NexusGroup.Admin.Data.ApiResponse;
using NexusGroup.Admin.Data.Models;
using NexusGroup.Admin.Data.Response;
using NexusGroup.Admin.Data.Token;
using System.Net.Http.Headers;

namespace NexusGroup.Admin.Data.ApiServices.AccessLevels
{
    public class AccessLevelsApiService : IAccessLevelsApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string baseUrl;
        private readonly IConfiguration _configuration;
        private readonly TokenHelper _token;
        public AccessLevelsApiService (IHttpClientFactory httpClientFactory, IConfiguration configuration, TokenHelper tokenHelper)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            baseUrl = this._configuration["ApiSettings:BaseUrl"];
            _token = tokenHelper;
        }
        public async Task<APIR_AccessLevels.All> GetAll()
        {
            APIR_AccessLevels.All result = new APIR_AccessLevels.All();
            try
            {
                string token = await _token.GetToken();
                var httpClient = _httpClientFactory.CreateClient();
                httpClient.BaseAddress = new Uri(baseUrl);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var httpResponse = await httpClient.GetAsync("AccessLevels");
                if(httpResponse.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    result.Success = false;
                    result.Message = "Internal Error. Intente mas tarde.";
                }
                else 
                {
                    var content = await httpResponse.Content.ReadFromJsonAsync<APIR_AccessLevels.All>();
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
                result.Data = Enumerable.Empty<AccessLevelsResponse>();
                return result;
            }
            return result;
        }

        public async Task<APIR_AccessLevels.One> GetOne(string id)
        {
            APIR_AccessLevels.One result = new APIR_AccessLevels.One();
            try
            {
                string token = await _token.GetToken();
                var httpClient = _httpClientFactory.CreateClient();
                httpClient.BaseAddress = new Uri(baseUrl);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var httpResponse = await httpClient.GetAsync($"AccessLevels/value/{id}");
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    result.Success = false;
                    result.Message = "Internal Error. Intente mas tarde.";
                }
                else
                {
                    var content = await httpResponse.Content.ReadFromJsonAsync<APIR_AccessLevels.One>();
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
                result.Data = new AccessLevelsModel();
                return result;
            }
            return result;
        }
    }
}

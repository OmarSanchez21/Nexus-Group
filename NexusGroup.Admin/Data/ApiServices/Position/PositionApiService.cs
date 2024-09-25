using NexusGroup.Admin.Data.ApiResponse;
using NexusGroup.Admin.Data.Models;
using NexusGroup.Admin.Data.Request;
using NexusGroup.Admin.Data.Response;
using NexusGroup.Admin.Data.Token;
using System.Net;
using System.Net.Http.Headers;

namespace NexusGroup.Admin.Data.ApiServices.Position
{
    public class PositionApiService : IPositionApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string baseUrl;
        private readonly IConfiguration _configuration;
        private readonly TokenHelper _token;
        public PositionApiService(IHttpClientFactory httpClientFactory, IConfiguration configuration, TokenHelper tokenHelper)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            baseUrl = this._configuration["ApiSettings:BaseUrl"];
            _token = tokenHelper;
        }

        public Task<APIR_Position.One> Add(PositionRequest.AddPosition add)
        {
            throw new NotImplementedException();
        }

        public Task<_CoreApiR.BaseResponse> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<_CoreApiR.BaseResponse> DeletePermantly(int id)
        {
            throw new NotImplementedException();
        }

        public Task<APIR_Position.One> Edit(PositionRequest.EditPosition edit)
        {
            throw new NotImplementedException();
        }

        public async Task<APIR_Position.All> GetAll()
        {
            APIR_Position.All result = new APIR_Position.All();
            try
            {
                string token = await _token.GetToken();
                var httpClient = _httpClientFactory.CreateClient();
                httpClient.BaseAddress = new Uri(baseUrl);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var httpResponse = await httpClient.GetAsync("Position");
                if (httpResponse.StatusCode == HttpStatusCode.InternalServerError)
                {
                    result.Success = false;
                    result.Message = "Internal Error. Pruebe mas tarde";
                }
                else
                {
                    var content = await httpResponse.Content.ReadFromJsonAsync<APIR_Position.All>();
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
                result.Data = Enumerable.Empty<PositionResponse>();
                return result;
            }
            return result;
        }

        public async Task<APIR_Position.One> GetOne(int id)
        {
            APIR_Position.One result = new APIR_Position.One();
            try
            {
                string token = await _token.GetToken();
                var httpClient = _httpClientFactory.CreateClient();
                httpClient.BaseAddress = new Uri(baseUrl);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var httpResponse = await httpClient.GetAsync($"Position/value/{id}");
                if (httpResponse.StatusCode == HttpStatusCode.InternalServerError)
                {
                    result.Success = false;
                    result.Message = "Internal Error. Pruebe mas tarde";
                }
                else
                {
                    var content = await httpResponse.Content.ReadFromJsonAsync<APIR_Position.One>();
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
                result.Data = new PositionModel();
                return result;
            }
            return result;
        }

        public Task<_CoreApiR.BaseResponse> Recover(int id)
        {
            throw new NotImplementedException();
        }

    }
}

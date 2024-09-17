using Microsoft.Extensions.Configuration;
using NexusGroup.Admin.Data.ApiResponse;
using NexusGroup.Admin.Data.Models;
using NexusGroup.Admin.Data.Request;
using NexusGroup.Admin.Data.Token;
using System.Net.Http;
using System.Net.Http.Headers;

namespace NexusGroup.Admin.Data.ApiServices
{
    public interface IEmpleadoService: _Core
    {
        Task<BaseResponse> Add(AddEmpleadoRequest request);
        Task<BaseResponse> Edit(EditEmpleadoRequest request);
    }
    public class EmpleadoService : IEmpleadoService
    {
        private readonly TokenHelper _token;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string baseUrl;
        private readonly IConfiguration _configuration;
        public EmpleadoService(TokenHelper tokenHelper, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _token = tokenHelper;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            baseUrl = this._configuration["ApiSettings:BaseUrl"];
        }
        public async Task<BaseResponse> Add(AddEmpleadoRequest request)
        {
            BaseResponse result = new BaseResponse();
            try
            {
                var token = await _token.GetToken();
                var httpClient = _httpClientFactory.CreateClient();
                httpClient.BaseAddress = new Uri(baseUrl);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var httpResponse = await httpClient.PostAsJsonAsync<AddEmpleadoRequest>("api/Empleado", request);
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    result.Success = false;
                    result.Message = "Error interno";
                }
                else
                {
                    var content = await httpResponse.Content.ReadFromJsonAsync<BaseResponse>();
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

        public Task<BaseResponse> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> DeletePermantly(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> Edit(EditEmpleadoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> Recover(int id)
        {
            throw new NotImplementedException();
        }
    }
}

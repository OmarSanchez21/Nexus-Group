using NexusGroup.Admin.Data.ApiResponse;
using NexusGroup.Admin.Data.Models;
using NexusGroup.Admin.Data.Request;
using NexusGroup.Admin.Data.Response;
using NexusGroup.Admin.Data.Token;
using System.Net;
using System.Net.Http.Headers;

namespace NexusGroup.Admin.Data.ApiServices.Employees
{
    public class EmployeesApiService : IEmployeesApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string baseUrl;
        private readonly IConfiguration _configuration;
        private readonly TokenHelper _token;
        public EmployeesApiService(IHttpClientFactory httpClientFactory, IConfiguration configuration, TokenHelper tokenHelper)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            baseUrl = this._configuration["ApiSettings:BaseUrl"];
            _token = tokenHelper;
        }
        public Task<APIR_Employee.One> Add(EmployeeRequest.AddEmployee add)
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

        public Task<APIR_Employee.One> Edit(EmployeeRequest.EditEmployee edit)
        {
            throw new NotImplementedException();
        }

        public async Task<APIR_Employee.All> GetAll()
        {
            APIR_Employee.All result = new APIR_Employee.All();
            try
            {
                var httpClient = _httpClientFactory.CreateClient();
                httpClient.BaseAddress = new Uri(baseUrl);
                var httpResponse = await httpClient.GetAsync("Employee");
                if(httpResponse.StatusCode == HttpStatusCode.InternalServerError)
                {
                    result.Success = false;
                    result.Message = "Internal errro. Intenta mas tarde.";
                }
                else
                {
                    var content = await httpResponse.Content.ReadFromJsonAsync<APIR_Employee.All>();
                    if(content != null)
                    {
                        result = content;
                    }
                }
            }
            catch (Exception ex) 
            {
                result.Success = false;
                result.Message = "Error en la peticion";
                result.Data = Enumerable.Empty<EmployeeResponse>();
                return result;
            }
            return result;
        }

        public async Task<APIR_Employee.One> GetOne(int id)
        {
            APIR_Employee.One result = new APIR_Employee.One();
            try
            {
                string token = await _token.GetToken();
                var httpClient = _httpClientFactory.CreateClient();
                httpClient.BaseAddress = new Uri(baseUrl);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var httpResponse = await httpClient.GetAsync($"Employee/value/{id}");
                if (httpResponse.StatusCode == HttpStatusCode.InternalServerError)
                {
                    result.Success = false;
                    result.Message = "Internal errro. Intenta mas tarde.";
                }
                else
                {
                    var content = await httpResponse.Content.ReadFromJsonAsync<APIR_Employee.One>();
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
                result.Data = new EmpleadoModel();
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

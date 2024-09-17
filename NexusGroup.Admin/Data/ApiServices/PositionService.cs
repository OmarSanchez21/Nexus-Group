using NexusGroup.Admin.Data.ApiResponse;
using NexusGroup.Admin.Data.Request;
using NexusGroup.Admin.Data.Token;

namespace NexusGroup.Admin.Data.ApiServices
{
    public interface IPositionService: _Core
    {
        Task<BaseResponse> Add(AddPositionRequest request);
        Task<BaseResponse> Edit(EditPositionRequest request);
    }
    public class PositionService : IPositionService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string baseUrl;
        private readonly IConfiguration _configuration;
        private readonly TokenHelper _token;
        public PositionService(IHttpClientFactory httpClientFactory, IConfiguration configuration, TokenHelper token)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _token = token;
            baseUrl = this._configuration["ApiSettings:BaseUrl"];
        }
        public Task<BaseResponse> Add(AddPositionRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> DeletePermantly(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> Edit(EditPositionRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> GetAll()
        {
            BaseResponse @base = new BaseResponse();
            try
            {
                var httpClient = _httpClientFactory.CreateClient();
                httpClient.BaseAddress = new Uri(this.baseUrl);
                var httpResponse = await httpClient.GetAsync($"api/Position");
                if(httpResponse.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    @base.Success = false;
                    @base.Message = "Ocurrio un error interno";
                }
                else
                {
                    var content = await httpResponse.Content.ReadFromJsonAsync<BaseResponse>();
                    if(content != null)
                    {
                        @base = content;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return @base;
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

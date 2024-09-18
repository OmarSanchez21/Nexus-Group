using NexusGroup.Admin.Data.Models;
using NexusGroup.Admin.Data.Response;

namespace NexusGroup.Admin.Data.ApiResponse
{
    public class APIR_Position
    {
        public class All : _CoreApiR.ApiResponse
        {
            public IEnumerable<PositionResponse> Data { get; set; }
        }
        public class One : _CoreApiR.ApiResponse
        {
            PositionModel Data { get; set; }
        }
    }
}

using NexusGroup.Admin.Data.Models;
using NexusGroup.Admin.Data.Response;

namespace NexusGroup.Admin.Data.ApiResponse
{
    public class APIR_OverTime
    {
        public class All : _CoreApiR.ApiResponse
        {
            IEnumerable<OverTimeResponse> Data { get; set; }
        }
        public class One : _CoreApiR.ApiResponse
        {
            OverTimeModel Data { get; set; }
        }
    }
}

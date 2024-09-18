using NexusGroup.Admin.Data.Models;
using NexusGroup.Admin.Data.Response;

namespace NexusGroup.Admin.Data.ApiResponse
{
    public class APIR_PayRoll
    {
        public class All : _CoreApiR.ApiResponse
        {
            IEnumerable<PayRollResponse> Data { get; set; }
        }
        public class One : _CoreApiR.ApiResponse
        {
            PayRollModel Data { get; set; }
        }
    }
}

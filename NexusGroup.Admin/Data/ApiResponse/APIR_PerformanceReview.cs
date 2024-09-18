using NexusGroup.Admin.Data.Models;
using NexusGroup.Admin.Data.Response;

namespace NexusGroup.Admin.Data.ApiResponse
{
    public class APIR_PerformanceReview
    {
        public class All : _CoreApiR.ApiResponse
        {
            IEnumerable<PerformanceReviewResponse> Data { get; set; }
        }
        public class One : _CoreApiR.ApiResponse
        {
            PerformanceReviewModel Data { get; set; }
        }
    }
}

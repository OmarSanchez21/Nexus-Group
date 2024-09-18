using NexusGroup.Admin.Data.Response;

namespace NexusGroup.Admin.Data.ApiResponse
{
    public class APIR_JobOffers
    {
        public class All : _CoreApiR.ApiResponse
        {
            IEnumerable<AccessLevelsResponse> Data { get; set; }
        }
        public class One : _CoreApiR.ApiResponse
        {
            AccessLevelsResponse Data { get; set; }
        }
    }
}

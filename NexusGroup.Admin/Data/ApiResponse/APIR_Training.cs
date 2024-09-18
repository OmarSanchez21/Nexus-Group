using NexusGroup.Admin.Data.Models;
using NexusGroup.Admin.Data.Response;

namespace NexusGroup.Admin.Data.ApiResponse
{
    public class APIR_Training
    {
        public class All : _CoreApiR.ApiResponse
        {
            IEnumerable<TrainingResponse> Data { get; set; }
        }
        public class One : _CoreApiR.ApiResponse
        {
            TrainingModel Data { get; set; }
        }
    }
}

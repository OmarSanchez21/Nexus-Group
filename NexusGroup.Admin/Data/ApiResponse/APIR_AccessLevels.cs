using NexusGroup.Admin.Data.Models;
using NexusGroup.Admin.Data.Response;

namespace NexusGroup.Admin.Data.ApiResponse
{
    public class APIR_AccessLevels
    {
        public class All: _CoreApiR.ApiResponse
        {
            IEnumerable<AccessLevelsResponse> Data { get; set; }
        }
        public class One : _CoreApiR.ApiResponse
        {
            AccessLevelsModel Data { get; set; }
        }
    }
}

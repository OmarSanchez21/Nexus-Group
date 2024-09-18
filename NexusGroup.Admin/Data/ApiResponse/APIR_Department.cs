using NexusGroup.Admin.Data.Models;
using NexusGroup.Admin.Data.Response;

namespace NexusGroup.Admin.Data.ApiResponse
{
    public class APIR_Department
    {
        public class All : _CoreApiR.ApiResponse
        {
            IEnumerable<DepartmentResponse> Data { get; set; }
        }
        public class One : _CoreApiR.ApiResponse
        {
            DepartmentModel Data { get; set; }
        }
    }
}

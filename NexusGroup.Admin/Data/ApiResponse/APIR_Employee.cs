using NexusGroup.Admin.Data.Models;
using NexusGroup.Admin.Data.Response;

namespace NexusGroup.Admin.Data.ApiResponse
{
    public class APIR_Employee
    {
        public class All : _CoreApiR.ApiResponse
        {
            public IEnumerable<EmployeeResponse> Data { get; set; }
        }
        public class One : _CoreApiR.ApiResponse
        {
            public EmpleadoModel Data { get; set; }
        }
    }
}

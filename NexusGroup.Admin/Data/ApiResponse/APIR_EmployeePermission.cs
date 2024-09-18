using NexusGroup.Admin.Data.Models;
using NexusGroup.Admin.Data.Response;

namespace NexusGroup.Admin.Data.ApiResponse
{
    public class APIR_EmployeePermission
    {
        public class All : _CoreApiR.ApiResponse
        {
            IEnumerable<EmployeesPermissionResponse> Data { get; set; }
        }
        public class One : _CoreApiR.ApiResponse
        {
            EmployeesPermissionModel Data { get; set; }
        }
    }
}

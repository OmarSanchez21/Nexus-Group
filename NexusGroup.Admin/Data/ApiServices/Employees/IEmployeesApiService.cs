using NexusGroup.Admin.Data.ApiResponse;
using NexusGroup.Admin.Data.Request;
using NexusGroup.Admin.Data.Response;

namespace NexusGroup.Admin.Data.ApiServices.Employees
{
    public interface IEmployeesApiService: _CoreApiService
    {
        Task<APIR_Employee.All> GetAll();
        Task<APIR_Employee.One> GetOne(int id);
        Task<APIR_Employee.One> Save(EmployeeRequest.AddEmployee add);
        Task<APIR_Employee.One> Edit(EmployeeRequest.EditEmployee edit);
    }
}

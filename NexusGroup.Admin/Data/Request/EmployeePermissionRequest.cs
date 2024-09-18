namespace NexusGroup.Admin.Data.Request
{
    public class EmployeePermissionRequest
    {
        public class AddEmployeePermission
        {
            public int EmployeeID { get; set; }
            public string PermissionType { get; set; }
            public DateOnly StartDate { get; set; }
            public DateOnly EndDate { get; set; }
            public bool IsRequest { get; set; }
            public DateOnly ApprovedDate { get; set; }
        }
        public class EditEmployeePermission
        {
            public int EmployeesPermissionID { get; set; }
            public int EmployeeID { get; set; }
            public string PermissionType { get; set; }
            public DateOnly StartDate { get; set; }
            public DateOnly EndDate { get; set; }
            public bool IsRequest { get; set; }
            public DateOnly ApprovedDate { get; set; }
        }
    }
}

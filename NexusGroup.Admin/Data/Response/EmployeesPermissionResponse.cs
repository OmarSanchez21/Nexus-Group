namespace NexusGroup.Admin.Data.Response
{
    public class EmployeesPermissionResponse
    {
        public int EmployeesPermissionID { get; set; }
        public int EmployeeID { get; set; }
        public string PermissionType { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public bool IsRequest { get; set; }
        public DateOnly ApprovedDate { get; set; }
        public DateTime CreateAt { get; set; }
    }
}

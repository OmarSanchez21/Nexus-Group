namespace NexusGroup.Admin.Data.Request
{
    public class DepartmentRequest
    {
        public class AddDepartment
        {
            public string Name { get; set; }
            public int ManagerID { get; set; }
        }
        public class EditDepartment
        {
            public int DepartmentID { get; set; }
            public string Name { get; set; }
            public int ManagerID { get; set; }
        }
    }
}

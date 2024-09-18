namespace NexusGroup.Admin.Data.Models
{
    public class DepartmentModel: _CoreM
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public int ManagerID { get; set; }
    }
}

using NexusGroup.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace NexusGroup.Data.Models
{
    public class EmployeesPermissionModels: BaseData
    {
        [Key]
        public int permissionID { get; set; }
        public int employeeID { get; set; }
        public string permissionType { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public DateTime requestDate { get; set; }
        public bool isAproved { get; set; }     
    }
}

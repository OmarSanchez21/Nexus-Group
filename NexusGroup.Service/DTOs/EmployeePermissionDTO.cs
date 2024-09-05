using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.DTOs
{
    public class EmployeePermissionDTO
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
    public class AddEmployeePermissionDTO
    {
        public int EmployeeID { get; set; }
        public string PermissionType { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public bool IsRequest { get; set; }
        public DateOnly ApprovedDate { get; set; }
    }
    public class EditEmployeePermissionDTO
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

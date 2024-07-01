using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.DTOs.EmployeesPermission
{
    public class AddEmployeesPermissionDTO
    {
        public int employeeID { get; set; }
        public string permissionType { get; set; }
        public DateOnly startDate { get; set; }
        public DateOnly endDate { get; set; }
        public DateOnly requestDate { get; set; }
        public bool isAproved { get; set; }
    }
}

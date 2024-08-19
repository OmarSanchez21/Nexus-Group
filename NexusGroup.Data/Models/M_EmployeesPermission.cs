using NexusGroup.Data.BaseData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Data.Models
{
    public class M_EmployeesPermission: CoreData
    {
        [Key]
        public int EmployeesPermissionID { get; set; }
        public int EmployeeID { get; set; }
        public string PermissionType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsRequest { get; set; }
        public DateTime ApprovedDate { get; set; }
    }
}

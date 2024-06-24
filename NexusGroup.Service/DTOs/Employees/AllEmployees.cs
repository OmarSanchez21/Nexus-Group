using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.DTOs.Employees
{
    internal class AllEmployees
    {
        public int employeeID { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string photo { get; set; }
        public string email { get; set; }
        public string passwordHash { get; set; }
        public DateOnly joinDate { get; set; }
        public int positionID { get; set; }
        public int accessLevelID { get; set; }
    }
}

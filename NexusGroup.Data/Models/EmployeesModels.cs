using NexusGroup.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Data.Models
{
    public class EmployeesModels: BaseData
    {
        [Key]
        public int employeeID { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string photo { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string passwordHash { get; set; }
        public DateTime joinDate { get; set; }
        public int positionID { get; set; }
        public int accessLevelID { get; set; }
    }
}

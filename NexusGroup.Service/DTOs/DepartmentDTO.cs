using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.DTOs
{
    public class DepartmentDTO
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public int ManagerID { get; set; }
        public DateTime CreateAt { get; set; }
    }
    public class AddDepartmentDTO
    {
        public string Name { get; set; }
        public int ManagerID { get; set; }
    }
    public class EditDepartmentDTO
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public int ManagerID { get; set; }
    }
}

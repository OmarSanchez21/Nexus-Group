using NexusGroup.Data.BaseData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Data.Models
{
    public class M_Department: CoreData
    {
        [Key]
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public int ManagerID { get; set; }
    }
}

using NexusGroup.Data.BaseData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Data.Models
{
    public class M_Training: CoreData
    {
        [Key]
        public int TrainingID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime TrainingDate { get; set; }
        public string TrainingDescription { get; set; }
    }
}

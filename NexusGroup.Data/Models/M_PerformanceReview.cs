using NexusGroup.Data.BaseData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Data.Models
{
    public class M_PerformanceReview: CoreData
    {
        [Key]
        public int ReviewID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime ReviewDate { get; set; }
        public string Reviewer { get; set; }
        public string ReviewDescription { get; set; }
        public string Observation { get; set; }
        public int Score { get; set; }
    }
}

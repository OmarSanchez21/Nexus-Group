using NexusGroup.Data.BaseData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Data.Models
{
    public class M_Overtime: CoreData
    {
        [Key]
        public int OverTimeID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime WorkDate { get; set; }
        public string PayrollPeriod { get; set; }
        public int ExtraHours { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal TotalPayment { get; set; }
    }
}

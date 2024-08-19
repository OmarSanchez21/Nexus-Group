using NexusGroup.Data.BaseData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Data.Models
{
    public class M_PayRoll: CoreData
    {
        [Key]
        public int PayrollID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime PayDate { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal? OvertimePay { get; set; }
        public decimal? Deduction { get; set; }
        public decimal SalaryNet { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.DTOs
{
    public class PayRollDTO
    {
        public int PayrollID { get; set; }
        public int EmployeeID { get; set; }
        public DateOnly PayDate { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal? OvertimePay { get; set; }
        public decimal? Deduction { get; set; }
        public decimal SalaryNet { get; set; }
        public DateTime CreateAt { get; set; }
    }
    public class AddPayRollDTO
    {
        public int EmployeeID { get; set; }
        public DateOnly PayDate { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal? OvertimePay { get; set; }
        public decimal? Deduction { get; set; }
    }
    public class EditPayRollDTO
    {
        public int PayrollID { get; set; }
        public int EmployeeID { get; set; }
        public DateOnly PayDate { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal? OvertimePay { get; set; }
        public decimal? Deduction { get; set; }
    }

}

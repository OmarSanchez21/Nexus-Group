using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.DTOs
{
    public class OverTimeDTO
    {
        public int OverTimeID { get; set; }
        public int EmployeeID { get; set; }
        public DateOnly WorkDate { get; set; }
        public string PayrollPeriod { get; set; }
        public int ExtraHours { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal TotalPayment { get; set; }
        public DateTime CreateAt { get; set; }
    }
    public class AddOverTimeDTO
    {
        public int EmployeeID { get; set; }
        public DateOnly WorkDate { get; set; }
        public string PayrollPeriod { get; set; }
        public int ExtraHours { get; set; }
        public decimal HourlyRate { get; set; }
    }
    public class EditOverTimeDTO
    {
        public int OverTimeID { get; set; }
        public int EmployeeID { get; set; }
        public DateOnly WorkDate { get; set; }
        public string PayrollPeriod { get; set; }
        public int ExtraHours { get; set; }
        public decimal HourlyRate { get; set; }
    }
}

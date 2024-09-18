namespace NexusGroup.Admin.Data.Models
{
    public class PayRollModel: _CoreM
    {
        public int PayrollID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime PayDate { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal? OvertimePay { get; set; }
        public decimal? Deduction { get; set; }
        public decimal SalaryNet { get; set; }
    }
}

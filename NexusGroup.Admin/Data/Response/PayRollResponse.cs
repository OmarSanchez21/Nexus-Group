namespace NexusGroup.Admin.Data.Response
{
    public class PayRollResponse
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
}

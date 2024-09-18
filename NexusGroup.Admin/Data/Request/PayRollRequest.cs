namespace NexusGroup.Admin.Data.Request
{
    public class PayRollRequest
    {
        public class AddPayRoll
        {
            public int EmployeeID { get; set; }
            public DateOnly PayDate { get; set; }
            public decimal BaseSalary { get; set; }
            public decimal? OvertimePay { get; set; }
            public decimal? Deduction { get; set; }
        }
        public class EditPayRoll
        {
            public int PayrollID { get; set; }
            public int EmployeeID { get; set; }
            public DateOnly PayDate { get; set; }
            public decimal BaseSalary { get; set; }
            public decimal? OvertimePay { get; set; }
            public decimal? Deduction { get; set; }
        }
    }
}

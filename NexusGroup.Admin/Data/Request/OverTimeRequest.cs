namespace NexusGroup.Admin.Data.Request
{
    public class OverTimeRequest
    {
        public class AddOverTime
        {
            public int EmployeeID { get; set; }
            public DateOnly WorkDate { get; set; }
            public string PayrollPeriod { get; set; }
            public int ExtraHours { get; set; }
            public decimal HourlyRate { get; set; }
        }
        public class EditOverTime
        {
            public int OverTimeID { get; set; }
            public int EmployeeID { get; set; }
            public DateOnly WorkDate { get; set; }
            public string PayrollPeriod { get; set; }
            public int ExtraHours { get; set; }
            public decimal HourlyRate { get; set; }
        }
    }
}

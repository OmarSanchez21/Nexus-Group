namespace NexusGroup.Admin.Data.Response
{
    public class OverTimeResponse
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
}

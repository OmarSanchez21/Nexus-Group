namespace NexusGroup.Admin.Data.Models
{
    public class OverTimeModel: _CoreM
    {
        public int OverTimeID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime WorkDate { get; set; }
        public string PayrollPeriod { get; set; }
        public int ExtraHours { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal TotalPayment { get; set; }
    }
}

namespace NexusGroup.Admin.Data.Models
{
    public class PerformanceReviewModel: _CoreM
    {
        public int ReviewID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime ReviewDate { get; set; }
        public string Reviewer { get; set; }
        public string ReviewDescription { get; set; }
        public string Observation { get; set; }
        public int Score { get; set; }
    }
}

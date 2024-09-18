namespace NexusGroup.Admin.Data.Response
{
    public class PerformanceReviewResponse
    {
        public int ReviewID { get; set; }
        public int EmployeeID { get; set; }
        public DateOnly ReviewDate { get; set; }
        public string Reviewer { get; set; }
        public string ReviewDescription { get; set; }
        public string Observation { get; set; }
        public int Score { get; set; }
        public DateTime CreateAt { get; set; }
    }
}

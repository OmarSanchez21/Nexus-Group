namespace NexusGroup.Admin.Data.Request
{
    public class PerformanceReviewRequest
    {
        public class AddPerformanceReview
        {
            public int EmployeeID { get; set; }
            public DateOnly ReviewDate { get; set; }
            public string Reviewer { get; set; }
            public string ReviewDescription { get; set; }
            public string Observation { get; set; }
            public int Score { get; set; }
        }
        public class EditPerformanceReview
        {
            public int ReviewID { get; set; }
            public int EmployeeID { get; set; }
            public DateOnly ReviewDate { get; set; }
            public string Reviewer { get; set; }
            public string ReviewDescription { get; set; }
            public string Observation { get; set; }
            public int Score { get; set; }
        }
    }
}

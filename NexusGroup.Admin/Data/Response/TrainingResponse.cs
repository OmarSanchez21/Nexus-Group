namespace NexusGroup.Admin.Data.Response
{
    public class TrainingResponse
    {
        public int TrainingID { get; set; }
        public int EmployeeID { get; set; }
        public DateOnly TrainingDate { get; set; }
        public string TrainingDescription { get; set; }
        public DateTime CreateAt { get; set; }
    }
}

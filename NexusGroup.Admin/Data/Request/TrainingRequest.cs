namespace NexusGroup.Admin.Data.Request
{
    public class TrainingRequest
    {
        public class AddTraining
        {
            public int EmployeeID { get; set; }
            public DateOnly TrainingDate { get; set; }
            public string TrainingDescription { get; set; }
        }
        public class EditTraining
        {
            public int TrainingID { get; set; }
            public int EmployeeID { get; set; }
            public DateOnly TrainingDate { get; set; }
            public string TrainingDescription { get; set; }
        }
    }
}

namespace NexusGroup.Admin.Data.Models
{
    public class TrainingModel: _CoreM
    {
        public int TrainingID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime TrainingDate { get; set; }
        public string TrainingDescription { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.DTOs
{
    public class TrainingDTO
    {
        public int TrainingID { get; set; }
        public int EmployeeID { get; set; }
        public DateOnly TrainingDate { get; set; }
        public string TrainingDescription { get; set; }
        public DateTime CreateAt { get; set; }
    }
    public class AddTrainingDTO
    {
        public int EmployeeID { get; set; }
        public DateOnly TrainingDate { get; set; }
        public string TrainingDescription { get; set; }
    }
    public class EditTrainingDTO
    {
        public int TrainingID { get; set; }
        public int EmployeeID { get; set; }
        public DateOnly TrainingDate { get; set; }
        public string TrainingDescription { get; set; }
    }
}

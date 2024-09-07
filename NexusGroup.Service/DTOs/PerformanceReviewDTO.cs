using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.DTOs
{
    public class PerformanceReviewDTO
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
    public class AddPerformanceReviewDTO
    {
        public int EmployeeID { get; set; }
        public DateOnly ReviewDate { get; set; }
        public string Reviewer { get; set; }
        public string ReviewDescription { get; set; }
        public string Observation { get; set; }
        public int Score { get; set; }
    }
    public class EditPerformanceReviewDTO
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

using NexusGroup.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Data.Models
{
    public class EvaluationsModels: BaseData
    {
        [Key]
        public int evaluationID { get; set; }
        public int employeeID { get; set; }
        public DateTime evalutionDate { get; set; }
        public string objectives { get; set; }
        public string feedback { get; set; }
        public string result { get; set; }
    }
}

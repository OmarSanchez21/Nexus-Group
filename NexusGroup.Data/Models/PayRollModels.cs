using NexusGroup.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Data.Models
{
    public class PayRollModels: BaseData
    {
        [Key]
        public int payRollID { get; set; }
        public int employeeID { get; set; }
        public decimal salary { get; set; }
        public decimal? deductions { get; set; }
        public decimal? taxes { get; set; }
        public DateTime paymentDate { get; set; }
    }
}

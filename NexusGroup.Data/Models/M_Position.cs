using NexusGroup.Data.BaseData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Data.Models
{
    public class M_Position: CoreData
    {
        [Key]
        public int PositionID { get; set; }
        public string Title { get; set; }
    }
}

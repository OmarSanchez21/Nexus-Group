using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Data.Models
{
    public class PositionsModels
    {
        [Key]
        public int positionID { get; set; }
        public string name { get; set; }
    }
}

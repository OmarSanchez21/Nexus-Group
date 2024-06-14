using NexusGroup.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Data.Models
{
    public class AccessLevelsModels: BaseData
    {
        [Key]
        public int accessLevelsID { get; set; }
        public string name { get; set; }
    }
}

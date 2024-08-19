using NexusGroup.Data.BaseData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Data.Models
{
    public class M_AccessLevels: CoreData
    {
        [Key]
        public string AccessLevelsID { get; set; }
        public string Name { get; set; }
    }
}

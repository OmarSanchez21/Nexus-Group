using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.DTOs
{
    public class AccessLevelsDTO
    {
        public string AccessLevelsID { get; set; }
        public string Name { get; set; }
        public DateOnly CreateAt { get; set; }
    }
}

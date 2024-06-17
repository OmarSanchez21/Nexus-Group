using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.DTOs.AccessLevels
{
    public class UpdateAccessLevels
    {
        public UpdateAccessLevels()
        {
            this.updatedRegistration = DateTime.Now;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime updatedRegistration { get; set; }
    }
}

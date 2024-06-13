using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.DTOs.Position
{
    public class UpdatePosition
    {
        public UpdatePosition()
        {
            this.updatedRegistration = DateTime.Now;
        }
        public int Id { get; set; }
        public string name { get; set; }
        public DateTime updatedRegistration { get; set; }
    }
}

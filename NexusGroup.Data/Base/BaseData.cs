using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;

namespace NexusGroup.Data.Base
{
    public class BaseData
    {
        public BaseData()
        {
            this.isDeleted = false;
        }
        public DateTime createdRegistration { get; set; }
        public DateTime updatedRegistration { get; set; }
        public bool isDeleted { get; set; }
    }
}

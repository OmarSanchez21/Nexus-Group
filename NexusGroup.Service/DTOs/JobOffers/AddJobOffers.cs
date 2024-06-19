using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.DTOs.JobOffers
{
    public class AddJobOffers
    {
        public string title { get; set; }
        public string description { get; set; }
        public DateOnly publicationDate { get; set; }
        public DateOnly clouserDate { get; set; }
    }
}

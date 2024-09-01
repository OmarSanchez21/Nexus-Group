using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.DTOs
{
    public class JobOffersDTO
    {
        public int JobOfferID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateOnly StartPublication { get; set; }
        public DateOnly EndPublication { get; set; }
        public DateTime CreateAt { get; set; }
    }
    public class AddJobOffersDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateOnly StartPublication { get; set; }
        public DateOnly EndPublication { get; set; }

    }
    public class EditJobOffersDTO
    {
        public int JobOfferID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateOnly StartPublication { get; set; }
        public DateOnly EndPublication { get; set; }

    }
}

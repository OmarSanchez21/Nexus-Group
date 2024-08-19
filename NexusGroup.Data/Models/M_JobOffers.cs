using NexusGroup.Data.BaseData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Data.Models
{
    public class M_JobOffers: CoreData
    {
        [Key]
        public int JobOfferID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartPublication { get; set; }
        public DateTime EndPublication { get; set; }
    }
}

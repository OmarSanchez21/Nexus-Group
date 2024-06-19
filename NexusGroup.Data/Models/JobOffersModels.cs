using NexusGroup.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Data.Models
{
    public class JobOffersModels: BaseData
    {
        [Key]
        public int offerID { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateOnly publicationDate { get; set; }
        public DateOnly clouserDate { get; set; }
    }
}

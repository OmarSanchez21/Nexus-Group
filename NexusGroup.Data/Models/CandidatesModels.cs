using NexusGroup.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Data.Models
{
    public class CandidatesModels: BaseData
    {
        [Key]
        public int candidateID { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string cvURL { get; set; }
        public string status { get; set; }
        public int offerID { get; set; }
    }
}

using NexusGroup.Data.BaseData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Data.Models
{
    public class M_Candidates: CoreData
    {
        [Key]
        public int CandidateID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string cvURL { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int IdJobOffer { get; set; }
    }
}

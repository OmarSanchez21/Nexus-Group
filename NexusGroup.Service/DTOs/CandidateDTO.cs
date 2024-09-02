using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.DTOs
{
    public class CandidateDTO
    {
        public int CandidateID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string cvURL { get; set; }
        public DateOnly ApplicationDate { get; set; }
        public int IdJobOffer { get; set; }
        public DateTime CreateAt { get; set; }
    }
    public class AddCandidateDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string cvURL { get; set; }
        public DateOnly ApplicationDate { get; set; }
        public int IdJobOffer { get; set; }
    }
    public class EditCandidateDTO
    {
        public int CandidateID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string cvURL { get; set; }
        public DateOnly ApplicationDate { get; set; }
        public int IdJobOffer { get; set; }
    }
}

namespace NexusGroup.Admin.Data.Models
{
    public class CandidatesModel: _CoreM
    {
        public int CandidateID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string cvURL { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int IdJobOffer { get; set; }
    }
}

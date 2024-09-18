namespace NexusGroup.Admin.Data.Request
{
    public class CandidateRequest
    {
        public class AddCandidate
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string cvURL { get; set; }
            public DateOnly ApplicationDate { get; set; }
            public int IdJobOffer { get; set; }
        }
        public class EditCandidate
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
}

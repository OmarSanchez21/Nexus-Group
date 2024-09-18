namespace NexusGroup.Admin.Data.Response
{
    public class JobOffersResponse
    {
        public int JobOfferID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateOnly StartPublication { get; set; }
        public DateOnly EndPublication { get; set; }
        public DateTime CreateAt { get; set; }
    }
}

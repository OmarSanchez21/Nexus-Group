namespace NexusGroup.Admin.Data.Request
{
    public class JobOffersRequest
    {
        public class AddJobOffers
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public DateOnly StartPublication { get; set; }
            public DateOnly EndPublication { get; set; }
        }
        public class EditJobOffers
        {
            public int JobOfferID { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public DateOnly StartPublication { get; set; }
            public DateOnly EndPublication { get; set; }
        }
    }
}

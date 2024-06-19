namespace NexusGroup.Service.DTOs.JobOffers
{
    public class AllJobOffers
    {
        public int offerID { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateOnly publicationDate { get; set; }
        public DateOnly clouserDate { get; set; }
    }
}

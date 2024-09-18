namespace NexusGroup.Admin.Data.Models
{
    public class JobOffersModel: _CoreM
    {
        public int JobOfferID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartPublication { get; set; }
        public DateTime EndPublication { get; set; }
    }
}

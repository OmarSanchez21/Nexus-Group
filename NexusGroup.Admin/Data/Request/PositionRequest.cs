namespace NexusGroup.Admin.Data.Request
{
    public partial class PositionRequest
    {
        public string Title { get; set; }
    }
    public partial class AllPositionReponse : PositionRequest
    {
        public int PositionID { get; set; }
        public DateTime CreateAt { get; set; }
    }
    public partial class AddPositionRequest: PositionRequest { 
    }
    public partial class EditPositionRequest : PositionRequest
    {
        public int PositionID { get; set; }
    }
}

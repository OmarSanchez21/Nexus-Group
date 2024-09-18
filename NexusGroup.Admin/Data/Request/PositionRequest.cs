namespace NexusGroup.Admin.Data.Request
{
    public class PositionRequest
    {
        public class AddPosition
        {
            public string Title { get; set; }
        }
        public class EditPosition
        {
            public int Id { get; set; }
            public string Title { get; set; }
        }
    }
}

namespace NexusGroup.Admin.Data.ApiResponse
{
    public class _CoreApiR
    {
        public class ApiResponse
        {
            public bool Success { get; set; }
            public string Message { get; set; }
        }
        public class BaseResponse
        {

            public bool Success { get; set; }
            public string Message { get; set; }
            public dynamic? Data { get; set; }
        }
    }
}

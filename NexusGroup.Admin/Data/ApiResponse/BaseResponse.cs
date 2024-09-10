namespace NexusGroup.Admin.Data.ApiResponse
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
    }
    public class BaseResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public dynamic? Data { get; set; }
    }
}

namespace NexusGroup.Admin.Data.Request
{
    public class AuthRequest
    {
        public class LoginRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
        public class ChangePassword
        {
            public int Id { get; set; }
            public string newPassword { get; set; }
        }
    }
}

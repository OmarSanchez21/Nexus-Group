
namespace NexusGroup.Service.Base
{
    public static class FuncCore
    {
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        public static bool VerifyPassword(string password, string hashed)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashed);
        }
        public static bool isValidEmail(string email)
        {
            return email.Contains("@") && email.Contains(".");
        }
        public static ServiceResult CreateServiceResultValidations(string message)
        {
            ServiceResult result = new ServiceResult();
            if (!string.IsNullOrEmpty(message))
            {
                result.Success = false;
                result.Message = message;
            }
            return result;
        }
    }
}

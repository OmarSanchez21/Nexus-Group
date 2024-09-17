using Blazored.SessionStorage;
using System.IdentityModel.Tokens.Jwt;
namespace NexusGroup.Admin.Data.Token
{
    public class JwtToken
    {
        public string UniqueName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string AccessLevel { get; set; }
        public string PositionID { get; set; }
        public DateTime NotBefore { get; set; }
        public DateTime Expiration { get; set; }
        public DateTime IssuedAt { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
    public class TokenHelper
    {
        private readonly ISessionStorageService _sessionStorageService;
        public TokenHelper(ISessionStorageService sessionStorageService)
        {
            _sessionStorageService = sessionStorageService;
        }
        public async Task SaveToken(string token)
        {
            await _sessionStorageService.SetItemAsync("token", token);
        }
        public async Task<string> GetToken()
        {
            return await _sessionStorageService.GetItemAsync<string>("token");
        }
        public async Task<JwtToken> GetDecodedToken()
        {
            var token = await GetToken();
            if (string.IsNullOrEmpty(token))
                return null;
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var payload = jwtToken.Payload;
            var tokenData = new JwtToken()
            {
                UniqueName = payload["unique_name"].ToString(),
                FullName = payload["FullName"].ToString(),
                Email = payload["email"].ToString(),
                AccessLevel = payload["AccessLevel"].ToString(),
                PositionID = payload["PositionID"].ToString(),
                NotBefore = DateTimeOffset.FromUnixTimeSeconds(long.Parse(payload["nbf"].ToString())).DateTime,
                Expiration = DateTimeOffset.FromUnixTimeSeconds(long.Parse(payload["exp"].ToString())).DateTime,
                IssuedAt = DateTimeOffset.FromUnixTimeSeconds(long.Parse(payload["iat"].ToString())).DateTime,
                Issuer = payload["iss"].ToString(),
                Audience = payload["aud"].ToString()
            };
            return tokenData;
        }
        public async Task<string> GetTokenValueAsync(string key)
        {
            var decodedToken = await GetDecodedToken();
            if (decodedToken == null)
                return null;

            return key switch
            {
                "FullName" => decodedToken.FullName,
                "Email" => decodedToken.Email,
                "AccessLevel" => decodedToken.AccessLevel,
                "PositionID" => decodedToken.PositionID,
                _ => null
            };
        }

        public async Task<bool> IsTokenExpiredAsync()
        {
            var decodedToken = await GetDecodedToken();
            if (decodedToken == null)
                return true;

            return DateTime.UtcNow >= decodedToken.Expiration;
        }
        public async Task<string> ExtractToken()
        {
            string token = await GetToken();
            if(token == null)
            {
                return null;
            }
            else
            {
                return await Task.FromResult(token.Substring(0,15));
            }
        }
    }
}

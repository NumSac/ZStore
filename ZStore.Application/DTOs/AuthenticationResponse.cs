using System.Text.Json.Serialization;

namespace ZStore.Application.DTOs
{
    public class AuthenticationResponse
    {
        public string Id { get; set; } = "";
        public string UserName { get; set; } = "";
        public string Email { get; set; } = "";
        public List<string> Roles { get; set; } = null!;
        public bool IsVerified { get; set; }
        public string Token { get; set; } = "";

        [JsonIgnore]
        public string? RefreshToken { get; set; } = "";
    }
}

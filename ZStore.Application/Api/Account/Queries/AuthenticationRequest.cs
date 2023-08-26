using System.ComponentModel.DataAnnotations;

namespace ZStore.Application.Api.Account.Queries
{
    public class AuthenticationRequest
    {
        [Required]
        public string Email { get; set; } = "";

        [Required]
        public string Password { get; set; } = "";
    }
}

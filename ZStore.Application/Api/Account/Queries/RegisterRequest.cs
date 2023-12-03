using System.ComponentModel.DataAnnotations;
using ZStore.Application.DTOs.Common;

namespace ZStore.Application.Api.Account.Queries
{
    public class RegisterRequest : Credentials
    {
        [Required]
        public string FirstName { get; set; } = "";

        [Required]
        public string LastName { get; set; } = "";

        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        [MinLength(6)]
        public string UserName { get; set; } = "";
    }
}

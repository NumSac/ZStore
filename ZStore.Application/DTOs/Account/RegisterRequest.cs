using System.ComponentModel.DataAnnotations;
using ZStore.Application.DTOs.Common;

namespace ZStore.Application.DTOs.Account
{
    public class RegisterRequest : Credentials
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string UserName { get; set; } = "";
    }
}

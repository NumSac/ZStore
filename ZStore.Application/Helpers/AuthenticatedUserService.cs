using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using ZStore.Application.Interfaces;

namespace ZStore.Application.Helpers
{
    public class AuthenticatedUserService : IUser, IAuthenticatedUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticatedUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string? Id => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}

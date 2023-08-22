using Microsoft.AspNetCore.Identity;
using ZStore.Application.DTOs;
using ZStore.Application.Helpers;
using ZStore.Domain.Common;
using ZStore.Domain.Utils;

namespace ZStore.Application.Features
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AccountBaseEntity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenService _tokenService;

        public AccountService(UserManager<AccountBaseEntity> userManager,
             RoleManager<IdentityRole> roleManager, 
            ITokenService tokenService
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
        }

        public async Task<Response<string>> ChangePassword(string id, ChangePasswordDTO request)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return new Response<string>("User not found.");
            }

            var passwordChangeResult = await _userManager.ChangePasswordAsync(user, 
                request.CurrentPassword, request.NewPassword
                );
            if (!passwordChangeResult.Succeeded)
            {
                return new Response<string>("Failed to change password.");
            }

            return new Response<string>("Password changed successfully.");
        }
    }
}

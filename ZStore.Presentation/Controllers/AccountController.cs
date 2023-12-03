using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ZStore.Application.Api.Interfaces;
using ZStore.Application.DTOs.Account;
using ZStore.Domain.Exceptions;
using ZStore.Domain.Utils;

namespace ZStore.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = SD.Role_User)]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody] AuthenticationRequest request)
        {
            return Ok(await _accountService.AuthenticateAsync(request));
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest request)
        {
            return Ok(await _accountService.RegisterAsync(request));
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(await _accountService.UpdateUserInfo(GetNameIdentifierFromClaimsPrincipal(User), request));
        }

        [HttpPost("UpdatePassword")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(await _accountService.UpdatePassword(GetNameIdentifierFromClaimsPrincipal(User), request));
        }

        private static string GetNameIdentifierFromClaimsPrincipal(ClaimsPrincipal claimsPrincipal)
        {
            Claim? nameIdentifierClaim = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier);

            if (nameIdentifierClaim == null)
                throw new ApiException($"Invalid Token");

            return nameIdentifierClaim.Value;
        }
    }
}

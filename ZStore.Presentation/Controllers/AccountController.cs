using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ZStore.Application.Api.Features;
using ZStore.Application.DTOs;
using ZStore.Domain.Exceptions;
using ZStore.Domain.Utils;

namespace ZStore.Presentation.Controllers
{
    [Authorize(Roles = SD.Role_User)]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] AuthenticationRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(await _accountService.AuthenticateAsync(request));
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
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
                throw new ApiException($"No Id associated");

            return nameIdentifierClaim.Value;
        }
    }
}

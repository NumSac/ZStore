using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ZStore.Application.Api.Account.Queries;
using ZStore.Application.Api.Account.Service;
using ZStore.Application.DTOs;
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
                throw new ApiException($"Invalid Token");

            return nameIdentifierClaim.Value;
        }
    }
}

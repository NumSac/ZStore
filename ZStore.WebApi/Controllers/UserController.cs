using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ZStore.Application.DTOs;
using ZStore.Application.Features;
using ZStore.Domain.Exceptions;

namespace ZStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) 
        { 
            _userService = userService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] AuthenticationRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(await _userService.AuthenticateAsync(request));
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(await _userService.RegisterAsync(request));   
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(await _userService.UpdateUserInfo(GetNameIdentifierFromClaimsPrincipal(User), request));
        }

        [HttpPost("UpdatePassword")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(await _userService.UpdatePassword(GetNameIdentifierFromClaimsPrincipal(User), request));
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

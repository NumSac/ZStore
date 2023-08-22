using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZStore.Domain.Utils;

namespace ZStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public AccountController() { }

        [HttpGet("refresh-token")]
        public async Task<IActionResult> RefreshToken()
        {
            return Ok();
        }
        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            return Ok();
        }
    }
}

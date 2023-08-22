using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using ZStore.Application.Features;
using ZStore.Domain.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = SD.Role_Admin)]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService) 
        {
            _adminService = adminService;
        }

        [HttpGet("Users")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _adminService.GetAllCustomerUsers());
        }

        [HttpGet("Companies")]
        public async Task<IActionResult> GetAllCompanyUsers()
        {
            return Ok(await _adminService.GetAllCompanyUsers());
        }

        // DELETE api/<AdminController>/5
        [HttpDelete]
        public async Task<IActionResult> DeleteCompanyUsers([FromBody] IEnumerable<string> toDelete)
        {
            return Ok(await _adminService.DeleteCompanyUsers(toDelete));
        }
    }
}

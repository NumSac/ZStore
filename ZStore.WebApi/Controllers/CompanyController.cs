using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZStore.Application.DTOs;
using ZStore.Application.Features;
using ZStore.Domain.Models;
using ZStore.Domain.Utils;
using ZStore.WebApi.Util;

namespace ZStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService) 
        {
            _companyService = companyService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompany(int id)
        {
            return Ok(await _companyService.GetCompany(id));
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCompany([FromBody] RegisterCompanyRequest request)
        {
            if (ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(await _companyService.RegisterCompany(request));
           }
        [HttpPut]
        [Authorize(Roles = SD.Role_Company)]
        public async Task<IActionResult> EditCompany([FromBody] EditCompanyRequest request)
        {
            if (ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(await _companyService.EditCompany(0, request));
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}

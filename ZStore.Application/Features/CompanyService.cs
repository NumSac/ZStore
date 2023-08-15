using Microsoft.AspNetCore.Identity;
using ZStore.Application.DTOs;
using ZStore.Domain.Exceptions;
using ZStore.Domain.Models;
using ZStore.Domain.Utils;
using ZStore.Infrastructure.Repository.IRepository;

namespace ZStore.Application.Features
{
    public class CompanyService : ICompanyService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IUnitOfWork _unitOfWork;

        public CompanyService(UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager, 
            IUnitOfWork unitOfWork
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<CompanyDTO>> GetCompany(int id)
        {
            var company = await _unitOfWork.Company.GetByIdAsync(id);
            if (company == null)
                throw new ApiException($"Company not found");

            return new Response<CompanyDTO>(new CompanyDTO
            {
                Name = company.Name,
                Description = company.Profile.CompanyDescription
            });
        }

        public async Task<Response<string>> RegisterCompany(RegisterCompanyRequest request)
        {
            // Check if some data is already present in db
            var companyAlreadyRegistered = await _unitOfWork.Company.GetAsync(c => c.VatNumber == request.VatNumber);
            if (companyAlreadyRegistered != null)
                throw new ApiException($"A company with this Vat number is already registered");

            var emailAlreadyInUse = await _userManager.FindByEmailAsync(request.UserEmail);
            if (emailAlreadyInUse != null)
                throw new ApiException($"The provided email is already in use");

            var companyToRegister = new Company
            {
                Name = request.CompanyAlias,
                StreetAddress = request.StreetAddress,
                City = request.City,
                State = request.State,
                PostalCode = request.PostalCode,
                PhoneNumber = request.PhoneNumber,
                Country = request.Country,
                VatNumber = request.VatNumber,
            };

            var registeredCompany = await _unitOfWork.Company.InsertAsync(companyToRegister);

            var userToRegister = new ApplicationUser
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.UserEmail,
                CompanyId = registeredCompany.Id,
            };

            var result = await _userManager.CreateAsync(userToRegister, request.Password);
            if (!result.Succeeded)
                throw new ApiException(
                    $"Errors on register '{result.Errors.Select(error => error.Description)}'"
                );
            // add Roles to created user
            await _userManager.AddToRoleAsync(userToRegister, SD.Role_User);
            await _userManager.AddToRoleAsync(userToRegister, SD.Role_Company);

            await _unitOfWork.SaveAsync();

            return new Response<string>("Company created");
        }

        public async Task<Response<string>> EditCompany(int id, EditCompanyRequest request)
        {
            // retrrieve user company from jwt ApplicationUser subject to prevent unwanted behavior
            var companyUser = await _unitOfWork.ApplicationUser.GetByIdAsync(id);
            if (companyUser == null)
                throw new ApiException($"No user associated with id");

            var companyToEdit = await _unitOfWork.Company.GetCompanyFromUserCompanyIdAsync(companyUser);
            if (companyToEdit == null)
                throw new ApiException($"Error on retrieving company");

            companyToEdit.Name = request.Name;
            companyToEdit.Profile.CompanyDescription = request.Description;

            _unitOfWork.Company.Update(companyToEdit);

            return new Response<string>("Company updated");
        }
    }
}

using Microsoft.AspNetCore.Identity;
using ZStore.Application.DTOs.Account;
using ZStore.Application.Helpers;
using ZStore.Domain.Common;
using ZStore.Domain.Exceptions;
using ZStore.Domain.Models;
using ZStore.Domain.Utils;
using ZStore.Infrastructure.Repository.IRepository;

namespace ZStore.Application.Identity
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AccountBaseEntity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AccountBaseEntity> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(UserManager<AccountBaseEntity> userManager,
             RoleManager<IdentityRole> roleManager, SignInManager<AccountBaseEntity> signInManger,
            ITokenService tokenService, IUnitOfWork unitOfWork
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManger;
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<AuthenticationResponse>> AuthenticateAsync(
            AuthenticationRequest request
            )
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                throw new ApiException($"No Accounts Registered with {request.Email}");

            var result = await _signInManager.CheckPasswordSignInAsync(
                user,
                request.Password,
                false
            );
            if (!result.Succeeded)
                throw new ApiException($"Invalid Credentials for '{request.Email}'");

            // if (!user.EmailConfirmed)
            //     throw new ApiException($"Account Not Confirmed for '{request.Email}'")

            var accessToken = await _tokenService.CreateToken(user);
            var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);

            return new Response<AuthenticationResponse>(
                new AuthenticationResponse
                {
                    Id = user.Id,
                    UserName = user.UserName!,
                    Email = user.Email!,
                    Roles = rolesList.ToList(),
                    IsVerified = user.EmailConfirmed,
                    Token = accessToken
                }
            );
        }

        public async Task<Response<string>> RegisterAsync(RegisterRequest request)
        {
            var userWithSameName = await _userManager.FindByNameAsync(request.UserName);
            if (userWithSameName != null)
                throw new ApiException($"Username '{request.UserName}' is already taken");

            var user = CreateUser();

            user.UserName = request.UserName;
            user.Email = request.Email;

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                throw new ApiException(
                    $"Errors on register '{result.Errors.Select(error => error.Description)}'"
                );

            await _userManager.AddToRoleAsync(user, SD.Role_User);

            return new Response<string>("User created");
        }

        public async Task<Response<string>> UpdateUserInfo(string id, UpdateUserRequest request)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    var userToUpdate = await _unitOfWork.ApplicationUser.GetByIdAsync(id)
                        ?? throw new ApiException($"User with Id '{id}' not found");


                    userToUpdate.UserName = request.UserName;
                    userToUpdate.Email = request.Email;
                    userToUpdate.PhoneNumber = request.PhoneNumber;
                    userToUpdate.StreetAddress = request.StreetAddress;
                    userToUpdate.City = request.City;
                    userToUpdate.PostalCode = request.PostalCode;
                    userToUpdate.Country = request.Country;

                    _unitOfWork.ApplicationUser.Update(userToUpdate);

                    await _unitOfWork.SaveAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new ApiException(ex.Message);
                }
            }

            return new Response<string>("User updated");
        }

        public async Task<Response<string>> UpdatePassword(string id, UpdatePasswordRequest request)
        {
            var userToUpdate = await _userManager.FindByIdAsync(id);
            if (userToUpdate == null)
                throw new ApiException($"User with Id '{id}' not found");

            var updateUserPassword = await _userManager.ChangePasswordAsync(userToUpdate, request.OldPassword, request.NewPassword);
            if (updateUserPassword.Succeeded)
                throw new ApiException($"Unable to update password");

            return new Response<string>("Password updated");
        }

        public async Task<Response<string>> DeleteUser(string id)
        {
            var userToDelete = await _unitOfWork.ApplicationUser.GetOneAsync(u => u.Id == id);
            if (userToDelete == null)
                throw new ApiException($"User does not exits");

            _unitOfWork.ApplicationUser.Delete(userToDelete);

            await _unitOfWork.SaveAsync();

            return new Response<string>("User deleted");
        }

        private static ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(AccountBaseEntity)}'");
            }
        }
    }
}

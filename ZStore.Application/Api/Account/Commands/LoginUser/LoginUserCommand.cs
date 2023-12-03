using MediatR;
using Microsoft.AspNetCore.Identity;
using ZStore.Application.DTOs.Account;
using ZStore.Application.Helpers;
using ZStore.Domain.Common;
using ZStore.Domain.Exceptions;
using ZStore.Domain.Utils;

namespace ZStore.Application.Api.Account.Commands.LoginUser
{
    public partial class LoginUserCommand : IRequest<Response<AuthenticationResponse>>
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Response<AuthenticationResponse>>
    {
        private readonly UserManager<AccountBaseEntity> _userManager;
        private readonly ITokenService _tokenService;
        public LoginUserCommandHandler(UserManager<AccountBaseEntity> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<Response<AuthenticationResponse>> Handle(LoginUserCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var userToLogin = await _userManager.FindByEmailAsync(command.Email);
                if (userToLogin == null)
                {
                    throw new Exception("No user found");
                }
                else
                {
                    var token = await _tokenService.CreateToken(userToLogin);
                    var rolesList = await _userManager.GetRolesAsync(userToLogin).ConfigureAwait(false);

                    var jwtResponse = new AuthenticationResponse();

                    jwtResponse.Id = userToLogin.Id;
                    jwtResponse.UserName = userToLogin.UserName!;
                    jwtResponse.Email = userToLogin.Email!;
                    jwtResponse.Roles = rolesList.ToList();
                    jwtResponse.Token = token;

                    return new Response<AuthenticationResponse>(jwtResponse);
                } 
            } catch (Exception ex)
            {
                throw new ApiException("Something went wrong", ex.Message);
            }
        }
    }
}

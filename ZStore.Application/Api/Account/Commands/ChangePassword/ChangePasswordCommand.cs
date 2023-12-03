using MediatR;
using Microsoft.AspNetCore.Identity;
using ZStore.Domain.Common;
using ZStore.Domain.Utils;

namespace ZStore.Application.Api.Account.Commands.ChangePassword
{
    public class ChangePasswordCommand : IRequest<Response<string>>
    {
        public string UserId { get; set; } = "";
        public string CurrentPassword { get; set; } = "";
        public string Password { get; set; } = "";
        public string RepeatPassword { get; set; } = "";
    }
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, Response<string>>
    {
        private readonly UserManager<AccountBaseEntity> _userManager;
        public ChangePasswordCommandHandler(UserManager<AccountBaseEntity> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Response<string>> Handle(ChangePasswordCommand command, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(command.UserId);
            if (user == null)
            {
                throw new Exception("No user found");
            } else
            {
                await _userManager.ChangePasswordAsync(user, command.CurrentPassword, command.Password);
                return new Response<string>(command.UserId);
            }
        }
    }
}

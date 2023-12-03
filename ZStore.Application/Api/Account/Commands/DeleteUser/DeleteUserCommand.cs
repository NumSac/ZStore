using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ZStore.Domain.Common;
using ZStore.Domain.Utils;
using ZStore.Infrastructure.Repository.IRepository;

namespace ZStore.Application.Api.Account.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<Response<string>>
    {
        public string Id { get; set; }
        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Response<string>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly UserManager<AccountBaseEntity> _userManager;
            public DeleteUserCommandHandler(IUnitOfWork unitOfWork, UserManager<AccountBaseEntity> userManager)
            {
                _unitOfWork = unitOfWork;
                _userManager = userManager;
            }

            public async Task<Response<string>> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByIdAsync(command.Id);
                if (user == null)
                {
                    throw new Exception("User not found");
                } else
                {
                    await _userManager.DeleteAsync(user);
                    return new Response<string>(command.Id);
                }
            }
        }
    }
}

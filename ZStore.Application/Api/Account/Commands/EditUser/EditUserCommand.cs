using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ZStore.Domain.Common;
using ZStore.Domain.Exceptions;
using ZStore.Domain.Utils;
using ZStore.Infrastructure.Repository.IRepository;

namespace ZStore.Application.Api.Account.Commands.EditUser
{
    public partial class EditUserCommand : IRequest<Response<string>>
    {
       public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
    public class EditUserCommandHandler : IRequestHandler<EditUserCommand, Response<string>> 
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AccountBaseEntity> _userManager;
        private readonly IMapper _mapper;

        public EditUserCommandHandler(IUnitOfWork unitOfWork, UserManager<AccountBaseEntity> userManager, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(EditUserCommand command, CancellationToken cancellationToken)
        {
            var userToUpdate = await _unitOfWork.ApplicationUser.GetByIdAsync(command.UserId)
                ?? throw new ApiException($"User with Id '{command.UserId}' not found");

            userToUpdate.Name = string.Concat(command.FirstName, command.LastName);
            userToUpdate.UserName = command.UserName;
            userToUpdate.Email = command.Email;

            // Why no async Update??? Should be implemented in Repository
            _unitOfWork.ApplicationUser.Update(userToUpdate);

            await _unitOfWork.SaveAsync();

            return new Response<string>(command.UserId);
        }
    }
}

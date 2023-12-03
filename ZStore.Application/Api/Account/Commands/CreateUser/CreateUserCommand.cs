using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using ZStore.Domain.Common;
using ZStore.Domain.Exceptions;
using ZStore.Domain.Models;
using ZStore.Domain.Utils;
using ZStore.Infrastructure.Repository.IRepository;

namespace ZStore.Application.Api.Account.Commands.CreateUser
{
    public partial class CreateUserCommand : IRequest<Response<string>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<string>>
    {
        private readonly UserManager<AccountBaseEntity> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(UserManager<AccountBaseEntity> userManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<ApplicationUser>(request);
            var userWithSameName = await _userManager.FindByNameAsync(user.UserName);
            if (userWithSameName == null)
                throw new ApiException($"Username '{request.UserName}' is already taken");


            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                throw new ApiException(
                    $"Errors on register '{result.Errors.Select(error => error.Description)}'"
                );

            return new Response<string>(user.Id);
        }
    }
}

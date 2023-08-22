using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZStore.Application.DTOs;
using ZStore.Domain.Utils;

namespace ZStore.Application.Api.Features
{
    public interface IAccountService
    {
        Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request);
        Task<Response<string>> DeleteUser(string id);
        Task<Response<string>> RegisterAsync(RegisterRequest request);
        Task<Response<string>> UpdatePassword(string id, UpdatePasswordRequest request);
        Task<Response<string>> UpdateUserInfo(string id, UpdateUserRequest request);
    }
}

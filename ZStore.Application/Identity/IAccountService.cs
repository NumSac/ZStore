using ZStore.Application.DTOs.Account;
using ZStore.Domain.Utils;

namespace ZStore.Application.Identity
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

using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ZStore.Domain.Common;
using ZStore.Domain.Models;

namespace ZStore.Application.Helpers
{
    public interface ITokenService
    {
        JwtSecurityToken CreateJwtToken(List<Claim> claims, SigningCredentials credentials, DateTime expiration);
        SigningCredentials CreateSigningCredentials();
        Task<string> CreateToken(AccountBaseEntity user);
    }
}

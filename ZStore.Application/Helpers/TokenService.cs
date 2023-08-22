using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ZStore.Application.Models;
using ZStore.Domain.Common;
using ZStore.Domain.Models;

namespace ZStore.Application.Helpers
{
    public class TokenService : ITokenService
    {
        private readonly JwtOptions _jwtOptions;
        private readonly UserManager<AccountBaseEntity> _userManager;

        public TokenService(IOptions<JwtOptions> options, 
            UserManager<AccountBaseEntity> userManager
            )
        {
            _jwtOptions = options.Value;
            _userManager = userManager;
        }

        public async Task<string> CreateToken(AccountBaseEntity user)
        {
            var expiration = DateTime.UtcNow.AddMinutes(_jwtOptions.ExpiryMinutes);
            var token = CreateJwtToken(
                await CreateClaims(user),
                CreateSigningCredentials(),
                expiration
            );
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }

        public JwtSecurityToken CreateJwtToken(
            List<Claim> claims,
            SigningCredentials credentials,
            DateTime expiration
        ) =>
            new(
                "apiWithAuthBackend",
                "apiWithAuthBackend",
                claims,
                expires: expiration,
                signingCredentials: credentials
            );

        public async Task<List<Claim>> CreateClaims(AccountBaseEntity user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = roles.Select(role => new Claim("roles", role)).ToList();
            try
            {
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(
                        JwtRegisteredClaimNames.Iat,
                        DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)
                    ),
                    // new Claim(ClaimTypes.NameIdentifier, user.Id),
                };

                if (!string.IsNullOrEmpty(user.UserName))
                {
                    claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                }

                if (!string.IsNullOrEmpty(user.Email))
                {
                    claims.Add(new Claim(ClaimTypes.Email, user.Email));
                }
                claims.AddRange(userClaims);
                claims.AddRange(roleClaims);

                return claims;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public SigningCredentials CreateSigningCredentials()
        {
            return new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes("!mysecretforsigningplustenextrasecure")
                ),
                SecurityAlgorithms.HmacSha256
            );
        }
    }
}

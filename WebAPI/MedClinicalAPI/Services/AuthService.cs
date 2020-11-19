using MedClinical.API.Data.Models.Auth;
using MedClinical.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MedClinical.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly TokenValidationParameters _tokenValidationParameters;

        public AuthService(IConfiguration configuration, TokenValidationParameters tokenValidationParameters)
        {
            _configuration = configuration;
            _tokenValidationParameters = tokenValidationParameters;
        }

        public async Task<AuthResultDto> GenerateAuthResultAsync(IdentityUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JwtKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var expiryDate = DateTime.UtcNow.AddMinutes(2);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
               {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim("id", user.Id),
                    new Claim("expires", expiryDate.Subtract(DateTime.UtcNow).TotalSeconds.ToString())
                 }),
                Expires = expiryDate,
                SigningCredentials = credentials,
                Issuer = _configuration["JwtIssuer"],
                Audience = _configuration["JwtAudience"]
            };
            var token = new JwtSecurityTokenHandler().CreateToken(tokenDescriptor);
            //var newRefreshToken = new RefreshToken
            //{
            //    JwtId = token.Id,
            //    UserId = user.Id,
            //    ExpiryDate = DateTime.UtcNow.AddHours(48),
            //    CreationDate = DateTime.UtcNow
            //};
            //await _refreshTokenRepository.CreateAsync(newRefreshToken);
            return new AuthResultDto()
            {
                Success = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token)
                //RefreshToken = newRefreshToken.Token
            };
        }

        public ClaimsPrincipal GetClaimsPrincipalFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            //var principal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out SecurityToken validatedToken);
            var tokenValidationParameters = _tokenValidationParameters.Clone();
            tokenValidationParameters.ValidateLifetime = false;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);

            if (!(validatedToken is JwtSecurityToken jwtSecurityToken))
                return null;

            if (!jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                return null;
            return principal;
        }

        public bool ValidateTokenExpiry(string token)
        {
            var validatedToken = GetClaimsPrincipalFromToken(token);
            if (validatedToken == null)
            {
                return false;
            }
            var expiryDateUnix =
                long.Parse(validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

            var expiryDateTimeUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                .AddSeconds(expiryDateUnix);
            if (expiryDateTimeUtc <= DateTime.UtcNow)
            {
                return false;
            }
            return true;
        }

        public async Task LogOutAsync(HttpContext context)
        {
            var token = context.Request.Cookies[".AspNetCore.Application.Id"];
            if (!string.IsNullOrEmpty(token))
            {
                context.Response.Cookies.Delete(".AspNetCore.Application.Id");
                context.Response.Cookies.Delete(".AspNetCore.Application.Id-refresh");
                context.Response.Cookies.Delete("User-email");
            }
        }
    }
}
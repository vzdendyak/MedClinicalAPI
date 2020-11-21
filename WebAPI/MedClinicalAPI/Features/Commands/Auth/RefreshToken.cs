using MedClinical.API.Data.Models.Auth;
using MedClinical.API.Services.Interfaces;
using MedClinicalAPI.Data;
using MedClinicalAPI.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinical.API.Features.Commands.Auth
{
    public class RefreshToken
    {
        public class Command : IRequest<AuthResultDto>
        {
            public RefreshTokenRequest Model { get; set; }

            public Command(RefreshTokenRequest request)
            {
                this.Model = request;
            }
        }

        public class Handler : IRequestHandler<RefreshToken.Command, AuthResultDto>
        {
            private readonly AppDbContext _context;
            private readonly UserManager<User> _userManager;
            private readonly IAuthService _authService;

            public Handler(AppDbContext context, UserManager<User> userManager, IAuthService authService)
            {
                _context = context;
                _userManager = userManager;
                _authService = authService;
            }

            public async Task<AuthResultDto> Handle(Command command, CancellationToken cancellationToken)
            {
                var validatedToken = _authService.GetClaimsPrincipalFromToken(command.Model.Token);
                if (validatedToken == null)
                    return new AuthResultDto { ErrorMessages = new[] { "Invalid token" } };

                var expiryDateUnix = long.Parse(validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Exp).Value);
                var expiryDateTimeUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(expiryDateUnix);

                if (expiryDateTimeUtc > DateTime.UtcNow)
                    return new AuthResultDto { ErrorMessages = new[] { "This token hasn't expired yet" } };

                var jti = validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

                /*var storedRefreshToken = await _refreshTokenRepository.GetAsync(refreshToken);

                if (storedRefreshToken == null)
                {
                    return new AuthResultDto { ErrorMessages = new[] { "This refresh token does not exist" } };
                }

                if (DateTime.UtcNow > storedRefreshToken.ExpiryDate)
                {
                    return new AuthResultDto { ErrorMessages = new[] { "This refresh token has expired" } };
                }

                if (storedRefreshToken.Invalidated)
                {
                    return new AuthResultDto { ErrorMessages = new[] { "This refresh token has been invalidated" } };
                }

                if (storedRefreshToken.Used)
                {
                    return new AuthResultDto { ErrorMessages = new[] { "This refresh token has been used" } };
                }

                if (storedRefreshToken.JwtId != jti)
                {
                    return new AuthResultDto { ErrorMessages = new[] { "This refresh token does not match this JWT" } };
                }

                storedRefreshToken.Used = true;
                await _refreshTokenRepository.UpdateAsync(storedRefreshToken);*/
                var user = await _userManager.FindByIdAsync(validatedToken.Claims.Single(x => x.Type == "id").Value);
                return await _authService.GenerateAuthResultAsync(user);
            }
        }
    }
}
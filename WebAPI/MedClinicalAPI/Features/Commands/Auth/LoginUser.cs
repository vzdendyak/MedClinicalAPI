using MedClinical.API.Data.Models.Auth;
using MedClinical.API.Services;
using MedClinical.API.Services.Interfaces;
using MedClinicalAPI.Data;
using MedClinicalAPI.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinical.API.Features.Commands.Auth
{
    public class LoginUser
    {
        public class Command : IRequest<AuthResultDto>
        {
            public LoginRequest Model { get; set; }

            public Command(LoginRequest request)
            {
                this.Model = request;
            }
        }

        public class Handler : IRequestHandler<LoginUser.Command, AuthResultDto>
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
                var existingUser = await _userManager.FindByEmailAsync(command.Model.Email);
                if (existingUser == null)
                    return new AuthResultDto
                    {
                        Success = false,
                        ErrorMessages = new[] { "User doesn't exist" }
                    };

                var userValidPassword = await _userManager.CheckPasswordAsync(existingUser, command.Model.Password);
                if (!userValidPassword)
                    return new AuthResultDto
                    {
                        Success = false,
                        ErrorMessages = new[] { "Email/Password are incorrect!" }
                    };
                return await _authService.GenerateAuthResultAsync(existingUser);
            }
        }
    }
}
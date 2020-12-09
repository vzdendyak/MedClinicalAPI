using MedClinical.API.Data.Models.Auth;
using MedClinical.API.Services.Interfaces;
using MedClinicalAPI.Data;
using MedClinicalAPI.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinical.API.Features.Commands.Auth
{
    public class RegisterUser
    {
        public class Command : IRequest<AuthResultDto>
        {
            public RegisterRequest Model { get; set; }

            public Command(RegisterRequest request)
            {
                this.Model = request;
            }
        }

        public class Handler : IRequestHandler<RegisterUser.Command, AuthResultDto>
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
                if (existingUser != null)
                {
                    return new AuthResultDto
                    {
                        Success = false,
                        ErrorMessages = new[] { "User with this email is already exist!" }
                    };
                }
                User user = new User
                {
                    Email = command.Model.Email,
                    UserName = command.Model.Username,
                    FirstName = command.Model.FirstName,
                    LastName = command.Model.LastName,
                    Age = command.Model.Age,
                    AvatarPath = @"Resources\Images\default.jpg"
                };
                var result = await _userManager.CreateAsync(user, command.Model.Password);
                if (!result.Succeeded)
                    return new AuthResultDto()
                    {
                        ErrorMessages = result.Errors.Select(i => i.Description)
                    };
                user = await _userManager.FindByEmailAsync(user.Email);
                await _userManager.AddToRoleAsync(user, "patient");
                return await _authService.GenerateAuthResultAsync(user);
            }
        }
    }
}
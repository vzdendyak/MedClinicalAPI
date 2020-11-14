using MedClinical.API.Data.DTOs;
using MedClinicalAPI.Data;
using MedClinicalAPI.Data.Models;
using MedClinicalAPI.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinical.API.Features.Commands.UserCRUD.UpdateUserWithoutPassword
{
    public class UpdateUserWithoutPassword
    {
        public class Command : IRequest<bool>
        {
            public UserDto User { get; set; }

            public Command(UserDto user)
            {
                User = user;
            }
        }

        public class Handler : IRequestHandler<UpdateUserWithoutPassword.Command, bool>
        {
            private readonly AppDbContext _context;
            private UserManager<User> _userManager;

            public Handler(AppDbContext context, UserManager<User> userManager)
            {
                _context = context;
                _userManager = userManager;
            }

            public async Task<bool> Handle(Command command, CancellationToken cancellationToken)
            {
                User user = await _userManager.FindByIdAsync(command.User.Id);
                if (user == null)
                    return false;

                user.UserName = command.User.UserName;
                user.FirstName = command.User.FirstName;
                user.LastName = command.User.LastName;
                user.Email = command.User.Email;
                user.PhoneNumber = command.User.PhoneNumber;
                user.Age = command.User.Age;
                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    var returnText = new StringBuilder();
                    foreach (var err in result.Errors)
                    {
                        returnText.Append(err.Code + "-" + err.Description);
                    }
                    throw new BadRequestException(returnText.ToString());
                }
                return true;
            }
        }
    }
}
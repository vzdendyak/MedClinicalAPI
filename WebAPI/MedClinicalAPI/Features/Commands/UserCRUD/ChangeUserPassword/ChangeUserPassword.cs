using MedClinical.API.Data.DTOs;
using MedClinicalAPI.Data.Models;
using MedClinicalAPI.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinical.API.Features.Commands.UserCRUD.ChangeUserPassword
{
    public class ChangeUserPassword
    {
        public class Command : IRequest<bool>
        {
            public UserChangePasswordDto model { get; set; }

            public Command(UserChangePasswordDto user)
            {
                model = user;
            }
        }

        public class Handler : IRequestHandler<ChangeUserPassword.Command, bool>
        {
            private UserManager<User> _userManager;

            public Handler(UserManager<User> userManager)
            {
                _userManager = userManager;
            }

            public async Task<bool> Handle(Command command, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByIdAsync(command.model.Id);
                var result = await _userManager.ChangePasswordAsync(user, command.model.OldPassword, command.model.NewPassword);
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
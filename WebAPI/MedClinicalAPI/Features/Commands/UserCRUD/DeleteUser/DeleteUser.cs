using MedClinical.API.Helpers;
using MedClinicalAPI.Data;
using MedClinicalAPI.Data.Models;
using MedClinicalAPI.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinical.API.Features.Commands.UserCRUD.DeleteUser
{
    public class DeleteUser
    {
        public class Command : IRequest<bool>
        {
            public string UserId { get; set; }

            public Command(string userId)
            {
                UserId = userId;
            }
        }

        public class Handler : IRequestHandler<DeleteUser.Command, bool>
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
                var user = await _userManager.FindByIdAsync(command.UserId);

                if (user == null)
                    return false;

                //if (!(await user.IsUserAdmin(_userManager)))
                //    throw new ForbiddenException("You don't have enought permissions to do this action. Please contact administrator.");

                await _userManager.DeleteAsync(user);
                return true;
            }
        }
    }
}
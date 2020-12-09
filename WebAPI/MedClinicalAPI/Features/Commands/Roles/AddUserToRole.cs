using MedClinical.API.Data.DTOs;
using MedClinicalAPI.Data.Models;
using MedClinicalAPI.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinical.API.Features.Commands.Roles
{
    public class AddUserToRole
    {
        public class Command : IRequest<bool>
        {
            public AddToRoleDto model { get; set; }

            public Command(AddToRoleDto model)
            {
                this.model = model;
            }
        }

        public class Handler : IRequestHandler<AddUserToRole.Command, bool>
        {
            private readonly UserManager<User> _userManager;
            private readonly RoleManager<IdentityRole> _roleManager;

            public Handler(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
            {
                _userManager = userManager;
                _roleManager = roleManager;
            }

            public async Task<bool> Handle(Command command, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByIdAsync(command.model.UserId);
                if (user == null)
                    throw new BadRequestException("This user does not exist!");

                var res = await _userManager.AddToRoleAsync(user, command.model.Role);
                return res.Succeeded;
            }
        }
    }
}
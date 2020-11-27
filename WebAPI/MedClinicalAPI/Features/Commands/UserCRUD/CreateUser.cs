using MedClinical.API.Data.DTOs;
using MedClinicalAPI.Data.Models;
using MedClinicalAPI.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinical.API.Features.Commands.UserCRUD
{
    public class CreateUser
    {
        public class Command : IRequest<bool>
        {
            public UserDto model { get; set; }

            public Command(UserDto user)
            {
                model = user;
            }
        }

        public class Handler : IRequestHandler<CreateUser.Command, bool>
        {
            private UserManager<User> _userManager;
            private RoleManager<IdentityRole> _roleManager;

            public Handler(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
            {
                _userManager = userManager;
                _roleManager = roleManager;
            }

            public async Task<bool> Handle(Command command, CancellationToken cancellationToken)
            {
                var role = await _roleManager.FindByNameAsync(command.model.Role);
                if (role == null)
                    throw new BadRequestException("Role not exist!");

                var res = await _userManager.CreateAsync(new User
                {
                    UserName = command.model.UserName,
                    FirstName = command.model.FirstName,
                    LastName = command.model.LastName,
                    Email = command.model.Email,
                    PhoneNumber = command.model.PhoneNumber,
                    Age = command.model.Age,
                    DepartmentId = command.model.DepartmentId
                }, "User-1111");

                if (!res.Succeeded)
                {
                    var returnText = new StringBuilder();
                    foreach (var err in res.Errors)
                    {
                        returnText.Append(err.Code + "-" + err.Description);
                    }
                    throw new BadRequestException(returnText.ToString());
                }
                var user = await _userManager.FindByEmailAsync(command.model.Email);
                if (user == null)
                {
                    throw new BadRequestException("unknown error at user create operation");
                }
                await _userManager.AddToRoleAsync(user, role.Name);
                return true;
            }
        }
    }
}
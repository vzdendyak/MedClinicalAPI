using MedClinicalAPI.Data;
using MedClinicalAPI.Helpers;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinical.API.Features.Commands.Roles
{
    public class CreateRole
    {
        public class Command : IRequest<bool>
        {
            public string Name { get; set; }

            public Command(string name)
            {
                Name = name;
            }
        }

        public class Handler : IRequestHandler<CreateRole.Command, bool>
        {
            private readonly RoleManager<IdentityRole> _roleManager;
            private readonly AppDbContext _context;

            public Handler(RoleManager<IdentityRole> roleManager, AppDbContext context)
            {
                _roleManager = roleManager;
                _context = context;
            }

            public async Task<bool> Handle(Command command, CancellationToken cancellationToken)
            {
                ValidationHelper.IsRoleExist(command.Name, _context);
                await _roleManager.CreateAsync(new IdentityRole(command.Name));
                return true;
            }
        }
    }
}
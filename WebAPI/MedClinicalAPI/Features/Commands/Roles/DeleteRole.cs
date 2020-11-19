using MedClinicalAPI.Data;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinical.API.Features.Commands.Roles
{
    public class DeleteRole
    {
        public class Command : IRequest<bool>
        {
            public string Name { get; set; }

            public Command(string name)
            {
                Name = name;
            }
        }

        public class Handler : IRequestHandler<DeleteRole.Command, bool>
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
                IdentityRole role = await _roleManager.FindByNameAsync(command.Name);
                if (role != null)
                {
                    IdentityResult result = await _roleManager.DeleteAsync(role);
                    if (result.Succeeded)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
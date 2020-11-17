using MedClinical.API.Data.DTOs;
using MedClinicalAPI.Data.Models;
using MedClinicalAPI.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
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

            public Handler(RoleManager<IdentityRole> roleManager)
            {
                _roleManager = roleManager;
            }

            public async Task<bool> Handle(Command command, CancellationToken cancellationToken)
            {
                // check if role exist!!!!
                return (await _roleManager.CreateAsync(new IdentityRole(command.Name.ToUpper()))).Succeeded;
            }
        }
    }
}
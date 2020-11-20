using MedClinical.API.Data.DTOs;
using MedClinicalAPI.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinical.API.Features.Queries.Roles
{
    public class GetAllRoles
    {
        public class Query : IRequest<IEnumerable<RolesDto>>
        {
        }

        public class Handler : IRequestHandler<GetAllRoles.Query, IEnumerable<RolesDto>>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<RolesDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var roles = await _context.Roles
                    .Select(rol => new RolesDto
                    {
                        Id = rol.Id,
                        Name = rol.Name
                    }).ToListAsync();
                return roles;
            }
        }
    }
}
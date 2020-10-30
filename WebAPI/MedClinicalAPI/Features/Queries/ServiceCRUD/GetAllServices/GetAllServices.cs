using MedClinicalAPI.Data;
using MedClinicalAPI.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinicalAPI.Features.Queries.ServiceCRUD.GetAllServices
{
    public class GetAllServices
    {
        public class Query : IRequest<IEnumerable<Service>>
        {
        }

        public class Handler : IRequestHandler<GetAllServices.Query, IEnumerable<Service>>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Service>> Handle(Query request, CancellationToken cancellationToken)
            {
                var services = await _context.Services
                    .Select(serv => new Service
                    {
                        Id = serv.Id,
                        Price = serv.Price,
                        Name = serv.Name
                    }).ToListAsync();
                return services;
            }
        }
    }
}
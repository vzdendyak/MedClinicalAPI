using MedClinicalAPI.Data;
using MedClinicalAPI.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinicalAPI.Features.Queries.ServiceCRUD.GetServicesById
{
    public class GetServicesById
    {
        public class Query : IRequest<Service>
        {
            public int Id { get; set; }

            public Query(int id)
            {
                Id = id;
            }
        }

        public class Handler : IRequestHandler<GetServicesById.Query, Service>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Service> Handle(Query request, CancellationToken cancellationToken)
            {
                var services = await _context.Services.Where(d => d.Id == request.Id).Select(serv => new Service
                {

                    Id = serv.Id,
                    DepartmentId = serv.DepartmentId,
                    Price = serv.Price,
                    Name = serv.Name

                }).FirstOrDefaultAsync();
                return services;
            }
        }
    }
}

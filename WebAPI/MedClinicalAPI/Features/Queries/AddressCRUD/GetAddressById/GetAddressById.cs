using MedClinicalAPI.Data;
using MedClinicalAPI.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinicalAPI.Features.Queries.AddressCRUD.GetAddressById
{
    public class GetAddressById
    {
        public class Query : IRequest<Address>
        {
            public int Id { get; set; }

            public Query(int id)
            {
                Id = id;
            }
        }

        public class Handler : IRequestHandler<GetAddressById.Query, Address>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Address> Handle(Query request, CancellationToken cancellationToken)
            {
                var addresses = await _context.Addresses.Where(d => d.Id == request.Id).Select(addr => new Address
                {
                    Id = addr.Id,
                    Region = addr.Region,
                    City = addr.City,
                    Street = addr.Street,
                    HouseNumber = addr.HouseNumber,
                    Departments = addr.Departments.Select(dep => new Department
                    {
                        Id = dep.Id,
                        DepartmentName = dep.DepartmentName,
                        Description = dep.Description,
                        ScheduleId = dep.ScheduleId
                    }).ToList(),
                }).FirstOrDefaultAsync();
                return addresses;
            }
        }
    }
}
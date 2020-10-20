using MedClinicalAPI.Data.Models;
using MedClinicalAPI.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MedClinicalAPI.Features.Queries.AddressCRUD.GetAllAddresses
{
    public class GetAllAddresses
    {
        public class Query : IRequest<IEnumerable<Address>>
        {
        }

        public class Handler : IRequestHandler<GetAllAddresses.Query, IEnumerable<Address>>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Address>> Handle(Query request, CancellationToken cancellationToken)
            {
                var addresses = await _context.Addresses
                    .Select(addr => new Address
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
                    }).ToListAsync();
                return addresses;
            }
        }
    }
}

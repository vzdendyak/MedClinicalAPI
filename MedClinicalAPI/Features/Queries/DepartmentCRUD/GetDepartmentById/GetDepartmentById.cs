using MedClinicalAPI.Data;
using MedClinicalAPI.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinicalAPI.Features.Queries.DepartmentCRUD
{
    public class GetDepartmentById
    {
        public class Query : IRequest<Department>
        {
            public int Id { get; set; }

            public Query(int id)
            {
                Id = id;
            }
        }

        public class Handler : IRequestHandler<GetDepartmentById.Query, Department>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Department> Handle(Query request, CancellationToken cancellationToken)
            {
                var department = await _context.Departments.Where(d => d.Id == request.Id).Select(dep => new Department
                {
                    Id = dep.Id,
                    DepartmentName = dep.DepartmentName,
                    Address = new Address
                    {
                        Id = dep.Address.Id,
                        City = dep.Address.City,
                        HouseNumber = dep.Address.HouseNumber,
                        Region = dep.Address.Region,
                        Street = dep.Address.Street
                    },
                    AddressId = dep.AddressId,
                    Description = dep.Description,
                    Doctors = dep.Doctors.Select(doc => new User
                    {
                        Id = doc.Id,
                        FirstName = doc.FirstName,
                        LastName = doc.LastName,
                        PhoneNumber = doc.PhoneNumber
                    }).ToList(),
                    ScheduleId = dep.ScheduleId
                }).FirstOrDefaultAsync();
                return department;
            }
        }
    }
}
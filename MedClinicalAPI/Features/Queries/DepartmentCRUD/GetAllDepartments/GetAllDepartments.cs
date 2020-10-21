using MedClinicalAPI.Data;
using MedClinicalAPI.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinicalAPI.Features.Queries.DepartmentCRUD
{
    public class GetAllDepartments
    {
        public class Query : IRequest<IEnumerable<Department>>
        {
        }

        public class Handler : IRequestHandler<GetAllDepartments.Query, IEnumerable<Department>>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Department>> Handle(Query request, CancellationToken cancellationToken)
            {
                var departments = await _context.Departments
                    .Select(dep => new Department
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
                        DepartmentServices = dep.DepartmentServices.Select(ds => new DepartmentService
                        {
                            ServiceId = ds.ServiceId,
                            Service = new Service
                            {
                                Id = ds.Service.Id,
                                Name = ds.Service.Name,
                                Price = ds.Service.Price,
                                Description = ds.Service.Description
                            }
                        }).ToList(),
                        ScheduleId = dep.ScheduleId
                    }).ToListAsync();
                return departments;
            }
        }
    }
}
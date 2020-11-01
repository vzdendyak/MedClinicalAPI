using MedClinical.API.Data.DTOs;
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
        public class Query : IRequest<IEnumerable<DepartmentDto>>
        {
        }

        public class Handler : IRequestHandler<GetAllDepartments.Query, IEnumerable<DepartmentDto>>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<DepartmentDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var departments = await _context.Departments
                    .Select(dep => new DepartmentDto
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
                        Doctors = dep.Doctors.Select(doc => new UserDto
                        {
                            Id = doc.Id,
                            DepartmentId = doc.DepartmentId,
                            UserName = doc.UserName,
                            Email = doc.Email,
                            FirstName = doc.FirstName,
                            LastName = doc.LastName
                        }).ToList(),
                        DepartmentServices = dep.DepartmentServices.Select(ds => new DepartmentService
                        {
                            ServiceId = ds.ServiceId,
                            Service = ds.Service
                        }).ToList(),
                        ScheduleId = dep.ScheduleId
                    }).ToListAsync();
                return departments;
            }
        }
    }
}
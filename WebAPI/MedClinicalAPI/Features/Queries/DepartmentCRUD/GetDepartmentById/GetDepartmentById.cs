using MedClinical.API.Data.DTOs;
using MedClinicalAPI.Data;
using MedClinicalAPI.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinicalAPI.Features.Queries.DepartmentCRUD
{
    public class GetDepartmentById
    {
        public class Query : IRequest<DepartmentDto>
        {
            public int Id { get; set; }

            public Query(int id)
            {
                Id = id;
            }
        }

        public class Handler : IRequestHandler<GetDepartmentById.Query, DepartmentDto>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<DepartmentDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var department = await _context.Departments.Where(d => d.Id == request.Id).Select(dep => new DepartmentDto
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
                    ScheduleId = dep.ScheduleId,
                    DepartmentServices = dep.DepartmentServices.Select(ds => new DepartmentService
                    {
                        ServiceId = ds.ServiceId,
                        Service = ds.Service
                    }).ToList()
                }).FirstOrDefaultAsync();
                return department;
            }
        }
    }
}
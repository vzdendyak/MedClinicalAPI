using MedClinical.API.Data.DTOs;
using MedClinical.API.Data.Models;
using MedClinicalAPI.Data;
using MedClinicalAPI.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinical.API.Features.Queries.GetRolesAndDepartments
{
    public class GetRolesAndDepartments
    {
        public class Query : IRequest<RolesAndDepartments>
        {
        }

        public class Handler : IRequestHandler<GetRolesAndDepartments.Query, RolesAndDepartments>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<RolesAndDepartments> Handle(Query request, CancellationToken cancellationToken)
            {
                var rolesAndDepartments = new RolesAndDepartments();

                rolesAndDepartments.Roles = await _context.Roles
                    .Select(rol => new RolesDto
                    {
                        Name = rol.Name
                    }).ToListAsync();

                rolesAndDepartments.Departments = await _context.Departments
                    .Select(dep => new Department
                    {
                        Id = dep.Id,
                        DepartmentName = dep.DepartmentName,
                        Address = new Address
                        {
                            Id = dep.Address.Id,
                            Region = dep.Address.Region,
                            City = dep.Address.City,
                            Street = dep.Address.Street,
                            HouseNumber = dep.Address.HouseNumber
                        }
                    }).ToListAsync();

                return rolesAndDepartments;
            }
        }
    }
}
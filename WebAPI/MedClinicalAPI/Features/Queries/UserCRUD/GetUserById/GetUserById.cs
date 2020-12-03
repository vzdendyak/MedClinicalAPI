using MedClinical.API.Data.DTOs;
using MedClinical.API.Services.Interfaces;
using MedClinicalAPI.Data;
using MedClinicalAPI.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinical.API.Features.Queries.UserCRUD.GetUserById
{
    public class GetUserById
    {
        public class Query : IRequest<UserDto>
        {
            public string Id { get; set; }

            public Query(string id)
            {
                Id = id;
            }
        }

        public class Handler : IRequestHandler<GetUserById.Query, UserDto>
        {
            private readonly UserManager<User> _userManager;
            private readonly IUserService _userService;
            private readonly AppDbContext _context;

            public Handler(UserManager<User> userManager, IUserService userService, AppDbContext context)
            {
                _userManager = userManager;
                _userService = userService;
                _context = context;
            }

            public async Task<UserDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByIdAsync(request.Id);
                UserDto model = new UserDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Age = user.Age,
                    DepartmentId = user.DepartmentId,
                    Department = user.Department
                };
                model.Records = await _userService.GetUserRecords(user);

                var department = _context.Departments.Where(d => d.Id == model.DepartmentId).FirstOrDefault();
                if (department == null)
                {
                    return model;
                }
                model.Department = new Department
                {
                    Id = department.Id,
                    DepartmentName = department.DepartmentName
                };

                return model;
            }
        }
    }
}
using MedClinical.API.Data.DTOs;
using MedClinical.API.Services.Interfaces;
using MedClinicalAPI.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinicalAPI.Features.Queries.UserCRUD
{
    public class GetAllUsers
    {
        public class Query : IRequest<IEnumerable<UserDto>>
        {
        }

        public class Handler : IRequestHandler<GetAllUsers.Query, IEnumerable<UserDto>>
        {
            private readonly UserManager<User> _userManager;
            private readonly IUserService _userService;

            public Handler(UserManager<User> userManager, IUserService userService)
            {
                _userManager = userManager;
                _userService = userService;
            }

            public async Task<IEnumerable<UserDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var users = await _userManager.Users.ToListAsync();
                var usersDto = new List<UserDto>();
                foreach (var user in users)
                {
                    var role = await _userManager.GetRolesAsync(user);
                    var userDto = new UserDto
                    {
                        Id = user.Id,
                        UserName = user.UserName,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        Age = user.Age,
                        DepartmentId = user.DepartmentId
                    };
                    if (role != null && role.Count > 0)
                    {
                        userDto.Role = role[0];
                    }
                    if (user.Department != null)
                    {
                        userDto.Department = new Department
                        {
                            DepartmentName = user.Department.DepartmentName
                        };
                    }
                    usersDto.Add(userDto);
                }
                return usersDto;
            }
        }
    }
}
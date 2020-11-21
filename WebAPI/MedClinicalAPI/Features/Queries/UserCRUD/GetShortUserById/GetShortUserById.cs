using MedClinical.API.Data.DTOs;
using MedClinical.API.Services.Interfaces;
using MedClinicalAPI.Data;
using MedClinicalAPI.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinical.API.Features.Queries.UserCRUD.GetShortUserById
{
    public class GetShortUserById
    {
        public class Query : IRequest<UserDto>
        {
            public string Id { get; set; }

            public Query(string id)
            {
                Id = id;
            }
        }

        public class Handler : IRequestHandler<GetShortUserById.Query, UserDto>
        {
            private readonly UserManager<User> _userManager;
            private readonly IUserService _userService;

            public Handler(UserManager<User> userManager, IUserService userService)
            {
                _userManager = userManager;
                _userService = userService;
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
                    DepartmentId = user.DepartmentId
                };
                return model;
            }
        }
    }
}
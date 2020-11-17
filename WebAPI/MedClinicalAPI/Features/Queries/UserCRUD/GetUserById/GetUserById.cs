using MedClinical.API.Data.DTOs;
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
            private readonly AppDbContext _context;

            public Handler(UserManager<User> userManager, AppDbContext context)
            {
                _userManager = userManager;
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
                    DepartmentId = user.DepartmentId
                };
                var userRecords = _context.Records.Where(r => r.PatientId == user.Id || r.DoctorId == user.Id)
                    .Select(rec => new RecordDto
                    {
                        Id = rec.Id,
                        DateOfMeeting = rec.DateOfMeeting,
                        DateOfRecord = rec.DateOfRecord,
                        DoctorId = rec.DoctorId,
                        PatientId = rec.PatientId,
                        ServiceId = (int)rec.ServiceId,
                        Service = new Service
                        {
                            Id = rec.Service.Id,
                            Name = rec.Service.Name,
                            Description = rec.Service.Description,
                            Price = rec.Service.Price
                        },
                        Doctor = new UserDto
                        {
                            Id = rec.Doctor.Id,
                            FirstName = rec.Doctor.FirstName,
                            LastName = rec.Doctor.LastName,
                            UserName = rec.Doctor.UserName
                        },
                        Patient = new UserDto
                        {
                            Id = rec.Patient.Id,
                            FirstName = rec.Patient.FirstName,
                            LastName = rec.Patient.LastName,
                            UserName = rec.Patient.UserName
                        }
                    }).ToList();
                model.Records = userRecords;

                return model;
            }
        }
    }
}
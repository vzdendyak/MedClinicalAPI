using MedClinical.API.Data.Models;
using MedClinicalAPI.Data;
using MedClinicalAPI.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinical.API.Features.Queries.GetAddressAndShedules
{
    public class GetAddressAndShedules
    {
        public class Query : IRequest<CreateDepartmentForm>
        {
        }

        public class Handler : IRequestHandler<GetAddressAndShedules.Query, CreateDepartmentForm>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<CreateDepartmentForm> Handle(Query request, CancellationToken cancellationToken)
            {
                var addressesAndShedules = new CreateDepartmentForm();

                addressesAndShedules.Addresses = await _context.Addresses
                    .Select(addr => new Address
                    {
                        Id = addr.Id,
                        Region = addr.Region,
                        City = addr.City,
                        Street = addr.Street,
                        HouseNumber = addr.HouseNumber
                    }).ToListAsync();

                addressesAndShedules.Schedules = await _context.Schedules
                    .Select(sch => new Schedule
                    {
                        Id = sch.Id,
                        StartHour = sch.StartHour,
                        EndHour = sch.EndHour,
                        IsSaturdayWork = sch.IsSaturdayWork
                    }).ToListAsync();
                addressesAndShedules.Services = await _context.Services
                    .Select(serv => new Service
                    {
                        Id = serv.Id,
                        Name = serv.Name
                    }).ToListAsync();
                return addressesAndShedules;
            }
        }
    }
}
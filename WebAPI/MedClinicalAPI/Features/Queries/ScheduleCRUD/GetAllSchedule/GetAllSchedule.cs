using MedClinicalAPI.Data;
using MedClinicalAPI.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinical.API.Features.Queries.ScheduleCRUD.GetAllSchedule
{
    public class GetAllSchedule
    {
        public class Query : IRequest<IEnumerable<Schedule>>
        {
        }

        public class Handler : IRequestHandler<GetAllSchedule.Query, IEnumerable<Schedule>>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Schedule>> Handle(Query request, CancellationToken cancellationToken)
            {
                var schedules = await _context.Schedules
                    .Select(sch => new Schedule
                    {
                        Id = sch.Id,
                        StartHour = sch.StartHour,
                        EndHour = sch.EndHour,
                        IsSaturdayWork = sch.IsSaturdayWork
                    }).ToListAsync();
                return schedules;
            }
        }
    }
}
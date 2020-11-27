using MedClinicalAPI.Data;
using MedClinicalAPI.Data.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinical.API.Features.Commands.ScheduleCRUD.UpdateSchedule
{
    public class UpdateSchedule
    {
        public class Command : IRequest<bool>
        {
            public Schedule Schedule { get; set; }

            public Command(Schedule schedule)
            {
                Schedule = schedule;
            }
        }

        public class Handler : IRequestHandler<UpdateSchedule.Command, bool>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                var schedule = await _context.Schedules.FindAsync(request.Schedule.Id);

                if (schedule != null)
                {
                    schedule.StartHour = request.Schedule.StartHour;
                    schedule.EndHour = request.Schedule.EndHour;
                    schedule.IsSaturdayWork = request.Schedule.IsSaturdayWork;
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
        }
    }
}
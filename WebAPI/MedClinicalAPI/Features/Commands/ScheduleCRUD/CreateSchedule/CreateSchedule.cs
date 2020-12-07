using MedClinicalAPI.Data;
using MedClinicalAPI.Data.Models;
using MedClinicalAPI.Helpers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinical.API.Features.Commands.ScheduleCRUD.CreateSchedule
{
    public class CreateSchedule
    {
        public class Command : IRequest<bool>
        {
            public Schedule Schedule { get; set; }

            public Command(Schedule schedule)
            {
                Schedule = schedule;
            }
        }

        public class Handler : IRequestHandler<CreateSchedule.Command, bool>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                ValidationHelper.IsScheduleExist(request.Schedule, _context);
                await _context.Schedules.AddAsync(request.Schedule);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}
using MedClinicalAPI.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinical.API.Features.Commands.ScheduleCRUD.DeleteSchedule
{
    public class DeleteSchedule
    {
        public class Command : IRequest<bool>
        {
            public int ScheduleId { get; set; }

            public Command(int scheduleId)
            {
                ScheduleId = scheduleId;
            }
        }

        public class Handler : IRequestHandler<DeleteSchedule.Command, bool>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(Command command, CancellationToken cancellationToken)
            {
                var result = await _context.Schedules.FindAsync(command.ScheduleId);
                if (result != null)
                {
                    _context.Schedules.Remove(result);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
        }
    }
}
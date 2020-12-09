using MedClinicalAPI.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinical.API.Features.Commands.ServiceCRUD.DeleteService
{
    public class DeleteService
    {
        public class Command : IRequest<bool>
        {
            public int ServiceId { get; set; }

            public Command(int serviceId)
            {
                ServiceId = serviceId;
            }
        }

        public class Handler : IRequestHandler<DeleteService.Command, bool>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(Command command, CancellationToken cancellationToken)
            {
                var result = await _context.Services.FindAsync(command.ServiceId);
                if (result != null)
                {
                    _context.Services.Remove(result);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
        }
    }
}
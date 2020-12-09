using MedClinicalAPI.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinical.API.Features.Commands.RecordCRUD.DeleteRecord
{
    public class DeleteRecord
    {
        public class Command : IRequest<bool>
        {
            public int RecordId { get; set; }

            public Command(int recordId)
            {
                RecordId = recordId;
            }
        }

        public class Handler : IRequestHandler<DeleteRecord.Command, bool>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(Command command, CancellationToken cancellationToken)
            {
                var result = await _context.Records.FindAsync(command.RecordId);
                if (result != null)
                {
                    _context.Records.Remove(result);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
        }
    }
}
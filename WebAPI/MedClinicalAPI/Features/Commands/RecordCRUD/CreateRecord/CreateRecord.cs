using MedClinicalAPI.Data;
using MedClinicalAPI.Data.Models;
using MedClinicalAPI.Helpers;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinical.API.Features.Commands.RecordCRUD.CreateRecord
{
    public class CreateRecord
    {
        public class Command : IRequest<bool>
        {
            public Record Record { get; set; }

            public Command(Record record)
            {
                Record = record;
            }
        }

        public class Handler : IRequestHandler<CreateRecord.Command, bool>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                ValidationHelper.IsRecordExist(request.Record, _context);
                await _context.Records.AddAsync(request.Record);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}
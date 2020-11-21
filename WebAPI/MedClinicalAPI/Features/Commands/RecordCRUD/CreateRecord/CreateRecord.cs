using MedClinical.API.Data.DTOs;
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
            public CreateRecordRequest Record { get; set; }

            public Command(CreateRecordRequest record)
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
                var tspan = new TimeSpan();
                var needDate = new DateTimeOffset(request.Record.DateOfMeeting, tspan).LocalDateTime;
                var record = new Record
                {
                    Id = 0,
                    DateOfMeeting = needDate,
                    DoctorId = request.Record.DoctorId,
                    PatientId = request.Record.PatientId,
                    DateOfRecord = DateTime.Now,
                    ServiceId = request.Record.ServiceId
                };
                ValidationHelper.IsRecordExist(record, _context);
                await _context.Records.AddAsync(record);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}
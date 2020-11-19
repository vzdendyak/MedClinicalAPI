using MedClinicalAPI.Data;
using MedClinicalAPI.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinical.API.Features.Queries.RecordCRUD.GetPatientRecord
{
    public class GetPatientRecords
    {
        public class Query : IRequest<IEnumerable<Record>>
        {
            public string PatientId { get; set; }

            public Query(string id)
            {
                PatientId = id;
            }
        }

        public class Handler : IRequestHandler<GetPatientRecords.Query, IEnumerable<Record>>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }


            public async Task<IEnumerable<Record>> Handle(Query request, CancellationToken cancellationToken)
            {
                var records = await _context.Records.Where(d => d.PatientId == request.PatientId).Select(rec => new Record
                {
                    Id = rec.Id,
                    PatientId = rec.PatientId,
                    DoctorId = rec.DoctorId,
                    DateOfMeeting = rec.DateOfMeeting,
                    DateOfRecord = rec.DateOfRecord
                }).ToListAsync();
                return records;
            }
        }
    }
}
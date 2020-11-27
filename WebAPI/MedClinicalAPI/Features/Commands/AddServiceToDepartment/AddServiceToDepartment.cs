using MedClinicalAPI.Data;
using MedClinicalAPI.Data.Models;
using MedClinicalAPI.Helpers;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinical.API.Features.Commands.AddServiceToDepartment
{
    public class AddServiceToDepartment
    {
        public class Command : IRequest<bool>
        {
            public int DepartmentId { get; set; }
            public int ServiceId { get; set; }

            public Command(int departmentId, int serviceId)
            {
                DepartmentId = departmentId;
                ServiceId = serviceId;
            }
        }

        public class Handler : IRequestHandler<AddServiceToDepartment.Command, bool>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                var depService = new DepartmentService
                {
                    DepartmentId = request.DepartmentId,
                    ServiceId = request.ServiceId
                };
                _context.DepartmentServices.Add(depService);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}
using MedClinicalAPI.Data;
using MedClinicalAPI.Data.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinical.API.Features.Commands.ServiceCRUD.UpdateService
{
    public class UpdateService
    {
        public class Command : IRequest<bool>
        {
            public Service Service { get; set; }

            public Command(Service service)
            {
                Service = service;
            }
        }

        public class Handler : IRequestHandler<UpdateService.Command, bool>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                var service = await _context.Services.FindAsync(request.Service.Id);

                if (service != null)
                {
                    service.Name = request.Service.Name;
                    service.Price = request.Service.Price;
                    service.Description = request.Service.Description;
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
        }
    }
}
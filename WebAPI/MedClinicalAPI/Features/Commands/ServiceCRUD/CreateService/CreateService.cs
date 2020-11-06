using MedClinicalAPI.Data;
using MedClinicalAPI.Data.Models;
using MedClinicalAPI.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinical.API.Features.Commands.ServiceCRUD.CreateService
{
    public class CreateService
    {
        public class Command : IRequest<bool>
        {
            public Service Service { get; set; }

            public Command(Service service)
            {
                Service = service;
            }
        }

        public class Handler : IRequestHandler<CreateService.Command, bool>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                ValidationHelper.IsServiceExist(request.Service, _context);
                try
                {
                    await _context.Services.AddAsync(request.Service);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }
    }
}
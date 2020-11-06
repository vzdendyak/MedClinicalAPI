using MedClinicalAPI.Data;
using MedClinicalAPI.Data.Models;
using MedClinicalAPI.Helpers;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinical.API.Features.Commands.AddressCRUD.CreateAddress
{
    public class CreateAddress
    {
        public class Command : IRequest<bool>
        {
            public Address Address { get; set; }

            public Command(Address address)
            {
                Address = address;
            }
        }

        public class Handler : IRequestHandler<CreateAddress.Command, bool>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                ValidationHelper.IsAddressExist(request.Address, _context);
                try
                {
                    await _context.Addresses.AddAsync(request.Address);
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
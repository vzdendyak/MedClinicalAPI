using MedClinicalAPI.Data;
using MedClinicalAPI.Data.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinical.API.Features.Commands.AddressCRUD.UpdateAddress
{
    public class UpdateAddress
    {
        public class Command : IRequest<bool>
        {
            public Address Address { get; set; }

            public Command(Address address)
            {
                Address = address;
            }
        }

        public class Handler : IRequestHandler<UpdateAddress.Command, bool>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                var address = await _context.Addresses.FindAsync(request.Address.Id);

                if (address != null)
                {
                    address.Region = request.Address.Region;
                    address.City = request.Address.City;
                    address.Street = request.Address.Street;
                    address.HouseNumber = request.Address.HouseNumber;

                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
        }
    }
}
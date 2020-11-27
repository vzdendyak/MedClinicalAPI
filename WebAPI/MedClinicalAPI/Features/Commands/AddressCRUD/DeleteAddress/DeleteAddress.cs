using MedClinicalAPI.Data;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinical.API.Features.Commands.AddressCRUD.DeleteAddress
{
    public class DeleteAddress
    {
        public class Command : IRequest<bool>
        {
            public int AddressId { get; set; }

            public Command(int addressId)
            {
                AddressId = addressId;
            }
        }

        public class Handler : IRequestHandler<DeleteAddress.Command, bool>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(Command command, CancellationToken cancellationToken)
            {
                var result = await _context.Addresses.FindAsync(command.AddressId);
                if (result != null)
                {
                    _context.Addresses.Remove(result);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
        }
    }
}
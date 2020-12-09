using MedClinicalAPI.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinical.API.Features.Commands.DepartmentCRUD.DeleteDepartment
{
    public class DeleteDepartment
    {
        public class Command : IRequest<bool>
        {
            public int DepartmentId { get; set; }

            public Command(int departmentId)
            {
                DepartmentId = departmentId;
            }
        }

        public class Handler : IRequestHandler<DeleteDepartment.Command, bool>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(Command command, CancellationToken cancellationToken)
            {
                var result = await _context.Departments.FindAsync(command.DepartmentId);
                if (result != null)
                {
                    _context.Departments.Remove(result);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
        }
    }
}
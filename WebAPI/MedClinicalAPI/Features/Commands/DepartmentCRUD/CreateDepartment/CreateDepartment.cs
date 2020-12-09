using MedClinicalAPI.Data;
using MedClinicalAPI.Data.Models;
using MedClinicalAPI.Helpers;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinicalAPI.Features.Commands.DepartmentCRUD.CreateDepartment
{
    public class CreateDepartment
    {
        public class Command : IRequest<int>
        {
            public Department Department { get; set; }

            public Command(Department department)
            {
                Department = department;
            }
        }

        public class Handler : IRequestHandler<CreateDepartment.Command, int>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                ValidationHelper.IsDepartmentExist(request.Department, _context);

                await _context.Departments.AddAsync(request.Department);
                await _context.SaveChangesAsync();
                var dep = _context.Departments.Where(dep => dep.DepartmentName == request.Department.DepartmentName).FirstOrDefault();
                if (dep == null)
                {
                    return 0;
                }
                return dep.Id;
            }
        }
    }
}
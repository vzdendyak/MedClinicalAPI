using MedClinicalAPI.Data;
using MedClinicalAPI.Data.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinical.API.Features.Commands.DepartmentCRUD.UpdateDepartment
{
    public class UpdateDepartment
    {
        public class Command : IRequest<bool>
        {
            public Department Department { get; set; }

            public Command(Department department)
            {
                Department = department;
            }
        }

        public class Handler : IRequestHandler<UpdateDepartment.Command, bool>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                var department = await _context.Departments.FindAsync(request.Department.Id);

                if (department != null)
                {
                    department.DepartmentName = request.Department.DepartmentName;
                    department.Description = request.Department.Description;
                    department.AddressId = request.Department.AddressId;
                    department.ScheduleId = request.Department.ScheduleId;
                    department.PhotoPath = request.Department.PhotoPath;

                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
        }
    }
}
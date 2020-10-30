using MedClinicalAPI.Data;
using MedClinicalAPI.Data.Models;
using MedClinicalAPI.Helpers;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinicalAPI.Features.Commands.DepartmentCRUD.CreateDepartment
{
    public class CreateDepartment
    {
        public class Command : IRequest<bool>
        {
            public Department Department { get; set; }

            public Command(Department department)
            {
                Department = department;
            }
        }

        public class Handler : IRequestHandler<CreateDepartment.Command, bool>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                ValidationHelper.IsDepartmentExist(request.Department, _context);
                try
                {
                    await _context.Departments.AddAsync(request.Department);
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
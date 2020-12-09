using MedClinicalAPI.Data;
using MedClinicalAPI.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinical.API.Features.Queries.GetDepartmentPhoto
{
    public class GetDepartmentPhoto
    {
        public class Query : IRequest<string>
        {
            public int Id { get; set; }

            public Query(int id)
            {
                Id = id;
            }
        }

        public class Handler : IRequestHandler<GetDepartmentPhoto.Query, string>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<string> Handle(Query request, CancellationToken cancellationToken)
            {
                var department = await _context.Departments.Where(dep => dep.Id == request.Id).FirstOrDefaultAsync();
                if (department == null)
                    throw new NotFoundException("Department not found");

                return department.PhotoPath;
            }
        }
    }
}
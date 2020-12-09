using MedClinicalAPI.Data;
using MedClinicalAPI.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinical.API.Features.Commands.UploadDepartmentPhoto
{
    public class UploadDepartmentPhoto
    {
        public class Command : IRequest<bool>
        {
            public IFormFile File { get; set; }
            public int DepartmentId { get; set; }

            public Command(IFormFile file, int departmentId)
            {
                File = file;
                DepartmentId = departmentId;
            }
        }

        public class Handler : IRequestHandler<UploadDepartmentPhoto.Command, bool>
        {
            private UserManager<User> _userManager;
            private AppDbContext _context;

            public Handler(UserManager<User> userManager, AppDbContext context)
            {
                _userManager = userManager;
                _context = context;
            }

            public async Task<bool> Handle(Command command, CancellationToken cancellationToken)
            {
                var folderName = Path.Combine("Resources", "Images", "Departments");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var dep = await _context.Departments.Where(dep => dep.Id == command.DepartmentId).FirstOrDefaultAsync();
                if (command.File.Length == 0 || dep == null)
                    return false;

                var fileName = ContentDispositionHeaderValue.Parse(command.File.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    command.File.CopyTo(stream);
                }
                dep.PhotoPath = dbPath;
                _context.Departments.Update(dep);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}
using MedClinicalAPI.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.IO;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace MedClinical.API.Features.Commands.UploadUserAvatar
{
    public class UploadUserAvatar
    {
        public class Command : IRequest<bool>
        {
            public IFormFile File { get; set; }
            public string UserId { get; set; }

            public Command(IFormFile file, string userId)
            {
                File = file;
                UserId = userId;
            }
        }

        public class Handler : IRequestHandler<UploadUserAvatar.Command, bool>
        {
            private UserManager<User> _userManager;

            public Handler(UserManager<User> userManager)
            {
                _userManager = userManager;
            }

            public async Task<bool> Handle(Command command, CancellationToken cancellationToken)
            {
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var user = await _userManager.FindByIdAsync(command.UserId);
                if (command.File.Length == 0 || user == null)
                    return false;

                var fileName = ContentDispositionHeaderValue.Parse(command.File.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    command.File.CopyTo(stream);
                }
                user.AvatarPath = dbPath;
                await _userManager.UpdateAsync(user);
                return true;
            }
        }
    }
}
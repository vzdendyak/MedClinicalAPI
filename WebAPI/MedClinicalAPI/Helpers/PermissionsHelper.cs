using MedClinical.API.Data.Models;
using MedClinicalAPI.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace MedClinical.API.Helpers
{
    public static class PermissionsHelper
    {
        public async static Task<bool> IsUserAdmin(this User user, UserManager<User> _context)
        {
            var roles = await _context.GetRolesAsync(user);
            if (roles.Any(r => r == Roles.ADMIN.ToString()))
            {
                return true;
            }
            return false;
        }
    }
}
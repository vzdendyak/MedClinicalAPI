using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MedClinicalAPI.Data.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int? DepartmentId { get; set; }
        public int RoleId { get; set; }

        // nav props
        public Department Department { get; set; }

        public virtual ICollection<Record> Records { get; set; }
    }
}
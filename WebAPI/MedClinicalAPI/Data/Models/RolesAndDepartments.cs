using MedClinical.API.Data.DTOs;
using MedClinicalAPI.Data.Models;
using System.Collections.Generic;

namespace MedClinical.API.Data.Models
{
    public class RolesAndDepartments
    {
        public virtual ICollection<RolesDto> Roles { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
    }
}
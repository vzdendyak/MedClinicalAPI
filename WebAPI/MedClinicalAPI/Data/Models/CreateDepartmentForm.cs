using MedClinicalAPI.Data.Models;
using System.Collections.Generic;

namespace MedClinical.API.Data.Models
{
    public class CreateDepartmentForm
    {
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}
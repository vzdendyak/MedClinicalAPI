using MedClinicalAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedClinical.API.Data.Models
{
    public class CreateDepartmentForm
    {
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
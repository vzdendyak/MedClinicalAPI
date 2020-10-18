using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedClinicalAPI.Data.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartementName { get; set; }
        public string Description { get; set; }
        public int AdressId { get; set; }
        public int SheduleId { get; set; }
        public Schedule Schedule { get; set; }
        public Address Address { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}

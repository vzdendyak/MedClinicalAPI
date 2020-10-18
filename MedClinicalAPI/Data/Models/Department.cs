using System.Collections.Generic;

namespace MedClinicalAPI.Data.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public int AdressId { get; set; }
        public int ScheduleId { get; set; }

        // nav props
        public Schedule Schedule { get; set; }

        public Address Address { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}
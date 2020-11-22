using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedClinicalAPI.Data.Models
{
    [Table("Departments")]
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public int AddressId { get; set; }
        public int ScheduleId { get; set; }
        public string PhotoPath { get; set; }

        // nav props
        public Schedule Schedule { get; set; }

        public Address Address { get; set; }
        public virtual ICollection<DepartmentService> DepartmentServices { get; set; }
        public virtual ICollection<User> Doctors { get; set; }
    }
}
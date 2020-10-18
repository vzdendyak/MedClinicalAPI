using System.Collections.Generic;

namespace MedClinicalAPI.Data.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }

        // nav props
        public virtual ICollection<Department> Departments { get; set; }
    }
}
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedClinicalAPI.Data.Models
{
    [Table("Services")]
    public class Service
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // nav props
        public virtual ICollection<DepartmentService> DepartmentServices { get; set; }
    }
}
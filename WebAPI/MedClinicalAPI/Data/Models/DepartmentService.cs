using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedClinicalAPI.Data.Models
{
    public class DepartmentService
    {
        public int DepartmentId { get; set; }
        public int ServiceId { get; set; }

        // nav
        public Department Department { get; set; }

        public Service Service { get; set; }
    }
}
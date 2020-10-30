using MedClinicalAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedClinical.API.Data.DTOs
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public int AddressId { get; set; }
        public int ScheduleId { get; set; }

        // nav props
        public Schedule Schedule { get; set; }

        public Address Address { get; set; }
        public ICollection<DepartmentService> DepartmentServices { get; set; }
        public ICollection<UserDto> Doctors { get; set; }
    }
}
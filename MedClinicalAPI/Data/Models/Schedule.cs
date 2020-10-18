using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedClinicalAPI.Data.Models
{
    [Table("Schedules")]
    public class Schedule
    {
        public int Id { get; set; }
        public int StartHour { get; set; }
        public int EndHour { get; set; }
        public bool IsSaturdayWork { get; set; }

        // nav props
        public virtual ICollection<Department> Departments { get; set; }
    }
}
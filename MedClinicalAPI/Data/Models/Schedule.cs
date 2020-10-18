using System.Collections.Generic;

namespace MedClinicalAPI.Data.Models
{
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
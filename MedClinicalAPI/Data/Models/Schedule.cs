using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedClinicalAPI.Data.Models
{
    public class Schedule
    {
        public int Id  { get; set; }
        public int StartHour { get; set; }
        public int EndHour { get; set; }
        public bool IsSaturdayWork{ get; set; }
    }
}

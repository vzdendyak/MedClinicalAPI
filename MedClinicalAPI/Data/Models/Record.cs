using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedClinicalAPI.Data.Models
{
    public class Record
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int UserId { get; set; }
        public DateTime DateOfRecord { get; set; }
        public DateTime DateOfMeeting { get; set; }
    }
}

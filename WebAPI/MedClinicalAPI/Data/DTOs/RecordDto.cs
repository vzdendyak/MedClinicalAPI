using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedClinical.API.Data.DTOs
{
    public class RecordDto
    {
        public int Id { get; set; }
        public string DoctorId { get; set; }
        public string PatientId { get; set; }
        public DateTime DateOfRecord { get; set; }
        public DateTime DateOfMeeting { get; set; }
        public int ServiceId { get; set; }
    }
}
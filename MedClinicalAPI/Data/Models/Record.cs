using System;

namespace MedClinicalAPI.Data.Models
{
    public class Record
    {
        public int Id { get; set; }
        public string DoctorId { get; set; }
        public string PatientId { get; set; }
        public DateTime DateOfRecord { get; set; }
        public DateTime DateOfMeeting { get; set; }

        // nav props
    }
}
using System;

namespace MedClinicalAPI.Data.Models
{
    public class Record
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime DateOfRecord { get; set; }
        public DateTime DateOfMeeting { get; set; }

        // nav props
    }
}